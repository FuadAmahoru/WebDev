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
                }
            return false;
        }
        
       public void runMainMenu()
        {
            bool input;
            while (true) {
                displayTitle("Main Menu");
                displayList();
                displayHint();
                input = validingInput();
                
            } 
        }
        
       public void quit()
        {
            Environment.Exit(0);
        }

        Store requestStore()
        {
            Store store = null;
           
            while (true)
            {
                
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
