using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
namespace WebA1
{
    class MainMenu : Menu
    {
       public MainMenu()
        {
            
            
            menuItem.Add("Owner");
            menuItem.Add("Franchise Owner");
            menuItem.Add("Customer");
            menuItem.Add("Quit");
               
            
        }
  
       bool validingInput()
        {
            int option;
            
           
                option = getInput(Console.ReadLine());
                if (option!=-1)
                {
                    
                    switch (option)
                 {
                    case 1:
                        Owner owner = new Owner();
                        owner.runOwnerMenu();
                        break;

                    case 2:
                        Store store = requestStore();
                        Franchise franchise = new Franchise(store);
                        franchise.runFranchiseMenu();
                        break;

                    case 3:
                        Store store1 = requestStore();
                        Customer cust = new Customer(store1);
                        cust.runCustomerMenu();
                        break;

                    case 4:
                        quit();
                        break;

                    default:
                        Console.WriteLine("The option is not available! Please enter another option(1 to {0}):",menuItem.Count);
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        return false;
                       
                }
                return true;
                }else
                {
                    //Console.WriteLine("Please enter correct value!");
                return false;
                }
        }
        
       public void runMainMenu()
        {
            bool input;
            while (true) {
                displayTitle("Main Menu");
                displayList();
                displayHint();
                input = validingInput();
                //if (!input)
                //{
                //    new MainMenu();
               // }
            } 
        }
        
       public void quit()
        {
            Environment.Exit(0);
        }

        Store requestStore()
        {
            Store store = null;
           // bool invalid = false;
            while (true)
            {
                //Console.Clear();
                Console.WriteLine("Choose a store Id: \n ");
                 
                    var stores = JsonUtility.readJsonFile<List<Store>>("F:\\stores.json");
                for(int i =0; i<stores.Count; i++)
                {
                    Console.WriteLine("    {0} . {1} ",  i+1 ,stores[i].Name);
                }
                Console.WriteLine();
                Console.WriteLine("Please enter an option : ");
                    int option = getInput(Console.ReadLine());
                    if (option == -1)
                    {
                       // Console.WriteLine("The Store ID is invalid, Please enter again");
                        continue;
                    }
                    else
                    {

                    store = getStoreForFranchise(option, stores);
                    return store;
                        /*switch (option)
                        {
                            case 1:
                            Store store1 = new Store(stores[option - 1].Id, stores[option - 1].Name);
                            return store1;
                                //Franchise store1 = new Franchise(stores[option - 1].Name);
                                //store1.runFranchiseMenu();
                               
                            case 2:
                            Store store2 = new Store(stores[option - 1].Id, stores[option - 1].Name);
                            return store2;
                            //Franchise store2 = new Franchise(stores[option - 1].Name);
                            //store2.runFranchiseMenu();
                            
                            case 3:
                            Store store3 = new Store(stores[option - 1].Id, stores[option - 1].Name);
                            return store3;
                            //Franchise store3 = new Franchise(stores[option - 1].Name);
                            //store3.runFranchiseMenu();
                            
                            case 4:
                                Store store4 = new Store(stores[option - 1].Id, stores[option - 1].Name);
                                 return store4;
                            //Franchise store4 = new Franchise(stores[option - 1].Name);
                            //store4.runFranchiseMenu();
                            
                            case 5:
                             Store store5 = new Store(stores[option - 1].Id, stores[option - 1].Name);
                             return store5;
                            //Franchise store5 = new Franchise(stores[option - 1].Name);
                            //store5.runFranchiseMenu();
                            
                            default :
                                Console.WriteLine("The Store ID is between 1 and {0},Please enter ID again", stores.Count);
                                break;

                        }*/
                    }
                
            }
        }

        Store getStoreForFranchise(int option, List<Store> stores)
        {
            Store store = null;

            if(option>0&& option <= stores.Count)
            {
                store = new Store(stores[option - 1].Id, stores[option - 1].Name);
            }
            else 
            {
                Console.WriteLine("The Store ID is between 1 and {0},Please enter ID again", stores.Count);
            }
            return store;
        }
    }
}
