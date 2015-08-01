using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualVendingMachine
{
    public class ProductSet : Product
    {
        public int count;

		public ProductSet(string name, int cost, int count):base(name, cost) {									
			this.count = count;
		}				
    }       
}
