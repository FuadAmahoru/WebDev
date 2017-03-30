using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WebA1
{
     class Inventory
    {
        
        public void displayProductLines()
        {
            List<Product> ro = JsonUtility.readJsonFile<List<Product>>(@"F:\owners_inventory.json");
           
            Console.WriteLine("=================");
            Console.WriteLine("Inventory      ||");
            Console.WriteLine("=================");
            Console.WriteLine("ID\tProduct\t\t\t  Current Stock");
            Console.WriteLine("____________________________________________________");
            foreach (Product item in ro)
            {
                Console.WriteLine("{0,-5}\t{1,-8}\t\t{2,3}", item.ID, item.Name, item.CurrentStock);
            }

            Console.WriteLine("\n");
          
        }
    }
}
