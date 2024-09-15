namespace MediaBazaarApp
{
    partial class AddOrEditProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddOrEditProduct));
            label3 = new Label();
            label2 = new Label();
            tbxProductName = new TextBox();
            label1 = new Label();
            label4 = new Label();
            tbxDescription = new TextBox();
            btnSubmit = new Button();
            nudYear = new NumericUpDown();
            cmbCategory = new ComboBox();
            pbPrevPage = new PictureBox();
            tbxBarcode = new TextBox();
            label5 = new Label();
            nudMaxCapacity = new NumericUpDown();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)nudYear).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbPrevPage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudMaxCapacity).BeginInit();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(21, 261);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(63, 32);
            label3.TabIndex = 12;
            label3.Text = "Year:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 211);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(115, 32);
            label2.TabIndex = 10;
            label2.Text = "Category:";
            // 
            // tbxProductName
            // 
            tbxProductName.Location = new Point(198, 149);
            tbxProductName.Margin = new Padding(5, 5, 5, 5);
            tbxProductName.Name = "tbxProductName";
            tbxProductName.Size = new Size(620, 39);
            tbxProductName.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 157);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(168, 32);
            label1.TabIndex = 8;
            label1.Text = "Product name:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(20, 411);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(140, 32);
            label4.TabIndex = 14;
            label4.Text = "Description:";
            // 
            // tbxDescription
            // 
            tbxDescription.Location = new Point(172, 411);
            tbxDescription.Margin = new Padding(5, 5, 5, 5);
            tbxDescription.MaxLength = 1000;
            tbxDescription.Multiline = true;
            tbxDescription.Name = "tbxDescription";
            tbxDescription.Size = new Size(646, 364);
            tbxDescription.TabIndex = 15;
            // 
            // btnSubmit
            // 
            btnSubmit.BackColor = Color.FromArgb(161, 7, 2);
            btnSubmit.ForeColor = Color.White;
            btnSubmit.Location = new Point(146, 787);
            btnSubmit.Margin = new Padding(5, 5, 5, 5);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(517, 46);
            btnSubmit.TabIndex = 17;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = false;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // nudYear
            // 
            nudYear.Location = new Point(94, 253);
            nudYear.Margin = new Padding(5, 5, 5, 5);
            nudYear.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            nudYear.Name = "nudYear";
            nudYear.Size = new Size(726, 39);
            nudYear.TabIndex = 18;
            // 
            // cmbCategory
            // 
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(146, 202);
            cmbCategory.Margin = new Padding(5, 5, 5, 5);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(672, 40);
            cmbCategory.TabIndex = 19;
            // 
            // pbPrevPage
            // 
            pbPrevPage.Image = Properties.Resources.arrow_55_75;
            pbPrevPage.Location = new Point(3, 3);
            pbPrevPage.Name = "pbPrevPage";
            pbPrevPage.Size = new Size(101, 99);
            pbPrevPage.SizeMode = PictureBoxSizeMode.StretchImage;
            pbPrevPage.TabIndex = 88;
            pbPrevPage.TabStop = false;
            pbPrevPage.Click += pbPrevPage_Click;
            // 
            // tbxBarcode
            // 
            tbxBarcode.Location = new Point(138, 306);
            tbxBarcode.Margin = new Padding(5, 5, 5, 5);
            tbxBarcode.Name = "tbxBarcode";
            tbxBarcode.Size = new Size(680, 39);
            tbxBarcode.TabIndex = 90;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(20, 314);
            label5.Margin = new Padding(5, 0, 5, 0);
            label5.Name = "label5";
            label5.Size = new Size(105, 32);
            label5.TabIndex = 89;
            label5.Text = "Barcode:";
            // 
            // nudMaxCapacity
            // 
            nudMaxCapacity.Location = new Point(192, 358);
            nudMaxCapacity.Margin = new Padding(5, 5, 5, 5);
            nudMaxCapacity.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            nudMaxCapacity.Name = "nudMaxCapacity";
            nudMaxCapacity.Size = new Size(629, 39);
            nudMaxCapacity.TabIndex = 92;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(21, 366);
            label6.Margin = new Padding(5, 0, 5, 0);
            label6.Name = "label6";
            label6.Size = new Size(157, 32);
            label6.TabIndex = 91;
            label6.Text = "Max capacity:";
            // 
            // AddOrEditProduct
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(232, 235, 238);
            ClientSize = new Size(863, 870);
            Controls.Add(nudMaxCapacity);
            Controls.Add(label6);
            Controls.Add(tbxBarcode);
            Controls.Add(label5);
            Controls.Add(pbPrevPage);
            Controls.Add(cmbCategory);
            Controls.Add(nudYear);
            Controls.Add(btnSubmit);
            Controls.Add(tbxDescription);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(tbxProductName);
            Controls.Add(label1);
            ForeColor = SystemColors.ControlText;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(5, 5, 5, 5);
            MaximizeBox = false;
            MaximumSize = new Size(889, 941);
            MinimumSize = new Size(889, 941);
            Name = "AddOrEditProduct";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Add Product";
            ((System.ComponentModel.ISupportInitialize)nudYear).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbPrevPage).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudMaxCapacity).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label3;
        private Label label2;
        private TextBox tbxProductName;
        private Label label1;
        private Label label4;
        private TextBox tbxDescription;
        private Button btnSubmit;
        private NumericUpDown nudYear;
        private ComboBox cmbCategory;
        private PictureBox pbPrevPage;
		private TextBox tbxBarcode;
		private Label label5;
		private NumericUpDown nudMaxCapacity;
		private Label label6;
	}
}