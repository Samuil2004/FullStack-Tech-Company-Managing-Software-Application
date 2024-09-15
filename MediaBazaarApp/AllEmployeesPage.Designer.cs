namespace MediaBazaarApp
{
    partial class AllEmployeesPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AllEmployeesPage));
            lbEmployeesList = new ListBox();
            labelSearch = new Label();
            tbSearchInput = new TextBox();
            tbSelectedUserInfo = new TextBox();
            btnAddNewEmployee = new Button();
            rbManagers = new RadioButton();
            rbEmployees = new RadioButton();
            btnRemoveEmployee = new Button();
            btnChangeWage = new Button();
            BackToMenu = new PictureBox();
            panel1 = new Panel();
            labelPageNum = new Label();
            btnPrevPage = new Button();
            btnNextPage = new Button();
            pbSearch = new PictureBox();
            WorkHoursGraph = new OxyPlot.WindowsForms.PlotView();
            ((System.ComponentModel.ISupportInitialize)BackToMenu).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbSearch).BeginInit();
            SuspendLayout();
            // 
            // lbEmployeesList
            // 
            lbEmployeesList.BackColor = Color.White;
            lbEmployeesList.FormattingEnabled = true;
            lbEmployeesList.Items.AddRange(new object[] { "" });
            lbEmployeesList.Location = new Point(73, 243);
            lbEmployeesList.Name = "lbEmployeesList";
            lbEmployeesList.Size = new Size(662, 580);
            lbEmployeesList.TabIndex = 0;
            lbEmployeesList.SelectedIndexChanged += lbEmployeesList_SelectedIndexChanged;
            // 
            // labelSearch
            // 
            labelSearch.AutoSize = true;
            labelSearch.Location = new Point(73, 134);
            labelSearch.Name = "labelSearch";
            labelSearch.Size = new Size(90, 32);
            labelSearch.TabIndex = 1;
            labelSearch.Text = "Search:";
            // 
            // tbSearchInput
            // 
            tbSearchInput.BackColor = Color.White;
            tbSearchInput.Location = new Point(197, 131);
            tbSearchInput.Name = "tbSearchInput";
            tbSearchInput.Size = new Size(311, 39);
            tbSearchInput.TabIndex = 2;
            // 
            // tbSelectedUserInfo
            // 
            tbSelectedUserInfo.BackColor = Color.White;
            tbSelectedUserInfo.ImeMode = ImeMode.NoControl;
            tbSelectedUserInfo.Location = new Point(804, 202);
            tbSelectedUserInfo.Multiline = true;
            tbSelectedUserInfo.Name = "tbSelectedUserInfo";
            tbSelectedUserInfo.ReadOnly = true;
            tbSelectedUserInfo.Size = new Size(404, 562);
            tbSelectedUserInfo.TabIndex = 17;
            tbSelectedUserInfo.Text = "Please, select a user";
            tbSelectedUserInfo.TextAlign = HorizontalAlignment.Center;
            // 
            // btnAddNewEmployee
            // 
            btnAddNewEmployee.BackColor = Color.FromArgb(147, 255, 144);
            btnAddNewEmployee.FlatStyle = FlatStyle.Flat;
            btnAddNewEmployee.ForeColor = Color.Black;
            btnAddNewEmployee.Location = new Point(931, 82);
            btnAddNewEmployee.Name = "btnAddNewEmployee";
            btnAddNewEmployee.Size = new Size(276, 64);
            btnAddNewEmployee.TabIndex = 18;
            btnAddNewEmployee.Text = "+ Add new Employee";
            btnAddNewEmployee.UseVisualStyleBackColor = false;
            btnAddNewEmployee.Click += btnAddNewEmployee_Click;
            // 
            // rbManagers
            // 
            rbManagers.AutoSize = true;
            rbManagers.Location = new Point(73, 202);
            rbManagers.Name = "rbManagers";
            rbManagers.Size = new Size(150, 36);
            rbManagers.TabIndex = 19;
            rbManagers.TabStop = true;
            rbManagers.Text = "Managers";
            rbManagers.UseVisualStyleBackColor = true;
            rbManagers.CheckedChanged += rbManagers_CheckedChanged;
            // 
            // rbEmployees
            // 
            rbEmployees.AutoSize = true;
            rbEmployees.Location = new Point(265, 202);
            rbEmployees.Name = "rbEmployees";
            rbEmployees.Size = new Size(116, 36);
            rbEmployees.TabIndex = 20;
            rbEmployees.TabStop = true;
            rbEmployees.Text = "Others";
            rbEmployees.UseVisualStyleBackColor = true;
            rbEmployees.CheckedChanged += rbEmployees_CheckedChanged;
            // 
            // btnRemoveEmployee
            // 
            btnRemoveEmployee.BackColor = Color.Black;
            btnRemoveEmployee.FlatStyle = FlatStyle.Flat;
            btnRemoveEmployee.ForeColor = Color.White;
            btnRemoveEmployee.Location = new Point(804, 794);
            btnRemoveEmployee.Name = "btnRemoveEmployee";
            btnRemoveEmployee.Size = new Size(180, 51);
            btnRemoveEmployee.TabIndex = 21;
            btnRemoveEmployee.Text = "Remove";
            btnRemoveEmployee.UseVisualStyleBackColor = false;
            btnRemoveEmployee.Click += btnRemoveEmployee_Click;
            // 
            // btnChangeWage
            // 
            btnChangeWage.BackColor = Color.Chocolate;
            btnChangeWage.ForeColor = Color.White;
            btnChangeWage.Location = new Point(804, 864);
            btnChangeWage.Name = "btnChangeWage";
            btnChangeWage.Size = new Size(180, 51);
            btnChangeWage.TabIndex = 24;
            btnChangeWage.Text = "Change Wage";
            btnChangeWage.UseVisualStyleBackColor = false;
            btnChangeWage.Click += button1_Click;
            // 
            // BackToMenu
            // 
            BackToMenu.BackColor = Color.Transparent;
            BackToMenu.Image = (Image)resources.GetObject("BackToMenu.Image");
            BackToMenu.Location = new Point(11, 13);
            BackToMenu.Name = "BackToMenu";
            BackToMenu.Size = new Size(101, 99);
            BackToMenu.SizeMode = PictureBoxSizeMode.StretchImage;
            BackToMenu.TabIndex = 90;
            BackToMenu.TabStop = false;
            BackToMenu.Click += BackToMenu_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(161, 7, 2);
            panel1.Location = new Point(-8, 339);
            panel1.Name = "panel1";
            panel1.Size = new Size(1974, 315);
            panel1.TabIndex = 91;
            // 
            // labelPageNum
            // 
            labelPageNum.AutoSize = true;
            labelPageNum.BackColor = Color.Transparent;
            labelPageNum.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelPageNum.ForeColor = Color.Black;
            labelPageNum.Location = new Point(592, 842);
            labelPageNum.Name = "labelPageNum";
            labelPageNum.Size = new Size(65, 37);
            labelPageNum.TabIndex = 94;
            labelPageNum.Text = "1/10";
            // 
            // btnPrevPage
            // 
            btnPrevPage.BackColor = Color.FromArgb(167, 204, 237);
            btnPrevPage.FlatStyle = FlatStyle.Flat;
            btnPrevPage.Font = new Font("Segoe UI Black", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPrevPage.Location = new Point(526, 829);
            btnPrevPage.Name = "btnPrevPage";
            btnPrevPage.Size = new Size(58, 61);
            btnPrevPage.TabIndex = 92;
            btnPrevPage.Text = "<";
            btnPrevPage.UseVisualStyleBackColor = false;
            btnPrevPage.Click += btnPrevPage_Click;
            // 
            // btnNextPage
            // 
            btnNextPage.BackColor = Color.FromArgb(167, 204, 237);
            btnNextPage.FlatStyle = FlatStyle.Flat;
            btnNextPage.Font = new Font("Segoe UI Black", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNextPage.Location = new Point(676, 829);
            btnNextPage.Name = "btnNextPage";
            btnNextPage.Size = new Size(58, 61);
            btnNextPage.TabIndex = 93;
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
            pbSearch.Location = new Point(526, 122);
            pbSearch.Margin = new Padding(3, 3, 3, 5);
            pbSearch.Name = "pbSearch";
            pbSearch.Size = new Size(50, 50);
            pbSearch.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSearch.TabIndex = 95;
            pbSearch.TabStop = false;
            pbSearch.Click += pbSearch_Click;
            // 
            // WorkHoursGraph
            // 
            WorkHoursGraph.Location = new Point(1253, 181);
            WorkHoursGraph.Margin = new Padding(5, 5, 5, 5);
            WorkHoursGraph.Name = "WorkHoursGraph";
            WorkHoursGraph.PanCursor = Cursors.Hand;
            WorkHoursGraph.Size = new Size(691, 586);
            WorkHoursGraph.TabIndex = 96;
            WorkHoursGraph.Text = "plotView1";
            WorkHoursGraph.ZoomHorizontalCursor = Cursors.SizeWE;
            WorkHoursGraph.ZoomRectangleCursor = Cursors.SizeNWSE;
            WorkHoursGraph.ZoomVerticalCursor = Cursors.SizeNS;
            // 
            // AllEmployeesPage
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1963, 955);
            Controls.Add(WorkHoursGraph);
            Controls.Add(pbSearch);
            Controls.Add(labelPageNum);
            Controls.Add(btnPrevPage);
            Controls.Add(btnNextPage);
            Controls.Add(BackToMenu);
            Controls.Add(btnChangeWage);
            Controls.Add(btnRemoveEmployee);
            Controls.Add(rbEmployees);
            Controls.Add(rbManagers);
            Controls.Add(btnAddNewEmployee);
            Controls.Add(tbSelectedUserInfo);
            Controls.Add(tbSearchInput);
            Controls.Add(labelSearch);
            Controls.Add(lbEmployeesList);
            Controls.Add(panel1);
            ForeColor = Color.Black;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(1989, 1026);
            MinimumSize = new Size(1989, 1026);
            Name = "AllEmployeesPage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "All Employes";
            FormClosing += AnyForm_FormClosing;
            ((System.ComponentModel.ISupportInitialize)BackToMenu).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbSearch).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lbEmployeesList;
        private Label labelSearch;
        private TextBox tbSearchInput;
        private TextBox tbSelectedUserInfo;
        private Button btnAddNewEmployee;
        private RadioButton rbManagers;
        private RadioButton rbEmployees;
        private Button btnRemoveEmployee;
        private Button btnChangeWage;
        private PictureBox BackToMenu;
        private Panel panel1;
        private Label labelPageNum;
        private Button btnPrevPage;
        private Button btnNextPage;
        private PictureBox pbSearch;
		private OxyPlot.WindowsForms.PlotView WorkHoursGraph;
	}
}