namespace MediaBazaarApp
{
    partial class OrderHistoryPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderHistoryPage));
            OnTheWayButton = new Button();
            DeliveredButton = new Button();
            label2 = new Label();
            label3 = new Label();
            panel1 = new Panel();
            OrdersListView = new ListView();
            OrderID = new ColumnHeader();
            Supplier = new ColumnHeader();
            Status = new ColumnHeader();
            PlacedOn = new ColumnHeader();
            ExpectedArrival = new ColumnHeader();
            OrderItemsListBox = new ListBox();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // OnTheWayButton
            // 
            OnTheWayButton.BackColor = Color.White;
            OnTheWayButton.Location = new Point(327, 90);
            OnTheWayButton.Margin = new Padding(5);
            OnTheWayButton.Name = "OnTheWayButton";
            OnTheWayButton.Size = new Size(320, 64);
            OnTheWayButton.TabIndex = 6;
            OnTheWayButton.Text = "On the way";
            OnTheWayButton.UseVisualStyleBackColor = false;
            OnTheWayButton.Click += OnTheWayButton_Click;
            // 
            // DeliveredButton
            // 
            DeliveredButton.BackColor = Color.Gainsboro;
            DeliveredButton.Location = new Point(65, 90);
            DeliveredButton.Margin = new Padding(5);
            DeliveredButton.Name = "DeliveredButton";
            DeliveredButton.Size = new Size(270, 64);
            DeliveredButton.TabIndex = 5;
            DeliveredButton.Text = "Delivered";
            DeliveredButton.UseVisualStyleBackColor = false;
            DeliveredButton.Click += DeliveredButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(800, 365);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(315, 50);
            label2.TabIndex = 7;
            label2.Text = "No Orders found";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(-5, 454);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.MinimumSize = new Size(1934, 0);
            label3.Name = "label3";
            label3.Size = new Size(1934, 32);
            label3.TabIndex = 8;
            label3.Text = "No orders found with the <> status";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.Controls.Add(OrdersListView);
            panel1.Controls.Add(OrderItemsListBox);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(36, 226);
            panel1.Margin = new Padding(5);
            panel1.Name = "panel1";
            panel1.Size = new Size(1864, 651);
            panel1.TabIndex = 9;
            panel1.Visible = false;
            // 
            // OrdersListView
            // 
            OrdersListView.BackColor = SystemColors.ControlLightLight;
            OrdersListView.BorderStyle = BorderStyle.None;
            OrdersListView.Columns.AddRange(new ColumnHeader[] { OrderID, Supplier, Status, PlacedOn, ExpectedArrival });
            OrdersListView.FullRowSelect = true;
            OrdersListView.Location = new Point(29, 26);
            OrdersListView.Name = "OrdersListView";
            OrdersListView.Size = new Size(1095, 571);
            OrdersListView.TabIndex = 4;
            OrdersListView.UseCompatibleStateImageBehavior = false;
            OrdersListView.View = View.Details;
            OrdersListView.SelectedIndexChanged += OrdersListView_SelectedIndexChanged;
            // 
            // OrderID
            // 
            OrderID.Text = "ID";
            OrderID.Width = 100;
            // 
            // Supplier
            // 
            Supplier.Text = "Supplier";
            Supplier.Width = 150;
            // 
            // Status
            // 
            Status.Text = "Status";
            Status.Width = 120;
            // 
            // PlacedOn
            // 
            PlacedOn.Text = "Placed on";
            PlacedOn.Width = 150;
            // 
            // ExpectedArrival
            // 
            ExpectedArrival.Text = "Expected arrival";
            ExpectedArrival.Width = 150;
            // 
            // OrderItemsListBox
            // 
            OrderItemsListBox.FormattingEnabled = true;
            OrderItemsListBox.Items.AddRange(new object[] { "" });
            OrderItemsListBox.Location = new Point(1259, 142);
            OrderItemsListBox.Margin = new Padding(5);
            OrderItemsListBox.Name = "OrderItemsListBox";
            OrderItemsListBox.Size = new Size(545, 452);
            OrderItemsListBox.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(1259, 78);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(149, 32);
            label1.TabIndex = 3;
            label1.Text = "Order items";
            // 
            // OrderHistoryPage
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Lavender;
            ClientSize = new Size(1934, 947);
            Controls.Add(panel1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(DeliveredButton);
            Controls.Add(OnTheWayButton);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(1960, 1018);
            MinimumSize = new Size(1960, 1018);
            Name = "OrderHistoryPage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Order History";
            Load += OrderHistoryPage_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button OnTheWayButton;
        private Button DeliveredButton;
        private Label label2;
        private Label label3;
        private Panel panel1;
        private ListView OrdersListView;
        private ColumnHeader OrderID;
        private ColumnHeader Supplier;
        private ColumnHeader Status;
        private ColumnHeader PlacedOn;
        private ColumnHeader ExpectedArrival;
        private ListBox OrderItemsListBox;
        private Label label1;
    }
}