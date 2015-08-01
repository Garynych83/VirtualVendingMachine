using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VirtualVendingMachine.Components;

namespace VirtualVendingMachine
{
    public partial class frmVendingMachine : Form
    {
        VendingMachine vm = new VendingMachine();
        User user = new User();

        walletPaneControl userwallet;
        slotPaneControl slotPane;
        walletPaneControl vmwallet;
        productPaneControl productPane;

        public frmVendingMachine()
        {
            FillForm();
            InitializeComponent();

            userwallet.WalletEvent += new walletPaneControl.WalletEventHandler(wallet_changed);
            slotPane.ReturnEvent += new slotPaneControl.ReturnEventHandler(change_returned);
            productPane.ProductEvent += new productPaneControl.ProductEventHandler(buy_product);
        }

        private void wallet_changed(object sender, walletPaneControl.WalletEventArgs e)
        {
            user.wallet.CoinByValue(e.value).count--;
            userwallet.UpdateWallet(user.wallet);
            vm.tempwallet.AddCoin(new CoinSet(e.value, 1)); // CoinByValue(e.value).count++;
            slotPane.setData(vm.tempwallet);
        }

        private void change_returned(object sender, slotPaneControl.ReturnEventArgs e)
        {
            Wallet tmp = vm.Cancel();
            if (tmp != null)
            {
                user.wallet += tmp;
                userwallet.UpdateWallet(user.wallet);
                slotPane.setData(vm.tempwallet);
                vmwallet.UpdateWallet(vm.wallet);
            }
            else
            {
                MessageBox.Show("Нет размена для сдачи");
            }
        }

        private void buy_product(object sender, productPaneControl.ProductEventArgs e)
        {
            if (vm.Check(vm.ProductSetByName(e.name)))
            {
                if (vm.Buy(vm.ProductSetByName(e.name)) != null)
                {
                    slotPane.setData(vm.tempwallet);
                    productPane.UpdateProducts(vm.products);
                    vmwallet.UpdateWallet(vm.wallet);
                    MessageBox.Show("Спасибо!");
                }
                else
                {
                    MessageBox.Show("Нет размена для сдачи");
                }
            }
            else
            {
                MessageBox.Show("Недостаточно средств");
            }
        }

        private void FillForm()
        {
            int x = 0, y = 0;
            userwallet = new walletPaneControl(user.wallet);
            userwallet.Dock = System.Windows.Forms.DockStyle.Left;
            userwallet.Location = new System.Drawing.Point(x, y);
            userwallet.Name = "userwalletPane";
            userwallet.Size = new System.Drawing.Size(195, 264);
            userwallet.BorderStyle = BorderStyle.Fixed3D;

            //slotPane = new slotPaneControl(vm, user);
            slotPane = new slotPaneControl(vm.tempwallet);
            slotPane.Dock = System.Windows.Forms.DockStyle.Left;
            slotPane.Location = new System.Drawing.Point(x += userwallet.Size.Width, 0);
            slotPane.Name = "productPane";
            slotPane.Size = new System.Drawing.Size(195, 264);
            slotPane.BorderStyle = BorderStyle.Fixed3D;

            vmwallet = new walletPaneControl(vm.wallet);
            vmwallet.Dock = System.Windows.Forms.DockStyle.Right;
            vmwallet.Location = new System.Drawing.Point(x += slotPane.Size.Width, 0);
            vmwallet.Name = "vmwalletPane";
            vmwallet.Size = new System.Drawing.Size(195, 264);
            vmwallet.BorderStyle = BorderStyle.Fixed3D;
            vmwallet.Enabled = false;
            //vmwallet.

            productPane = new productPaneControl(vm.products);
            productPane.Dock = System.Windows.Forms.DockStyle.Right;
            productPane.Location = new System.Drawing.Point(x += vmwallet.Size.Width, 0);
            productPane.Name = "productPane";
            productPane.Size = new System.Drawing.Size(195, 264);
            productPane.BorderStyle = BorderStyle.Fixed3D;
            
            this.Controls.Add(slotPane);
            this.Controls.Add(userwallet);
            this.Controls.Add(productPane);
            this.Controls.Add(vmwallet);


        }
    }
}
