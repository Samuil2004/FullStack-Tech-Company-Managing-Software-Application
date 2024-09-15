namespace MediaBazaarApp
{
    partial class Alert
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Alert));
            btnCancle = new Button();
            btnAgree = new Button();
            labelMessage = new Label();
            SuspendLayout();
            // 
            // btnCancle
            // 
            btnCancle.BackColor = Color.FromArgb(255, 128, 128);
            btnCancle.DialogResult = DialogResult.Cancel;
            btnCancle.FlatStyle = FlatStyle.Flat;
            btnCancle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancle.Location = new Point(394, 329);
            btnCancle.Name = "btnCancle";
            btnCancle.Size = new Size(184, 63);
            btnCancle.TabIndex = 8;
            btnCancle.Text = "Cancel";
            btnCancle.UseVisualStyleBackColor = false;
            // 
            // btnAgree
            // 
            btnAgree.BackColor = Color.FromArgb(4, 232, 36);
            btnAgree.DialogResult = DialogResult.Yes;
            btnAgree.FlatStyle = FlatStyle.Flat;
            btnAgree.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAgree.Location = new Point(182, 329);
            btnAgree.Name = "btnAgree";
            btnAgree.Size = new Size(184, 63);
            btnAgree.TabIndex = 7;
            btnAgree.Text = "Yes";
            btnAgree.UseVisualStyleBackColor = false;
            btnAgree.Click += btnAgree_Click;
            // 
            // labelMessage
            // 
            labelMessage.AutoSize = true;
            labelMessage.BackColor = Color.Transparent;
            labelMessage.ForeColor = Color.Black;
            labelMessage.Location = new Point(146, 148);
            labelMessage.Name = "labelMessage";
            labelMessage.Size = new Size(115, 96);
            labelMessage.TabIndex = 6;
            labelMessage.Text = "Message \r\n\r\nHere";
            // 
            // Alert
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCancle);
            Controls.Add(btnAgree);
            Controls.Add(labelMessage);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(826, 521);
            MinimizeBox = false;
            MinimumSize = new Size(826, 521);
            Name = "Alert";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Alert";
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancle;
        private Button btnAgree;
        private Label labelMessage;
    }
}