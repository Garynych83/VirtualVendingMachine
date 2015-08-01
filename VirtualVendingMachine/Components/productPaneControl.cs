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
    public partial class productPaneControl : UserControl
    {
        public List<ProductSet> products;
        public class ProductEventArgs : EventArgs
        {
            public string name { get; set; }
            //public int cost { get; set; }
            //public int count { get; set; }
            public ProductEventArgs(string name/*, int cost, int count*/)
            {
                this.name = name;
                //this.cost = cost;
                //this.count = count;
            }
        }

        public delegate void ProductEventHandler(object sender, ProductEventArgs e);
        public event ProductEventHandler ProductEvent;

        public productPaneControl(List<ProductSet> products)
        {
            this.products = products;
            this.FillPane();
            InitializeComponent();
        }

        public void FillPane()
        {
            int x = 0;
            int y = 0;
            foreach (var product in products)
            {
                button2Labels bll = new button2Labels();
                bll.setData(product);
                bll.Location = new System.Drawing.Point(x, y += 25);
                bll.Name = "bl" + product.name.ToString();
                bll.Size = new System.Drawing.Size(75, 23);
                bll.TabIndex = 0;
                bll.getButton.Click += new EventHandler(button_Click);
                this.Controls.Add(bll);
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            OnProductEvent(new ProductEventArgs(button.Text));
        }

        protected virtual void OnProductEvent(ProductEventArgs e)
        {
            ProductEvent(this, e);
        }

        internal void UpdateProducts(List<ProductSet> products)
        {
            this.products = products;
            foreach (button2Labels bll in this.Controls)
            {
                bll.setData(this.products.FirstOrDefault<ProductSet>(p => p.name == bll.getData().name));
            }
        }
    }
}
