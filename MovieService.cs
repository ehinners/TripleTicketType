using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Linq;
using NLog.Web;


namespace MediaLibrary
{  
    public class MovieService
    {
        public NLog.Logger logger;

        public void setLogger(NLog.Logger l)
        {
            logger = l;
        }

        public Movie mapMovieFromCSV(string csv)
        {
            Movie movie = new Movie();

            string[] lines = movie.Display().Split("\n");
            int numAttributes = lines.Length - 1;

            string[] movieAttributes;
            movieAttributes = csv.Split(",");

            int movieAttribute = 1;
            bool excededAttributes;
            string titleStitcher = "";
            TimeSpan tempRunningTime;

            if(movieAttributes.Length > numAttributes)
            {
                excededAttributes = true;
            }
            else
            {
                excededAttributes = false;
            }

            
            foreach(string s in movieAttributes)
            {
                if(movieAttribute==1)
                {
                    try
                    {
                        movie.mediaId = (UInt16)int.Parse(s);
                    }
                    catch
                    {
                        logger.Error("ID not Integer Value");
                    }
                    
                }
                if(movieAttribute==2)
                {
                    movie.title = s;
                }
                if(movieAttribute==3)
                {
                    if(excededAttributes)
                    {
                        titleStitcher = movie.title;
                        titleStitcher += s;
                        movie.title = titleStitcher;
                    }
                    else
                    {
                        movie.genres = genreSplitter(s);
                    }
                }
                if(movieAttribute==4)
                {
                    if(excededAttributes)
                    {
                        movie.genres = genreSplitter(s);
                    }
                    else
                    {
                        movie.director = s;
                    }
                }
                if(movieAttribute==5)
                {
                    if(excededAttributes)
                    {
                        movie.director = s;
                    }
                    else
                    {
                        movie.runningTime = spanParser(s);
                    }
                }
                if(movieAttribute==6)
                {
                    movie.runningTime = spanParser(s);
                }
                movieAttribute++;
            }


            return movie;
        }

        private List<string> genreSplitter(string genreCSV)
        {
            List<string> genres;
            genres = genreCSV.Split("|").ToList();
            return genres;
        }


        private TimeSpan spanParser(string ts)
        {
            TimeSpan runningTime;

            try
            {
                runningTime = TimeSpan.Parse(ts);
                
            }
            catch
            {
                logger.Error("Running Time Not Valid TimeSpan");
                runningTime = new TimeSpan();
            }

            return runningTime;

        }

    }
}