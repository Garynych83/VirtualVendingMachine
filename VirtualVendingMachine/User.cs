using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualVendingMachine
{
    public class User
    {
        public List<CoinSet> coins = new List<CoinSet>(){
			    new CoinSet(1, 10),
			    new CoinSet(2, 30),
			    new CoinSet(5, 20),
			    new CoinSet(10, 15)
	    };

        public Wallet wallet;

        public User()
        {            
            wallet = new Wallet(coins);
        }
    }
}
