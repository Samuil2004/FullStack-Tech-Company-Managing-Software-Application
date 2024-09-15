namespace MediaBazaarApp
{
    partial class AddNewEmployeePage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddNewEmployeePage));
            labelEmail = new Label();
            labelFirstName = new Label();
            labelLastName = new Label();
            cbGender = new ComboBox();
            labelDepartment = new Label();
            labelRole = new Label();
            labelGender = new Label();
            tbEmail = new TextBox();
            tbFirstName = new TextBox();
            tbLastName = new TextBox();
            cbDepartment = new ComboBox();
            cbRole = new ComboBox();
            btnAddEmployee = new Button();
            labelPhoneNumber = new Label();
            tbPhoneNumber = new TextBox();
            label1 = new Label();
            nmWage = new NumericUpDown();
            pbPrevPage = new PictureBox();
            nmFloor = new NumericUpDown();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)nmWage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbPrevPage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nmFloor).BeginInit();
            SuspendLayout();
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold);
            labelEmail.ForeColor = Color.Black;
            labelEmail.Location = new Point(98, 157);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(90, 37);
            labelEmail.TabIndex = 18;
            labelEmail.Text = "Email:";
            // 
            // labelFirstName
            // 
            labelFirstName.AutoSize = true;
            labelFirstName.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold);
            labelFirstName.ForeColor = Color.Black;
            labelFirstName.Location = new Point(98, 221);
            labelFirstName.Name = "labelFirstName";
            labelFirstName.Size = new Size(157, 37);
            labelFirstName.TabIndex = 19;
            labelFirstName.Text = "First Name:";
            // 
            // labelLastName
            // 
            labelLastName.AutoSize = true;
            labelLastName.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold);
            labelLastName.ForeColor = Color.Black;
            labelLastName.Location = new Point(98, 282);
            labelLastName.Name = "labelLastName";
            labelLastName.Size = new Size(153, 37);
            labelLastName.TabIndex = 20;
            labelLastName.Text = "Last Name:";
            // 
            // cbGender
            // 
            cbGender.BackColor = Color.FromArgb(217, 217, 217);
            cbGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cbGender.FormattingEnabled = true;
            cbGender.Location = new Point(335, 390);
            cbGender.Name = "cbGender";
            cbGender.Size = new Size(241, 40);
            cbGender.TabIndex = 21;
            // 
            // labelDepartment
            // 
            labelDepartment.AutoSize = true;
            labelDepartment.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold);
            labelDepartment.ForeColor = Color.Black;
            labelDepartment.Location = new Point(98, 469);
            labelDepartment.Name = "labelDepartment";
            labelDepartment.Size = new Size(172, 37);
            labelDepartment.TabIndex = 22;
            labelDepartment.Text = "Department:";
            // 
            // labelRole
            // 
            labelRole.AutoSize = true;
            labelRole.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold);
            labelRole.ForeColor = Color.Black;
            labelRole.Location = new Point(98, 541);
            labelRole.Name = "labelRole";
            labelRole.Size = new Size(77, 37);
            labelRole.TabIndex = 23;
            labelRole.Text = "Role:";
            // 
            // labelGender
            // 
            labelGender.AutoSize = true;
            labelGender.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold);
            labelGender.ForeColor = Color.Black;
            labelGender.Location = new Point(98, 400);
            labelGender.Name = "labelGender";
            labelGender.Size = new Size(114, 37);
            labelGender.TabIndex = 24;
            labelGender.Text = "Gender:";
            // 
            // tbEmail
            // 
            tbEmail.BackColor = Color.White;
            tbEmail.BorderStyle = BorderStyle.FixedSingle;
            tbEmail.Location = new Point(335, 149);
            tbEmail.Name = "tbEmail";
            tbEmail.Size = new Size(325, 39);
            tbEmail.TabIndex = 25;
            tbEmail.TextChanged += tbEmail_TextChanged;
            // 
            // tbFirstName
            // 
            tbFirstName.BackColor = Color.White;
            tbFirstName.BorderStyle = BorderStyle.FixedSingle;
            tbFirstName.Location = new Point(335, 211);
            tbFirstName.Name = "tbFirstName";
            tbFirstName.Size = new Size(325, 39);
            tbFirstName.TabIndex = 26;
            tbFirstName.TextChanged += tbFirstName_TextChanged;
            // 
            // tbLastName
            // 
            tbLastName.BackColor = Color.White;
            tbLastName.BorderStyle = BorderStyle.FixedSingle;
            tbLastName.Location = new Point(335, 275);
            tbLastName.Name = "tbLastName";
            tbLastName.Size = new Size(325, 39);
            tbLastName.TabIndex = 27;
            tbLastName.TextChanged += tbLastName_TextChanged;
            // 
            // cbDepartment
            // 
            cbDepartment.BackColor = Color.FromArgb(217, 217, 217);
            cbDepartment.DropDownStyle = ComboBoxStyle.DropDownList;
            cbDepartment.FormattingEnabled = true;
            cbDepartment.Location = new Point(335, 461);
            cbDepartment.Name = "cbDepartment";
            cbDepartment.Size = new Size(241, 40);
            cbDepartment.TabIndex = 28;
            cbDepartment.SelectedIndexChanged += cbDepartment_SelectedIndexChanged;
            // 
            // cbRole
            // 
            cbRole.BackColor = Color.FromArgb(217, 217, 217);
            cbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cbRole.FormattingEnabled = true;
            cbRole.Location = new Point(335, 534);
            cbRole.Name = "cbRole";
            cbRole.Size = new Size(241, 40);
            cbRole.TabIndex = 29;
            // 
            // btnAddEmployee
            // 
            btnAddEmployee.BackColor = Color.FromArgb(147, 255, 144);
            btnAddEmployee.ForeColor = SystemColors.Desktop;
            btnAddEmployee.Location = new Point(335, 736);
            btnAddEmployee.Name = "btnAddEmployee";
            btnAddEmployee.Size = new Size(240, 48);
            btnAddEmployee.TabIndex = 30;
            btnAddEmployee.Text = "Add Employee";
            btnAddEmployee.UseVisualStyleBackColor = false;
            btnAddEmployee.Click += btnAddEmployee_Click;
            // 
            // labelPhoneNumber
            // 
            labelPhoneNumber.AutoSize = true;
            labelPhoneNumber.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold);
            labelPhoneNumber.ForeColor = Color.Black;
            labelPhoneNumber.Location = new Point(98, 339);
            labelPhoneNumber.Name = "labelPhoneNumber";
            labelPhoneNumber.Size = new Size(211, 37);
            labelPhoneNumber.TabIndex = 31;
            labelPhoneNumber.Text = "Phone Number:";
            // 
            // tbPhoneNumber
            // 
            tbPhoneNumber.BackColor = Color.White;
            tbPhoneNumber.BorderStyle = BorderStyle.FixedSingle;
            tbPhoneNumber.Location = new Point(335, 336);
            tbPhoneNumber.MaxLength = 16;
            tbPhoneNumber.Name = "tbPhoneNumber";
            tbPhoneNumber.Size = new Size(325, 39);
            tbPhoneNumber.TabIndex = 32;
            tbPhoneNumber.TextChanged += tbPhoneNumber_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(98, 678);
            label1.Name = "label1";
            label1.Size = new Size(133, 37);
            label1.TabIndex = 33;
            label1.Text = "Wage (€):";
            // 
            // nmWage
            // 
            nmWage.BackColor = Color.White;
            nmWage.Location = new Point(335, 672);
            nmWage.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            nmWage.Name = "nmWage";
            nmWage.Size = new Size(242, 39);
            nmWage.TabIndex = 86;
            // 
            // pbPrevPage
            // 
            pbPrevPage.Image = (Image)resources.GetObject("pbPrevPage.Image");
            pbPrevPage.Location = new Point(11, 11);
            pbPrevPage.Name = "pbPrevPage";
            pbPrevPage.Size = new Size(101, 99);
            pbPrevPage.SizeMode = PictureBoxSizeMode.StretchImage;
            pbPrevPage.TabIndex = 87;
            pbPrevPage.TabStop = false;
            pbPrevPage.Click += pbPrevPage_Click;
            // 
            // nmFloor
            // 
            nmFloor.BackColor = Color.White;
            nmFloor.Location = new Point(333, 600);
            nmFloor.Maximum = new decimal(new int[] { 3, 0, 0, 0 });
            nmFloor.Name = "nmFloor";
            nmFloor.Size = new Size(242, 39);
            nmFloor.TabIndex = 89;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(96, 606);
            label2.Name = "label2";
            label2.Size = new Size(88, 37);
            label2.TabIndex = 88;
            label2.Text = "Floor:";
            // 
            // AddNewEmployeePage
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(232, 235, 238);
            ClientSize = new Size(718, 818);
            Controls.Add(nmFloor);
            Controls.Add(label2);
            Controls.Add(pbPrevPage);
            Controls.Add(nmWage);
            Controls.Add(label1);
            Controls.Add(tbPhoneNumber);
            Controls.Add(labelPhoneNumber);
            Controls.Add(btnAddEmployee);
            Controls.Add(cbRole);
            Controls.Add(cbDepartment);
            Controls.Add(tbLastName);
            Controls.Add(tbFirstName);
            Controls.Add(tbEmail);
            Controls.Add(labelGender);
            Controls.Add(labelRole);
            Controls.Add(labelDepartment);
            Controls.Add(cbGender);
            Controls.Add(labelLastName);
            Controls.Add(labelFirstName);
            Controls.Add(labelEmail);
            ForeColor = Color.WhiteSmoke;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(744, 889);
            MinimumSize = new Size(744, 889);
            Name = "AddNewEmployeePage";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Add Employee";
            FormClosing += AnyForm_FormClosing;
            ((System.ComponentModel.ISupportInitialize)nmWage).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbPrevPage).EndInit();
            ((System.ComponentModel.ISupportInitialize)nmFloor).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label labelEmail;
        private Label labelFirstName;
        private Label labelLastName;
        private ComboBox cbGender;
        private Label labelDepartment;
        private Label labelRole;
        private Label labelGender;
        private TextBox tbEmail;
        private TextBox tbFirstName;
        private TextBox tbLastName;
        private ComboBox cbDepartment;
        private ComboBox cbRole;
        private Button btnAddEmployee;
        private Label labelPhoneNumber;
        private TextBox tbPhoneNumber;
        private Label label1;
        private NumericUpDown nmWage;
        private PictureBox pbPrevPage;
		private NumericUpDown nmFloor;
		private Label label2;
	}
}