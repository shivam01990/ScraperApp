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
            

            DataGridViewLinkColumn DeleteFeedLink = new DataGridViewLinkColumn();
            DeleteFeedLink.UseColumnTextForLinkValue = true;
            DeleteFeedLink.HeaderText = "Delete";
            DeleteFeedLink.Name = "DeleteJob";
            DeleteFeedLink.LinkColor = Color.Blue;
            DeleteFeedLink.TrackVisitedState = false;
            DeleteFeedLink.Text = "Delete";
            grdJobs.Columns.Add(DeleteFeedLink);

            DataGridViewLinkColumn EditFeedLink = new DataGridViewLinkColumn();
            EditFeedLink.UseColumnTextForLinkValue = true;
            EditFeedLink.HeaderText = "Edit";
            EditFeedLink.Name = "Edit";
            EditFeedLink.LinkColor = Color.Blue;
            EditFeedLink.TrackVisitedState = false;
            EditFeedLink.Text = "Edit";
            EditFeedLink.DisplayIndex = 0;
            grdJobs.Columns.Add(EditFeedLink);

            //grdFeed.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            //grdJobs.Columns["NetworkID"].Visible = false;
            //grdFeed.Columns["AgencyID"].Visible = false;
            //grdFeed.Columns["MerchantID"].Visible = false;
            //grdFeed.Columns["IsActive"].Width = 70;
            //grdFeed.Columns["OrderNo"].Width = 70;
            //grdFeed.Columns["MerchantProductURL"].Width = 200;
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
            int DeleteJobindex = grdJobs.Columns["DeleteJob"].Index;
            int Editcolindex = grdJobs.Columns["Edit"].Index;
            if (e.ColumnIndex == Editcolindex)
            {
                int SchedulerId = 0;
                int.TryParse(grdJobs.Rows[e.RowIndex].Cells["SchedulerId"].Value.ToString(), out SchedulerId);
                AddEditScheduler obj = new AddEditScheduler(SchedulerId);
                obj.ShowDialog();
            }

            if (e.ColumnIndex == DeleteJobindex)
            {

            }
        }

    }
}
