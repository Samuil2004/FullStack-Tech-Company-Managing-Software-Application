namespace MediaBazaarApp
{
    partial class UpdateSalary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateSalary));
            label1 = new Label();
            labelCurrentSalary = new Label();
            label3 = new Label();
            btnAddNewEmployee = new Button();
            nmNewWage = new NumericUpDown();
            button1 = new Button();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)nmNewWage).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(125, 150);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(205, 40);
            label1.TabIndex = 24;
            label1.Text = "Current Wage:";
            // 
            // labelCurrentSalary
            // 
            labelCurrentSalary.AutoSize = true;
            labelCurrentSalary.Font = new Font("Segoe UI Semibold", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelCurrentSalary.ForeColor = Color.Black;
            labelCurrentSalary.Location = new Point(394, 150);
            labelCurrentSalary.Margin = new Padding(4, 0, 4, 0);
            labelCurrentSalary.Name = "labelCurrentSalary";
            labelCurrentSalary.Size = new Size(116, 40);
            labelCurrentSalary.TabIndex = 25;
            labelCurrentSalary.Text = "X Euros";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(125, 241);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(165, 40);
            label3.TabIndex = 26;
            label3.Text = "New Wage:";
            // 
            // btnAddNewEmployee
            // 
            btnAddNewEmployee.BackColor = Color.FromArgb(147, 255, 144);
            btnAddNewEmployee.FlatStyle = FlatStyle.Flat;
            btnAddNewEmployee.ForeColor = Color.Black;
            btnAddNewEmployee.Location = new Point(442, 448);
            btnAddNewEmployee.Margin = new Padding(4, 3, 4, 3);
            btnAddNewEmployee.Name = "btnAddNewEmployee";
            btnAddNewEmployee.Size = new Size(242, 58);
            btnAddNewEmployee.TabIndex = 27;
            btnAddNewEmployee.Text = "Confirm";
            btnAddNewEmployee.UseVisualStyleBackColor = false;
            btnAddNewEmployee.Click += btnAddNewEmployee_Click;
            // 
            // nmNewWage
            // 
            nmNewWage.BackColor = Color.White;
            nmNewWage.ForeColor = Color.Black;
            nmNewWage.Location = new Point(382, 244);
            nmNewWage.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nmNewWage.Name = "nmNewWage";
            nmNewWage.Size = new Size(204, 39);
            nmNewWage.TabIndex = 28;
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.Location = new Point(42, 448);
            button1.Margin = new Padding(4);
            button1.Name = "button1";
            button1.Size = new Size(157, 58);
            button1.TabIndex = 93;
            button1.Text = "Cancel";
            button1.UseVisualStyleBackColor = false;
            button1.Click += pbPrevPage_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.DarkRed;
            button2.Location = new Point(-13, -23);
            button2.Margin = new Padding(4);
            button2.Name = "button2";
            button2.Size = new Size(783, 114);
            button2.TabIndex = 94;
            button2.UseVisualStyleBackColor = false;
            // 
            // UpdateSalary
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(722, 544);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(nmNewWage);
            Controls.Add(btnAddNewEmployee);
            Controls.Add(label3);
            Controls.Add(labelCurrentSalary);
            Controls.Add(label1);
            ForeColor = Color.Black;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(748, 615);
            MinimumSize = new Size(748, 615);
            Name = "UpdateSalary";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Update Salary";
            ((System.ComponentModel.ISupportInitialize)nmNewWage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label labelCurrentSalary;
        private Label label3;
        private Button btnAddNewEmployee;
        private NumericUpDown nmNewWage;
        private Button button1;
        private Button button2;
    }
}