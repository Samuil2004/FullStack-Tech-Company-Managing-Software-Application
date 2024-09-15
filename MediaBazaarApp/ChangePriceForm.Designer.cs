namespace MediaBazaarApp
{
    partial class ChangePriceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangePriceForm));
            pbPrevPage = new PictureBox();
            lblS = new Label();
            nudPrice = new NumericUpDown();
            btnSubmit = new Button();
            lblProduct = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pbPrevPage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPrice).BeginInit();
            SuspendLayout();
            // 
            // pbPrevPage
            // 
            pbPrevPage.Image = Properties.Resources.arrow_55_75;
            pbPrevPage.Location = new Point(15, 14);
            pbPrevPage.Name = "pbPrevPage";
            pbPrevPage.Size = new Size(101, 99);
            pbPrevPage.SizeMode = PictureBoxSizeMode.StretchImage;
            pbPrevPage.TabIndex = 89;
            pbPrevPage.TabStop = false;
            pbPrevPage.Click += pbPrevPage_Click;
            // 
            // lblS
            // 
            lblS.AutoSize = true;
            lblS.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblS.Location = new Point(228, 226);
            lblS.Margin = new Padding(5, 0, 5, 0);
            lblS.Name = "lblS";
            lblS.Size = new Size(88, 37);
            lblS.TabIndex = 90;
            lblS.Text = "Price:";
            // 
            // nudPrice
            // 
            nudPrice.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            nudPrice.Location = new Point(351, 221);
            nudPrice.Margin = new Padding(5);
            nudPrice.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            nudPrice.Name = "nudPrice";
            nudPrice.Size = new Size(167, 44);
            nudPrice.TabIndex = 91;
            // 
            // btnSubmit
            // 
            btnSubmit.BackColor = Color.FromArgb(161, 7, 2);
            btnSubmit.ForeColor = Color.WhiteSmoke;
            btnSubmit.Location = new Point(146, 382);
            btnSubmit.Margin = new Padding(5);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(492, 77);
            btnSubmit.TabIndex = 114;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = false;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // lblProduct
            // 
            lblProduct.AutoSize = true;
            lblProduct.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblProduct.Location = new Point(366, 144);
            lblProduct.Margin = new Padding(5, 0, 5, 0);
            lblProduct.Name = "lblProduct";
            lblProduct.Size = new Size(155, 38);
            lblProduct.TabIndex = 116;
            lblProduct.Text = "<product>";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label1.Location = new Point(228, 144);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(126, 37);
            label1.TabIndex = 115;
            label1.Text = "Product:";
            // 
            // ChangePriceForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(767, 490);
            Controls.Add(lblProduct);
            Controls.Add(label1);
            Controls.Add(btnSubmit);
            Controls.Add(nudPrice);
            Controls.Add(lblS);
            Controls.Add(pbPrevPage);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(5);
            MaximizeBox = false;
            MaximumSize = new Size(793, 561);
            MinimumSize = new Size(793, 561);
            Name = "ChangePriceForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Change Product Price";
            TopMost = true;
            Load += ChangePriceForm_Load;
            ((System.ComponentModel.ISupportInitialize)pbPrevPage).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPrice).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox pbPrevPage;
        private Label lblS;
        private NumericUpDown nudPrice;
        private Button btnSubmit;
        private Label lblProduct;
        private Label label1;
    }
}