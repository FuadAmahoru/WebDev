using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebA1
{
    class Franchise : Menu
    {
        public Store store { get; }
        
        public Franchise(Store store)
        {
            this.store = store;

            menuItem.Add("Display Inventory");
            menuItem.Add("Display Inventory (Treshold)");
            menuItem.Add("Add New Inventory Item");
            menuItem.Add("Return To Main Menu");
            menuItem.Add("Exit");

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
                        displayInventory();

                        break;

                    case 2:

                        break;

                    case 3:
                        addNewInventoryItem();

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
                Console.WriteLine("Please enter correct value!");
                return false;
            }
        }
        public void runFranchiseMenu()
        {
            bool input;
            while (true)
            {
                if (store != null) {
                displayTitle("Franchise Holder - " + store.Name);
                displayList();
                displayHint();
            }
                input = validingInput();
                //if (!input)
               // {
                //    new Franchise(store);
               // }
            }
        }
        void quit()
        {
            Environment.Exit(0);
        }
        string getUrl(int id)
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
        void displayInventory()
        {
            string url = getUrl(store.Id);
            List<Product> ro = JsonUtility.readJsonFile<List<Product>>(url);
            //string jsondata = @"["{"ID":1,"Name":"Rabbit","StockLevel":4},{"Id":2,"Name":"Rabbit","StockLevel":1}];
            Console.WriteLine("=================");
            Console.WriteLine("Inventory      ||");
            Console.WriteLine("=================");
            Console.WriteLine("ID\tProduct\t\t\t  Current Stock\t\tRe-Stock");
            Console.WriteLine("____________________________________________________");
            foreach (Product item in ro)
            {
                Console.WriteLine("{0,-5}\t{1,-8}\t\t{2,3}\t\t{3}", item.ID, item.Name, item.CurrentStock, item.ReStock);
            }
           
            Console.Write("Enter Request to process:  ");

            int entry = getInput(Console.ReadLine());

            // Console.WriteLine(ro[entry-1].ReStock);
            if (entry != -1)
            {
                if (entry > 0 && entry <= ro.Count)
                {
                    
                            if (ro[entry-1].ReStock == true)
                            {
                                Console.WriteLine("The Change in the json file has been updated!");
                            }
                            else if (ro[entry - 1].ReStock == false) 
                            {
                                Console.WriteLine("There are enough Stock in the inventory , No need to restock!");
                            }
                    
                }
                else
                {
                    Console.WriteLine("Please enter the option from 1 to {0} :", ro.Count);
                }
            }
           
            else
            {
                Console.WriteLine("Incorrect data type, Please enter integer! ");
            }


                Console.WriteLine("\n");
            }

           void addNewInventoryItem()
        {
            List<Product> list1 = JsonUtility.readJsonFile<List<Product>>(@"F:\owners_inventory.json");
            List<Product> list2 = JsonUtility.readJsonFile<List<Product>>(getUrl(store.Id));
            List<Product> list3 = list1;
            bool found = true;
            for(int i=0; i < list1.Count; i++) //outer loop for owners inventory
            {
                
                for(int j =0; j < list2.Count; j++)
                {
                    
                    if(list1[i].Name !=list2[j].Name)
                    {
                        found = false;
                    }
                    else
                    {
                        found = true;
                        break;
                    }

                }

                if (found)
                {
                    list3.Remove(list3[i]);
                }
               
            }
            Console.WriteLine("ID\t\tName");
            Console.WriteLine("=========================================");
            int count = 1; // the int number for storing new ID in the list 3
            foreach(Product p in list3)
            {
                Console.WriteLine("{0}\t\t{1}",count++,p.Name);
            }
        }

        /*List<Product> getFile()
        {
            List<Product> product = null;
            switch (store.Id)
            {
                case 1: product = JsonUtility.readJsonFile<List<Product>>(@"F:\Jack_inventory.json");break;
                case 2: product = JsonUtility.readJsonFile<List<Product>>(@"F:\Fuad_inventory.json"); break;
                case 3: product = JsonUtility.readJsonFile<List<Product>>(@"F:\Joyice_inventory.json"); break;
                case 4: product = JsonUtility.readJsonFile<List<Product>>(@"F:\Jay_inventory.json"); break;
                case 5: product = JsonUtility.readJsonFile<List<Product>>(@"F:\Olinda_inventory.json"); break;
            }
            return product;
        }*/
            /* void displayInventoryThreshhold()
             {
                 string url = getUrl(store.Id);
                 List<Product> ro = JsonUtility.readJsonFile<List<Product>>(url);
                 //string jsondata = @"["{"ID":1,"Name":"Rabbit","StockLevel":4},{"Id":2,"Name":"Rabbit","StockLevel":1}];
                 Console.WriteLine("=================");
                 Console.WriteLine("Inventory      ||");
                 Console.WriteLine("=================");
                 Console.WriteLine("ID\tProduct\t\t\t  Current Stock\t\tRe-Stock");
                 Console.WriteLine("____________________________________________________");
                 foreach (Product item in ro)
                 {

                     Console.WriteLine("{0,-5}\t{1,-8}\t\t{2,3}\t\t{3}", item.ID, item.Name, item.CurrentStock, item.ReStock);
                 }

                 Console.WriteLine("\n\n\n");
             }*/
        }
    }


