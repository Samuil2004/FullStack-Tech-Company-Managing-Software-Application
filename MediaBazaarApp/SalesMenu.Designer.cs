namespace MediaBazaarApp
{
    partial class SalesMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalesMenu));
            tbxYear = new TextBox();
            cmbCategory = new ComboBox();
            nudMaxPrice = new NumericUpDown();
            nudMinPrice = new NumericUpDown();
            btnFilter = new Button();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            tbxProductName = new TextBox();
            label1 = new Label();
            lbxProducts = new ListBox();
            panelProduct = new Panel();
            lblSelectedProduct = new Label();
            btnChangePrice = new Button();
            lblPrice = new Label();
            lblProductNumber = new Label();
            lblCategory = new Label();
            lblYear = new Label();
            lblPr = new Label();
            label7 = new Label();
            label6 = new Label();
            lblP = new Label();
            lblS = new Label();
            lblNumberOfResults = new Label();
            lblNumRes = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)nudMaxPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudMinPrice).BeginInit();
            panelProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // tbxYear
            // 
            tbxYear.Location = new Point(908, 235);
            tbxYear.Margin = new Padding(5);
            tbxYear.Name = "tbxYear";
            tbxYear.Size = new Size(542, 39);
            tbxYear.TabIndex = 109;
            // 
            // cmbCategory
            // 
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Items.AddRange(new object[] { "" });
            cmbCategory.Location = new Point(960, 179);
            cmbCategory.Margin = new Padding(5);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(490, 40);
            cmbCategory.TabIndex = 108;
            // 
            // nudMaxPrice
            // 
            nudMaxPrice.Location = new Point(1025, 342);
            nudMaxPrice.Margin = new Padding(5);
            nudMaxPrice.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
            nudMaxPrice.Name = "nudMaxPrice";
            nudMaxPrice.Size = new Size(427, 39);
            nudMaxPrice.TabIndex = 105;
            nudMaxPrice.Value = new decimal(new int[] { 99999, 0, 0, 0 });
            // 
            // nudMinPrice
            // 
            nudMinPrice.Location = new Point(1025, 290);
            nudMinPrice.Margin = new Padding(5);
            nudMinPrice.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
            nudMinPrice.Name = "nudMinPrice";
            nudMinPrice.Size = new Size(427, 39);
            nudMinPrice.TabIndex = 104;
            // 
            // btnFilter
            // 
            btnFilter.BackColor = Color.FromArgb(161, 7, 2);
            btnFilter.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnFilter.ForeColor = Color.White;
            btnFilter.Location = new Point(834, 398);
            btnFilter.Margin = new Padding(5);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(619, 51);
            btnFilter.TabIndex = 103;
            btnFilter.Text = "Filter";
            btnFilter.UseVisualStyleBackColor = false;
            btnFilter.Click += btnFilter_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(834, 342);
            label5.Margin = new Padding(5, 0, 5, 0);
            label5.Name = "label5";
            label5.Size = new Size(185, 32);
            label5.TabIndex = 100;
            label5.Text = "Maximum price:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(834, 290);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(182, 32);
            label4.TabIndex = 99;
            label4.Text = "Minimum price:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(834, 235);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(63, 32);
            label3.TabIndex = 98;
            label3.Text = "Year:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(834, 182);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(115, 32);
            label2.TabIndex = 97;
            label2.Text = "Category:";
            // 
            // tbxProductName
            // 
            tbxProductName.Location = new Point(1012, 125);
            tbxProductName.Margin = new Padding(5);
            tbxProductName.Name = "tbxProductName";
            tbxProductName.Size = new Size(438, 39);
            tbxProductName.TabIndex = 96;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(834, 131);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(168, 32);
            label1.TabIndex = 95;
            label1.Text = "Product name:";
            // 
            // lbxProducts
            // 
            lbxProducts.FormattingEnabled = true;
            lbxProducts.Location = new Point(89, 213);
            lbxProducts.Margin = new Padding(5);
            lbxProducts.Name = "lbxProducts";
            lbxProducts.Size = new Size(656, 836);
            lbxProducts.TabIndex = 111;
            lbxProducts.SelectedIndexChanged += lbxProducts_SelectedIndexChanged;
            // 
            // panelProduct
            // 
            panelProduct.BackColor = Color.White;
            panelProduct.Controls.Add(lblSelectedProduct);
            panelProduct.Controls.Add(btnChangePrice);
            panelProduct.Controls.Add(lblPrice);
            panelProduct.Controls.Add(lblProductNumber);
            panelProduct.Controls.Add(lblCategory);
            panelProduct.Controls.Add(lblYear);
            panelProduct.Controls.Add(lblPr);
            panelProduct.Controls.Add(label7);
            panelProduct.Controls.Add(label6);
            panelProduct.Controls.Add(lblP);
            panelProduct.Controls.Add(lblS);
            panelProduct.Location = new Point(834, 510);
            panelProduct.Margin = new Padding(5);
            panelProduct.Name = "panelProduct";
            panelProduct.Size = new Size(621, 526);
            panelProduct.TabIndex = 112;
            panelProduct.Visible = false;
            // 
            // lblSelectedProduct
            // 
            lblSelectedProduct.AutoSize = true;
            lblSelectedProduct.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSelectedProduct.Location = new Point(270, 18);
            lblSelectedProduct.Margin = new Padding(5, 0, 5, 0);
            lblSelectedProduct.Name = "lblSelectedProduct";
            lblSelectedProduct.Size = new Size(155, 38);
            lblSelectedProduct.TabIndex = 114;
            lblSelectedProduct.Text = "<product>";
            // 
            // btnChangePrice
            // 
            btnChangePrice.BackColor = Color.FromArgb(161, 7, 2);
            btnChangePrice.ForeColor = Color.White;
            btnChangePrice.Location = new Point(5, 445);
            btnChangePrice.Margin = new Padding(5);
            btnChangePrice.Name = "btnChangePrice";
            btnChangePrice.Size = new Size(609, 77);
            btnChangePrice.TabIndex = 113;
            btnChangePrice.Text = "Change price";
            btnChangePrice.UseVisualStyleBackColor = false;
            btnChangePrice.Click += btnChangePrice_Click;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPrice.Location = new Point(86, 274);
            lblPrice.Margin = new Padding(5, 0, 5, 0);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(101, 32);
            lblPrice.TabIndex = 27;
            lblPrice.Text = "<price>";
            // 
            // lblProductNumber
            // 
            lblProductNumber.AutoSize = true;
            lblProductNumber.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblProductNumber.Location = new Point(206, 94);
            lblProductNumber.Margin = new Padding(5, 0, 5, 0);
            lblProductNumber.Name = "lblProductNumber";
            lblProductNumber.Size = new Size(133, 32);
            lblProductNumber.TabIndex = 26;
            lblProductNumber.Text = "<number>";
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCategory.Location = new Point(132, 150);
            lblCategory.Margin = new Padding(5, 0, 5, 0);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(144, 32);
            lblCategory.TabIndex = 25;
            lblCategory.Text = "<category>";
            // 
            // lblYear
            // 
            lblYear.AutoSize = true;
            lblYear.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblYear.Location = new Point(80, 211);
            lblYear.Margin = new Padding(5, 0, 5, 0);
            lblYear.Name = "lblYear";
            lblYear.Size = new Size(95, 32);
            lblYear.TabIndex = 24;
            lblYear.Text = "<year>";
            // 
            // lblPr
            // 
            lblPr.AutoSize = true;
            lblPr.Location = new Point(5, 274);
            lblPr.Margin = new Padding(5, 0, 5, 0);
            lblPr.Name = "lblPr";
            lblPr.Size = new Size(70, 32);
            lblPr.TabIndex = 23;
            lblPr.Text = "Price:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(5, 211);
            label7.Margin = new Padding(5, 0, 5, 0);
            label7.Name = "label7";
            label7.Size = new Size(63, 32);
            label7.TabIndex = 22;
            label7.Text = "Year:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(5, 150);
            label6.Margin = new Padding(5, 0, 5, 0);
            label6.Name = "label6";
            label6.Size = new Size(115, 32);
            label6.TabIndex = 21;
            label6.Text = "Category:";
            // 
            // lblP
            // 
            lblP.AutoSize = true;
            lblP.Location = new Point(5, 94);
            lblP.Margin = new Padding(5, 0, 5, 0);
            lblP.Name = "lblP";
            lblP.Size = new Size(192, 32);
            lblP.TabIndex = 20;
            lblP.Text = "Product number:";
            // 
            // lblS
            // 
            lblS.AutoSize = true;
            lblS.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblS.Location = new Point(5, 18);
            lblS.Margin = new Padding(5, 0, 5, 0);
            lblS.Name = "lblS";
            lblS.Size = new Size(249, 37);
            lblS.TabIndex = 19;
            lblS.Text = "Selected product: ";
            // 
            // lblNumberOfResults
            // 
            lblNumberOfResults.AutoSize = true;
            lblNumberOfResults.Location = new Point(89, 165);
            lblNumberOfResults.Margin = new Padding(5, 0, 5, 0);
            lblNumberOfResults.Name = "lblNumberOfResults";
            lblNumberOfResults.RightToLeft = RightToLeft.No;
            lblNumberOfResults.Size = new Size(130, 32);
            lblNumberOfResults.TabIndex = 114;
            lblNumberOfResults.Text = "<number>";
            // 
            // lblNumRes
            // 
            lblNumRes.AutoSize = true;
            lblNumRes.Location = new Point(172, 165);
            lblNumRes.Margin = new Padding(5, 0, 5, 0);
            lblNumRes.Name = "lblNumRes";
            lblNumRes.RightToLeft = RightToLeft.No;
            lblNumRes.Size = new Size(90, 32);
            lblNumRes.TabIndex = 113;
            lblNumRes.Text = " results";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, -3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(89, 90);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 115;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click_1;
            // 
            // SalesMenu
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1581, 1125);
            Controls.Add(pictureBox1);
            Controls.Add(lblNumRes);
            Controls.Add(lblNumberOfResults);
            Controls.Add(panelProduct);
            Controls.Add(lbxProducts);
            Controls.Add(tbxYear);
            Controls.Add(cmbCategory);
            Controls.Add(nudMaxPrice);
            Controls.Add(nudMinPrice);
            Controls.Add(btnFilter);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(tbxProductName);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(1607, 1196);
            MinimumSize = new Size(1607, 1196);
            Name = "SalesMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sales Menu";
            Load += SalesMenu_Load;
            ((System.ComponentModel.ISupportInitialize)nudMaxPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudMinPrice).EndInit();
            panelProduct.ResumeLayout(false);
            panelProduct.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox tbxYear;
        private ComboBox cmbCategory;
        private NumericUpDown nudMaxPrice;
        private NumericUpDown nudMinPrice;
        private Button btnFilter;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox tbxProductName;
        private Label label1;
        private ListBox lbxProducts;
        private Panel panelProduct;
        private Label lblS;
        private Label lblP;
        private Label label7;
        private Label label6;
        private Label lblYear;
        private Label lblPr;
        private Label lblProductNumber;
        private Label lblCategory;
        private Label lblPrice;
        private Button btnChangePrice;
        private Label lblSelectedProduct;
        private Label lblNumberOfResults;
        private Label lblNumRes;
        private PictureBox pictureBox1;
    }
}