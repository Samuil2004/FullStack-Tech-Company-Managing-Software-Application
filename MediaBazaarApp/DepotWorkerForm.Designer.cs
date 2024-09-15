namespace MediaBazaarApp
{
    partial class DepotWorkerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DepotWorkerForm));
            lbxDepoProducts = new ListBox();
            pictureBox1 = new PictureBox();
            tbxProductName = new TextBox();
            nudStock = new NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            btnFilter = new Button();
            lblNumberOfResults = new Label();
            lblNumRes = new Label();
            RequestNewDepoStockButton = new Button();
            SelectedDepoProductLabel = new Label();
            StoreRestockinglistBox = new ListBox();
            label5 = new Label();
            ReplenishStoreStockButton = new Button();
            SelectedStoreProductLabel = new Label();
            ProductQuantityRequiredLabel = new Label();
            lblProductName = new Label();
            lblQuantity = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudStock).BeginInit();
            SuspendLayout();
            // 
            // lbxDepoProducts
            // 
            lbxDepoProducts.FormattingEnabled = true;
            lbxDepoProducts.Location = new Point(735, 240);
            lbxDepoProducts.Name = "lbxDepoProducts";
            lbxDepoProducts.Size = new Size(566, 344);
            lbxDepoProducts.TabIndex = 16;
            lbxDepoProducts.SelectedIndexChanged += lbxDepoProducts_SelectedIndexChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(11, 11);
            pictureBox1.Margin = new Padding(2, 2, 2, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(55, 56);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 95;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // tbxProductName
            // 
            tbxProductName.Location = new Point(845, 82);
            tbxProductName.Name = "tbxProductName";
            tbxProductName.Size = new Size(356, 27);
            tbxProductName.TabIndex = 96;
            // 
            // nudStock
            // 
            nudStock.Location = new Point(845, 126);
            nudStock.Name = "nudStock";
            nudStock.Size = new Size(97, 27);
            nudStock.TabIndex = 97;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(735, 85);
            label1.Name = "label1";
            label1.Size = new Size(104, 20);
            label1.TabIndex = 98;
            label1.Text = "Product name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(735, 128);
            label2.Name = "label2";
            label2.Size = new Size(93, 20);
            label2.TabIndex = 99;
            label2.Text = "Stock above:";
            // 
            // btnFilter
            // 
            btnFilter.BackColor = Color.FromArgb(161, 7, 2);
            btnFilter.ForeColor = Color.White;
            btnFilter.Location = new Point(781, 168);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(465, 31);
            btnFilter.TabIndex = 100;
            btnFilter.Text = "Filter";
            btnFilter.UseVisualStyleBackColor = false;
            btnFilter.Click += btnFilter_Click;
            // 
            // lblNumberOfResults
            // 
            lblNumberOfResults.AutoSize = true;
            lblNumberOfResults.Location = new Point(735, 211);
            lblNumberOfResults.Name = "lblNumberOfResults";
            lblNumberOfResults.RightToLeft = RightToLeft.No;
            lblNumberOfResults.Size = new Size(80, 20);
            lblNumberOfResults.TabIndex = 102;
            lblNumberOfResults.Text = "<number>";
            // 
            // lblNumRes
            // 
            lblNumRes.AutoSize = true;
            lblNumRes.Location = new Point(813, 211);
            lblNumRes.Name = "lblNumRes";
            lblNumRes.RightToLeft = RightToLeft.No;
            lblNumRes.Size = new Size(55, 20);
            lblNumRes.TabIndex = 101;
            lblNumRes.Text = " results";
            // 
            // RequestNewDepoStockButton
            // 
            RequestNewDepoStockButton.BackColor = Color.FromArgb(161, 7, 2);
            RequestNewDepoStockButton.ForeColor = Color.White;
            RequestNewDepoStockButton.Location = new Point(963, 638);
            RequestNewDepoStockButton.Margin = new Padding(2, 2, 2, 2);
            RequestNewDepoStockButton.Name = "RequestNewDepoStockButton";
            RequestNewDepoStockButton.Size = new Size(204, 47);
            RequestNewDepoStockButton.TabIndex = 103;
            RequestNewDepoStockButton.Text = "Request new stock";
            RequestNewDepoStockButton.UseVisualStyleBackColor = false;
            RequestNewDepoStockButton.Click += RequestNewDepoStockButton_Click;
            // 
            // SelectedDepoProductLabel
            // 
            SelectedDepoProductLabel.AutoSize = true;
            SelectedDepoProductLabel.Location = new Point(735, 602);
            SelectedDepoProductLabel.Margin = new Padding(2, 0, 2, 0);
            SelectedDepoProductLabel.Name = "SelectedDepoProductLabel";
            SelectedDepoProductLabel.Size = new Size(129, 20);
            SelectedDepoProductLabel.TabIndex = 104;
            SelectedDepoProductLabel.Text = "Selected product: ";
            // 
            // StoreRestockinglistBox
            // 
            StoreRestockinglistBox.FormattingEnabled = true;
            StoreRestockinglistBox.Items.AddRange(new object[] { "" });
            StoreRestockinglistBox.Location = new Point(175, 128);
            StoreRestockinglistBox.Margin = new Padding(2, 2, 2, 2);
            StoreRestockinglistBox.Name = "StoreRestockinglistBox";
            StoreRestockinglistBox.Size = new Size(447, 384);
            StoreRestockinglistBox.TabIndex = 107;
            StoreRestockinglistBox.SelectedIndexChanged += StoreRestockinglistBox_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(270, 85);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(253, 20);
            label5.TabIndex = 108;
            label5.Text = "Store product replenshment requests";
            // 
            // ReplenishStoreStockButton
            // 
            ReplenishStoreStockButton.BackColor = Color.FromArgb(161, 7, 2);
            ReplenishStoreStockButton.ForeColor = Color.White;
            ReplenishStoreStockButton.Location = new Point(235, 638);
            ReplenishStoreStockButton.Margin = new Padding(2, 2, 2, 2);
            ReplenishStoreStockButton.Name = "ReplenishStoreStockButton";
            ReplenishStoreStockButton.Size = new Size(302, 47);
            ReplenishStoreStockButton.TabIndex = 109;
            ReplenishStoreStockButton.Text = "Replenish store stock";
            ReplenishStoreStockButton.UseVisualStyleBackColor = false;
            ReplenishStoreStockButton.Click += ReplenishStoreStockButton_Click;
            // 
            // SelectedStoreProductLabel
            // 
            SelectedStoreProductLabel.AutoSize = true;
            SelectedStoreProductLabel.Location = new Point(282, 531);
            SelectedStoreProductLabel.Margin = new Padding(2, 0, 2, 0);
            SelectedStoreProductLabel.Name = "SelectedStoreProductLabel";
            SelectedStoreProductLabel.Size = new Size(129, 20);
            SelectedStoreProductLabel.TabIndex = 112;
            SelectedStoreProductLabel.Text = "Selected product: ";
            // 
            // ProductQuantityRequiredLabel
            // 
            ProductQuantityRequiredLabel.AutoSize = true;
            ProductQuantityRequiredLabel.Location = new Point(282, 573);
            ProductQuantityRequiredLabel.Margin = new Padding(2, 0, 2, 0);
            ProductQuantityRequiredLabel.Name = "ProductQuantityRequiredLabel";
            ProductQuantityRequiredLabel.Size = new Size(128, 20);
            ProductQuantityRequiredLabel.TabIndex = 113;
            ProductQuantityRequiredLabel.Text = "Quantity required:";
            // 
            // lblProductName
            // 
            lblProductName.AutoSize = true;
            lblProductName.Location = new Point(415, 531);
            lblProductName.Margin = new Padding(2, 0, 2, 0);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(81, 20);
            lblProductName.TabIndex = 114;
            lblProductName.Text = "<product>";
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Location = new Point(414, 573);
            lblQuantity.Margin = new Padding(2, 0, 2, 0);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(83, 20);
            lblQuantity.TabIndex = 115;
            lblQuantity.Text = "<quantity>";
            // 
            // DepotWorkerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1333, 769);
            Controls.Add(lblQuantity);
            Controls.Add(lblProductName);
            Controls.Add(ProductQuantityRequiredLabel);
            Controls.Add(SelectedStoreProductLabel);
            Controls.Add(ReplenishStoreStockButton);
            Controls.Add(label5);
            Controls.Add(StoreRestockinglistBox);
            Controls.Add(SelectedDepoProductLabel);
            Controls.Add(RequestNewDepoStockButton);
            Controls.Add(lblNumberOfResults);
            Controls.Add(lblNumRes);
            Controls.Add(btnFilter);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(nudStock);
            Controls.Add(tbxProductName);
            Controls.Add(pictureBox1);
            Controls.Add(lbxDepoProducts);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(1351, 816);
            MinimumSize = new Size(1187, 660);
            Name = "DepotWorkerForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Depo Worker Menu";
            Load += DepoWorkerForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudStock).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lbxDepoProducts;
        private PictureBox pictureBox1;
        private TextBox tbxProductName;
        private NumericUpDown nudStock;
        private Label label1;
        private Label label2;
        private Button btnFilter;
        private Label lblNumberOfResults;
        private Label lblNumRes;
        private Button RequestNewDepoStockButton;
        private Label SelectedDepoProductLabel;
        private ListBox StoreRestockinglistBox;
        private Label label5;
        private Button ReplenishStoreStockButton;
        private Label SelectedStoreProductLabel;
        private Label ProductQuantityRequiredLabel;
        private Label lblProductName;
        private Label lblQuantity;
    }
}