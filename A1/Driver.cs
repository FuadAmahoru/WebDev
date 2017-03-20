using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebA1
{
    class Driver
    {
        static void Main(string[] args)
        {
            MainMenu driver = new MainMenu();
            driver.runMainMenu();
            Console.ReadLine();
          //  driver.displayMainMenu();
        }
    }
}
