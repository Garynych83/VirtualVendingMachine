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
    public partial class buttonLabel : UserControl
    {
        CoinSet data;
        public buttonLabel()
        {
            InitializeComponent();
        }

        public Button getButton
        {
            get { return button; }
        }

        public void setData(CoinSet data)
        {
            this.data = data;
            this.button.Text = this.data.value.ToString();
            this.label.Text = this.data.count.ToString();
            this.Enabled = this.data.count > 0;
        }

        public CoinSet getData()
        {
            return this.data;
        }
    }
}
