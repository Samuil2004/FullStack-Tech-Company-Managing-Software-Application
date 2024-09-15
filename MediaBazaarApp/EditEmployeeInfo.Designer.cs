namespace MediaBazaarApp
{
	partial class EditEmployeeInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditEmployeeInfo));
            label2 = new Label();
            label3 = new Label();
            tbxPhoneNumber = new TextBox();
            tbxPassword = new TextBox();
            btnSubmit = new Button();
            tbxNewPassword = new TextBox();
            label1 = new Label();
            cbxChangePassword = new CheckBox();
            label4 = new Label();
            label5 = new Label();
            tbxSecretAnswer = new TextBox();
            cmbSecretQuestion = new ComboBox();
            cbxSecretQuestion = new CheckBox();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(36, 136);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(178, 32);
            label2.TabIndex = 2;
            label2.Text = "Phone number:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(36, 216);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(163, 32);
            label3.TabIndex = 3;
            label3.Text = "Old password:";
            // 
            // tbxPhoneNumber
            // 
            tbxPhoneNumber.Location = new Point(222, 133);
            tbxPhoneNumber.Margin = new Padding(5);
            tbxPhoneNumber.Name = "tbxPhoneNumber";
            tbxPhoneNumber.Size = new Size(371, 39);
            tbxPhoneNumber.TabIndex = 5;
            tbxPhoneNumber.TextChanged += tbxPhoneNumber_TextChanged;
            // 
            // tbxPassword
            // 
            tbxPassword.Location = new Point(222, 210);
            tbxPassword.Margin = new Padding(5);
            tbxPassword.Name = "tbxPassword";
            tbxPassword.Size = new Size(371, 39);
            tbxPassword.TabIndex = 6;
            tbxPassword.UseSystemPasswordChar = true;
            // 
            // btnSubmit
            // 
            btnSubmit.BackColor = Color.FromArgb(161, 7, 2);
            btnSubmit.ForeColor = Color.White;
            btnSubmit.Location = new Point(101, 698);
            btnSubmit.Margin = new Padding(5);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(602, 55);
            btnSubmit.TabIndex = 7;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = false;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // tbxNewPassword
            // 
            tbxNewPassword.Enabled = false;
            tbxNewPassword.Location = new Point(222, 366);
            tbxNewPassword.Margin = new Padding(5);
            tbxNewPassword.Name = "tbxNewPassword";
            tbxNewPassword.Size = new Size(371, 39);
            tbxNewPassword.TabIndex = 19;
            tbxNewPassword.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(36, 366);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(173, 32);
            label1.TabIndex = 18;
            label1.Text = "New password:";
            // 
            // cbxChangePassword
            // 
            cbxChangePassword.AutoSize = true;
            cbxChangePassword.Location = new Point(222, 298);
            cbxChangePassword.Margin = new Padding(5);
            cbxChangePassword.Name = "cbxChangePassword";
            cbxChangePassword.Size = new Size(245, 36);
            cbxChangePassword.TabIndex = 20;
            cbxChangePassword.Text = "Change password?";
            cbxChangePassword.UseVisualStyleBackColor = true;
            cbxChangePassword.CheckedChanged += cbxChangePassword_CheckedChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(36, 515);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(185, 32);
            label4.TabIndex = 21;
            label4.Text = "Secret question:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(36, 589);
            label5.Margin = new Padding(5, 0, 5, 0);
            label5.Name = "label5";
            label5.Size = new Size(166, 32);
            label5.TabIndex = 22;
            label5.Text = "Secret answer:";
            // 
            // tbxSecretAnswer
            // 
            tbxSecretAnswer.Enabled = false;
            tbxSecretAnswer.Location = new Point(222, 586);
            tbxSecretAnswer.Margin = new Padding(5);
            tbxSecretAnswer.Name = "tbxSecretAnswer";
            tbxSecretAnswer.Size = new Size(371, 39);
            tbxSecretAnswer.TabIndex = 23;
            // 
            // cmbSecretQuestion
            // 
            cmbSecretQuestion.Enabled = false;
            cmbSecretQuestion.FormattingEnabled = true;
            cmbSecretQuestion.Items.AddRange(new object[] { "What is the name of your first pet?", "What is the maiden name of your mother?", "Where did your parents first meet?" });
            cmbSecretQuestion.Location = new Point(222, 515);
            cmbSecretQuestion.Margin = new Padding(5);
            cmbSecretQuestion.Name = "cmbSecretQuestion";
            cmbSecretQuestion.Size = new Size(538, 40);
            cmbSecretQuestion.TabIndex = 24;
            // 
            // cbxSecretQuestion
            // 
            cbxSecretQuestion.AutoSize = true;
            cbxSecretQuestion.Location = new Point(222, 445);
            cbxSecretQuestion.Margin = new Padding(5);
            cbxSecretQuestion.Name = "cbxSecretQuestion";
            cbxSecretQuestion.Size = new Size(261, 36);
            cbxSecretQuestion.TabIndex = 25;
            cbxSecretQuestion.Text = "Set secret question?";
            cbxSecretQuestion.UseVisualStyleBackColor = true;
            cbxSecretQuestion.CheckedChanged += cbxSecretQuestion_CheckedChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 100);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 93;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // EditEmployeeInfo
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(772, 769);
            Controls.Add(pictureBox1);
            Controls.Add(cbxSecretQuestion);
            Controls.Add(cmbSecretQuestion);
            Controls.Add(tbxSecretAnswer);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(cbxChangePassword);
            Controls.Add(tbxNewPassword);
            Controls.Add(label1);
            Controls.Add(btnSubmit);
            Controls.Add(tbxPassword);
            Controls.Add(tbxPhoneNumber);
            Controls.Add(label3);
            Controls.Add(label2);
            ForeColor = Color.Black;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(5);
            MaximizeBox = false;
            MaximumSize = new Size(798, 840);
            MinimumSize = new Size(798, 840);
            Name = "EditEmployeeInfo";
            SizeGripStyle = SizeGripStyle.Show;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Edit Account";
            FormClosing += AnyForm_FormClosing;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
		private Label label3;
		private TextBox tbxPhoneNumber;
		private TextBox tbxPassword;
		private Button btnSubmit;
		private TextBox tbxNewPassword;
		private Label label1;
		private CheckBox cbxChangePassword;
		private Label label4;
		private Label label5;
		private TextBox tbxSecretAnswer;
		private ComboBox cmbSecretQuestion;
		private CheckBox cbxSecretQuestion;
        private PictureBox pictureBox1;
    }
}