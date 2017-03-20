using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebA1
{
    class Customer : Menu
    {
        public Store store { get; }
        public Customer(Store store) 
        {
            this.store = store;
            menuItem.Add("Display Products");
            menuItem.Add("Display Workshops");
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
                        MainMenu menu = new MainMenu();
                        menu.runMainMenu();
                        break;

                    case 4:
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
                Console.WriteLine("Please enter correct value!");
                return false;
            }
        }
       
        static void displayMenue()
        {
            Console.WriteLine("Welcome to Marvellous Magic (Retail - NAME)");
            Console.WriteLine("=============================================");
            Console.WriteLine("\t 1. Display Products");
            Console.WriteLine("\t 2. Display Workshops");
            Console.WriteLine("\t 3. Return To Main Menu");
            Console.WriteLine("\t 4. EXIT");
        }

        public void runCustomerMenu()
        {
            bool input;
            while (true)
            {
                if (store != null)
                {
                    displayTitle("Customer");
                    displayList();
                    displayHint();
                }
                input = validingInput();
                //if (!input)
                //{
                //    new Customer();
               // }
            }
        }

        void quit()
        {
            Environment.Exit(0);
        }
    }
}
