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
    public partial class button2Labels : UserControl
    {
        ProductSet data;
        public button2Labels()
        {
            InitializeComponent();
        }

        public Button getButton
        {
            get { return button; }
        }

        public void setData(ProductSet data)
        {
            this.data = data;
            this.button.Text = this.data.name.ToString();
            this.label1.Text = this.data.count.ToString();
            this.label2.Text = this.data.cost.ToString();
            this.Enabled = this.data.count > 0;
        }

        public ProductSet getData()
        {
            return this.data;
        }
    }
}
