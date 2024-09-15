namespace MediaBazaarApp
{
    partial class StockManagerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StockManagerForm));
            label1 = new Label();
            tbxProductName = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            btnFilter = new Button();
            lbxProducts = new ListBox();
            btnCreateNewProduct = new Button();
            lblNumRes = new Label();
            lblS = new Label();
            lblP = new Label();
            lblC = new Label();
            lblProductDescriptionLabel = new Label();
            lblPr = new Label();
            lblMaxS = new Label();
            lblStck = new Label();
            pgbStock = new ProgressBar();
            btnEditDetails = new Button();
            lblProductDescription = new Label();
            nudMinPrice = new NumericUpDown();
            nudMaxPrice = new NumericUpDown();
            nudMinPrecent = new NumericUpDown();
            nudMaxPrecent = new NumericUpDown();
            cmbCategory = new ComboBox();
            lblY = new Label();
            lblSelectedProduct = new Label();
            lblProductNumber = new Label();
            lblCategory = new Label();
            lblYear = new Label();
            lblPrice = new Label();
            lblMaxStockCapacity = new Label();
            lblNumberOfResults = new Label();
            lblStockPercentage = new Label();
            tbxYear = new TextBox();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)nudMinPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudMaxPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudMinPrecent).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudMaxPrecent).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(60, 83);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(168, 32);
            label1.TabIndex = 0;
            label1.Text = "Product name:";
            // 
            // tbxProductName
            // 
            tbxProductName.Location = new Point(239, 78);
            tbxProductName.Margin = new Padding(5, 5, 5, 5);
            tbxProductName.Name = "tbxProductName";
            tbxProductName.Size = new Size(620, 39);
            tbxProductName.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(60, 136);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(115, 32);
            label2.TabIndex = 2;
            label2.Text = "Category:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(60, 189);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(63, 32);
            label3.TabIndex = 4;
            label3.Text = "Year:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(60, 242);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(182, 32);
            label4.TabIndex = 6;
            label4.Text = "Minimum price:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(60, 294);
            label5.Margin = new Padding(5, 0, 5, 0);
            label5.Name = "label5";
            label5.Size = new Size(185, 32);
            label5.TabIndex = 8;
            label5.Text = "Maximum price:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(60, 410);
            label6.Margin = new Padding(5, 0, 5, 0);
            label6.Name = "label6";
            label6.Size = new Size(275, 32);
            label6.TabIndex = 10;
            label6.Text = "Stock precentage above:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(60, 462);
            label7.Margin = new Padding(5, 0, 5, 0);
            label7.Name = "label7";
            label7.Size = new Size(274, 32);
            label7.TabIndex = 12;
            label7.Text = "Stock precentage below:";
            // 
            // btnFilter
            // 
            btnFilter.BackColor = Color.FromArgb(161, 7, 2);
            btnFilter.ForeColor = Color.White;
            btnFilter.Location = new Point(60, 526);
            btnFilter.Margin = new Padding(5, 5, 5, 5);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(788, 46);
            btnFilter.TabIndex = 14;
            btnFilter.Text = "Filter";
            btnFilter.UseVisualStyleBackColor = false;
            btnFilter.Click += btnFilter_Click;
            // 
            // lbxProducts
            // 
            lbxProducts.FormattingEnabled = true;
            lbxProducts.Location = new Point(60, 643);
            lbxProducts.Margin = new Padding(5, 5, 5, 5);
            lbxProducts.Name = "lbxProducts";
            lbxProducts.Size = new Size(786, 420);
            lbxProducts.TabIndex = 15;
            lbxProducts.SelectedIndexChanged += lbxProducts_SelectedIndexChanged;
            // 
            // btnCreateNewProduct
            // 
            btnCreateNewProduct.BackColor = Color.FromArgb(161, 7, 2);
            btnCreateNewProduct.ForeColor = Color.White;
            btnCreateNewProduct.Location = new Point(60, 1093);
            btnCreateNewProduct.Margin = new Padding(5, 5, 5, 5);
            btnCreateNewProduct.Name = "btnCreateNewProduct";
            btnCreateNewProduct.Size = new Size(788, 64);
            btnCreateNewProduct.TabIndex = 16;
            btnCreateNewProduct.Text = "Create new product";
            btnCreateNewProduct.UseVisualStyleBackColor = false;
            btnCreateNewProduct.Click += btnCreateNewProduct_Click;
            // 
            // lblNumRes
            // 
            lblNumRes.AutoSize = true;
            lblNumRes.Location = new Point(187, 606);
            lblNumRes.Margin = new Padding(5, 0, 5, 0);
            lblNumRes.Name = "lblNumRes";
            lblNumRes.RightToLeft = RightToLeft.No;
            lblNumRes.Size = new Size(90, 32);
            lblNumRes.TabIndex = 17;
            lblNumRes.Text = " results";
            // 
            // lblS
            // 
            lblS.AutoSize = true;
            lblS.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblS.Location = new Point(996, 83);
            lblS.Margin = new Padding(5, 0, 5, 0);
            lblS.Name = "lblS";
            lblS.Size = new Size(249, 37);
            lblS.TabIndex = 18;
            lblS.Text = "Selected product: ";
            lblS.Visible = false;
            // 
            // lblP
            // 
            lblP.AutoSize = true;
            lblP.Location = new Point(996, 242);
            lblP.Margin = new Padding(5, 0, 5, 0);
            lblP.Name = "lblP";
            lblP.Size = new Size(192, 32);
            lblP.TabIndex = 19;
            lblP.Text = "Product number:";
            lblP.Visible = false;
            // 
            // lblC
            // 
            lblC.AutoSize = true;
            lblC.Location = new Point(996, 301);
            lblC.Margin = new Padding(5, 0, 5, 0);
            lblC.Name = "lblC";
            lblC.Size = new Size(122, 32);
            lblC.TabIndex = 20;
            lblC.Text = "Category: ";
            lblC.Visible = false;
            // 
            // lblProductDescriptionLabel
            // 
            lblProductDescriptionLabel.AutoSize = true;
            lblProductDescriptionLabel.Location = new Point(999, 406);
            lblProductDescriptionLabel.Margin = new Padding(5, 0, 5, 0);
            lblProductDescriptionLabel.MaximumSize = new Size(876, 0);
            lblProductDescriptionLabel.Name = "lblProductDescriptionLabel";
            lblProductDescriptionLabel.Size = new Size(226, 32);
            lblProductDescriptionLabel.TabIndex = 21;
            lblProductDescriptionLabel.Text = "Product description:";
            lblProductDescriptionLabel.Visible = false;
            // 
            // lblPr
            // 
            lblPr.AutoSize = true;
            lblPr.Location = new Point(996, 726);
            lblPr.Margin = new Padding(5, 0, 5, 0);
            lblPr.Name = "lblPr";
            lblPr.Size = new Size(70, 32);
            lblPr.TabIndex = 22;
            lblPr.Text = "Price:";
            lblPr.Visible = false;
            // 
            // lblMaxS
            // 
            lblMaxS.AutoSize = true;
            lblMaxS.Location = new Point(996, 805);
            lblMaxS.Margin = new Padding(5, 0, 5, 0);
            lblMaxS.Name = "lblMaxS";
            lblMaxS.Size = new Size(281, 32);
            lblMaxS.TabIndex = 23;
            lblMaxS.Text = "Maximum stock capacity:";
            lblMaxS.Visible = false;
            // 
            // lblStck
            // 
            lblStck.AutoSize = true;
            lblStck.Location = new Point(996, 946);
            lblStck.Margin = new Padding(5, 0, 5, 0);
            lblStck.Name = "lblStck";
            lblStck.Size = new Size(191, 32);
            lblStck.TabIndex = 24;
            lblStck.Text = "Stock remaining:";
            lblStck.Visible = false;
            // 
            // pgbStock
            // 
            pgbStock.Location = new Point(1263, 946);
            pgbStock.Margin = new Padding(5, 5, 5, 5);
            pgbStock.Name = "pgbStock";
            pgbStock.Size = new Size(606, 46);
            pgbStock.TabIndex = 25;
            pgbStock.Visible = false;
            // 
            // btnEditDetails
            // 
            btnEditDetails.BackColor = Color.FromArgb(161, 7, 2);
            btnEditDetails.ForeColor = Color.White;
            btnEditDetails.Location = new Point(996, 1093);
            btnEditDetails.Margin = new Padding(5, 5, 5, 5);
            btnEditDetails.Name = "btnEditDetails";
            btnEditDetails.Size = new Size(873, 64);
            btnEditDetails.TabIndex = 26;
            btnEditDetails.Text = "Edit details";
            btnEditDetails.UseVisualStyleBackColor = false;
            btnEditDetails.Visible = false;
            btnEditDetails.Click += btnEditDetails_Click;
            // 
            // lblProductDescription
            // 
            lblProductDescription.AutoSize = true;
            lblProductDescription.Location = new Point(1220, 406);
            lblProductDescription.Margin = new Padding(5, 0, 5, 0);
            lblProductDescription.MaximumSize = new Size(652, 0);
            lblProductDescription.Name = "lblProductDescription";
            lblProductDescription.Size = new Size(171, 32);
            lblProductDescription.TabIndex = 29;
            lblProductDescription.Text = " <description>";
            lblProductDescription.Visible = false;
            // 
            // nudMinPrice
            // 
            nudMinPrice.Location = new Point(252, 242);
            nudMinPrice.Margin = new Padding(5, 5, 5, 5);
            nudMinPrice.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
            nudMinPrice.Name = "nudMinPrice";
            nudMinPrice.Size = new Size(609, 39);
            nudMinPrice.TabIndex = 30;
            // 
            // nudMaxPrice
            // 
            nudMaxPrice.Location = new Point(252, 294);
            nudMaxPrice.Margin = new Padding(5, 5, 5, 5);
            nudMaxPrice.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
            nudMaxPrice.Name = "nudMaxPrice";
            nudMaxPrice.Size = new Size(609, 39);
            nudMaxPrice.TabIndex = 31;
            nudMaxPrice.Value = new decimal(new int[] { 99999, 0, 0, 0 });
            // 
            // nudMinPrecent
            // 
            nudMinPrecent.Location = new Point(349, 406);
            nudMinPrecent.Margin = new Padding(5, 5, 5, 5);
            nudMinPrecent.Name = "nudMinPrecent";
            nudMinPrecent.Size = new Size(512, 39);
            nudMinPrecent.TabIndex = 32;
            // 
            // nudMaxPrecent
            // 
            nudMaxPrecent.Location = new Point(349, 461);
            nudMaxPrecent.Margin = new Padding(5, 5, 5, 5);
            nudMaxPrecent.Name = "nudMaxPrecent";
            nudMaxPrecent.Size = new Size(512, 39);
            nudMaxPrecent.TabIndex = 33;
            nudMaxPrecent.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // cmbCategory
            // 
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Items.AddRange(new object[] { "" });
            cmbCategory.Location = new Point(187, 131);
            cmbCategory.Margin = new Padding(5, 5, 5, 5);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(672, 40);
            cmbCategory.TabIndex = 34;
            // 
            // lblY
            // 
            lblY.AutoSize = true;
            lblY.Location = new Point(999, 355);
            lblY.Margin = new Padding(5, 0, 5, 0);
            lblY.Name = "lblY";
            lblY.Size = new Size(63, 32);
            lblY.TabIndex = 36;
            lblY.Text = "Year:";
            lblY.Visible = false;
            // 
            // lblSelectedProduct
            // 
            lblSelectedProduct.AutoSize = true;
            lblSelectedProduct.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSelectedProduct.Location = new Point(1243, 83);
            lblSelectedProduct.Margin = new Padding(5, 0, 5, 0);
            lblSelectedProduct.Name = "lblSelectedProduct";
            lblSelectedProduct.Size = new Size(157, 37);
            lblSelectedProduct.TabIndex = 37;
            lblSelectedProduct.Text = "<product>";
            lblSelectedProduct.Visible = false;
            // 
            // lblProductNumber
            // 
            lblProductNumber.AutoSize = true;
            lblProductNumber.Location = new Point(1198, 242);
            lblProductNumber.Margin = new Padding(5, 0, 5, 0);
            lblProductNumber.Name = "lblProductNumber";
            lblProductNumber.Size = new Size(130, 32);
            lblProductNumber.TabIndex = 38;
            lblProductNumber.Text = "<number>";
            lblProductNumber.Visible = false;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(1110, 301);
            lblCategory.Margin = new Padding(5, 0, 5, 0);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(138, 32);
            lblCategory.TabIndex = 39;
            lblCategory.Text = "<category>";
            lblCategory.Visible = false;
            // 
            // lblYear
            // 
            lblYear.AutoSize = true;
            lblYear.Location = new Point(1068, 355);
            lblYear.Margin = new Padding(5, 0, 5, 0);
            lblYear.Name = "lblYear";
            lblYear.Size = new Size(91, 32);
            lblYear.TabIndex = 40;
            lblYear.Text = "<year>";
            lblYear.Visible = false;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(1068, 726);
            lblPrice.Margin = new Padding(5, 0, 5, 0);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(98, 32);
            lblPrice.TabIndex = 41;
            lblPrice.Text = "<price>";
            lblPrice.Visible = false;
            // 
            // lblMaxStockCapacity
            // 
            lblMaxStockCapacity.AutoSize = true;
            lblMaxStockCapacity.Location = new Point(1290, 805);
            lblMaxStockCapacity.Margin = new Padding(5, 0, 5, 0);
            lblMaxStockCapacity.Name = "lblMaxStockCapacity";
            lblMaxStockCapacity.Size = new Size(130, 32);
            lblMaxStockCapacity.TabIndex = 42;
            lblMaxStockCapacity.Text = "<number>";
            lblMaxStockCapacity.Visible = false;
            // 
            // lblNumberOfResults
            // 
            lblNumberOfResults.AutoSize = true;
            lblNumberOfResults.Location = new Point(60, 606);
            lblNumberOfResults.Margin = new Padding(5, 0, 5, 0);
            lblNumberOfResults.Name = "lblNumberOfResults";
            lblNumberOfResults.RightToLeft = RightToLeft.No;
            lblNumberOfResults.Size = new Size(130, 32);
            lblNumberOfResults.TabIndex = 43;
            lblNumberOfResults.Text = "<number>";
            // 
            // lblStockPercentage
            // 
            lblStockPercentage.AutoSize = true;
            lblStockPercentage.Location = new Point(1190, 947);
            lblStockPercentage.Margin = new Padding(5, 0, 5, 0);
            lblStockPercentage.Name = "lblStockPercentage";
            lblStockPercentage.Size = new Size(60, 32);
            lblStockPercentage.TabIndex = 44;
            lblStockPercentage.Text = "00%";
            lblStockPercentage.Visible = false;
            // 
            // tbxYear
            // 
            tbxYear.Location = new Point(135, 189);
            tbxYear.Margin = new Padding(5, 5, 5, 5);
            tbxYear.Name = "tbxYear";
            tbxYear.Size = new Size(724, 39);
            tbxYear.TabIndex = 46;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(2, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(89, 90);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 94;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // StockManagerForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1924, 1176);
            Controls.Add(pictureBox1);
            Controls.Add(tbxYear);
            Controls.Add(lblStockPercentage);
            Controls.Add(lblNumberOfResults);
            Controls.Add(lblMaxStockCapacity);
            Controls.Add(lblPrice);
            Controls.Add(lblYear);
            Controls.Add(lblCategory);
            Controls.Add(lblProductNumber);
            Controls.Add(lblSelectedProduct);
            Controls.Add(lblY);
            Controls.Add(cmbCategory);
            Controls.Add(nudMaxPrecent);
            Controls.Add(nudMinPrecent);
            Controls.Add(nudMaxPrice);
            Controls.Add(nudMinPrice);
            Controls.Add(lblProductDescription);
            Controls.Add(btnEditDetails);
            Controls.Add(pgbStock);
            Controls.Add(lblStck);
            Controls.Add(lblMaxS);
            Controls.Add(lblPr);
            Controls.Add(lblProductDescriptionLabel);
            Controls.Add(lblC);
            Controls.Add(lblP);
            Controls.Add(lblS);
            Controls.Add(lblNumRes);
            Controls.Add(btnCreateNewProduct);
            Controls.Add(lbxProducts);
            Controls.Add(btnFilter);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(tbxProductName);
            Controls.Add(label1);
            ForeColor = Color.Black;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(5, 5, 5, 5);
            MaximizeBox = false;
            MaximumSize = new Size(1950, 1247);
            MinimumSize = new Size(1950, 1247);
            Name = "StockManagerForm";
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Product Management";
            FormClosing += AnyForm_FormClosing;
            ((System.ComponentModel.ISupportInitialize)nudMinPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudMaxPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudMinPrecent).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudMaxPrecent).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox tbxProductName;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Button btnFilter;
        private ListBox lbxProducts;
        private Button btnCreateNewProduct;
        private Label lblNumRes;
        private Label lblS;
        private Label lblP;
        private Label lblC;
        private Label lblProductDescriptionLabel;
        private Label lblPr;
        private Label lblMaxS;
        private Label lblStck;
        private ProgressBar pgbStock;
        private Button btnEditDetails;
        private Label lblProductDescription;
        private NumericUpDown nudMinPrice;
        private NumericUpDown nudMaxPrice;
        private NumericUpDown nudMinPrecent;
        private NumericUpDown nudMaxPrecent;
        private ComboBox cmbCategory;
        private Label lblY;
        private Label lblSelectedProduct;
        private Label lblProductNumber;
        private Label lblCategory;
        private Label lblYear;
        private Label lblPrice;
        private Label lblMaxStockCapacity;
        private Label lblNumberOfResults;
        private Label lblStockPercentage;
		private TextBox tbxYear;
        private PictureBox pictureBox1;
    }
}