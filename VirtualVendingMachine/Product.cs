using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualVendingMachine
{
    public class Product
    {
        public string name;
        public int cost;

		public Product(string name, int cost) {			
			this.name = name;								
			this.cost = cost;				
		}				
    }       
}
