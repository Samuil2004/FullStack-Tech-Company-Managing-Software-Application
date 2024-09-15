namespace MediaBazaarApp
{
    partial class ManagerSchedulePlanner
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManagerSchedulePlanner));
			lbAvailableMemebersFirstShift = new ListBox();
			labelAvailableMembers = new Label();
			lbDayPlannerFirstShift = new ListBox();
			lbDayPlannerSecondShift = new ListBox();
			labelSelectedDayAndDate = new Label();
			labelFirstShift = new Label();
			labelSecondShift = new Label();
			btnRemovePersonFromShift = new Button();
			btnAddPersonToShift = new Button();
			btnClearSchedule = new Button();
			lbAvailableMembersSecondShift = new ListBox();
			lbAvailableMembersThirdShift = new ListBox();
			labelThirdShift = new Label();
			lbDayPlannerThirdShift = new ListBox();
			btnGenerateSchedule = new Button();
			rbGenerateDaySchedule = new RadioButton();
			rbGenerateWeekSchedule = new RadioButton();
			groupBox1 = new GroupBox();
			labelRangeInWeeks = new Label();
			cbWeeksRange = new ComboBox();
			rbWeekForWholeDepartment = new RadioButton();
			labelWholeDepartment = new Label();
			labelByRole = new Label();
			groupBox2 = new GroupBox();
			label6 = new Label();
			label1 = new Label();
			label2 = new Label();
			label3 = new Label();
			label4 = new Label();
			label5 = new Label();
			labelSelectDayPlanner = new Label();
			labelDepartment = new Label();
			cbDepartment = new ComboBox();
			labelRole = new Label();
			cbRole = new ComboBox();
			pbPrevPage = new PictureBox();
			calendar = new MonthCalendar();
			lbNotes = new ListBox();
			labelNotifications = new Label();
			backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			groupBox1.SuspendLayout();
			groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pbPrevPage).BeginInit();
			SuspendLayout();
			// 
			// lbAvailableMemebersFirstShift
			// 
			lbAvailableMemebersFirstShift.BackColor = Color.White;
			lbAvailableMemebersFirstShift.DrawMode = DrawMode.OwnerDrawFixed;
			lbAvailableMemebersFirstShift.FormattingEnabled = true;
			lbAvailableMemebersFirstShift.Items.AddRange(new object[] { "" });
			lbAvailableMemebersFirstShift.Location = new Point(664, 148);
			lbAvailableMemebersFirstShift.Margin = new Padding(2, 2, 2, 2);
			lbAvailableMemebersFirstShift.Name = "lbAvailableMemebersFirstShift";
			lbAvailableMemebersFirstShift.Size = new Size(224, 164);
			lbAvailableMemebersFirstShift.TabIndex = 0;
			lbAvailableMemebersFirstShift.DrawItem += lbAvailableMembersFirstShift_DrawItem;
			lbAvailableMemebersFirstShift.MouseDown += lbAvailableMemebersFirstShift_MouseDown;
			// 
			// labelAvailableMembers
			// 
			labelAvailableMembers.AutoSize = true;
			labelAvailableMembers.Font = new Font("Microsoft Sans Serif", 11F);
			labelAvailableMembers.ForeColor = Color.FromArgb(161, 7, 2);
			labelAvailableMembers.Location = new Point(701, 88);
			labelAvailableMembers.Margin = new Padding(2, 0, 2, 0);
			labelAvailableMembers.Name = "labelAvailableMembers";
			labelAvailableMembers.Size = new Size(171, 24);
			labelAvailableMembers.TabIndex = 1;
			labelAvailableMembers.Text = "Available Members";
			// 
			// lbDayPlannerFirstShift
			// 
			lbDayPlannerFirstShift.FormattingEnabled = true;
			lbDayPlannerFirstShift.Items.AddRange(new object[] { "" });
			lbDayPlannerFirstShift.Location = new Point(1208, 148);
			lbDayPlannerFirstShift.Margin = new Padding(2, 2, 2, 2);
			lbDayPlannerFirstShift.Name = "lbDayPlannerFirstShift";
			lbDayPlannerFirstShift.Size = new Size(222, 164);
			lbDayPlannerFirstShift.TabIndex = 2;
			lbDayPlannerFirstShift.DragDrop += lbDayPlannerFirstShift_DragDrop;
			lbDayPlannerFirstShift.DragEnter += lbDayPlannerFirstShift_DragEnter;
			// 
			// lbDayPlannerSecondShift
			// 
			lbDayPlannerSecondShift.FormattingEnabled = true;
			lbDayPlannerSecondShift.Items.AddRange(new object[] { "" });
			lbDayPlannerSecondShift.Location = new Point(1208, 352);
			lbDayPlannerSecondShift.Margin = new Padding(2, 2, 2, 2);
			lbDayPlannerSecondShift.Name = "lbDayPlannerSecondShift";
			lbDayPlannerSecondShift.Size = new Size(222, 164);
			lbDayPlannerSecondShift.TabIndex = 3;
			lbDayPlannerSecondShift.DragDrop += lbDayPlannerSecondShift_DragDrop;
			lbDayPlannerSecondShift.DragEnter += lbDayPlannerSecondShift_DragEnter;
			// 
			// labelSelectedDayAndDate
			// 
			labelSelectedDayAndDate.AutoSize = true;
			labelSelectedDayAndDate.Font = new Font("Microsoft Sans Serif", 9F);
			labelSelectedDayAndDate.Location = new Point(119, 56);
			labelSelectedDayAndDate.Margin = new Padding(2, 0, 2, 0);
			labelSelectedDayAndDate.Name = "labelSelectedDayAndDate";
			labelSelectedDayAndDate.Size = new Size(143, 18);
			labelSelectedDayAndDate.TabIndex = 4;
			labelSelectedDayAndDate.Text = "Selected Day + Date";
			// 
			// labelFirstShift
			// 
			labelFirstShift.AutoSize = true;
			labelFirstShift.Font = new Font("Microsoft Sans Serif", 9F);
			labelFirstShift.Location = new Point(664, 126);
			labelFirstShift.Margin = new Padding(2, 0, 2, 0);
			labelFirstShift.Name = "labelFirstShift";
			labelFirstShift.Size = new Size(62, 18);
			labelFirstShift.TabIndex = 5;
			labelFirstShift.Text = "Morning";
			// 
			// labelSecondShift
			// 
			labelSecondShift.AutoSize = true;
			labelSecondShift.Font = new Font("Microsoft Sans Serif", 9F);
			labelSecondShift.Location = new Point(664, 331);
			labelSecondShift.Margin = new Padding(2, 0, 2, 0);
			labelSecondShift.Name = "labelSecondShift";
			labelSecondShift.Size = new Size(72, 18);
			labelSecondShift.TabIndex = 6;
			labelSecondShift.Text = "Afternoon";
			// 
			// btnRemovePersonFromShift
			// 
			btnRemovePersonFromShift.BackColor = Color.FromArgb(232, 235, 238);
			btnRemovePersonFromShift.FlatStyle = FlatStyle.Flat;
			btnRemovePersonFromShift.Font = new Font("Segoe UI", 9F);
			btnRemovePersonFromShift.ForeColor = Color.Black;
			btnRemovePersonFromShift.Location = new Point(160, 218);
			btnRemovePersonFromShift.Margin = new Padding(2, 2, 2, 2);
			btnRemovePersonFromShift.Name = "btnRemovePersonFromShift";
			btnRemovePersonFromShift.Size = new Size(80, 42);
			btnRemovePersonFromShift.TabIndex = 10;
			btnRemovePersonFromShift.Text = "Remove";
			btnRemovePersonFromShift.UseVisualStyleBackColor = false;
			btnRemovePersonFromShift.Click += btnRemovePersonFromShift_Click;
			// 
			// btnAddPersonToShift
			// 
			btnAddPersonToShift.BackColor = Color.FromArgb(232, 235, 238);
			btnAddPersonToShift.FlatStyle = FlatStyle.Flat;
			btnAddPersonToShift.Font = new Font("Segoe UI", 9F);
			btnAddPersonToShift.ForeColor = Color.Black;
			btnAddPersonToShift.Location = new Point(68, 218);
			btnAddPersonToShift.Margin = new Padding(2, 2, 2, 2);
			btnAddPersonToShift.Name = "btnAddPersonToShift";
			btnAddPersonToShift.Size = new Size(88, 42);
			btnAddPersonToShift.TabIndex = 9;
			btnAddPersonToShift.Text = "Add";
			btnAddPersonToShift.UseVisualStyleBackColor = false;
			btnAddPersonToShift.Click += btnAddPersonToShift_Click;
			// 
			// btnClearSchedule
			// 
			btnClearSchedule.BackColor = Color.FromArgb(232, 235, 238);
			btnClearSchedule.FlatStyle = FlatStyle.Flat;
			btnClearSchedule.Font = new Font("Segoe UI", 9F);
			btnClearSchedule.ForeColor = Color.Black;
			btnClearSchedule.Location = new Point(76, 102);
			btnClearSchedule.Margin = new Padding(2, 2, 2, 2);
			btnClearSchedule.Name = "btnClearSchedule";
			btnClearSchedule.Size = new Size(172, 42);
			btnClearSchedule.TabIndex = 13;
			btnClearSchedule.Text = "Clear Schedule";
			btnClearSchedule.UseVisualStyleBackColor = false;
			btnClearSchedule.Click += btnClearSchedule_Click;
			// 
			// lbAvailableMembersSecondShift
			// 
			lbAvailableMembersSecondShift.FormattingEnabled = true;
			lbAvailableMembersSecondShift.Items.AddRange(new object[] { "" });
			lbAvailableMembersSecondShift.Location = new Point(664, 352);
			lbAvailableMembersSecondShift.Margin = new Padding(2, 2, 2, 2);
			lbAvailableMembersSecondShift.Name = "lbAvailableMembersSecondShift";
			lbAvailableMembersSecondShift.Size = new Size(224, 164);
			lbAvailableMembersSecondShift.TabIndex = 16;
			lbAvailableMembersSecondShift.MouseDown += lbAvailableMembersSecondShift_MouseDown;
			// 
			// lbAvailableMembersThirdShift
			// 
			lbAvailableMembersThirdShift.DrawMode = DrawMode.OwnerDrawFixed;
			lbAvailableMembersThirdShift.FormattingEnabled = true;
			lbAvailableMembersThirdShift.Items.AddRange(new object[] { "" });
			lbAvailableMembersThirdShift.Location = new Point(664, 551);
			lbAvailableMembersThirdShift.Margin = new Padding(2, 2, 2, 2);
			lbAvailableMembersThirdShift.Name = "lbAvailableMembersThirdShift";
			lbAvailableMembersThirdShift.Size = new Size(224, 144);
			lbAvailableMembersThirdShift.TabIndex = 18;
			lbAvailableMembersThirdShift.DrawItem += lbAvailableMembersThirdShift_DrawItem;
			lbAvailableMembersThirdShift.MouseDown += lbAvailableMembersThirdShift_MouseDown;
			// 
			// labelThirdShift
			// 
			labelThirdShift.AutoSize = true;
			labelThirdShift.Font = new Font("Microsoft Sans Serif", 9F);
			labelThirdShift.Location = new Point(664, 529);
			labelThirdShift.Margin = new Padding(2, 0, 2, 0);
			labelThirdShift.Name = "labelThirdShift";
			labelThirdShift.Size = new Size(60, 18);
			labelThirdShift.TabIndex = 17;
			labelThirdShift.Text = "Evening";
			// 
			// lbDayPlannerThirdShift
			// 
			lbDayPlannerThirdShift.FormattingEnabled = true;
			lbDayPlannerThirdShift.Items.AddRange(new object[] { "" });
			lbDayPlannerThirdShift.Location = new Point(1208, 551);
			lbDayPlannerThirdShift.Margin = new Padding(2, 2, 2, 2);
			lbDayPlannerThirdShift.Name = "lbDayPlannerThirdShift";
			lbDayPlannerThirdShift.Size = new Size(222, 144);
			lbDayPlannerThirdShift.TabIndex = 19;
			lbDayPlannerThirdShift.DragDrop += lbDayPlannerThirdShift_DragDrop;
			lbDayPlannerThirdShift.DragEnter += lbDayPlannerThirdShift_DragEnter;
			// 
			// btnGenerateSchedule
			// 
			btnGenerateSchedule.BackColor = Color.FromArgb(232, 235, 238);
			btnGenerateSchedule.FlatStyle = FlatStyle.Flat;
			btnGenerateSchedule.Font = new Font("Segoe UI", 9F);
			btnGenerateSchedule.ForeColor = Color.Black;
			btnGenerateSchedule.Location = new Point(28, 89);
			btnGenerateSchedule.Margin = new Padding(2, 2, 2, 2);
			btnGenerateSchedule.Name = "btnGenerateSchedule";
			btnGenerateSchedule.Size = new Size(212, 42);
			btnGenerateSchedule.TabIndex = 20;
			btnGenerateSchedule.Text = "Generate";
			btnGenerateSchedule.UseVisualStyleBackColor = false;
			btnGenerateSchedule.Click += btnGenerateSchedule_Click;
			// 
			// rbGenerateDaySchedule
			// 
			rbGenerateDaySchedule.AutoSize = true;
			rbGenerateDaySchedule.Font = new Font("Microsoft Sans Serif", 9F);
			rbGenerateDaySchedule.Location = new Point(38, 52);
			rbGenerateDaySchedule.Margin = new Padding(2, 2, 2, 2);
			rbGenerateDaySchedule.Name = "rbGenerateDaySchedule";
			rbGenerateDaySchedule.Size = new Size(55, 22);
			rbGenerateDaySchedule.TabIndex = 22;
			rbGenerateDaySchedule.TabStop = true;
			rbGenerateDaySchedule.Text = "Day";
			rbGenerateDaySchedule.UseVisualStyleBackColor = true;
			// 
			// rbGenerateWeekSchedule
			// 
			rbGenerateWeekSchedule.AutoSize = true;
			rbGenerateWeekSchedule.Font = new Font("Microsoft Sans Serif", 9F);
			rbGenerateWeekSchedule.Location = new Point(160, 52);
			rbGenerateWeekSchedule.Margin = new Padding(2, 2, 2, 2);
			rbGenerateWeekSchedule.Name = "rbGenerateWeekSchedule";
			rbGenerateWeekSchedule.Size = new Size(68, 22);
			rbGenerateWeekSchedule.TabIndex = 23;
			rbGenerateWeekSchedule.TabStop = true;
			rbGenerateWeekSchedule.Text = "Week";
			rbGenerateWeekSchedule.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			groupBox1.BackColor = Color.FromArgb(161, 7, 2);
			groupBox1.Controls.Add(labelRangeInWeeks);
			groupBox1.Controls.Add(cbWeeksRange);
			groupBox1.Controls.Add(rbWeekForWholeDepartment);
			groupBox1.Controls.Add(labelWholeDepartment);
			groupBox1.Controls.Add(labelByRole);
			groupBox1.Controls.Add(btnGenerateSchedule);
			groupBox1.Controls.Add(rbGenerateWeekSchedule);
			groupBox1.Controls.Add(rbGenerateDaySchedule);
			groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			groupBox1.ForeColor = Color.White;
			groupBox1.Location = new Point(918, 443);
			groupBox1.Margin = new Padding(4, 4, 4, 4);
			groupBox1.Name = "groupBox1";
			groupBox1.Padding = new Padding(4, 4, 4, 4);
			groupBox1.Size = new Size(268, 271);
			groupBox1.TabIndex = 24;
			groupBox1.TabStop = false;
			groupBox1.Text = "                  Generate schedule                    ";
			// 
			// labelRangeInWeeks
			// 
			labelRangeInWeeks.AutoSize = true;
			labelRangeInWeeks.Location = new Point(28, 209);
			labelRangeInWeeks.Margin = new Padding(2, 0, 2, 0);
			labelRangeInWeeks.Name = "labelRangeInWeeks";
			labelRangeInWeeks.Size = new Size(117, 20);
			labelRangeInWeeks.TabIndex = 28;
			labelRangeInWeeks.Text = "Range in weeks";
			// 
			// cbWeeksRange
			// 
			cbWeeksRange.DropDownStyle = ComboBoxStyle.DropDownList;
			cbWeeksRange.FormattingEnabled = true;
			cbWeeksRange.Items.AddRange(new object[] { "1", "2", "3", "4" });
			cbWeeksRange.Location = new Point(160, 207);
			cbWeeksRange.Margin = new Padding(2, 2, 2, 2);
			cbWeeksRange.Name = "cbWeeksRange";
			cbWeeksRange.Size = new Size(82, 28);
			cbWeeksRange.TabIndex = 27;
			cbWeeksRange.SelectedIndexChanged += cbWeeksRange_SelectedIndexChanged;
			// 
			// rbWeekForWholeDepartment
			// 
			rbWeekForWholeDepartment.AutoSize = true;
			rbWeekForWholeDepartment.Font = new Font("Microsoft Sans Serif", 9F);
			rbWeekForWholeDepartment.Location = new Point(28, 171);
			rbWeekForWholeDepartment.Margin = new Padding(2, 2, 2, 2);
			rbWeekForWholeDepartment.Name = "rbWeekForWholeDepartment";
			rbWeekForWholeDepartment.Size = new Size(211, 22);
			rbWeekForWholeDepartment.TabIndex = 26;
			rbWeekForWholeDepartment.TabStop = true;
			rbWeekForWholeDepartment.Text = "Week for whole department";
			rbWeekForWholeDepartment.UseVisualStyleBackColor = true;
			// 
			// labelWholeDepartment
			// 
			labelWholeDepartment.AutoSize = true;
			labelWholeDepartment.Location = new Point(28, 141);
			labelWholeDepartment.Margin = new Padding(2, 0, 2, 0);
			labelWholeDepartment.Name = "labelWholeDepartment";
			labelWholeDepartment.Size = new Size(145, 20);
			labelWholeDepartment.TabIndex = 25;
			labelWholeDepartment.Text = "Whole department:";
			// 
			// labelByRole
			// 
			labelByRole.AutoSize = true;
			labelByRole.Location = new Point(28, 24);
			labelByRole.Margin = new Padding(2, 0, 2, 0);
			labelByRole.Name = "labelByRole";
			labelByRole.Size = new Size(62, 20);
			labelByRole.TabIndex = 24;
			labelByRole.Text = "By role:";
			// 
			// groupBox2
			// 
			groupBox2.BackColor = Color.FromArgb(161, 7, 2);
			groupBox2.Controls.Add(label6);
			groupBox2.Controls.Add(label1);
			groupBox2.Controls.Add(btnAddPersonToShift);
			groupBox2.Controls.Add(btnRemovePersonFromShift);
			groupBox2.Controls.Add(labelSelectedDayAndDate);
			groupBox2.Controls.Add(btnClearSchedule);
			groupBox2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
			groupBox2.ForeColor = Color.White;
			groupBox2.Location = new Point(918, 148);
			groupBox2.Margin = new Padding(4, 4, 4, 4);
			groupBox2.Name = "groupBox2";
			groupBox2.Padding = new Padding(4, 4, 4, 4);
			groupBox2.Size = new Size(268, 281);
			groupBox2.TabIndex = 25;
			groupBox2.TabStop = false;
			groupBox2.Text = "                  Manual scheduling                   ";
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Font = new Font("Microsoft Sans Serif", 9F);
			label6.Location = new Point(28, 182);
			label6.Margin = new Padding(4, 0, 4, 0);
			label6.Name = "label6";
			label6.Size = new Size(141, 18);
			label6.TabIndex = 14;
			label6.Text = "Selected employee: ";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Microsoft Sans Serif", 8.25F);
			label1.Location = new Point(28, 56);
			label1.Margin = new Padding(4, 0, 4, 0);
			label1.Name = "label1";
			label1.Size = new Size(94, 17);
			label1.TabIndex = 11;
			label1.Text = "Selected day:";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Microsoft Sans Serif", 9F);
			label2.Location = new Point(1208, 529);
			label2.Margin = new Padding(2, 0, 2, 0);
			label2.Name = "label2";
			label2.Size = new Size(60, 18);
			label2.TabIndex = 26;
			label2.Text = "Evening";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Font = new Font("Microsoft Sans Serif", 9F);
			label3.Location = new Point(1208, 331);
			label3.Margin = new Padding(2, 0, 2, 0);
			label3.Name = "label3";
			label3.Size = new Size(72, 18);
			label3.TabIndex = 27;
			label3.Text = "Afternoon";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Font = new Font("Microsoft Sans Serif", 9F);
			label4.Location = new Point(1208, 128);
			label4.Margin = new Padding(2, 0, 2, 0);
			label4.Name = "label4";
			label4.Size = new Size(62, 18);
			label4.TabIndex = 28;
			label4.Text = "Morning";
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.BackColor = Color.WhiteSmoke;
			label5.Font = new Font("Microsoft Sans Serif", 11F);
			label5.ForeColor = Color.FromArgb(161, 7, 2);
			label5.Location = new Point(1249, 88);
			label5.Margin = new Padding(4, 0, 4, 0);
			label5.Name = "label5";
			label5.Size = new Size(168, 24);
			label5.TabIndex = 29;
			label5.Text = "Planned schedule ";
			// 
			// labelSelectDayPlanner
			// 
			labelSelectDayPlanner.AutoSize = true;
			labelSelectDayPlanner.Font = new Font("Microsoft Sans Serif", 9F);
			labelSelectDayPlanner.Location = new Point(108, 340);
			labelSelectDayPlanner.Margin = new Padding(2, 0, 2, 0);
			labelSelectDayPlanner.Name = "labelSelectDayPlanner";
			labelSelectDayPlanner.Size = new Size(83, 18);
			labelSelectDayPlanner.TabIndex = 12;
			labelSelectDayPlanner.Text = "Select Day:";
			// 
			// labelDepartment
			// 
			labelDepartment.AutoSize = true;
			labelDepartment.Font = new Font("Microsoft Sans Serif", 9F);
			labelDepartment.Location = new Point(105, 200);
			labelDepartment.Margin = new Padding(4, 0, 4, 0);
			labelDepartment.Name = "labelDepartment";
			labelDepartment.Size = new Size(93, 18);
			labelDepartment.TabIndex = 31;
			labelDepartment.Text = "Department: ";
			// 
			// cbDepartment
			// 
			cbDepartment.DropDownStyle = ComboBoxStyle.DropDownList;
			cbDepartment.FormattingEnabled = true;
			cbDepartment.Location = new Point(212, 195);
			cbDepartment.Margin = new Padding(2, 2, 2, 2);
			cbDepartment.Name = "cbDepartment";
			cbDepartment.Size = new Size(200, 28);
			cbDepartment.TabIndex = 30;
			cbDepartment.SelectedIndexChanged += cbDepartment_SelectedIndexChanged;
			// 
			// labelRole
			// 
			labelRole.AutoSize = true;
			labelRole.Font = new Font("Microsoft Sans Serif", 9F);
			labelRole.Location = new Point(105, 234);
			labelRole.Margin = new Padding(4, 0, 4, 0);
			labelRole.Name = "labelRole";
			labelRole.Size = new Size(47, 18);
			labelRole.TabIndex = 32;
			labelRole.Text = "Role: ";
			// 
			// cbRole
			// 
			cbRole.DropDownStyle = ComboBoxStyle.DropDownList;
			cbRole.FormattingEnabled = true;
			cbRole.Location = new Point(212, 234);
			cbRole.Margin = new Padding(2, 2, 2, 2);
			cbRole.Name = "cbRole";
			cbRole.Size = new Size(200, 28);
			cbRole.TabIndex = 33;
			cbRole.SelectedIndexChanged += cbRole_SelectedIndexChanged;
			// 
			// pbPrevPage
			// 
			pbPrevPage.BackColor = Color.Transparent;
			pbPrevPage.Image = (Image)resources.GetObject("pbPrevPage.Image");
			pbPrevPage.Location = new Point(27, 16);
			pbPrevPage.Margin = new Padding(2, 2, 2, 2);
			pbPrevPage.Name = "pbPrevPage";
			pbPrevPage.Size = new Size(62, 62);
			pbPrevPage.SizeMode = PictureBoxSizeMode.StretchImage;
			pbPrevPage.TabIndex = 91;
			pbPrevPage.TabStop = false;
			pbPrevPage.Click += pbPrevPage_Click;
			// 
			// calendar
			// 
			calendar.FirstDayOfWeek = Day.Monday;
			calendar.Location = new Point(212, 331);
			calendar.Margin = new Padding(6, 6, 6, 6);
			calendar.Name = "calendar";
			calendar.ShowTodayCircle = false;
			calendar.ShowWeekNumbers = true;
			calendar.TabIndex = 92;
			calendar.DateChanged += calendar_DateChanged;
			// 
			// lbNotes
			// 
			lbNotes.FormattingEnabled = true;
			lbNotes.Location = new Point(7, 583);
			lbNotes.Margin = new Padding(2, 2, 2, 2);
			lbNotes.Name = "lbNotes";
			lbNotes.Size = new Size(654, 144);
			lbNotes.TabIndex = 93;
			// 
			// labelNotifications
			// 
			labelNotifications.AutoSize = true;
			labelNotifications.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
			labelNotifications.Location = new Point(7, 558);
			labelNotifications.Margin = new Padding(2, 0, 2, 0);
			labelNotifications.Name = "labelNotifications";
			labelNotifications.Size = new Size(111, 23);
			labelNotifications.TabIndex = 94;
			labelNotifications.Text = "Notifications:";
			// 
			// backgroundWorker1
			// 
			backgroundWorker1.DoWork += backgroundWorker1_DoWork;
			// 
			// ManagerSchedulePlanner
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.WhiteSmoke;
			ClientSize = new Size(1496, 757);
			Controls.Add(labelNotifications);
			Controls.Add(lbNotes);
			Controls.Add(calendar);
			Controls.Add(pbPrevPage);
			Controls.Add(cbRole);
			Controls.Add(labelRole);
			Controls.Add(labelDepartment);
			Controls.Add(cbDepartment);
			Controls.Add(label5);
			Controls.Add(label4);
			Controls.Add(label3);
			Controls.Add(label2);
			Controls.Add(groupBox2);
			Controls.Add(groupBox1);
			Controls.Add(lbDayPlannerThirdShift);
			Controls.Add(lbAvailableMembersThirdShift);
			Controls.Add(labelThirdShift);
			Controls.Add(lbAvailableMembersSecondShift);
			Controls.Add(labelSelectDayPlanner);
			Controls.Add(labelSecondShift);
			Controls.Add(labelFirstShift);
			Controls.Add(lbDayPlannerSecondShift);
			Controls.Add(lbDayPlannerFirstShift);
			Controls.Add(labelAvailableMembers);
			Controls.Add(lbAvailableMemebersFirstShift);
			ForeColor = Color.Black;
			Icon = (Icon)resources.GetObject("$this.Icon");
			Margin = new Padding(2, 2, 2, 2);
			MaximizeBox = false;
			MaximumSize = new Size(1920, 1080);
			MinimumSize = new Size(1187, 654);
			Name = "ManagerSchedulePlanner";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Planner";
			FormClosing += AnyForm_FormClosing;
			Load += ManagerSchedulePlanner_Load;
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pbPrevPage).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private ListBox lbAvailableMemebersFirstShift;
        private Label labelAvailableMembers;
        private ListBox lbDayPlannerFirstShift;
        private ListBox lbDayPlannerSecondShift;
        private Label labelSelectedDayAndDate;
        private Label labelFirstShift;
        private Label labelSecondShift;
        private Button btnRemovePersonFromShift;
        private Button btnAddPersonToShift;
        private Button btnClearSchedule;
        private ListBox lbAvailableMembersSecondShift;
        private ListBox lbAvailableMembersThirdShift;
        private Label labelThirdShift;
        private ListBox lbDayPlannerThirdShift;
        private Button btnGenerateSchedule;
        private RadioButton rbGenerateDaySchedule;
        private RadioButton rbGenerateWeekSchedule;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label labelSelectDayPlanner;
        private Label labelDepartment;
        private ComboBox cbDepartment;
        private Label labelRole;
        private ComboBox cbRole;
        private PictureBox pbPrevPage;
        private MonthCalendar monthCalendar1;
        private MonthCalendar calendar;
        private Label labelByRole;
        private Label labelWholeDepartment;
        private RadioButton rbWeekForWholeDepartment;
        private Label labelNotifications;
        private ComboBox comboBox1;
        private Label labelRangeInWeeks;
        private ComboBox cbWeeksRange;
        private ListBox lbNotes;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}