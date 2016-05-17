using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DLL;

namespace StockScheduler
{
    public partial class AddEditScheduler : Form
    {
        #region--Initialization--
        public int scheduler_id = 0;
        #endregion

        public AddEditScheduler()
        {
            InitializeComponent();
            Initialize();
        }

        public AddEditScheduler(int _scheduler_id)
        {
            InitializeComponent();
            scheduler_id = _scheduler_id;
            Initialize();

        }

        #region--Initialize--
        public void Initialize()
        {
            dtExpireDate.Enabled = false;
            dtExpireTime.Enabled = false;
            rdoDaily.Checked = true;
            rdoYearly_Every.Checked = true;
           

            string[] months = new string[] {"January", "February", "March", "April", "May",
  "June", "July", "August", "September", "October", "November", "December"};
            string[] monthsweek = new string[] {"January", "February", "March", "April", "May",
  "June", "July", "August", "September", "October", "November", "December"};

            string[] dayno = new string[] {"1","2","3","4","5"};
            string[] Weekday = new string[] { "Monday", "Tuesday", "Wednesday", "Thuresday", "Friday" ,"Saturday","Sunday"};
           
            cmbYearlyDay.DataSource = dayno;
            cmbYearly_Month.DataSource = months;
            cmbYearlyWeekDay.DataSource = Weekday;
            cmbYearlyMonthWeek.DataSource = monthsweek;
            cmbYearlyDay.SelectedIndex = 0;
            cmbYearly_Month.SelectedIndex = 0;
            cmbYearlyMonthWeek.SelectedIndex = 0;
            cmbYearlyWeekDay.SelectedIndex = 0;

            BindJobType();
            BindJob();
        }
        #endregion

        #region--Bind Job--
        public void BindJob()
        {
            if (scheduler_id > 0)
            {
                p_GetAllFieldsForJobScheduler_Result _scheduler = ws_JobSchedulerServices.Instance.GetAllFieldsForScheduler(scheduler_id).FirstOrDefault();
                if (_scheduler != null)
                {
                    int JobType_id = 0;
                    cmbJobType.SelectedValue = _scheduler.jobtype_id;
                    txtName.Text = _scheduler.name;
                    txtDescription.Text = _scheduler.description;
                    dtStartDate.Value = _scheduler.start_date;
                    dtStartTime.Value = _scheduler.start_date.Add(_scheduler.start_time);

                    if (_scheduler.end_date != null && _scheduler.end_time != null)
                    {
                        chkExpire.Checked = true;
                        dtExpireDate.Value = (DateTime)_scheduler.end_date;
                        dtExpireTime.Value = ((DateTime)_scheduler.end_date).Add((TimeSpan)_scheduler.end_time);
                    }

                    if (_scheduler.schedulertype_id == 1)
                    {
                        rdoDaily.Checked = true;
                        if (_scheduler.IsWeekDay_daily ?? false)
                        {
                            rdoDaily_WeekDay.Checked = true;
                        }
                        else
                        {
                            rdoDaily_EveryDay.Checked = true;
                        }
                        numericDailyDays.Value = _scheduler.recur_days_daily == 0 ? 1 : _scheduler.recur_days_daily;
                    }
                    if (_scheduler.schedulertype_id == 2)
                    {
                        rdoWeekly.Checked = true;
                        chkWeekly_Sunday.Checked = _scheduler.weekly_sunday;
                        chkWeekly_Monday.Checked = _scheduler.weekly_monday;
                        chkWeekly_Tuesday.Checked = _scheduler.weekly_tuesday;
                        chkWeekly_Wednesday.Checked = _scheduler.weekly_wednesday;
                        chkWeekly_Thursday.Checked = _scheduler.weekly_thursday;
                        chkWeekly_Friday.Checked = _scheduler.weekly_friday;
                        chkWeekly_Saturday.Checked = _scheduler.weekly_saturday;
                    }
                    if (_scheduler.schedulertype_id == 3)
                    {
                        rdoMonthly.Checked = true;
                    }
                    if (_scheduler.schedulertype_id == 4)
                    {
                        rdoYearly.Checked = true;
                    }

                    txtMaxRunCount.Value = _scheduler.max_run_count;
                }
                else
                {

                }
            }
        }
        #endregion

        protected void BindJobType()
        {
            cmbJobType.ValueMember = "jobtype_id";
            cmbJobType.DisplayMember = "jobtype_name";
            cmbJobType.DataSource = wslu_JobTypesServices.Instance.GetJobTypes(0);
        }

        private void chkExpire_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkExpire.Checked)
            {
                dtExpireDate.Enabled = false;
                dtExpireTime.Enabled = false;
            }
            else
            {
                dtExpireDate.Enabled = true;
                dtExpireTime.Enabled = true;
            }
        }

        private void rdoDaily_CheckedChanged(object sender, EventArgs e)
        {
            HideAllPanels();
            pnlDaily.Visible = true;
        }

        private void rdoWeekly_CheckedChanged(object sender, EventArgs e)
        {
            HideAllPanels();
            pnlWeekly.Location = pnlDaily.Location;
            pnlWeekly.Visible = true;
        }

        private void rdoMonthly_CheckedChanged(object sender, EventArgs e)
        {
            HideAllPanels();
            pnlMonthly.Location = pnlDaily.Location;
            pnlMonthly.Visible = true;
        }

        private void rdoYearly_CheckedChanged(object sender, EventArgs e)
        {
            HideAllPanels();
            pnlYearly.Location = pnlDaily.Location;
            pnlYearly.Visible = true;
        }

        private void HideAllPanels()
        {
            pnlDaily.Visible = false;
            pnlWeekly.Visible = false;
            pnlMonthly.Visible = false;
            pnlYearly.Visible = false;
        }

        #region--Save Job--
        private void btnSaveJob_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                ws_JobScheduler objJob = new ws_JobScheduler();
                objJob.scheduler_id = scheduler_id;
                objJob.name = txtName.Text;
                objJob.description = txtDescription.Text;

                string strstartdate = dtStartDate.Text + " " + dtStartTime.Text;
                DateTime startdate = DateTime.Parse(strstartdate);
                TimeSpan starttime = new TimeSpan(startdate.Hour, startdate.Minute, startdate.Second);
                objJob.start_date = startdate;
                objJob.start_time = starttime;

                if (chkExpire.Checked)
                {
                    string strenddate = dtExpireDate.Text + " " + dtExpireTime.Text;
                    DateTime enddate = DateTime.Parse(strenddate);
                    TimeSpan endtime = new TimeSpan(enddate.Hour, enddate.Minute, enddate.Second);
                    objJob.end_date = enddate;
                    objJob.end_time = endtime;
                }
                int jobtype_id = 0;
                int.TryParse(cmbJobType.SelectedValue.ToString(), out jobtype_id);
                objJob.jobtype_id = jobtype_id;
                int max_run_count = 0;
                int.TryParse(txtMaxRunCount.Text, out max_run_count);
                objJob.schedulertype_id = GetSchedulerTypeID();
                objJob.max_run_count = max_run_count;
                objJob.Status = true;

                scheduler_id = ws_JobSchedulerServices.Instance.Save_ws_JobScheduler(objJob);
                if (rdoDaily.Checked)
                {
                    ws_JobScheduler_Daily _daily = new ws_JobScheduler_Daily();
                    _daily.scheduler_id = scheduler_id;
                    int recrday = 1;
                    int.TryParse(numericDailyDays.Value.ToString(), out recrday);
                    _daily.recur_days = recrday;
                    _daily.IsWeekDay = rdoDaily_WeekDay.Checked ? true : false;
                    ws_JobScheduler_DailyServices.Instance.Save_ws_JobScheduler_Daily(_daily);
                }

                if (rdoWeekly.Checked)
                {
                    ws_JobScheduler_Weekly _weekly = new ws_JobScheduler_Weekly();
                    _weekly.scheduler_id = scheduler_id;
                    int recrday = 1;
                    int.TryParse(numericWeekly.Value.ToString(), out recrday);
                    _weekly.weekly_freq = recrday;
                    _weekly.weekly_sunday = chkWeekly_Sunday.Checked;
                    _weekly.weekly_monday = chkWeekly_Monday.Checked;
                    _weekly.weekly_tuesday = chkWeekly_Tuesday.Checked;
                    _weekly.weekly_wednesday = chkWeekly_Wednesday.Checked;
                    _weekly.weekly_thursday = chkWeekly_Thursday.Checked;
                    _weekly.weekly_friday = chkWeekly_Friday.Checked;
                    _weekly.weekly_saturday = chkWeekly_Saturday.Checked;
                    ws_JobScheduler_WeeklyService.Instance.Save_ws_JobScheduler_Weekly(_weekly);

                }

                if(rdoMonthly.Checked)
                {
                    ws_JobScheduler_Monthly _monthly = new ws_JobScheduler_Monthly();

                    _monthly.schedulder_id = scheduler_id;
                    int nominal_day = 0;
                    int.TryParse(numericMonthly_day.Value.ToString(), out nominal_day);
                    _monthly.monthly_nominal_day = nominal_day;

                    int nominal_month = 0;
                    int.TryParse(numericMonthly_MonthRec.Value.ToString(), out nominal_month);
                    _monthly.monthly_nominal_month = nominal_month;

                    int day = 0;
                    int.TryParse((cmbMonthlyWeek.SelectedIndex + 1).ToString(), out day);

                    int week_of_day = 0;
                    int.TryParse((cmbMonthWeekDay.SelectedIndex + 1).ToString(), out week_of_day);

                    int MonthRec = 0;
                    int.TryParse(numericMonthly_MonthRec.Value.ToString(), out MonthRec);
                    _monthly.monthly_freq = MonthRec;

                  if(rdoMonthly_Day.Checked)
                  {
                      
                  }


                }

                if (rdoYearly.Checked)
                {
                    ws_JobScheduler_Yearly _yearly = new ws_JobScheduler_Yearly();
                    _yearly.scheduler_id = scheduler_id;
                    int nominalDay = 1;
                    int.TryParse(numeric_YearlyNominalDay.Value.ToString(), out nominalDay);
                    _yearly.yearly_nominal_day = nominalDay;
                    int nominalmonth = 0;
                    int.TryParse((cmbYearly_Month.SelectedIndex+1).ToString(), out nominalmonth);
                    _yearly.yearly_nominal_month = nominalmonth;
                    int yearly_day = 0;

                    int.TryParse((cmbYearlyDay.SelectedIndex+1).ToString(), out yearly_day);
                    _yearly.yearly_day = yearly_day;

                    int yearly_week_of_day = 0;
                    int.TryParse((cmbYearlyWeekDay.SelectedIndex+1).ToString(), out yearly_week_of_day);
                    _yearly.yearly_week_of_day = yearly_week_of_day;

                    int yearly_month = 0;
                    int.TryParse((cmbYearlyMonthWeek.SelectedIndex+1).ToString(), out yearly_month);
                    _yearly.yearly_month = yearly_month;

                    if (rdoYearly_Every.Checked)
                    {
                        _yearly.yearly_isweekday = false;
                    }
                    else
                    {
                        _yearly.yearly_isweekday = true;
                    }

                    ws_JobScheduler_YearlyServices.Instance.Save_ws_JobScheduler_Yearly(_yearly);

                }

                if (scheduler_id > 0)
                {
                    MessageBox.Show("Job Saved");
                }
            }
        }
        #endregion

        #region--Get Job Type--
        public int GetSchedulerTypeID()
        {
            int schedulertype_id = 0;

            if (rdoDaily.Checked)
            {
                schedulertype_id = 1;
            }

            if (rdoWeekly.Checked)
            {
                schedulertype_id = 2;
            }

            if (rdoMonthly.Checked)
            {
                schedulertype_id = 3;
            }

            if (rdoYearly.Checked)
            {
                schedulertype_id = 4;
            }
            return schedulertype_id;

        }
        #endregion

        #region--Validate--
        public bool ValidateFields()
        {
            bool flag = true;
            if (txtName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Job Name is Required");
                flag = false;
            }
            return flag;
        }
        #endregion


    }
}
