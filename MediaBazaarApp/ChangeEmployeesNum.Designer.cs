namespace MediaBazaarApp
{
    partial class ChangeEmployeesNum
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeEmployeesNum));
            btnCancle = new Button();
            btnAgree = new Button();
            labelMessage = new Label();
            cbRoles = new ComboBox();
            calendar = new MonthCalendar();
            nmNumOfEmployees = new NumericUpDown();
            labelRole = new Label();
            labelEmployees = new Label();
            labelShift = new Label();
            cbShift = new ComboBox();
            btnSaveChanges = new Button();
            ((System.ComponentModel.ISupportInitialize)nmNumOfEmployees).BeginInit();
            SuspendLayout();
            // 
            // btnCancle
            // 
            btnCancle.BackColor = Color.FromArgb(255, 128, 128);
            btnCancle.DialogResult = DialogResult.Cancel;
            btnCancle.FlatStyle = FlatStyle.Flat;
            btnCancle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancle.Location = new Point(960, 12);
            btnCancle.Name = "btnCancle";
            btnCancle.Size = new Size(184, 63);
            btnCancle.TabIndex = 11;
            btnCancle.Text = "Cancel";
            btnCancle.UseVisualStyleBackColor = false;
            btnCancle.Click += btnCancle_Click;
            // 
            // btnAgree
            // 
            btnAgree.BackColor = Color.FromArgb(4, 232, 36);
            btnAgree.DialogResult = DialogResult.Yes;
            btnAgree.FlatStyle = FlatStyle.Flat;
            btnAgree.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAgree.Location = new Point(960, 375);
            btnAgree.Name = "btnAgree";
            btnAgree.Size = new Size(184, 63);
            btnAgree.TabIndex = 10;
            btnAgree.Text = "Yes";
            btnAgree.UseVisualStyleBackColor = false;
            btnAgree.Click += btnAgree_Click;
            // 
            // labelMessage
            // 
            labelMessage.AutoSize = true;
            labelMessage.BackColor = Color.Transparent;
            labelMessage.ForeColor = Color.Black;
            labelMessage.Location = new Point(12, 88);
            labelMessage.Name = "labelMessage";
            labelMessage.Size = new Size(940, 32);
            labelMessage.TabIndex = 9;
            labelMessage.Text = "Would you like to cahnge the pre-set number of employees needed per shift per role?";
            // 
            // cbRoles
            // 
            cbRoles.DropDownStyle = ComboBoxStyle.DropDownList;
            cbRoles.FormattingEnabled = true;
            cbRoles.Location = new Point(601, 129);
            cbRoles.Name = "cbRoles";
            cbRoles.Size = new Size(351, 40);
            cbRoles.TabIndex = 12;
            cbRoles.SelectedIndexChanged += cbRoles_SelectedIndexChanged;
            // 
            // calendar
            // 
            calendar.Location = new Point(12, 129);
            calendar.Name = "calendar";
            calendar.TabIndex = 13;
            calendar.DateChanged += calendar_DateChanged;
            // 
            // nmNumOfEmployees
            // 
            nmNumOfEmployees.Location = new Point(601, 252);
            nmNumOfEmployees.Name = "nmNumOfEmployees";
            nmNumOfEmployees.Size = new Size(351, 39);
            nmNumOfEmployees.TabIndex = 14;
            // 
            // labelRole
            // 
            labelRole.AutoSize = true;
            labelRole.Location = new Point(428, 132);
            labelRole.Name = "labelRole";
            labelRole.Size = new Size(65, 32);
            labelRole.TabIndex = 15;
            labelRole.Text = "Role:";
            // 
            // labelEmployees
            // 
            labelEmployees.AutoSize = true;
            labelEmployees.Location = new Point(428, 259);
            labelEmployees.Name = "labelEmployees";
            labelEmployees.Size = new Size(134, 32);
            labelEmployees.TabIndex = 16;
            labelEmployees.Text = "Employees:";
            // 
            // labelShift
            // 
            labelShift.AutoSize = true;
            labelShift.Location = new Point(428, 194);
            labelShift.Name = "labelShift";
            labelShift.Size = new Size(68, 32);
            labelShift.TabIndex = 17;
            labelShift.Text = "Shift:";
            // 
            // cbShift
            // 
            cbShift.DropDownStyle = ComboBoxStyle.DropDownList;
            cbShift.FormattingEnabled = true;
            cbShift.Items.AddRange(new object[] { "FirstShift", "SecondShift", "ThirdShift" });
            cbShift.Location = new Point(601, 191);
            cbShift.Name = "cbShift";
            cbShift.Size = new Size(351, 40);
            cbShift.TabIndex = 18;
            // 
            // btnSaveChanges
            // 
            btnSaveChanges.BackColor = Color.FromArgb(128, 255, 255);
            btnSaveChanges.FlatStyle = FlatStyle.Flat;
            btnSaveChanges.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSaveChanges.Location = new Point(960, 230);
            btnSaveChanges.Name = "btnSaveChanges";
            btnSaveChanges.Size = new Size(114, 61);
            btnSaveChanges.TabIndex = 19;
            btnSaveChanges.Text = "Save";
            btnSaveChanges.UseVisualStyleBackColor = false;
            btnSaveChanges.Click += btnSaveChanges_Click;
            // 
            // ChangeEmployeesNum
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1156, 450);
            Controls.Add(btnSaveChanges);
            Controls.Add(cbShift);
            Controls.Add(labelShift);
            Controls.Add(labelEmployees);
            Controls.Add(labelRole);
            Controls.Add(nmNumOfEmployees);
            Controls.Add(calendar);
            Controls.Add(cbRoles);
            Controls.Add(btnCancle);
            Controls.Add(btnAgree);
            Controls.Add(labelMessage);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(1182, 521);
            MinimumSize = new Size(1182, 521);
            Name = "ChangeEmployeesNum";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Apply Changes";
            ((System.ComponentModel.ISupportInitialize)nmNumOfEmployees).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancle;
        private Button btnAgree;
        private Label labelMessage;
        private ComboBox cbRoles;
        private MonthCalendar calendar;
        private NumericUpDown nmNumOfEmployees;
        private Label labelRole;
        private Label labelEmployees;
        private Label labelShift;
        private ComboBox cbShift;
        private Button btnSaveChanges;
    }
}