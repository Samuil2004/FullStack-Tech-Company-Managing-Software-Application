namespace ClockingIn
{
	partial class ClockingIn
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
            components = new System.ComponentModel.Container();
            lblWelcomeMessage = new Label();
            tbxEmployeeID = new TextBox();
            timer = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // lblWelcomeMessage
            // 
            lblWelcomeMessage.AutoSize = true;
            lblWelcomeMessage.Font = new Font("Segoe UI", 12F);
            lblWelcomeMessage.Location = new Point(585, 488);
            lblWelcomeMessage.Margin = new Padding(5, 0, 5, 0);
            lblWelcomeMessage.Name = "lblWelcomeMessage";
            lblWelcomeMessage.Size = new Size(0, 45);
            lblWelcomeMessage.TabIndex = 3;
            lblWelcomeMessage.TextAlign = ContentAlignment.TopCenter;
            // 
            // tbxEmployeeID
            // 
            tbxEmployeeID.Location = new Point(692, 413);
            tbxEmployeeID.Margin = new Padding(5, 5, 5, 5);
            tbxEmployeeID.Name = "tbxEmployeeID";
            tbxEmployeeID.Size = new Size(339, 39);
            tbxEmployeeID.TabIndex = 2;
            //tbxEmployeeID.TextChanged += tbxEmployeeID_TextChanged;
            tbxEmployeeID.KeyDown += tbxEmployeeID_KeyDown;
            // 
            // timer
            // 
            timer.Tick += timer_Tick;
            // 
            // ClockingIn
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1726, 930);
            Controls.Add(lblWelcomeMessage);
            Controls.Add(tbxEmployeeID);
            Margin = new Padding(5, 5, 5, 5);
            Name = "ClockingIn";
            Text = "Clock in";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblWelcomeMessage;
		private TextBox tbxEmployeeID;
		private System.Windows.Forms.Timer timer;
	}
}