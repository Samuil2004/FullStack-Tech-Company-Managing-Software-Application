namespace MediaBazaarApp
{
	partial class ForgottenPassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ForgottenPassword));
            tbxEmail = new TextBox();
            lblEmail = new Label();
            cmbSecretQuestion = new ComboBox();
            tbxSecretAnswer = new TextBox();
            btnSubmitSecret = new Button();
            label1 = new Label();
            label2 = new Label();
            pbPrevPage = new PictureBox();
            gbxSecretQuestion = new GroupBox();
            lblNewPassword = new Label();
            tbxNewPassword = new TextBox();
            btnSubmitPassword = new Button();
            ((System.ComponentModel.ISupportInitialize)pbPrevPage).BeginInit();
            gbxSecretQuestion.SuspendLayout();
            SuspendLayout();
            // 
            // tbxEmail
            // 
            tbxEmail.BackColor = Color.White;
            tbxEmail.Location = new Point(238, 23);
            tbxEmail.Margin = new Padding(5);
            tbxEmail.Name = "tbxEmail";
            tbxEmail.ReadOnly = true;
            tbxEmail.Size = new Size(542, 39);
            tbxEmail.TabIndex = 2;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(50, 26);
            lblEmail.Margin = new Padding(5, 0, 5, 0);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(171, 32);
            lblEmail.TabIndex = 1;
            lblEmail.Text = "Account email:";
            // 
            // cmbSecretQuestion
            // 
            cmbSecretQuestion.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSecretQuestion.FormattingEnabled = true;
            cmbSecretQuestion.Items.AddRange(new object[] { "What is the name of your first pet?", "What is the maiden name of your mother?", "Where did your parents first meet?" });
            cmbSecretQuestion.Location = new Point(238, 106);
            cmbSecretQuestion.Margin = new Padding(5);
            cmbSecretQuestion.Name = "cmbSecretQuestion";
            cmbSecretQuestion.Size = new Size(542, 40);
            cmbSecretQuestion.TabIndex = 0;
            // 
            // tbxSecretAnswer
            // 
            tbxSecretAnswer.Location = new Point(236, 202);
            tbxSecretAnswer.Margin = new Padding(5);
            tbxSecretAnswer.Name = "tbxSecretAnswer";
            tbxSecretAnswer.Size = new Size(542, 39);
            tbxSecretAnswer.TabIndex = 1;
            // 
            // btnSubmitSecret
            // 
            btnSubmitSecret.BackColor = Color.FromArgb(161, 7, 2);
            btnSubmitSecret.ForeColor = Color.White;
            btnSubmitSecret.Location = new Point(49, 267);
            btnSubmitSecret.Margin = new Padding(5);
            btnSubmitSecret.Name = "btnSubmitSecret";
            btnSubmitSecret.Size = new Size(730, 54);
            btnSubmitSecret.TabIndex = 2;
            btnSubmitSecret.Text = "Submit";
            btnSubmitSecret.UseVisualStyleBackColor = false;
            btnSubmitSecret.Click += btnSubmitSecret_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(50, 114);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(189, 32);
            label1.TabIndex = 3;
            label1.Text = "Secret Question:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(50, 202);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(96, 32);
            label2.TabIndex = 4;
            label2.Text = "Answer:";
            // 
            // pbPrevPage
            // 
            pbPrevPage.BackColor = Color.Transparent;
            pbPrevPage.ErrorImage = null;
            pbPrevPage.Image = Properties.Resources.arrow_55_75;
            pbPrevPage.Location = new Point(11, 11);
            pbPrevPage.Name = "pbPrevPage";
            pbPrevPage.Size = new Size(101, 99);
            pbPrevPage.SizeMode = PictureBoxSizeMode.StretchImage;
            pbPrevPage.TabIndex = 90;
            pbPrevPage.TabStop = false;
            pbPrevPage.Click += pbPrevPage_Click;
            // 
            // gbxSecretQuestion
            // 
            gbxSecretQuestion.BackColor = Color.Transparent;
            gbxSecretQuestion.Controls.Add(lblNewPassword);
            gbxSecretQuestion.Controls.Add(tbxNewPassword);
            gbxSecretQuestion.Controls.Add(btnSubmitPassword);
            gbxSecretQuestion.Controls.Add(cmbSecretQuestion);
            gbxSecretQuestion.Controls.Add(lblEmail);
            gbxSecretQuestion.Controls.Add(label2);
            gbxSecretQuestion.Controls.Add(tbxSecretAnswer);
            gbxSecretQuestion.Controls.Add(tbxEmail);
            gbxSecretQuestion.Controls.Add(btnSubmitSecret);
            gbxSecretQuestion.Controls.Add(label1);
            gbxSecretQuestion.Location = new Point(48, 118);
            gbxSecretQuestion.Margin = new Padding(5);
            gbxSecretQuestion.Name = "gbxSecretQuestion";
            gbxSecretQuestion.Padding = new Padding(5);
            gbxSecretQuestion.Size = new Size(790, 377);
            gbxSecretQuestion.TabIndex = 91;
            gbxSecretQuestion.TabStop = false;
            // 
            // lblNewPassword
            // 
            lblNewPassword.AutoSize = true;
            lblNewPassword.Location = new Point(50, 92);
            lblNewPassword.Margin = new Padding(5, 0, 5, 0);
            lblNewPassword.Name = "lblNewPassword";
            lblNewPassword.Size = new Size(173, 32);
            lblNewPassword.TabIndex = 92;
            lblNewPassword.Text = "New password:";
            lblNewPassword.Visible = false;
            // 
            // tbxNewPassword
            // 
            tbxNewPassword.Location = new Point(238, 89);
            tbxNewPassword.Margin = new Padding(5);
            tbxNewPassword.Name = "tbxNewPassword";
            tbxNewPassword.PasswordChar = '*';
            tbxNewPassword.Size = new Size(540, 39);
            tbxNewPassword.TabIndex = 93;
            tbxNewPassword.Visible = false;
            // 
            // btnSubmitPassword
            // 
            btnSubmitPassword.BackColor = Color.FromArgb(161, 7, 2);
            btnSubmitPassword.ForeColor = Color.White;
            btnSubmitPassword.Location = new Point(48, 239);
            btnSubmitPassword.Margin = new Padding(5);
            btnSubmitPassword.Name = "btnSubmitPassword";
            btnSubmitPassword.Size = new Size(730, 54);
            btnSubmitPassword.TabIndex = 94;
            btnSubmitPassword.Text = "Submit";
            btnSubmitPassword.UseVisualStyleBackColor = false;
            btnSubmitPassword.Visible = false;
            btnSubmitPassword.Click += btnSubmitPassword_Click;
            // 
            // ForgottenPassword
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gainsboro;
            ClientSize = new Size(874, 547);
            Controls.Add(gbxSecretQuestion);
            Controls.Add(pbPrevPage);
            ForeColor = Color.Black;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(5);
            MaximizeBox = false;
            MaximumSize = new Size(900, 618);
            MinimumSize = new Size(900, 618);
            Name = "ForgottenPassword";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Forgotten Password";
            FormClosing += AnyForm_FormClosing;
            ((System.ComponentModel.ISupportInitialize)pbPrevPage).EndInit();
            gbxSecretQuestion.ResumeLayout(false);
            gbxSecretQuestion.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label lblEmail;
        private TextBox tbxEmail;
		private ComboBox cmbSecretQuestion;
		private TextBox tbxSecretAnswer;
		private Button btnSubmitSecret;
		private Label label1;
		private Label label2;
        private PictureBox pbPrevPage;
        private GroupBox gbxSecretQuestion;
        private Label lblNewPassword;
        private TextBox tbxNewPassword;
        private Button btnSubmitPassword;
    }
}