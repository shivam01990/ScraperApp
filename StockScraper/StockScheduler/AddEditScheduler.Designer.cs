namespace StockScheduler
{
    partial class AddEditScheduler
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
            this.Header = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnSaveJob = new System.Windows.Forms.Button();
            this.txtMaxRunCount = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlYearly = new System.Windows.Forms.Panel();
            this.cmbYearlyMonthWeek = new System.Windows.Forms.ComboBox();
            this.cmbYearlyWeekDay = new System.Windows.Forms.ComboBox();
            this.cmbYearlyDay = new System.Windows.Forms.ComboBox();
            this.numeric_YearlyNominalDay = new System.Windows.Forms.NumericUpDown();
            this.cmbYearly_Month = new System.Windows.Forms.ComboBox();
            this.rdoYearly_The = new System.Windows.Forms.RadioButton();
            this.rdoYearly_Every = new System.Windows.Forms.RadioButton();
            this.pnlMonthly = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.numericFreq = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbMonthlyWeek = new System.Windows.Forms.ComboBox();
            this.cmbMonthWeekDay = new System.Windows.Forms.ComboBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.rdoMonthly_Day = new System.Windows.Forms.RadioButton();
            this.numericMonthly_MonthRec = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.numericMonthly_day = new System.Windows.Forms.NumericUpDown();
            this.pnlWeekly = new System.Windows.Forms.Panel();
            this.numericWeekly = new System.Windows.Forms.NumericUpDown();
            this.chkWeekly_Saturday = new System.Windows.Forms.CheckBox();
            this.chkWeekly_Friday = new System.Windows.Forms.CheckBox();
            this.chkWeekly_Thursday = new System.Windows.Forms.CheckBox();
            this.chkWeekly_Wednesday = new System.Windows.Forms.CheckBox();
            this.chkWeekly_Tuesday = new System.Windows.Forms.CheckBox();
            this.chkWeekly_Monday = new System.Windows.Forms.CheckBox();
            this.chkWeekly_Sunday = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pnlDaily = new System.Windows.Forms.Panel();
            this.numericDailyDays = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.rdoDaily_WeekDay = new System.Windows.Forms.RadioButton();
            this.rdoDaily_EveryDay = new System.Windows.Forms.RadioButton();
            this.dtExpireTime = new System.Windows.Forms.DateTimePicker();
            this.dtExpireDate = new System.Windows.Forms.DateTimePicker();
            this.chkExpire = new System.Windows.Forms.CheckBox();
            this.dtStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtStartTime = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rdoYearly = new System.Windows.Forms.RadioButton();
            this.rdoMonthly = new System.Windows.Forms.RadioButton();
            this.rdoWeekly = new System.Windows.Forms.RadioButton();
            this.rdoDaily = new System.Windows.Forms.RadioButton();
            this.cmbJobType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaxRunCount)).BeginInit();
            this.panel1.SuspendLayout();
            this.pnlYearly.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_YearlyNominalDay)).BeginInit();
            this.pnlMonthly.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericFreq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMonthly_MonthRec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMonthly_day)).BeginInit();
            this.pnlWeekly.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericWeekly)).BeginInit();
            this.pnlDaily.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericDailyDays)).BeginInit();
            this.SuspendLayout();
            // 
            // Header
            // 
            this.Header.BackColor = System.Drawing.SystemColors.Control;
            this.Header.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Header.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Header.Enabled = false;
            this.Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Header.ForeColor = System.Drawing.Color.DimGray;
            this.Header.Location = new System.Drawing.Point(0, 0);
            this.Header.Name = "Header";
            this.Header.Size = new System.Drawing.Size(784, 31);
            this.Header.TabIndex = 6;
            this.Header.Text = "Trigger Scheduler";
            this.Header.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(0, 56);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(784, 505);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnSaveJob);
            this.tabPage1.Controls.Add(this.txtMaxRunCount);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.dtExpireTime);
            this.tabPage1.Controls.Add(this.dtExpireDate);
            this.tabPage1.Controls.Add(this.chkExpire);
            this.tabPage1.Controls.Add(this.dtStartDate);
            this.tabPage1.Controls.Add(this.dtStartTime);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.txtDescription);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txtName);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.rdoYearly);
            this.tabPage1.Controls.Add(this.rdoMonthly);
            this.tabPage1.Controls.Add(this.rdoWeekly);
            this.tabPage1.Controls.Add(this.rdoDaily);
            this.tabPage1.Controls.Add(this.cmbJobType);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(776, 479);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Scheduler";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnSaveJob
            // 
            this.btnSaveJob.Location = new System.Drawing.Point(18, 428);
            this.btnSaveJob.Name = "btnSaveJob";
            this.btnSaveJob.Size = new System.Drawing.Size(75, 23);
            this.btnSaveJob.TabIndex = 76;
            this.btnSaveJob.Text = "Create Job";
            this.btnSaveJob.UseVisualStyleBackColor = true;
            this.btnSaveJob.Click += new System.EventHandler(this.btnSaveJob_Click);
            // 
            // txtMaxRunCount
            // 
            this.txtMaxRunCount.Location = new System.Drawing.Point(108, 384);
            this.txtMaxRunCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtMaxRunCount.Name = "txtMaxRunCount";
            this.txtMaxRunCount.Size = new System.Drawing.Size(82, 20);
            this.txtMaxRunCount.TabIndex = 75;
            this.txtMaxRunCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(20, 386);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(74, 13);
            this.label11.TabIndex = 74;
            this.label11.Text = "Maximum Run";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.pnlYearly);
            this.panel1.Controls.Add(this.pnlMonthly);
            this.panel1.Controls.Add(this.pnlWeekly);
            this.panel1.Controls.Add(this.pnlDaily);
            this.panel1.Location = new System.Drawing.Point(108, 172);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(665, 206);
            this.panel1.TabIndex = 73;
            // 
            // pnlYearly
            // 
            this.pnlYearly.Controls.Add(this.cmbYearlyMonthWeek);
            this.pnlYearly.Controls.Add(this.cmbYearlyWeekDay);
            this.pnlYearly.Controls.Add(this.cmbYearlyDay);
            this.pnlYearly.Controls.Add(this.numeric_YearlyNominalDay);
            this.pnlYearly.Controls.Add(this.cmbYearly_Month);
            this.pnlYearly.Controls.Add(this.rdoYearly_The);
            this.pnlYearly.Controls.Add(this.rdoYearly_Every);
            this.pnlYearly.Location = new System.Drawing.Point(3, 86);
            this.pnlYearly.Name = "pnlYearly";
            this.pnlYearly.Size = new System.Drawing.Size(218, 159);
            this.pnlYearly.TabIndex = 75;
            this.pnlYearly.Visible = false;
            // 
            // cmbYearlyMonthWeek
            // 
            this.cmbYearlyMonthWeek.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYearlyMonthWeek.FormattingEnabled = true;
            this.cmbYearlyMonthWeek.Location = new System.Drawing.Point(95, 126);
            this.cmbYearlyMonthWeek.Name = "cmbYearlyMonthWeek";
            this.cmbYearlyMonthWeek.Size = new System.Drawing.Size(82, 21);
            this.cmbYearlyMonthWeek.TabIndex = 94;
            // 
            // cmbYearlyWeekDay
            // 
            this.cmbYearlyWeekDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYearlyWeekDay.FormattingEnabled = true;
            this.cmbYearlyWeekDay.Location = new System.Drawing.Point(95, 99);
            this.cmbYearlyWeekDay.Name = "cmbYearlyWeekDay";
            this.cmbYearlyWeekDay.Size = new System.Drawing.Size(82, 21);
            this.cmbYearlyWeekDay.TabIndex = 93;
            // 
            // cmbYearlyDay
            // 
            this.cmbYearlyDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYearlyDay.FormattingEnabled = true;
            this.cmbYearlyDay.Location = new System.Drawing.Point(95, 72);
            this.cmbYearlyDay.Name = "cmbYearlyDay";
            this.cmbYearlyDay.Size = new System.Drawing.Size(82, 21);
            this.cmbYearlyDay.TabIndex = 92;
            // 
            // numeric_YearlyNominalDay
            // 
            this.numeric_YearlyNominalDay.Location = new System.Drawing.Point(95, 44);
            this.numeric_YearlyNominalDay.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.numeric_YearlyNominalDay.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numeric_YearlyNominalDay.Name = "numeric_YearlyNominalDay";
            this.numeric_YearlyNominalDay.Size = new System.Drawing.Size(82, 20);
            this.numeric_YearlyNominalDay.TabIndex = 91;
            this.numeric_YearlyNominalDay.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cmbYearly_Month
            // 
            this.cmbYearly_Month.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYearly_Month.FormattingEnabled = true;
            this.cmbYearly_Month.Location = new System.Drawing.Point(95, 15);
            this.cmbYearly_Month.Name = "cmbYearly_Month";
            this.cmbYearly_Month.Size = new System.Drawing.Size(82, 21);
            this.cmbYearly_Month.TabIndex = 90;
            // 
            // rdoYearly_The
            // 
            this.rdoYearly_The.AutoSize = true;
            this.rdoYearly_The.Location = new System.Drawing.Point(15, 72);
            this.rdoYearly_The.Name = "rdoYearly_The";
            this.rdoYearly_The.Size = new System.Drawing.Size(44, 17);
            this.rdoYearly_The.TabIndex = 1;
            this.rdoYearly_The.TabStop = true;
            this.rdoYearly_The.Text = "The";
            this.rdoYearly_The.UseVisualStyleBackColor = true;
            // 
            // rdoYearly_Every
            // 
            this.rdoYearly_Every.AutoSize = true;
            this.rdoYearly_Every.Location = new System.Drawing.Point(15, 16);
            this.rdoYearly_Every.Name = "rdoYearly_Every";
            this.rdoYearly_Every.Size = new System.Drawing.Size(52, 17);
            this.rdoYearly_Every.TabIndex = 0;
            this.rdoYearly_Every.TabStop = true;
            this.rdoYearly_Every.Text = "Every";
            this.rdoYearly_Every.UseVisualStyleBackColor = true;
            // 
            // pnlMonthly
            // 
            this.pnlMonthly.Controls.Add(this.label10);
            this.pnlMonthly.Controls.Add(this.numericFreq);
            this.pnlMonthly.Controls.Add(this.label9);
            this.pnlMonthly.Controls.Add(this.cmbMonthlyWeek);
            this.pnlMonthly.Controls.Add(this.cmbMonthWeekDay);
            this.pnlMonthly.Controls.Add(this.radioButton1);
            this.pnlMonthly.Controls.Add(this.label7);
            this.pnlMonthly.Controls.Add(this.rdoMonthly_Day);
            this.pnlMonthly.Controls.Add(this.numericMonthly_MonthRec);
            this.pnlMonthly.Controls.Add(this.label8);
            this.pnlMonthly.Controls.Add(this.numericMonthly_day);
            this.pnlMonthly.Location = new System.Drawing.Point(227, 3);
            this.pnlMonthly.Name = "pnlMonthly";
            this.pnlMonthly.Size = new System.Drawing.Size(201, 172);
            this.pnlMonthly.TabIndex = 74;
            this.pnlMonthly.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(153, 129);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 13);
            this.label10.TabIndex = 93;
            this.label10.Text = "month(s)";
            // 
            // numericFreq
            // 
            this.numericFreq.Location = new System.Drawing.Point(65, 127);
            this.numericFreq.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericFreq.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericFreq.Name = "numericFreq";
            this.numericFreq.Size = new System.Drawing.Size(82, 20);
            this.numericFreq.TabIndex = 92;
            this.numericFreq.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 127);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 13);
            this.label9.TabIndex = 91;
            this.label9.Text = "Of Every";
            // 
            // cmbMonthlyWeek
            // 
            this.cmbMonthlyWeek.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMonthlyWeek.FormattingEnabled = true;
            this.cmbMonthlyWeek.Items.AddRange(new object[] {
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday",
            "Sunday"});
            this.cmbMonthlyWeek.Location = new System.Drawing.Point(65, 99);
            this.cmbMonthlyWeek.Name = "cmbMonthlyWeek";
            this.cmbMonthlyWeek.Size = new System.Drawing.Size(82, 21);
            this.cmbMonthlyWeek.TabIndex = 90;
            // 
            // cmbMonthWeekDay
            // 
            this.cmbMonthWeekDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMonthWeekDay.FormattingEnabled = true;
            this.cmbMonthWeekDay.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.cmbMonthWeekDay.Location = new System.Drawing.Point(65, 72);
            this.cmbMonthWeekDay.Name = "cmbMonthWeekDay";
            this.cmbMonthWeekDay.Size = new System.Drawing.Size(82, 21);
            this.cmbMonthWeekDay.TabIndex = 89;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(16, 73);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(44, 17);
            this.radioButton1.TabIndex = 88;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "The";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(153, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 87;
            this.label7.Text = "month(s)";
            // 
            // rdoMonthly_Day
            // 
            this.rdoMonthly_Day.AutoSize = true;
            this.rdoMonthly_Day.Location = new System.Drawing.Point(15, 13);
            this.rdoMonthly_Day.Name = "rdoMonthly_Day";
            this.rdoMonthly_Day.Size = new System.Drawing.Size(44, 17);
            this.rdoMonthly_Day.TabIndex = 86;
            this.rdoMonthly_Day.TabStop = true;
            this.rdoMonthly_Day.Text = "Day";
            this.rdoMonthly_Day.UseVisualStyleBackColor = true;
            // 
            // numericMonthly_MonthRec
            // 
            this.numericMonthly_MonthRec.Location = new System.Drawing.Point(65, 39);
            this.numericMonthly_MonthRec.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericMonthly_MonthRec.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericMonthly_MonthRec.Name = "numericMonthly_MonthRec";
            this.numericMonthly_MonthRec.Size = new System.Drawing.Size(82, 20);
            this.numericMonthly_MonthRec.TabIndex = 85;
            this.numericMonthly_MonthRec.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 13);
            this.label8.TabIndex = 84;
            this.label8.Text = "Of Every";
            // 
            // numericMonthly_day
            // 
            this.numericMonthly_day.Location = new System.Drawing.Point(65, 12);
            this.numericMonthly_day.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.numericMonthly_day.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericMonthly_day.Name = "numericMonthly_day";
            this.numericMonthly_day.Size = new System.Drawing.Size(82, 20);
            this.numericMonthly_day.TabIndex = 83;
            this.numericMonthly_day.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // pnlWeekly
            // 
            this.pnlWeekly.Controls.Add(this.numericWeekly);
            this.pnlWeekly.Controls.Add(this.chkWeekly_Saturday);
            this.pnlWeekly.Controls.Add(this.chkWeekly_Friday);
            this.pnlWeekly.Controls.Add(this.chkWeekly_Thursday);
            this.pnlWeekly.Controls.Add(this.chkWeekly_Wednesday);
            this.pnlWeekly.Controls.Add(this.chkWeekly_Tuesday);
            this.pnlWeekly.Controls.Add(this.chkWeekly_Monday);
            this.pnlWeekly.Controls.Add(this.chkWeekly_Sunday);
            this.pnlWeekly.Controls.Add(this.label6);
            this.pnlWeekly.Location = new System.Drawing.Point(429, 9);
            this.pnlWeekly.Name = "pnlWeekly";
            this.pnlWeekly.Size = new System.Drawing.Size(237, 110);
            this.pnlWeekly.TabIndex = 73;
            this.pnlWeekly.Visible = false;
            // 
            // numericWeekly
            // 
            this.numericWeekly.Location = new System.Drawing.Point(105, 12);
            this.numericWeekly.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericWeekly.Name = "numericWeekly";
            this.numericWeekly.Size = new System.Drawing.Size(82, 20);
            this.numericWeekly.TabIndex = 82;
            this.numericWeekly.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // chkWeekly_Saturday
            // 
            this.chkWeekly_Saturday.AutoSize = true;
            this.chkWeekly_Saturday.Location = new System.Drawing.Point(170, 38);
            this.chkWeekly_Saturday.Name = "chkWeekly_Saturday";
            this.chkWeekly_Saturday.Size = new System.Drawing.Size(68, 17);
            this.chkWeekly_Saturday.TabIndex = 81;
            this.chkWeekly_Saturday.Text = "Saturday";
            this.chkWeekly_Saturday.UseVisualStyleBackColor = true;
            // 
            // chkWeekly_Friday
            // 
            this.chkWeekly_Friday.AutoSize = true;
            this.chkWeekly_Friday.Location = new System.Drawing.Point(89, 84);
            this.chkWeekly_Friday.Name = "chkWeekly_Friday";
            this.chkWeekly_Friday.Size = new System.Drawing.Size(54, 17);
            this.chkWeekly_Friday.TabIndex = 80;
            this.chkWeekly_Friday.Text = "Friday";
            this.chkWeekly_Friday.UseVisualStyleBackColor = true;
            // 
            // chkWeekly_Thursday
            // 
            this.chkWeekly_Thursday.AutoSize = true;
            this.chkWeekly_Thursday.Location = new System.Drawing.Point(89, 62);
            this.chkWeekly_Thursday.Name = "chkWeekly_Thursday";
            this.chkWeekly_Thursday.Size = new System.Drawing.Size(70, 17);
            this.chkWeekly_Thursday.TabIndex = 79;
            this.chkWeekly_Thursday.Text = "Thursday";
            this.chkWeekly_Thursday.UseVisualStyleBackColor = true;
            // 
            // chkWeekly_Wednesday
            // 
            this.chkWeekly_Wednesday.AutoSize = true;
            this.chkWeekly_Wednesday.Location = new System.Drawing.Point(89, 39);
            this.chkWeekly_Wednesday.Name = "chkWeekly_Wednesday";
            this.chkWeekly_Wednesday.Size = new System.Drawing.Size(83, 17);
            this.chkWeekly_Wednesday.TabIndex = 78;
            this.chkWeekly_Wednesday.Text = "Wednesday";
            this.chkWeekly_Wednesday.UseVisualStyleBackColor = true;
            // 
            // chkWeekly_Tuesday
            // 
            this.chkWeekly_Tuesday.AutoSize = true;
            this.chkWeekly_Tuesday.Location = new System.Drawing.Point(21, 83);
            this.chkWeekly_Tuesday.Name = "chkWeekly_Tuesday";
            this.chkWeekly_Tuesday.Size = new System.Drawing.Size(67, 17);
            this.chkWeekly_Tuesday.TabIndex = 77;
            this.chkWeekly_Tuesday.Text = "Tuesday";
            this.chkWeekly_Tuesday.UseVisualStyleBackColor = true;
            // 
            // chkWeekly_Monday
            // 
            this.chkWeekly_Monday.AutoSize = true;
            this.chkWeekly_Monday.Location = new System.Drawing.Point(21, 62);
            this.chkWeekly_Monday.Name = "chkWeekly_Monday";
            this.chkWeekly_Monday.Size = new System.Drawing.Size(64, 17);
            this.chkWeekly_Monday.TabIndex = 76;
            this.chkWeekly_Monday.Text = "Monday";
            this.chkWeekly_Monday.UseVisualStyleBackColor = true;
            // 
            // chkWeekly_Sunday
            // 
            this.chkWeekly_Sunday.AutoSize = true;
            this.chkWeekly_Sunday.Location = new System.Drawing.Point(21, 39);
            this.chkWeekly_Sunday.Name = "chkWeekly_Sunday";
            this.chkWeekly_Sunday.Size = new System.Drawing.Size(62, 17);
            this.chkWeekly_Sunday.TabIndex = 75;
            this.chkWeekly_Sunday.Text = "Sunday";
            this.chkWeekly_Sunday.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(36, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 74;
            this.label6.Text = "Recur Days";
            // 
            // pnlDaily
            // 
            this.pnlDaily.Controls.Add(this.numericDailyDays);
            this.pnlDaily.Controls.Add(this.label5);
            this.pnlDaily.Controls.Add(this.rdoDaily_WeekDay);
            this.pnlDaily.Controls.Add(this.rdoDaily_EveryDay);
            this.pnlDaily.Location = new System.Drawing.Point(3, 3);
            this.pnlDaily.Name = "pnlDaily";
            this.pnlDaily.Size = new System.Drawing.Size(218, 72);
            this.pnlDaily.TabIndex = 72;
            this.pnlDaily.Visible = false;
            // 
            // numericDailyDays
            // 
            this.numericDailyDays.Location = new System.Drawing.Point(95, 14);
            this.numericDailyDays.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericDailyDays.Name = "numericDailyDays";
            this.numericDailyDays.Size = new System.Drawing.Size(82, 20);
            this.numericDailyDays.TabIndex = 74;
            this.numericDailyDays.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(183, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 73;
            this.label5.Text = "Days";
            // 
            // rdoDaily_WeekDay
            // 
            this.rdoDaily_WeekDay.AutoSize = true;
            this.rdoDaily_WeekDay.Location = new System.Drawing.Point(15, 41);
            this.rdoDaily_WeekDay.Name = "rdoDaily_WeekDay";
            this.rdoDaily_WeekDay.Size = new System.Drawing.Size(76, 17);
            this.rdoDaily_WeekDay.TabIndex = 1;
            this.rdoDaily_WeekDay.TabStop = true;
            this.rdoDaily_WeekDay.Text = "Week Day";
            this.rdoDaily_WeekDay.UseVisualStyleBackColor = true;
            // 
            // rdoDaily_EveryDay
            // 
            this.rdoDaily_EveryDay.AutoSize = true;
            this.rdoDaily_EveryDay.Checked = true;
            this.rdoDaily_EveryDay.Location = new System.Drawing.Point(15, 18);
            this.rdoDaily_EveryDay.Name = "rdoDaily_EveryDay";
            this.rdoDaily_EveryDay.Size = new System.Drawing.Size(74, 17);
            this.rdoDaily_EveryDay.TabIndex = 0;
            this.rdoDaily_EveryDay.TabStop = true;
            this.rdoDaily_EveryDay.Text = "Every Day";
            this.rdoDaily_EveryDay.UseVisualStyleBackColor = true;
            // 
            // dtExpireTime
            // 
            this.dtExpireTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtExpireTime.Location = new System.Drawing.Point(572, 119);
            this.dtExpireTime.Name = "dtExpireTime";
            this.dtExpireTime.ShowUpDown = true;
            this.dtExpireTime.Size = new System.Drawing.Size(105, 20);
            this.dtExpireTime.TabIndex = 71;
            // 
            // dtExpireDate
            // 
            this.dtExpireDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtExpireDate.Location = new System.Drawing.Point(436, 120);
            this.dtExpireDate.Name = "dtExpireDate";
            this.dtExpireDate.Size = new System.Drawing.Size(120, 20);
            this.dtExpireDate.TabIndex = 70;
            // 
            // chkExpire
            // 
            this.chkExpire.AutoSize = true;
            this.chkExpire.Location = new System.Drawing.Point(375, 122);
            this.chkExpire.Name = "chkExpire";
            this.chkExpire.Size = new System.Drawing.Size(55, 17);
            this.chkExpire.TabIndex = 69;
            this.chkExpire.Text = "Expire";
            this.chkExpire.UseVisualStyleBackColor = true;
            this.chkExpire.CheckedChanged += new System.EventHandler(this.chkExpire_CheckedChanged);
            // 
            // dtStartDate
            // 
            this.dtStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtStartDate.Location = new System.Drawing.Point(106, 120);
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.Size = new System.Drawing.Size(120, 20);
            this.dtStartDate.TabIndex = 68;
            // 
            // dtStartTime
            // 
            this.dtStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtStartTime.Location = new System.Drawing.Point(241, 120);
            this.dtStartTime.Name = "dtStartTime";
            this.dtStartTime.ShowUpDown = true;
            this.dtStartTime.Size = new System.Drawing.Size(105, 20);
            this.dtStartTime.TabIndex = 67;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 66;
            this.label4.Text = "Start Date";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(106, 55);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(630, 44);
            this.txtDescription.TabIndex = 65;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 64;
            this.label3.Text = "Description";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(493, 14);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(243, 20);
            this.txtName.TabIndex = 63;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(412, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 62;
            this.label2.Text = "Job Name";
            // 
            // rdoYearly
            // 
            this.rdoYearly.AutoSize = true;
            this.rdoYearly.Location = new System.Drawing.Point(33, 264);
            this.rdoYearly.Name = "rdoYearly";
            this.rdoYearly.Size = new System.Drawing.Size(54, 17);
            this.rdoYearly.TabIndex = 61;
            this.rdoYearly.TabStop = true;
            this.rdoYearly.Text = "Yearly";
            this.rdoYearly.UseVisualStyleBackColor = true;
            this.rdoYearly.CheckedChanged += new System.EventHandler(this.rdoYearly_CheckedChanged);
            // 
            // rdoMonthly
            // 
            this.rdoMonthly.AutoSize = true;
            this.rdoMonthly.Location = new System.Drawing.Point(32, 241);
            this.rdoMonthly.Name = "rdoMonthly";
            this.rdoMonthly.Size = new System.Drawing.Size(62, 17);
            this.rdoMonthly.TabIndex = 60;
            this.rdoMonthly.TabStop = true;
            this.rdoMonthly.Text = "Monthly";
            this.rdoMonthly.UseVisualStyleBackColor = true;
            this.rdoMonthly.CheckedChanged += new System.EventHandler(this.rdoMonthly_CheckedChanged);
            // 
            // rdoWeekly
            // 
            this.rdoWeekly.AutoSize = true;
            this.rdoWeekly.Location = new System.Drawing.Point(32, 218);
            this.rdoWeekly.Name = "rdoWeekly";
            this.rdoWeekly.Size = new System.Drawing.Size(61, 17);
            this.rdoWeekly.TabIndex = 59;
            this.rdoWeekly.TabStop = true;
            this.rdoWeekly.Text = "Weekly";
            this.rdoWeekly.UseVisualStyleBackColor = true;
            this.rdoWeekly.CheckedChanged += new System.EventHandler(this.rdoWeekly_CheckedChanged);
            // 
            // rdoDaily
            // 
            this.rdoDaily.AutoSize = true;
            this.rdoDaily.Location = new System.Drawing.Point(33, 195);
            this.rdoDaily.Name = "rdoDaily";
            this.rdoDaily.Size = new System.Drawing.Size(48, 17);
            this.rdoDaily.TabIndex = 58;
            this.rdoDaily.TabStop = true;
            this.rdoDaily.Text = "Daily";
            this.rdoDaily.UseVisualStyleBackColor = true;
            this.rdoDaily.CheckedChanged += new System.EventHandler(this.rdoDaily_CheckedChanged);
            // 
            // cmbJobType
            // 
            this.cmbJobType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbJobType.DropDownWidth = 150;
            this.cmbJobType.FormattingEnabled = true;
            this.cmbJobType.Location = new System.Drawing.Point(106, 13);
            this.cmbJobType.Name = "cmbJobType";
            this.cmbJobType.Size = new System.Drawing.Size(150, 21);
            this.cmbJobType.TabIndex = 57;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Job Type";
            // 
            // AddEditScheduler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.Header);
            this.Name = "AddEditScheduler";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaxRunCount)).EndInit();
            this.panel1.ResumeLayout(false);
            this.pnlYearly.ResumeLayout(false);
            this.pnlYearly.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_YearlyNominalDay)).EndInit();
            this.pnlMonthly.ResumeLayout(false);
            this.pnlMonthly.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericFreq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMonthly_MonthRec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMonthly_day)).EndInit();
            this.pnlWeekly.ResumeLayout(false);
            this.pnlWeekly.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericWeekly)).EndInit();
            this.pnlDaily.ResumeLayout(false);
            this.pnlDaily.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericDailyDays)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Header;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbJobType;
        private System.Windows.Forms.RadioButton rdoWeekly;
        private System.Windows.Forms.RadioButton rdoDaily;
        private System.Windows.Forms.RadioButton rdoYearly;
        private System.Windows.Forms.RadioButton rdoMonthly;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtStartDate;
        private System.Windows.Forms.DateTimePicker dtStartTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtExpireTime;
        private System.Windows.Forms.DateTimePicker dtExpireDate;
        private System.Windows.Forms.CheckBox chkExpire;
        private System.Windows.Forms.Panel pnlDaily;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rdoDaily_WeekDay;
        private System.Windows.Forms.RadioButton rdoDaily_EveryDay;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlWeekly;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkWeekly_Saturday;
        private System.Windows.Forms.CheckBox chkWeekly_Friday;
        private System.Windows.Forms.CheckBox chkWeekly_Thursday;
        private System.Windows.Forms.CheckBox chkWeekly_Wednesday;
        private System.Windows.Forms.CheckBox chkWeekly_Tuesday;
        private System.Windows.Forms.CheckBox chkWeekly_Monday;
        private System.Windows.Forms.CheckBox chkWeekly_Sunday;
        private System.Windows.Forms.NumericUpDown numericDailyDays;
        private System.Windows.Forms.NumericUpDown numericWeekly;
        private System.Windows.Forms.Panel pnlMonthly;
        private System.Windows.Forms.NumericUpDown numericMonthly_day;
        private System.Windows.Forms.RadioButton rdoMonthly_Day;
        private System.Windows.Forms.NumericUpDown numericMonthly_MonthRec;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numericFreq;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbMonthlyWeek;
        private System.Windows.Forms.ComboBox cmbMonthWeekDay;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Panel pnlYearly;
        private System.Windows.Forms.ComboBox cmbYearly_Month;
        private System.Windows.Forms.RadioButton rdoYearly_The;
        private System.Windows.Forms.RadioButton rdoYearly_Every;
        private System.Windows.Forms.ComboBox cmbYearlyMonthWeek;
        private System.Windows.Forms.ComboBox cmbYearlyDay;
        private System.Windows.Forms.NumericUpDown numeric_YearlyNominalDay;
        private System.Windows.Forms.Button btnSaveJob;
        private System.Windows.Forms.NumericUpDown txtMaxRunCount;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbYearlyWeekDay;
    }
}

