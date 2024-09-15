namespace WorkTasks_Individual_Kristof_Szabo
{
    partial class loginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(loginForm));
            panelDesignLeft = new Panel();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            labelWelcomeText = new Label();
            label1 = new Label();
            panel1 = new Panel();
            icon = new FontAwesome.Sharp.IconPictureBox();
            labelHint = new Label();
            buttonForgetPassword = new FontAwesome.Sharp.IconButton();
            buttonLogin = new FontAwesome.Sharp.IconButton();
            panel3 = new Panel();
            pictureBox2 = new PictureBox();
            textBoxPassword = new TextBox();
            iconPictureBox3 = new FontAwesome.Sharp.IconPictureBox();
            panel2 = new Panel();
            textBoxUsername = new TextBox();
            iconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
            timer1 = new System.Windows.Forms.Timer(components);
            panelDesignLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)icon).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox3).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox2).BeginInit();
            SuspendLayout();
            // 
            // panelDesignLeft
            // 
            panelDesignLeft.BackColor = Color.FromArgb(161, 7, 2);
            panelDesignLeft.Controls.Add(pictureBox1);
            panelDesignLeft.Controls.Add(label2);
            panelDesignLeft.Controls.Add(labelWelcomeText);
            panelDesignLeft.Dock = DockStyle.Left;
            panelDesignLeft.Location = new Point(0, 0);
            panelDesignLeft.MaximumSize = new Size(634, 765);
            panelDesignLeft.Name = "panelDesignLeft";
            panelDesignLeft.Size = new Size(634, 765);
            panelDesignLeft.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = MediaBazaarApp.Properties.Resources.LOGO;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(148, 192);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(364, 234);
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 14F);
            label2.ForeColor = SystemColors.Window;
            label2.Location = new Point(148, 490);
            label2.Name = "label2";
            label2.Size = new Size(341, 44);
            label2.TabIndex = 2;
            label2.Text = "Media Bazaar App!";
            // 
            // labelWelcomeText
            // 
            labelWelcomeText.AutoSize = true;
            labelWelcomeText.Font = new Font("Microsoft Sans Serif", 14F);
            labelWelcomeText.ForeColor = SystemColors.Window;
            labelWelcomeText.Location = new Point(148, 445);
            labelWelcomeText.Name = "labelWelcomeText";
            labelWelcomeText.Size = new Size(284, 44);
            labelWelcomeText.TabIndex = 0;
            labelWelcomeText.Text = "Welcome to the";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F);
            label1.ForeColor = Color.FromArgb(161, 7, 2);
            label1.Location = new Point(55, 166);
            label1.Name = "label1";
            label1.Size = new Size(325, 37);
            label1.TabIndex = 1;
            label1.Text = "Login to your account";
            // 
            // panel1
            // 
            panel1.BackColor = Color.WhiteSmoke;
            panel1.Controls.Add(icon);
            panel1.Controls.Add(labelHint);
            panel1.Controls.Add(buttonForgetPassword);
            panel1.Controls.Add(buttonLogin);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(634, 0);
            panel1.MaximumSize = new Size(554, 765);
            panel1.MinimumSize = new Size(554, 765);
            panel1.Name = "panel1";
            panel1.Size = new Size(554, 765);
            panel1.TabIndex = 1;
            // 
            // icon
            // 
            icon.BackColor = Color.WhiteSmoke;
            icon.ForeColor = Color.FromArgb(161, 7, 2);
            icon.IconChar = FontAwesome.Sharp.IconChar.X;
            icon.IconColor = Color.FromArgb(161, 7, 2);
            icon.IconFont = FontAwesome.Sharp.IconFont.Auto;
            icon.IconSize = 48;
            icon.Location = new Point(505, 0);
            icon.Margin = new Padding(5);
            icon.Name = "icon";
            icon.Size = new Size(49, 48);
            icon.TabIndex = 8;
            icon.TabStop = false;
            icon.Click += icon_Click;
            // 
            // labelHint
            // 
            labelHint.AutoSize = true;
            labelHint.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Italic);
            labelHint.Location = new Point(94, 555);
            labelHint.Name = "labelHint";
            labelHint.Size = new Size(0, 29);
            labelHint.TabIndex = 7;
            // 
            // buttonForgetPassword
            // 
            buttonForgetPassword.BackColor = Color.WhiteSmoke;
            buttonForgetPassword.FlatAppearance.BorderSize = 0;
            buttonForgetPassword.FlatStyle = FlatStyle.Flat;
            buttonForgetPassword.Font = new Font("Microsoft Sans Serif", 9F);
            buttonForgetPassword.ForeColor = Color.FromArgb(161, 7, 2);
            buttonForgetPassword.IconChar = FontAwesome.Sharp.IconChar.None;
            buttonForgetPassword.IconColor = Color.Black;
            buttonForgetPassword.IconFont = FontAwesome.Sharp.IconFont.Auto;
            buttonForgetPassword.Location = new Point(318, 456);
            buttonForgetPassword.Name = "buttonForgetPassword";
            buttonForgetPassword.Size = new Size(218, 93);
            buttonForgetPassword.TabIndex = 6;
            buttonForgetPassword.Text = "Forget Password?";
            buttonForgetPassword.UseVisualStyleBackColor = false;
            buttonForgetPassword.Click += buttonForgetPassword_Click;
            // 
            // buttonLogin
            // 
            buttonLogin.BackColor = Color.FromArgb(161, 7, 2);
            buttonLogin.FlatAppearance.BorderSize = 0;
            buttonLogin.FlatStyle = FlatStyle.Flat;
            buttonLogin.Font = new Font("Microsoft Sans Serif", 12F);
            buttonLogin.ForeColor = Color.White;
            buttonLogin.IconChar = FontAwesome.Sharp.IconChar.None;
            buttonLogin.IconColor = Color.Black;
            buttonLogin.IconFont = FontAwesome.Sharp.IconFont.Auto;
            buttonLogin.Location = new Point(55, 456);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new Size(252, 93);
            buttonLogin.TabIndex = 5;
            buttonLogin.Text = "Login";
            buttonLogin.UseVisualStyleBackColor = false;
            buttonLogin.Click += buttonLogin_Click;
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(pictureBox2);
            panel3.Controls.Add(textBoxPassword);
            panel3.Controls.Add(iconPictureBox3);
            panel3.Location = new Point(2, 363);
            panel3.Name = "panel3";
            panel3.Size = new Size(556, 61);
            panel3.TabIndex = 4;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(484, 3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(49, 50);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 8;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Font = new Font("Microsoft Sans Serif", 11F);
            textBoxPassword.Location = new Point(68, 6);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.PasswordChar = '*';
            textBoxPassword.Size = new Size(464, 41);
            textBoxPassword.TabIndex = 2;
            // 
            // iconPictureBox3
            // 
            iconPictureBox3.BackColor = Color.White;
            iconPictureBox3.ForeColor = Color.FromArgb(161, 7, 2);
            iconPictureBox3.IconChar = FontAwesome.Sharp.IconChar.Key;
            iconPictureBox3.IconColor = Color.FromArgb(161, 7, 2);
            iconPictureBox3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox3.IconSize = 52;
            iconPictureBox3.Location = new Point(8, 6);
            iconPictureBox3.Name = "iconPictureBox3";
            iconPictureBox3.Size = new Size(52, 54);
            iconPictureBox3.TabIndex = 1;
            iconPictureBox3.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(textBoxUsername);
            panel2.Controls.Add(iconPictureBox2);
            panel2.Location = new Point(3, 286);
            panel2.Name = "panel2";
            panel2.Size = new Size(556, 61);
            panel2.TabIndex = 3;
            // 
            // textBoxUsername
            // 
            textBoxUsername.Font = new Font("Microsoft Sans Serif", 11F);
            textBoxUsername.Location = new Point(62, 6);
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.Size = new Size(464, 41);
            textBoxUsername.TabIndex = 1;
            // 
            // iconPictureBox2
            // 
            iconPictureBox2.BackColor = Color.White;
            iconPictureBox2.ForeColor = Color.FromArgb(161, 7, 2);
            iconPictureBox2.IconChar = FontAwesome.Sharp.IconChar.UserLarge;
            iconPictureBox2.IconColor = Color.FromArgb(161, 7, 2);
            iconPictureBox2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox2.IconSize = 52;
            iconPictureBox2.Location = new Point(3, 6);
            iconPictureBox2.Name = "iconPictureBox2";
            iconPictureBox2.Size = new Size(52, 54);
            iconPictureBox2.TabIndex = 0;
            iconPictureBox2.TabStop = false;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // loginForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1193, 765);
            Controls.Add(panel1);
            Controls.Add(panelDesignLeft);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(1193, 765);
            MinimizeBox = false;
            MinimumSize = new Size(1193, 765);
            Name = "loginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Log In";
            FormClosing += AnyForm_FormClosing;
            Load += loginForm_Load;
            panelDesignLeft.ResumeLayout(false);
            panelDesignLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)icon).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox3).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelDesignLeft;
        private Label labelWelcomeText;
        private Label label2;
        private Label label1;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private TextBox textBoxPassword;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox3;
        private TextBox textBoxUsername;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox2;
        private FontAwesome.Sharp.IconButton buttonLogin;
        private FontAwesome.Sharp.IconButton buttonForgetPassword;
        private Label labelHint;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private System.Windows.Forms.Timer timer1;
        private FontAwesome.Sharp.IconPictureBox icon;
    }
}