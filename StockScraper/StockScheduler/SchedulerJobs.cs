using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DLL;
using BLL;

namespace StockScheduler
{
    public partial class SchedulerJobs : Form
    {
        public SchedulerJobs()
        {
            InitializeComponent();
            BindGrid();
        }

        private void InitilizeDataGridViewStyle()
        {
            // Setting the style of the DataGridView control
            grdJobs.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold, GraphicsUnit.Point);
            grdJobs.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.ControlDark;
            grdJobs.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            grdJobs.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdJobs.DefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Regular, GraphicsUnit.Point);
            grdJobs.DefaultCellStyle.BackColor = Color.Empty;
            grdJobs.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.Info;
            grdJobs.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            grdJobs.GridColor = SystemColors.ControlDarkDark;
        }

        private void InitilizeJobRunDataGridViewStyle()
        {
            // Setting the style of the DataGridView control
            grdJobRuns.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold, GraphicsUnit.Point);
            grdJobRuns.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.ControlDark;
            grdJobRuns.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            grdJobRuns.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdJobRuns.DefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Regular, GraphicsUnit.Point);
            grdJobRuns.DefaultCellStyle.BackColor = Color.Empty;
            grdJobRuns.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.Info;
            grdJobRuns.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            grdJobRuns.GridColor = SystemColors.ControlDarkDark;
        }

        private void InitilizeJobRecordCountDataGridViewStyle()
        {
            // Setting the style of the DataGridView control

            grdRecordCount.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold, GraphicsUnit.Point);
            grdRecordCount.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.ControlDark;
            grdRecordCount.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            grdRecordCount.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdRecordCount.DefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Regular, GraphicsUnit.Point);
            grdRecordCount.DefaultCellStyle.BackColor = Color.Empty;
            grdRecordCount.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.Info;
            grdRecordCount.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            grdRecordCount.GridColor = SystemColors.ControlDarkDark;
        }


        protected void BindGrid()
        {
            grdJobs.DataSource = null;
            grdJobs.Rows.Clear();
            grdJobs.Columns.Clear();

            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            worker.RunWorkerAsync();
        }
        List<p_GetJobScheduler_Result> jobRecord = new List<p_GetJobScheduler_Result>();
        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            jobRecord = ws_JobSchedulerServices.Instance.GetScheduler(0, txtJobName.Text);
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            InitilizeDataGridViewStyle();
            grdJobs.DataSource = jobRecord;

            cmbRunStatus.ValueMember = "SchedulerId";
            cmbRunStatus.DisplayMember = "Name";
            cmbRunStatus.DataSource = jobRecord;

            cmbScheduler.ValueMember = "SchedulerId";
            cmbScheduler.DisplayMember = "Name";
            cmbScheduler.DataSource = jobRecord;
            

            BindJobRunGrid();
            BindRecordCount();

            DataGridViewLinkColumn EditFeedLink = new DataGridViewLinkColumn();
            EditFeedLink.UseColumnTextForLinkValue = true;
            EditFeedLink.HeaderText = "Edit";
            EditFeedLink.Name = "Edit";
            EditFeedLink.LinkColor = Color.Blue;
            EditFeedLink.TrackVisitedState = false;
            EditFeedLink.Text = "Edit";
            EditFeedLink.DisplayIndex = 0;
            grdJobs.Columns.Add(EditFeedLink);
         
        }

        private void btnAddNewJob_Click(object sender, EventArgs e)
        {
            AddEditScheduler obj = new AddEditScheduler();
            obj.Show();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void grdJobs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //int DeleteJobindex = grdJobs.Columns["DeleteJob"].Index;
            int Editcolindex = grdJobs.Columns["Edit"].Index;
            if (e.ColumnIndex == Editcolindex)
            {
                int SchedulerId = 0;
                int.TryParse(grdJobs.Rows[e.RowIndex].Cells["SchedulerId"].Value.ToString(), out SchedulerId);
                AddEditScheduler obj = new AddEditScheduler(SchedulerId);
                obj.ShowDialog();
            }

            //if (e.ColumnIndex == DeleteJobindex)
            //{

            //}
        }

        private void cmbRunStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            int.TryParse(cmbRunStatus.SelectedValue.ToString(), out temp_schedulerid);
            BindJobRunGrid();
        }

        protected void BindJobRunGrid()
        {

            grdJobRuns.DataSource = null;
            grdJobRuns.Rows.Clear();
            grdJobRuns.Columns.Clear();

            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(worker_JobRunDoWork);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_JobRunRunWorkerCompleted);
            worker.RunWorkerAsync();
        }

        List<p_GetJobRunForScheduler_Result> jobRunRecord = new List<p_GetJobRunForScheduler_Result>();
        int temp_schedulerid = 0;
        void worker_JobRunDoWork(object sender, DoWorkEventArgs e)
        {     
            
            jobRunRecord = ws_JobRunsService.Instance.GetJobRunForScheduler(temp_schedulerid);
        }

        void worker_JobRunRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            InitilizeJobRunDataGridViewStyle();
            grdJobRuns.DataSource = jobRunRecord;
        }

        private void cmbScheduler_SelectedIndexChanged(object sender, EventArgs e)
        {

            int.TryParse(cmbScheduler.SelectedValue.ToString(), out temp_schedulerid1);
            BindRecordCount();
        }

        public void BindRecordCount()
        {
            grdRecordCount.DataSource = null;
            grdRecordCount.Rows.Clear();
            grdRecordCount.Columns.Clear();

            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(worker_RecordCountDoWork);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RecordCountWorkerCompleted);
            worker.RunWorkerAsync();
        }

        List<p_GetRecordCountForJob_Result> jobRecordCount = new List<p_GetRecordCountForJob_Result>();
        int temp_schedulerid1 = 0;
        void worker_RecordCountDoWork(object sender, DoWorkEventArgs e)
        {

            jobRecordCount = ws_JobsServices.Instance.GetRecordCountForJob(temp_schedulerid1);
        }

        void worker_RecordCountWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            InitilizeJobRecordCountDataGridViewStyle();
            grdRecordCount.DataSource = jobRecordCount;
        }
    }
}
