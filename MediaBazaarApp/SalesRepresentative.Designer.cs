namespace MediaBazaarApp
{
    partial class SalesRepresentative
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalesRepresentative));
            label4 = new Label();
            nudQuantity = new NumericUpDown();
            btnRequestNewDepoStock = new Button();
            lblSelectedProduct = new Label();
            label3 = new Label();
            tbxProductCode = new TextBox();
            lblCurrentQuantity = new Label();
            pbPrevPage = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)nudQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbPrevPage).BeginInit();
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(541, 402);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(111, 32);
            label4.TabIndex = 119;
            label4.Text = "Quantity:";
            // 
            // nudQuantity
            // 
            nudQuantity.Location = new Point(661, 398);
            nudQuantity.Margin = new Padding(5, 5, 5, 5);
            nudQuantity.Name = "nudQuantity";
            nudQuantity.Size = new Size(158, 39);
            nudQuantity.TabIndex = 118;
            nudQuantity.KeyDown += nudQuantity_KeyDown;
            // 
            // btnRequestNewDepoStock
            // 
            btnRequestNewDepoStock.Location = new Point(541, 469);
            btnRequestNewDepoStock.Name = "btnRequestNewDepoStock";
            btnRequestNewDepoStock.Size = new Size(757, 43);
            btnRequestNewDepoStock.TabIndex = 116;
            btnRequestNewDepoStock.Text = "Request new stock";
            btnRequestNewDepoStock.UseVisualStyleBackColor = true;
            btnRequestNewDepoStock.Click += RequestNewDepoStockButton_Click;
            // 
            // lblSelectedProduct
            // 
            lblSelectedProduct.AutoSize = true;
            lblSelectedProduct.Location = new Point(540, 261);
            lblSelectedProduct.Margin = new Padding(5, 0, 5, 0);
            lblSelectedProduct.Name = "lblSelectedProduct";
            lblSelectedProduct.Size = new Size(194, 32);
            lblSelectedProduct.TabIndex = 122;
            lblSelectedProduct.Text = "Selecter product:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(540, 195);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(160, 32);
            label3.TabIndex = 125;
            label3.Text = "Product code:";
            // 
            // tbxProductCode
            // 
            tbxProductCode.Location = new Point(718, 190);
            tbxProductCode.Margin = new Padding(5, 5, 5, 5);
            tbxProductCode.Name = "tbxProductCode";
            tbxProductCode.Size = new Size(576, 39);
            tbxProductCode.TabIndex = 124;
            tbxProductCode.TextChanged += tbxProductCode_TextChanged;
            tbxProductCode.KeyDown += tbxProductCode_KeyDown;
            // 
            // lblCurrentQuantity
            // 
            lblCurrentQuantity.AutoSize = true;
            lblCurrentQuantity.Location = new Point(540, 330);
            lblCurrentQuantity.Margin = new Padding(5, 0, 5, 0);
            lblCurrentQuantity.Name = "lblCurrentQuantity";
            lblCurrentQuantity.Size = new Size(194, 32);
            lblCurrentQuantity.TabIndex = 126;
            lblCurrentQuantity.Text = "Current quantity:";
            // 
            // pbPrevPage
            // 
            pbPrevPage.Image = Properties.Resources.arrow_55_75;
            pbPrevPage.Location = new Point(18, 18);
            pbPrevPage.Name = "pbPrevPage";
            pbPrevPage.Size = new Size(101, 99);
            pbPrevPage.SizeMode = PictureBoxSizeMode.StretchImage;
            pbPrevPage.TabIndex = 127;
            pbPrevPage.TabStop = false;
            pbPrevPage.Click += pbPrevPage_Click;
            // 
            // SalesRepresentative
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1924, 1054);
            Controls.Add(pbPrevPage);
            Controls.Add(lblCurrentQuantity);
            Controls.Add(label3);
            Controls.Add(tbxProductCode);
            Controls.Add(lblSelectedProduct);
            Controls.Add(label4);
            Controls.Add(nudQuantity);
            Controls.Add(btnRequestNewDepoStock);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(1950, 1125);
            MinimumSize = new Size(1950, 1125);
            Name = "SalesRepresentative";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Product Request";
            ((System.ComponentModel.ISupportInitialize)nudQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbPrevPage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label4;
        private NumericUpDown nudQuantity;
        private Label SelectedDepoProductLabel;
        private Button btnRequestNewDepoStock;
        private Label lblSelectedProduct;
		private Label label3;
		private TextBox tbxProductCode;
		private Label lblProductName;
		private Label lblCurrentQuantity;
		private PictureBox pbPrevPage;
	}
}