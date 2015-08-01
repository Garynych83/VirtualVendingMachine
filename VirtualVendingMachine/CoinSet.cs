using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualVendingMachine
{
    public class CoinSet : Coin
    {
        public int count;

        public CoinSet(int value, int count)
            : base(value)
        {
            this.count = count;
        }
    }
}

