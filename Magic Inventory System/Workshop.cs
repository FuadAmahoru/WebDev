using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebA1
{
    class Workshop
    {
        protected int space { get; set; }
        
        public Workshop()
        {
            space = 10;
        }
        public Workshop(int spaces)
        {
            space = spaces;
        }
    }

}
