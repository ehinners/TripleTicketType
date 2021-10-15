using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Linq;
using NLog.Web;

namespace MediaLibrary
{  
    public static class Model
    {
        private static string watcherEscape = "DONE";

        // This class allows controller to communicate with services and views

        // static instance of logger held so multiple instances don't have to be created
        private static NLog.Logger logger;

        // static instance of file contents so multiple instances don't have to be created
        //private static List<string> fileContents;

        private static List<string> bugDefectFileContents;

        private static List<string> enhancementsFileContents;

        private static List<string> taskFileContents;

        // static instance of ticket list so multiple instances don't have to be created
        private static List<BugDefect> ticketsBD;
        private static List<Enhancement> ticketsEH;
        private static List<Task> ticketsTK;


        //public static string fileName;
        public static string BugDefectFile;
        public static string EnhancementsFile;
        public static string TaskFile;

        public static string getWatcherEscape()
        {
            return watcherEscape;
        }

        public static void setLogger(NLog.Logger l)
        {
            logger = l;
        }

        public static NLog.Logger getLogger()
        {
            return logger;
        }

        public static void setBugDefectFile(string fn)
        {
            BugDefectFile = fn;
        }

        public static List<string> getBugDefectFileContents()
        {
            if(bugDefectFileContents == null)
            {
                bugDefectFileContents = FileHandler.getFileContents(BugDefectFile);
            }
            return bugDefectFileContents;            
        }

        ////

        public static void setEnhancementsFile(string fn)
        {
            EnhancementsFile = fn;
        }

        public static List<string> getEnhancementsFileContents()
        {
            if(enhancementsFileContents == null)
            {
                enhancementsFileContents = FileHandler.getFileContents(EnhancementsFile);
            }
            return enhancementsFileContents;            
        }

        ////

        public static void setTaskFileName(string fn)
        {
            TaskFile = fn;
        }

        public static List<string> getTaskFileContents()
        {
            if(taskFileContents == null)
            {
                taskFileContents = FileHandler.getFileContents(TaskFile);
            }
            return taskFileContents;            
        }

        ////
        public static List<BugDefect> getTicketsBD()
        {
            if(ticketsBD == null)
            {
                ticketsBD = TicketService.mapTicketsFromStringListBD(getBugDefectFileContents());
            }
            return ticketsBD;            
        }

        public static List<Enhancement> getTicketsEH()
        {
            if(ticketsEH == null)
            {
                ticketsEH = TicketService.mapTicketsFromStringListEH(getEnhancementsFileContents());
            }
            return ticketsEH;            
        }

        public static List<Task> getTicketsTK()
        {
            if(ticketsTK == null)
            {
                ticketsTK = TicketService.mapTicketsFromStringListTK(getTaskFileContents());
            }
            return ticketsTK;            
        }
        /*
        public static List<Movie> getMovies()
        {
            if(movies == null)
            {
                movies = MovieService.mapMoviesFromStringList(getFileContents());
            }
            return movies;            
        }*/

        // elminates redundancies in code requiring this value
        
        public static int getLargestIDBD()
        {
            
            int largestID = 0;
            foreach(Ticket t in getTicketsBD())
            {
                if(t.ticketId > largestID)
                {
                    largestID = t.ticketId;
                }
            }
            return largestID;
        }

        public static int getLargestIDEH()
        {
            
            int largestID = 0;
            foreach(Ticket t in getTicketsEH())
            {
                if(t.ticketId > largestID)
                {
                    largestID = t.ticketId;
                }
            }
            return largestID;
        }

        public static int getLargestIDTK()
        {
            
            int largestID = 0;
            foreach(Ticket t in getTicketsTK())
            {
                if(t.ticketId > largestID)
                {
                    largestID = t.ticketId;
                }
            }
            return largestID;
        }
        /*
        public static UInt64 getLargestID()
        {
            
            UInt64 largestID = 0;
            foreach(Movie m in getMovies())
            {
                if(m.mediaId > largestID)
                {
                    largestID = m.mediaId;
                }
            }
            return largestID;
        }*/

        // useful in case number of attributes ever changes
        /*
        public static int getNumAttributes()
        {
            Movie movie = new Movie();
            string[] lines = movie.Display().Split("\n");
            return lines.Length - 1;
        }*/

        
        public static int getBaseNumAttributes()
        {
            return 7;
        }
        /*
        public static void addMovie(Movie movie)
        {
            getMovies().Add(movie);
        }*/

        

        

    }


}