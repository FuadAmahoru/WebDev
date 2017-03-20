using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace WebA1
{
    class Owner : Menu
    {
       public Owner()
        {
            
            menuItem.Add("Display All Stock Requests");
            menuItem.Add("Display Stock Requests (True/False)");
            menuItem.Add("Display All Product Lines");
            menuItem.Add("Return To Main Menu");
            menuItem.Add("EXIT");
           
        }


       

         bool validingInput()
        {
            int option;


            option = getInput(Console.ReadLine());
            if (option != -1)
            {

                switch (option)
                {
                    case 1:

                        break;

                    case 2:

                        break;

                    case 3:
                        Inventory invent = new Inventory();
                        invent.displayProductLines();
                        
                        break;

                    case 4:
                        MainMenu menu = new MainMenu();
                        menu.runMainMenu();
                        break;
                    case 5:
                        quit();
                        break;

                    default:
                        Console.WriteLine("The option is not available! Please enter another option(1 to {0}):", menuItem.Count);
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        return false;
                     
                }
                return true;
            }
            else
            {
                Console.WriteLine("Please enter non-String value!");
                return false;
            }


        
        }

        void quit()
        {
            Environment.Exit(0);
        }

        public void runOwnerMenu()
        {
            bool input;
            while (true)
            {
             
                    displayTitle("Owner");
                displayList();
                displayHint();
                input = validingInput();
                //if (!input)
               // {
                //    new Owner();
               // }
            }
        }

        void displayStockRequest()
        {
            StreamReader s = new StreamReader(@"F:\stockrequest.txt");
            string txt = s.ReadToEnd();
            Console.WriteLine("ID\t\tName");
            Console.WriteLine("=========================================");
            int count = 1; // the int number for storing new ID in the list 3
            foreach (Store p in list)
            {
                Console.WriteLine("{0}\t\t{1}", count++, p.Name);
            }
        }
    }
}
