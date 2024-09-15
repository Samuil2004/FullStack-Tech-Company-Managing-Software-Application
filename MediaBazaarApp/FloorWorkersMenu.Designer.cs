namespace MediaBazaarApp
{
    partial class FloorWorkersMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FloorWorkersMenu));
            pictureBox1 = new PictureBox();
            btnManageDepo = new Button();
            pbDepo = new PictureBox();
            ManageStoreButton = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbDepo).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-2, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(171, 170);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 11;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // btnManageDepo
            // 
            btnManageDepo.BackColor = Color.FromArgb(161, 7, 2);
            btnManageDepo.Font = new Font("Microsoft Sans Serif", 14F);
            btnManageDepo.ForeColor = Color.White;
            btnManageDepo.Location = new Point(654, 486);
            btnManageDepo.Name = "btnManageDepo";
            btnManageDepo.Size = new Size(349, 349);
            btnManageDepo.TabIndex = 12;
            btnManageDepo.Text = "Manage depo";
            btnManageDepo.UseVisualStyleBackColor = false;
            btnManageDepo.Visible = false;
            btnManageDepo.Click += btnManageDepo_Click;
            // 
            // pbDepo
            // 
            pbDepo.Image = (Image)resources.GetObject("pbDepo.Image");
            pbDepo.Location = new Point(757, 329);
            pbDepo.Name = "pbDepo";
            pbDepo.Size = new Size(150, 150);
            pbDepo.SizeMode = PictureBoxSizeMode.StretchImage;
            pbDepo.TabIndex = 13;
            pbDepo.TabStop = false;
            pbDepo.Visible = false;
            // 
            // ManageStoreButton
            // 
            ManageStoreButton.BackColor = Color.FromArgb(161, 7, 2);
            ManageStoreButton.Font = new Font("Microsoft Sans Serif", 14F);
            ManageStoreButton.ForeColor = Color.White;
            ManageStoreButton.Location = new Point(654, 486);
            ManageStoreButton.Name = "ManageStoreButton";
            ManageStoreButton.Size = new Size(349, 349);
            ManageStoreButton.TabIndex = 14;
            ManageStoreButton.Text = "Manage store";
            ManageStoreButton.UseVisualStyleBackColor = false;
            ManageStoreButton.Visible = false;
            ManageStoreButton.Click += ManageStoreButton_Click;
            // 
            // FloorWorkersMenu
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1683, 931);
            Controls.Add(ManageStoreButton);
            Controls.Add(pbDepo);
            Controls.Add(btnManageDepo);
            Controls.Add(pictureBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(5);
            MaximizeBox = false;
            MaximumSize = new Size(1709, 1002);
            MinimumSize = new Size(1709, 1002);
            Name = "FloorWorkersMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Floor Worker Menu";
            Load += FloorWorkersMenu_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbDepo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Button btnManageDepo;
        private PictureBox pbDepo;
        private Button ManageStoreButton;
    }
}