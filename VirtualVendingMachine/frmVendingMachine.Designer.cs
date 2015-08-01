namespace VirtualVendingMachine
{
    partial class frmVendingMachine
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.paneMain = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // paneMain
            // 
            this.paneMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paneMain.Location = new System.Drawing.Point(0, 0);
            this.paneMain.Name = "paneMain";
            this.paneMain.Size = new System.Drawing.Size(784, 372);
            this.paneMain.TabIndex = 0;
            // 
            // frmVendingMachine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 372);
            this.Controls.Add(this.paneMain);
            this.Name = "frmVendingMachine";
            this.Text = "VendingMachine";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel paneMain;
    }
}

