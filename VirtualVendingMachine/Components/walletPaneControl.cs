using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VirtualVendingMachine.Components
{
    public partial class walletPaneControl : UserControl
    {
        public class WalletEventArgs : EventArgs
        {
            public int value { get; set; }
            public WalletEventArgs(int value)
            {
                this.value = value;
            }           
        }

        public delegate void WalletEventHandler(object sender, WalletEventArgs e);
        public event WalletEventHandler WalletEvent;

        Wallet wallet;
        public walletPaneControl(Wallet wallet)
        {
            this.wallet = wallet;
            this.FillPane();
            InitializeComponent();
        }

        public void FillPane()
        {
            int x = 0;
            int y = 0;
            foreach(var coin in wallet.coins)
            {
                buttonLabel bl = new buttonLabel();
                bl.setData(coin);
                bl.Location = new System.Drawing.Point(x, y+=25);
                bl.Name = "bl" + coin.value.ToString();
                bl.Size = new System.Drawing.Size(75, 23);
                bl.TabIndex = 0;
                bl.getButton.Click += new EventHandler(button_Click);
                this.Controls.Add(bl);
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            OnWalletEvent(new WalletEventArgs(Convert.ToInt32(button.Text)));
        }

        protected virtual void OnWalletEvent(WalletEventArgs e)
        {
            WalletEvent(this, e);
        }

        internal void UpdateWallet(Wallet wallet)
        {
            this.wallet = wallet;
            foreach (buttonLabel bl in this.Controls)
            {
                bl.setData(this.wallet.CoinByValue(bl.getData().value));
            }
        }
    }
}
