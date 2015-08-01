using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualVendingMachine
{
    public class Coin
    {
        public int value;

        public Coin(int value)
        {
            this.value = value;
        }

        public static int CompareByValue(Coin coin1, Coin coin2)
        {
            return coin2.value.CompareTo(coin1.value);
        }
    }
}
