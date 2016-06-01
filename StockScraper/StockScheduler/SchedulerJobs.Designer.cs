namespace StockScheduler
{
    partial class SchedulerJobs
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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.grdJobs = new System.Windows.Forms.DataGridView();
            this.btnAddNewJob = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtJobName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.grdJobRuns = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbRunStatus = new System.Windows.Forms.ComboBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbScheduler = new System.Windows.Forms.ComboBox();
            this.grdRecordCount = new System.Windows.Forms.DataGridView();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdJobs)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdJobRuns)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRecordCount)).BeginInit();
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
            this.Header.TabIndex = 3;
            this.Header.Text = "Scheduled Jobs";
            this.Header.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.grdJobs);
            this.tabPage1.Controls.Add(this.btnAddNewJob);
            this.tabPage1.Controls.Add(this.btnSearch);
            this.tabPage1.Controls.Add(this.txtJobName);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(776, 480);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Search Jobs";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // grdJobs
            // 
            this.grdJobs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdJobs.Location = new System.Drawing.Point(0, 86);
            this.grdJobs.Name = "grdJobs";
            this.grdJobs.Size = new System.Drawing.Size(776, 391);
            this.grdJobs.TabIndex = 5;
            this.grdJobs.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdJobs_CellContentClick);
            // 
            // btnAddNewJob
            // 
            this.btnAddNewJob.Location = new System.Drawing.Point(405, 31);
            this.btnAddNewJob.Name = "btnAddNewJob";
            this.btnAddNewJob.Size = new System.Drawing.Size(112, 23);
            this.btnAddNewJob.TabIndex = 4;
            this.btnAddNewJob.Text = "Add New Job";
            this.btnAddNewJob.UseVisualStyleBackColor = true;
            this.btnAddNewJob.Click += new System.EventHandler(this.btnAddNewJob_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(286, 31);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtJobName
            // 
            this.txtJobName.Location = new System.Drawing.Point(30, 31);
            this.txtJobName.Name = "txtJobName";
            this.txtJobName.Size = new System.Drawing.Size(194, 20);
            this.txtJobName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Job Name";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(0, 58);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(784, 506);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.grdJobRuns);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.cmbRunStatus);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(776, 480);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Job Run Status";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // grdJobRuns
            // 
            this.grdJobRuns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdJobRuns.Location = new System.Drawing.Point(3, 90);
            this.grdJobRuns.Name = "grdJobRuns";
            this.grdJobRuns.Size = new System.Drawing.Size(770, 387);
            this.grdJobRuns.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Select Scheduler ";
            // 
            // cmbRunStatus
            // 
            this.cmbRunStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRunStatus.FormattingEnabled = true;
            this.cmbRunStatus.Location = new System.Drawing.Point(126, 35);
            this.cmbRunStatus.Name = "cmbRunStatus";
            this.cmbRunStatus.Size = new System.Drawing.Size(207, 21);
            this.cmbRunStatus.TabIndex = 0;
            this.cmbRunStatus.SelectedIndexChanged += new System.EventHandler(this.cmbRunStatus_SelectedIndexChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.grdRecordCount);
            this.tabPage3.Controls.Add(this.cmbScheduler);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(776, 480);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Record Count";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Select Scheduler ";
            // 
            // cmbScheduler
            // 
            this.cmbScheduler.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbScheduler.FormattingEnabled = true;
            this.cmbScheduler.Location = new System.Drawing.Point(143, 38);
            this.cmbScheduler.Name = "cmbScheduler";
            this.cmbScheduler.Size = new System.Drawing.Size(169, 21);
            this.cmbScheduler.TabIndex = 3;
            this.cmbScheduler.SelectedIndexChanged += new System.EventHandler(this.cmbScheduler_SelectedIndexChanged);
            // 
            // grdRecordCount
            // 
            this.grdRecordCount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdRecordCount.Location = new System.Drawing.Point(3, 85);
            this.grdRecordCount.Name = "grdRecordCount";
            this.grdRecordCount.Size = new System.Drawing.Size(770, 395);
            this.grdRecordCount.TabIndex = 4;
            // 
            // SchedulerJobs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.Header);
            this.Name = "SchedulerJobs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdJobs)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdJobRuns)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRecordCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Header;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnAddNewJob;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtJobName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.DataGridView grdJobs;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView grdJobRuns;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbRunStatus;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView grdRecordCount;
        private System.Windows.Forms.ComboBox cmbScheduler;
        private System.Windows.Forms.Label label3;
    }
}