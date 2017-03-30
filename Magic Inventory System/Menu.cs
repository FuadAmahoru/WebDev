using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace WebA1

{
   abstract class Menu
    {
        protected List<string> menuItem = new List<string>();

        public void displayTitle(string title)
        {
            Console.WriteLine("Welcome to Marvellous Magic " + "( " + title + " )");
            Console.WriteLine("=============================================");
        }
        public  int getInput(string number)
        {
            int option;
           
                try
                {
                    option = Convert.ToInt32(number);
                }
                catch (Exception m)
                {


                 Console.WriteLine(m.Message);
                 return -1;
                    
                }
            return option;
             
        }

        public void displayHint()
        {
            Console.WriteLine("Enter an option: ");
            Console.WriteLine("(where the user enters a number from 1 to {0}, to select an option)",menuItem.Count);
        }
        
        public void displayList()
        {
            for(int i =0; i<menuItem.Count; i++)
            {
                Console.WriteLine("\t {0}.  {1}",i+1,menuItem[i]);
            }
            
        }

        


        }
    }
