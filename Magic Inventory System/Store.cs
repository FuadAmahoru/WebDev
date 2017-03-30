using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebA1
{
     class Store
    {
        protected Workshop work { get; set; }
       // public List<Product> list = new List<Product>();
        //public int Threshold { get; set; }
      public int Id { get; set; }
       public string Name { get; set; }
        
        public Store(int id, string name)
        {
            Id = id;
            Name = name;
            this.work = new Workshop();
        }

    }
}
