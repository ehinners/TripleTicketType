using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Linq;
using NLog.Web;

namespace TripleTicketType
{  
    public static class View
    {

        // this class handles all output to the user

        private static ArrayList menuDisplay = new ArrayList()
        {
            "1: To Create A New Ticket", 
            "2: To View All Current Tickets", 
            "Enter to quit"
        };

        private static ArrayList typeDisplay = new ArrayList()
        {
            "1: Bug/Defect Ticket", 
            "2: Enhancement Ticket", 
            "3: Task Ticket"
        };

        private static ArrayList promptDisplay = new ArrayList()
        {
            "Enter Summary" , 
            "Enter Status", 
            "Enter Priority",
            "Enter Submitter",
            "Enter Assigned",
            $"Enter Watcher(or {Model.getWatcherEscape()} to quit)"
        };

        private static ArrayList bugDefectPrompt = new ArrayList()
        {
            "Enter Severity" 
        };

        private static ArrayList enhancementPrompt = new ArrayList()
        {
            "Enter Software" , 
            "Enter Cost", 
            "Enter Reason",
            "Enter Estimate"
        };

        private static ArrayList taskPrompt = new ArrayList()
        {
            "Enter Project Name" , 
            "Enter Due Date"
        };


        public static void setMenuDisplay(ArrayList md)
        {
            menuDisplay = md;
        }

        public static void displayMenu()
        {
            foreach(string line in menuDisplay)
            {
                System.Console.WriteLine(line);
            }
        }

        public static void displayTypes()
        {
            foreach(string line in typeDisplay)
            {
                System.Console.WriteLine(line);
            }
        }

        
        public static void displayTickets(int type)
        {
            
            if(type ==1)
            {
                foreach(BugDefect t in Model.getTicketsBD())
                {
                    System.Console.WriteLine(t.display());           
                }
            }
            else if(type ==2)
            {
                foreach(Enhancement t in Model.getTicketsEH())
                {
                    System.Console.WriteLine(t.display());           
                }
            }
            else if(type ==3)
            {
                foreach(Task t in Model.getTicketsTK())
                {
                    System.Console.WriteLine(t.display());           
                }
            }
            
        } 

        public static void creationPrompt(int ticketAttribute)
        {
            System.Console.WriteLine(promptDisplay[ticketAttribute-1]);
        }

        public static void creationPromptBD(int ticketAttribute)
        {
            System.Console.WriteLine(bugDefectPrompt[ticketAttribute-1]);
        }

        public static void creationPromptEH(int ticketAttribute)
        {
            System.Console.WriteLine(enhancementPrompt[ticketAttribute-1]);
        }

        public static void creationPromptTK(int ticketAttribute)
        {
            System.Console.WriteLine(taskPrompt[ticketAttribute-1]);
        }

    }
}