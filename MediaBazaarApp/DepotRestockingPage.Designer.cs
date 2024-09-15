namespace MediaBazaarApp
{
    partial class DepotRestockingPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DepotRestockingPage));
            label5 = new Label();
            BackToMenu = new PictureBox();
            lbxCart = new ListBox();
            panel1 = new Panel();
            label7 = new Label();
            label6 = new Label();
            btnCheckOut = new Button();
            panelCartItem = new Panel();
            EditQuantityPanel = new Panel();
            nudQuantitySelected = new NumericUpDown();
            btnSetNewQuantity = new Button();
            btnEditQuantity = new Button();
            btnRemoveFromBasket = new Button();
            NoRequestsPanel = new Panel();
            label2 = new Label();
            label1 = new Label();
            SupplierLimitErrorPanel = new Panel();
            label4 = new Label();
            label3 = new Label();
            RequestsPanel = new Panel();
            label8 = new Label();
            SupplierComboBox = new ComboBox();
            RequestTextBox = new TextBox();
            PageNumberLabel = new Label();
            label9 = new Label();
            AddToBasketButton = new Button();
            NextRequestButton = new Button();
            PreviousRequestButton = new Button();
            label10 = new Label();
            ((System.ComponentModel.ISupportInitialize)BackToMenu).BeginInit();
            panel1.SuspendLayout();
            panelCartItem.SuspendLayout();
            EditQuantityPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudQuantitySelected).BeginInit();
            NoRequestsPanel.SuspendLayout();
            SupplierLimitErrorPanel.SuspendLayout();
            RequestsPanel.SuspendLayout();
            SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(37, 125);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(201, 28);
            label5.TabIndex = 117;
            label5.Text = "Restocking requests ";
            // 
            // BackToMenu
            // 
            BackToMenu.BackColor = Color.Transparent;
            BackToMenu.Image = (Image)resources.GetObject("BackToMenu.Image");
            BackToMenu.Location = new Point(11, 11);
            BackToMenu.Margin = new Padding(2, 2, 2, 2);
            BackToMenu.Name = "BackToMenu";
            BackToMenu.Size = new Size(62, 62);
            BackToMenu.SizeMode = PictureBoxSizeMode.StretchImage;
            BackToMenu.TabIndex = 121;
            BackToMenu.TabStop = false;
            BackToMenu.Click += BackToMenu_Click;
            // 
            // lbxCart
            // 
            lbxCart.FormattingEnabled = true;
            lbxCart.Items.AddRange(new object[] { "" });
            lbxCart.Location = new Point(72, 196);
            lbxCart.Name = "lbxCart";
            lbxCart.Size = new Size(338, 384);
            lbxCart.TabIndex = 134;
            lbxCart.Click += lbCart_SelectedIndexChanged;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(161, 7, 2);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(btnCheckOut);
            panel1.Controls.Add(lbxCart);
            panel1.Controls.Add(panelCartItem);
            panel1.Location = new Point(1084, -12);
            panel1.Name = "panel1";
            panel1.Size = new Size(469, 808);
            panel1.TabIndex = 135;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Underline, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.White;
            label7.Location = new Point(279, 33);
            label7.Name = "label7";
            label7.Size = new Size(131, 20);
            label7.TabIndex = 136;
            label7.Text = "View Order history";
            label7.Click += OrderHistory_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(72, 79);
            label6.Name = "label6";
            label6.Size = new Size(120, 25);
            label6.TabIndex = 140;
            label6.Text = "Order basket";
            // 
            // btnCheckOut
            // 
            btnCheckOut.Enabled = false;
            btnCheckOut.Location = new Point(72, 728);
            btnCheckOut.Name = "btnCheckOut";
            btnCheckOut.Size = new Size(338, 29);
            btnCheckOut.TabIndex = 135;
            btnCheckOut.Text = "Check out";
            btnCheckOut.UseVisualStyleBackColor = true;
            btnCheckOut.Click += btnCheckOut_Click;
            // 
            // panelCartItem
            // 
            panelCartItem.Controls.Add(EditQuantityPanel);
            panelCartItem.Controls.Add(btnEditQuantity);
            panelCartItem.Controls.Add(btnRemoveFromBasket);
            panelCartItem.Location = new Point(56, 584);
            panelCartItem.Name = "panelCartItem";
            panelCartItem.Size = new Size(365, 125);
            panelCartItem.TabIndex = 141;
            panelCartItem.Visible = false;
            // 
            // EditQuantityPanel
            // 
            EditQuantityPanel.Controls.Add(nudQuantitySelected);
            EditQuantityPanel.Controls.Add(btnSetNewQuantity);
            EditQuantityPanel.Location = new Point(0, 60);
            EditQuantityPanel.Name = "EditQuantityPanel";
            EditQuantityPanel.Size = new Size(365, 47);
            EditQuantityPanel.TabIndex = 137;
            // 
            // nudQuantitySelected
            // 
            nudQuantitySelected.Location = new Point(16, 3);
            nudQuantitySelected.Name = "nudQuantitySelected";
            nudQuantitySelected.Size = new Size(238, 27);
            nudQuantitySelected.TabIndex = 138;
            // 
            // btnSetNewQuantity
            // 
            btnSetNewQuantity.Location = new Point(260, 1);
            btnSetNewQuantity.Name = "btnSetNewQuantity";
            btnSetNewQuantity.Size = new Size(94, 29);
            btnSetNewQuantity.TabIndex = 139;
            btnSetNewQuantity.Text = "Set";
            btnSetNewQuantity.UseVisualStyleBackColor = true;
            btnSetNewQuantity.Click += btnSetNewQuantity_Click;
            // 
            // btnEditQuantity
            // 
            btnEditQuantity.Location = new Point(16, 11);
            btnEditQuantity.Name = "btnEditQuantity";
            btnEditQuantity.Size = new Size(163, 29);
            btnEditQuantity.TabIndex = 136;
            btnEditQuantity.Text = "Edit quantity";
            btnEditQuantity.UseVisualStyleBackColor = true;
            btnEditQuantity.Click += btnEditQuantity_Click;
            // 
            // btnRemoveFromBasket
            // 
            btnRemoveFromBasket.Location = new Point(201, 11);
            btnRemoveFromBasket.Name = "btnRemoveFromBasket";
            btnRemoveFromBasket.Size = new Size(153, 29);
            btnRemoveFromBasket.TabIndex = 137;
            btnRemoveFromBasket.Text = "Remove ";
            btnRemoveFromBasket.UseVisualStyleBackColor = true;
            btnRemoveFromBasket.Click += btnRemoveFromBasket_Click;
            // 
            // NoRequestsPanel
            // 
            NoRequestsPanel.Controls.Add(label2);
            NoRequestsPanel.Controls.Add(label1);
            NoRequestsPanel.Location = new Point(281, 315);
            NoRequestsPanel.Name = "NoRequestsPanel";
            NoRequestsPanel.Size = new Size(468, 213);
            NoRequestsPanel.TabIndex = 136;
            NoRequestsPanel.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(110, 112);
            label2.Name = "label2";
            label2.Size = new Size(263, 20);
            label2.TabIndex = 1;
            label2.Text = "Ther are currently no pending requests";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(155, 61);
            label1.Name = "label1";
            label1.Size = new Size(170, 25);
            label1.TabIndex = 0;
            label1.Text = "No requests found";
            // 
            // SupplierLimitErrorPanel
            // 
            SupplierLimitErrorPanel.Controls.Add(label4);
            SupplierLimitErrorPanel.Controls.Add(label3);
            SupplierLimitErrorPanel.Location = new Point(281, 256);
            SupplierLimitErrorPanel.Name = "SupplierLimitErrorPanel";
            SupplierLimitErrorPanel.Size = new Size(468, 272);
            SupplierLimitErrorPanel.TabIndex = 137;
            SupplierLimitErrorPanel.Visible = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(144, 132);
            label4.Name = "label4";
            label4.Size = new Size(0, 20);
            label4.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(84, 59);
            label3.Name = "label3";
            label3.Size = new Size(312, 20);
            label3.TabIndex = 0;
            label3.Text = "No more requests supplied by that supplier";
            // 
            // RequestsPanel
            // 
            RequestsPanel.Controls.Add(label8);
            RequestsPanel.Controls.Add(SupplierComboBox);
            RequestsPanel.Controls.Add(RequestTextBox);
            RequestsPanel.Controls.Add(PageNumberLabel);
            RequestsPanel.Controls.Add(label9);
            RequestsPanel.Controls.Add(AddToBasketButton);
            RequestsPanel.Controls.Add(NextRequestButton);
            RequestsPanel.Controls.Add(PreviousRequestButton);
            RequestsPanel.Controls.Add(label10);
            RequestsPanel.Location = new Point(37, 173);
            RequestsPanel.Name = "RequestsPanel";
            RequestsPanel.Size = new Size(992, 589);
            RequestsPanel.TabIndex = 144;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(41, 537);
            label8.Name = "label8";
            label8.Size = new Size(67, 20);
            label8.TabIndex = 146;
            label8.Text = "Supplier:";
            // 
            // SupplierComboBox
            // 
            SupplierComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            SupplierComboBox.FormattingEnabled = true;
            SupplierComboBox.Location = new Point(114, 534);
            SupplierComboBox.Name = "SupplierComboBox";
            SupplierComboBox.Size = new Size(233, 28);
            SupplierComboBox.TabIndex = 145;
            SupplierComboBox.Click += SupplierComboBox_SelectedIndexChanged;
            // 
            // RequestTextBox
            // 
            RequestTextBox.Location = new Point(41, 83);
            RequestTextBox.Multiline = true;
            RequestTextBox.Name = "RequestTextBox";
            RequestTextBox.Size = new Size(903, 423);
            RequestTextBox.TabIndex = 140;
            // 
            // PageNumberLabel
            // 
            PageNumberLabel.AutoSize = true;
            PageNumberLabel.Location = new Point(722, 42);
            PageNumberLabel.MinimumSize = new Size(222, 0);
            PageNumberLabel.Name = "PageNumberLabel";
            PageNumberLabel.Size = new Size(222, 20);
            PageNumberLabel.TabIndex = 141;
            PageNumberLabel.Text = "<page number>/<NoOfPages> ";
            PageNumberLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(299, 51);
            label9.Name = "label9";
            label9.Size = new Size(0, 20);
            label9.TabIndex = 133;
            // 
            // AddToBasketButton
            // 
            AddToBasketButton.BackColor = Color.DarkRed;
            AddToBasketButton.Enabled = false;
            AddToBasketButton.ForeColor = Color.White;
            AddToBasketButton.Location = new Point(616, 527);
            AddToBasketButton.Margin = new Padding(2, 2, 2, 2);
            AddToBasketButton.Name = "AddToBasketButton";
            AddToBasketButton.Size = new Size(328, 40);
            AddToBasketButton.TabIndex = 137;
            AddToBasketButton.Text = "Add to basket";
            AddToBasketButton.UseVisualStyleBackColor = false;
            AddToBasketButton.Click += AddToBasketButton_Click;
            // 
            // NextRequestButton
            // 
            NextRequestButton.Location = new Point(175, 42);
            NextRequestButton.Name = "NextRequestButton";
            NextRequestButton.Size = new Size(133, 29);
            NextRequestButton.TabIndex = 139;
            NextRequestButton.Text = "Next";
            NextRequestButton.UseVisualStyleBackColor = true;
            NextRequestButton.Click += NextRequestButton_Click;
            // 
            // PreviousRequestButton
            // 
            PreviousRequestButton.Enabled = false;
            PreviousRequestButton.Location = new Point(41, 42);
            PreviousRequestButton.Name = "PreviousRequestButton";
            PreviousRequestButton.Size = new Size(128, 29);
            PreviousRequestButton.TabIndex = 138;
            PreviousRequestButton.Text = "Previous ";
            PreviousRequestButton.UseVisualStyleBackColor = true;
            PreviousRequestButton.Click += PreviousRequestButton_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(429, 228);
            label10.Name = "label10";
            label10.Size = new Size(131, 20);
            label10.TabIndex = 144;
            label10.Text = "No requests found";
            // 
            // DepotRestockingPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1557, 805);
            Controls.Add(RequestsPanel);
            Controls.Add(SupplierLimitErrorPanel);
            Controls.Add(NoRequestsPanel);
            Controls.Add(panel1);
            Controls.Add(BackToMenu);
            Controls.Add(label5);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2, 2, 2, 2);
            MaximizeBox = false;
            MaximumSize = new Size(1575, 852);
            MinimumSize = new Size(1187, 660);
            Name = "DepotRestockingPage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Menu";
            ((System.ComponentModel.ISupportInitialize)BackToMenu).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panelCartItem.ResumeLayout(false);
            EditQuantityPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)nudQuantitySelected).EndInit();
            NoRequestsPanel.ResumeLayout(false);
            NoRequestsPanel.PerformLayout();
            SupplierLimitErrorPanel.ResumeLayout(false);
            SupplierLimitErrorPanel.PerformLayout();
            RequestsPanel.ResumeLayout(false);
            RequestsPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label5;
        private PictureBox BackToMenu;
        private ListBox lbxCart;
        private Panel panel1;
        private Button btnRemoveFromBasket;
        private Button btnEditQuantity;
        private Button btnCheckOut;
        private Button btnSetNewQuantity;
        private NumericUpDown nudQuantitySelected;
        private Label label6;
        private Label label7;
        private Panel panelCartItem;
        private Panel EditQuantityPanel;
        private Panel NoRequestsPanel;
        private Label label2;
        private Label label1;
        private Panel SupplierLimitErrorPanel;
        private Label label3;
        private Label label4;
        private Panel RequestsPanel;
        private Label label8;
        private ComboBox SupplierComboBox;
        private TextBox RequestTextBox;
        private Label PageNumberLabel;
        private Label label9;
        private Button AddToBasketButton;
        private Button NextRequestButton;
        private Button PreviousRequestButton;
        private Label label10;
    }
}