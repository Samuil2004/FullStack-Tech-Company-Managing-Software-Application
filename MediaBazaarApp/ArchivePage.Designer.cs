namespace MediaBazaarApp
{
    partial class ArchivePage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArchivePage));
            labelSearch = new Label();
            tbSearchInput = new TextBox();
            tbSelectedUserInfo = new TextBox();
            btnRestoreEmployee = new Button();
            pictureBox1 = new PictureBox();
            labelPageNum = new Label();
            btnPrevPage = new Button();
            btnNextPage = new Button();
            pbSearch = new PictureBox();
            lbEmployeesList = new ListBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbSearch).BeginInit();
            SuspendLayout();
            // 
            // labelSearch
            // 
            labelSearch.AutoSize = true;
            labelSearch.BackColor = Color.Transparent;
            labelSearch.Location = new Point(72, 116);
            labelSearch.Margin = new Padding(4, 0, 4, 0);
            labelSearch.Name = "labelSearch";
            labelSearch.Size = new Size(90, 32);
            labelSearch.TabIndex = 1;
            labelSearch.Text = "Search:";
            // 
            // tbSearchInput
            // 
            tbSearchInput.BackColor = Color.White;
            tbSearchInput.Location = new Point(198, 111);
            tbSearchInput.Margin = new Padding(4, 3, 4, 3);
            tbSearchInput.Name = "tbSearchInput";
            tbSearchInput.Size = new Size(476, 39);
            tbSearchInput.TabIndex = 2;
            // 
            // tbSelectedUserInfo
            // 
            tbSelectedUserInfo.BackColor = Color.White;
            tbSelectedUserInfo.Location = new Point(803, 173);
            tbSelectedUserInfo.Margin = new Padding(4, 3, 4, 3);
            tbSelectedUserInfo.Multiline = true;
            tbSelectedUserInfo.Name = "tbSelectedUserInfo";
            tbSelectedUserInfo.ReadOnly = true;
            tbSelectedUserInfo.Size = new Size(403, 561);
            tbSelectedUserInfo.TabIndex = 17;
            tbSelectedUserInfo.Text = "Please, select a user";
            tbSelectedUserInfo.TextAlign = HorizontalAlignment.Center;
            // 
            // btnRestoreEmployee
            // 
            btnRestoreEmployee.BackColor = Color.FromArgb(147, 255, 144);
            btnRestoreEmployee.FlatStyle = FlatStyle.Flat;
            btnRestoreEmployee.ForeColor = Color.Black;
            btnRestoreEmployee.Location = new Point(803, 759);
            btnRestoreEmployee.Margin = new Padding(4, 3, 4, 3);
            btnRestoreEmployee.Name = "btnRestoreEmployee";
            btnRestoreEmployee.Size = new Size(150, 47);
            btnRestoreEmployee.TabIndex = 21;
            btnRestoreEmployee.Text = "Rehire";
            btnRestoreEmployee.UseVisualStyleBackColor = false;
            btnRestoreEmployee.Click += btnRestoreEmployee_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 100);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 92;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // labelPageNum
            // 
            labelPageNum.AutoSize = true;
            labelPageNum.BackColor = Color.Transparent;
            labelPageNum.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelPageNum.ForeColor = Color.Black;
            labelPageNum.Location = new Point(591, 867);
            labelPageNum.Name = "labelPageNum";
            labelPageNum.Size = new Size(65, 37);
            labelPageNum.TabIndex = 97;
            labelPageNum.Text = "1/10";
            // 
            // btnPrevPage
            // 
            btnPrevPage.BackColor = Color.FromArgb(167, 204, 237);
            btnPrevPage.FlatStyle = FlatStyle.Flat;
            btnPrevPage.Font = new Font("Segoe UI Black", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPrevPage.Location = new Point(526, 855);
            btnPrevPage.Name = "btnPrevPage";
            btnPrevPage.Size = new Size(59, 61);
            btnPrevPage.TabIndex = 95;
            btnPrevPage.Text = "<";
            btnPrevPage.UseVisualStyleBackColor = false;
            btnPrevPage.Click += btnPrevPage_Click;
            // 
            // btnNextPage
            // 
            btnNextPage.BackColor = Color.FromArgb(167, 204, 237);
            btnNextPage.FlatStyle = FlatStyle.Flat;
            btnNextPage.Font = new Font("Segoe UI Black", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNextPage.Location = new Point(676, 855);
            btnNextPage.Name = "btnNextPage";
            btnNextPage.Size = new Size(59, 61);
            btnNextPage.TabIndex = 96;
            btnNextPage.Text = ">";
            btnNextPage.UseVisualStyleBackColor = false;
            btnNextPage.Click += btnNextPage_Click;
            // 
            // pbSearch
            // 
            pbSearch.BackColor = Color.Transparent;
            pbSearch.ErrorImage = (Image)resources.GetObject("pbSearch.ErrorImage");
            pbSearch.Image = (Image)resources.GetObject("pbSearch.Image");
            pbSearch.InitialImage = (Image)resources.GetObject("pbSearch.InitialImage");
            pbSearch.Location = new Point(682, 100);
            pbSearch.Margin = new Padding(4, 4, 4, 5);
            pbSearch.Name = "pbSearch";
            pbSearch.Size = new Size(50, 50);
            pbSearch.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSearch.TabIndex = 98;
            pbSearch.TabStop = false;
            pbSearch.Click += pbSearch_Click;
            // 
            // lbEmployeesList
            // 
            lbEmployeesList.BackColor = Color.White;
            lbEmployeesList.FormattingEnabled = true;
            lbEmployeesList.Items.AddRange(new object[] { "" });
            lbEmployeesList.Location = new Point(73, 173);
            lbEmployeesList.Margin = new Padding(4, 3, 4, 3);
            lbEmployeesList.Name = "lbEmployeesList";
            lbEmployeesList.Size = new Size(662, 644);
            lbEmployeesList.TabIndex = 99;
            lbEmployeesList.SelectedIndexChanged += lbEmployeesList_SelectedIndexChanged_1;
            // 
            // ArchivePage
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1264, 988);
            Controls.Add(lbEmployeesList);
            Controls.Add(pbSearch);
            Controls.Add(labelPageNum);
            Controls.Add(btnPrevPage);
            Controls.Add(btnNextPage);
            Controls.Add(pictureBox1);
            Controls.Add(btnRestoreEmployee);
            Controls.Add(tbSelectedUserInfo);
            Controls.Add(tbSearchInput);
            Controls.Add(labelSearch);
            ForeColor = Color.Black;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MaximumSize = new Size(1290, 1059);
            MinimumSize = new Size(1290, 1059);
            Name = "ArchivePage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Archive";
            FormClosing += AnyForm_FormClosing;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbSearch).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label labelSearch;
        private TextBox tbSearchInput;
        private TextBox tbSelectedUserInfo;
        private Button btnRestoreEmployee;
        private PictureBox pictureBox1;
        private Label labelPageNum;
        private Button btnPrevPage;
        private Button btnNextPage;
        private PictureBox pbSearch;
        private ListBox lbEmployeesList;
    }
}