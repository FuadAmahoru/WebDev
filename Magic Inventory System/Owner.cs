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
                        displayStockRequest();
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
                return false;     
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
              
            }
        }
        void displayStockRequest()
        {
            var lines = File.ReadAllLines(@"F:\stockrequest.txt");
            int count = 0;
            Console.WriteLine("ID\tStore\tProduct\t\tQuantity\tCurrent Stock\tStock Ava\t");
            for (int i = 0; i < lines.Length; i++)
            {
                string[] fields = lines[i].Split(',');
                Console.Write("{0,-8}", ++count);
                for (int j = 0; j < fields.Length; j++)
                {
                    switch (j)
                    {
                        case 0: Console.Write("{0,-5}", fields[j]); break;
                        case 1: Console.Write("{0,-10}", fields[j]); break;
                        case 2: Console.Write("{0,-10}", fields[j]); break;
                        case 3: Console.Write("{0,-15}", fields[j]); break;
                        case 4: Console.Write("{0,-5}", fields[j]); break;
                    }
                   
                    Console.Write("\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine();
        }
        //void displayStockRequest()
        //{
        //    //List<(@"F:\stockrequest.txt");
        //    //StreamReader s = new StreamReader(@"F:\stockrequest.txt")£»

        //    //while (!s.EndOfStream)
        //    //{
        //    //    s.
        //    //    string lineOfInfo = s.ReadLine();

        //    //}
        //    //string[] info;
        //    List<StockRequest> sr = JsonUtility.readJsonFile<List<StockRequest>>(@"F:\stockrequest.json");
        //    Console.WriteLine("ID\t\tStore\tProduct\tQuantity\tCurrent Stock\t\tStock Availability\t");
        //    Console.WriteLine("============================================================================");
        //    for(int i = 0; i < sr.Count; i++)
        //    {
        //        Console.WriteLine("{0}\t\t{1}\t{2}\t{3}\t{4}\t\t{5}\t",i,sr[i].Name, sr[i].Name, sr[i].Quantity, sr[i].CurrentStock);
                

        //    }
        //   // while (StringReader.)
        //    // int count = 1; the int number for storing new ID in the list 3
        //    //foreach (Store p in list)
        //    //{
        //    //    Console.WriteLine("{0}\t\t{1}", count++, p.Name);
        //    //}
        //}
    }
}
