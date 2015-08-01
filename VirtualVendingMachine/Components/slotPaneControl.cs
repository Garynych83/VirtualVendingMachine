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
    public partial class slotPaneControl : UserControl
    {
        public class ReturnEventArgs : EventArgs
        {
            public int value { get; set; }
            public ReturnEventArgs(int value)
            {
                this.value = value;
            }
        }

        public delegate void ReturnEventHandler(object sender, ReturnEventArgs e);
        public event ReturnEventHandler ReturnEvent;

        Wallet wallet;
        public slotPaneControl(Wallet wallet)
        {
            this.wallet = wallet;
            InitializeComponent();
            label2.Text = this.wallet.Sum().ToString();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            OnReturnEvent(new ReturnEventArgs(Convert.ToInt32(label2.Text)));
        }

        protected virtual void OnReturnEvent(ReturnEventArgs e)
        {
            ReturnEvent(this, e);
        }

        public void setData(Wallet data)
        {
            this.wallet = data;
            this.label2.Text = this.wallet.Sum().ToString();
        }
    }
}
