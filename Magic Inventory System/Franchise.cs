using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
namespace WebA1
{
    class Franchise : Menu
    {
        public Store _store { get; }
        readonly string owners_invent = "F:\\stockrequest.json";
        public Franchise(Store store)
        {
            this._store = store;

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
                        displayThreshold();
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

            return false;

        }
        public void runFranchiseMenu()
        {
            bool input;
            while (true)
            {
                if (_store != null) {
                displayTitle("Franchise Holder - " + _store.Name);
                displayList();
                displayHint();
            }
                input = validingInput();
               
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
            string url = getUrl(_store.Id);
            List<Product> ro = JsonUtility.readJsonFile<List<Product>>(url);
            Console.Write("Please enter a number that will list the threshold for restocking: ");
            string prompt = Console.ReadLine(); // get the input for threshold
            int threshold;
            bool result = Int32.TryParse(prompt,out threshold);
            bool[] restocking = new bool[ro.Count];  // store each bool for every item
            int count = 0; // tracking the bool index
            if (result)//check if it is a valid int number for threshold
            {
                     Console.WriteLine("=================");
                     Console.WriteLine("Inventory      ||");
                     Console.WriteLine("=================");
                     Console.WriteLine("ID\tProduct\t\t\t  Current Stock\t\tRe-Stock");
                     Console.WriteLine("____________________________________________________");
                
                foreach (Product item in ro)
                 {
                    if (item.CurrentStock <= threshold)
                    {
                        restocking[count] = true;
                        Console.WriteLine("{0,-5}\t{1,-8}\t\t{2,3}\t\t {3}", item.ID, item.Name, item.CurrentStock,restocking[count]);
                    }
                    else
                    {
                        restocking[count] = false;
                        Console.WriteLine("{0,-5}\t{1,-8}\t\t{2,3}\t\t {3}", item.ID, item.Name, item.CurrentStock,restocking[count]);
                    }
                    count++;
                 }//end of foreach loop
                count = 0;
                 Console.Write("Enter Request to process:  ");
                string input = Console.ReadLine();
                int req;
                bool request = Int32.TryParse(input, out req);
                if (request) // check for the input for request ID
                {
                    if(req <1 || req > ro.Count)//check if the requested ID is out of range
                    {
                        Console.WriteLine("ID is invalid");
                        
                    }
                    foreach(Product pro in ro)
                    {
                        if (req == pro.ID && restocking[count]==true)
                        {
                            List<StockRequest> _stockrequest = JsonUtility.readJsonFile<List<StockRequest>>(owners_invent);
                            if(_stockrequest == null)
                            {
                                StockRequest stockRequest = new StockRequest {store =_store.Name,Name=pro.Name,Quantity = threshold,CurrentStock=pro.CurrentStock,ReStock = false };
                                
                                JsonUtility.writeJsonFile(owners_invent, stockRequest);
                            }
                            else
                            {
                                foreach(StockRequest s in _stockrequest)
                                {
                                    if (s.Name == pro.Name)
                                    {
                                        s.Quantity = s.Quantity + threshold;
                                        if(s.Quantity > s.CurrentStock)
                                        {
                                            s.ReStock = false;
                                        }
                                        else
                                        {
                                            s.ReStock = true;
                                        }
                                    }
                                }
                                string jobj = JsonConvert.SerializeObject(_stockrequest, Formatting.Indented);
                                File.WriteAllText(owners_invent, jobj);
                               

                            }
                            Console.WriteLine("The Upgrade in the stock request json file has been updated!");
                        }
                        else if(req == pro.ID && restocking[count] == false)
                        {

                            Console.WriteLine("There are enough Stock in the inventory , No need to restock!");

                        }
                        count++;
                    }
                }//end of requesting ID to be processing
            }//end of checking threshold
            else// check if it is invalid
            {
                Console.WriteLine("Incorrect Format , should be a number!!!");
                
            }
                Console.WriteLine("\n");
        }//end of function of (displayInventory)
        

        void displayThreshold()
        {
            string url = getUrl(_store.Id);
            List<Product> ro = JsonUtility.readJsonFile<List<Product>>(url);
            Console.Write("Please enter a number that will list the threshold for restocking: ");
            string prompt = Console.ReadLine(); // get the input for threshold
            int threshold;
            bool result = Int32.TryParse(prompt, out threshold);
            bool[] restocking = new bool[ro.Count];  // store each bool for every item
            int count = 0; // tracking the bool index
            if (result)//check if it is a valid int number for threshold
            {
                Console.WriteLine("=================");
                Console.WriteLine("Inventory      ||");
                Console.WriteLine("=================");
                Console.WriteLine("ID\tProduct\t\t\t  Current Stock\t\tRe-Stock");
                Console.WriteLine("____________________________________________________");
                int filter = 1;
                foreach (Product item in ro) //printing each item in the file
                {
                    if (item.CurrentStock <= threshold)
                    {
                        restocking[count] = true;
                        filter++;
                        Console.WriteLine("{0,-5}\t{1,-8}\t\t{2,3}\t\t {3}", item.ID, item.Name, item.CurrentStock, restocking[count]);
                    }
                   
                    count++;
                }//end of foreach loop
                count = 0;
                Console.Write("Enter Request to process:  ");
                string input = Console.ReadLine();
                int req;
                bool request = Int32.TryParse(input, out req);
                if (request) // check for the input for request ID
                {
                    if (req < 1 || req >= filter)//check if the requested ID is out of range
                    {
                        Console.WriteLine("ID is invalid");
                        
                    }
                    foreach (Product pro in ro)
                    {
                        
                        if (req == pro.ID && restocking[count] == true)
                        {
                            List<StockRequest> _stockrequest = JsonUtility.readJsonFile<List<StockRequest>>(owners_invent);
                            if (_stockrequest == null)
                            {
                                StockRequest stockRequest = new StockRequest { store = _store.Name, Name = pro.Name, Quantity = threshold, CurrentStock = pro.CurrentStock, ReStock = false };

                                JsonUtility.writeJsonFile(owners_invent, stockRequest);
                            }
                            else
                            {
                                foreach (StockRequest s in _stockrequest)
                                {
                                    if (s.Name == pro.Name)
                                    {
                                        s.Quantity = s.Quantity + threshold;
                                        if (s.Quantity > s.CurrentStock)
                                        {
                                            s.ReStock = false;
                                        }
                                        else
                                        {
                                            s.ReStock = true;
                                        }
                                    }
                                }
                                string jobj = JsonConvert.SerializeObject(_stockrequest, Formatting.Indented);
                                File.WriteAllText(owners_invent, jobj);


                            }
                            Console.WriteLine("The Upgrade in the stock request json file has been updated!");
                        }
                        //else if (req == pro.ID && restocking[count] == false)
                        //{

                        //    Console.WriteLine("There are enough Stock in the inventory , No need to restock!");

                        //}
                        count++;
                    }
                }//end of requesting ID to be processing
            }//end of checking threshold
            else// check if it is invalid
            {
                Console.WriteLine("Incorrect Format , should be a number!!!");

            }
            Console.WriteLine("\n");
        }//end of function of displayThreshold!!!!
           void addNewInventoryItem()
        {
            List<Product> list1 = JsonUtility.readJsonFile<List<Product>>(@"F:\owners_inventory.json");
            List<Product> list2 = JsonUtility.readJsonFile<List<Product>>(getUrl(_store.Id));
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


