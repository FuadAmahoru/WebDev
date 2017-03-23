using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebA1
{
   public class Product
    {
        protected const int defaultRestocking = 4;
        protected int Threshold = 3;
        public int ID { get; set; }
        public string Name { get; set; }
        public Int32 CurrentStock { get; set; }
        public bool ReStock { get; set; }
    }
}
