using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualVendingMachine
{
    public class Wallet
    {
        public List<CoinSet> coins = new List<CoinSet>();

        public Wallet(){}

        public Wallet(List<CoinSet> wallet)
        {
            for (int i = 0; i < wallet.Count(); i++ )
            {
                CoinSet coin = new CoinSet(wallet[i].value, wallet[i].count);
                this.coins.Add(coin);
            }
        }

        public int Sum()
        {
            int result = 0;
            foreach (var coin in coins)
            {
                result += coin.count * coin.value; 
            }
            return result;
        }

        public void AddCoin(CoinSet coin)
        {
            if (this.CoinByValue(coin.value) != null)
            {
                this.CoinByValue(coin.value).count += coin.count;
            }
            else
            {
                this.coins.Add(coin);
            }
        }

        // Возвращает кошелек с монетами, необходимыми для сдачи
        // int change - какую сумму надо вернуть
        // return - кошелек с набором монет
        public Wallet CoinsForChange(int change)
        {
            Wallet result = new Wallet();
            coins.Sort(Coin.CompareByValue);

            foreach(var coin in this.coins)
            {
                int coinCountNeed = change / coin.value;                      // количество монет текущего значения
                if (coinCountNeed > coin.count)
                {            
                    coinCountNeed = coin.count;
                }
                if (coinCountNeed > 0)
                {
                    CoinSet c = new CoinSet(coin.value, coinCountNeed);
                    result.coins.Add(c);
                }
                change -= coinCountNeed * coin.value;
                if (change == 0) break;
            }
            if (change > 0) return null;
            return result;
        }

        public Wallet Substruct(Wallet p)
        {
            Wallet result = new Wallet();

            foreach (var coin in this.coins)
            {
                CoinSet c = p.CoinByValue(coin.value);
                if ( c != null ) coin.count -= c.count;
            }
            return result;
        }

        public int CoinCount(int value)
        {
            foreach (var coin in coins)
            {
                if (coin.value == value)
                {
                    return coin.count;
                }
            }
            return 0;
        }

        public CoinSet CoinByValue(int value)
        {
            foreach (var coin in this.coins)
            {
                if (coin.value == value)
                {
                    return coin;
                }
            }
            return null;
        }

        public static Wallet operator +(Wallet wallet1, Wallet wallet2)
        {
            Wallet resultwallet = new Wallet(wallet1.coins);
            foreach (var coin in wallet2.coins)
            {
                var c = resultwallet.CoinByValue(coin.value);
                if (c != null)
                 {
                     c.count += coin.count;
                 }
                 else
                 {
                     resultwallet.coins.Add(coin);
                 }
            }
            return resultwallet;
        }

        public void Clean()
        {
            this.coins.Clear();
        }
    }
}
