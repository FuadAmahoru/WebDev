using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
namespace WebA1
{
    class Customer : Menu
    {
        public Store _store { get; }
        public Customer(Store store) 
        {
            this._store = store;
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
                        displayProducts();
                        
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
                if (_store != null)
                {
                    displayTitle("Retail -  " + _store.Name);
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

        string getAddress(int id)
        {
            string location = null;
            switch (id)
            {
                case 1: location = "F:\\Jack_inventory.json"; break;
                case 2: location = "F:\\Fuad_inventory.json"; break;
                case 3: location = "F:\\Joyice_inventory.json"; break;
                case 4: location = "F:\\Jay_inventory.json"; break;
                case 5: location = "F:\\Olinda_inventory.json"; break;

            }
            return location;

        }

        void displayProducts()
        {
            List<Product> item = JsonUtility.readJsonFile<List<Product>>(getAddress(_store.Id));
            Console.WriteLine("=================");
            Console.WriteLine("Inventory      ||");
            Console.WriteLine("=================");
            Console.WriteLine("ID\tProduct\t\t\t  Current Stock");
            Console.WriteLine("____________________________________________________");
            for(int i=0; i<item.Count;i++) 
            {
                if ((i%5)!=0 )
                {
                    Console.WriteLine("{0,-5}\t{1,-8}\t\t{2,3}", item[i].ID, item[i].Name, item[i].CurrentStock);
                }
                else
                {
                    Console.WriteLine("[Legend: \'P\' Next Page | \'R\' Return to Menu |\'C\' Complete Transaction]");
                    Console.WriteLine();
                    Console.WriteLine("Enter Item Number to purchase or Function");
                    string prompt = Console.ReadLine();
                    if (prompt.Contains("P"))
                    {
                        continue;
                    }
                    else if (prompt.Contains("R"))
                    {
                        this.runCustomerMenu();
                    }
                    else if (prompt.Contains("C"))
                    {
                        Console.WriteLine("Complete Transaction!!!");
                        break;
                    }
                    else
                    {
                        char[] delimter = { ' ' };
                        int _proId = 0;
                        int _proQuantity = 0;
                        var tokens = prompt.Split(delimter);
                        if (tokens.Length == 2)
                        {
                          for(int j = 0; j < tokens.Length; j++)
                            {
                                 int test = int.Parse(tokens[j]);
                                 if (j == 0)
                                {
                                      _proId = test;
                                 }
                                else
                                {
                                     _proQuantity = test;
                                }
                             }

                        if (_proId <=item.Count)
                         {
                                   for(int k = 0; k < item.Count; k++)
                                {
                                    if (item[k].ID == _proId)
                                    {
                                        if(_proQuantity < item[k].CurrentStock)
                                        {
                                            item[k].CurrentStock = (item[k].CurrentStock - _proQuantity);
                                        }
                                    }
                                }
                                using (StreamWriter file = File.CreateText(@"E:\account.json"))
                                {
                                    JsonSerializer serializer = new JsonSerializer();
                                    serializer.Serialize(file, item);
                                }
                            }

                        }
                       
                    }
                }
               
            }

            Console.WriteLine("\n");
        }
        void quit()
        {
            Environment.Exit(0);
        }
    }
}
