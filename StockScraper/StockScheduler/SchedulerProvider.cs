using Microsoft.Win32.TaskScheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using DLL;
namespace StockScheduler
{
    public class SchedulerProvider
    {
        #region--Instance--
        public static SchedulerProvider Instance = new SchedulerProvider();
        #endregion

        public void GenerateTask(p_GetAllFieldsForJobScheduler_Result _scheduler)
        {
            DeleteTask(_scheduler.name);
            if (_scheduler.schedulertype_id == 1)
            {
                CreateTaskRunDaily(_scheduler);
            }

            if (_scheduler.schedulertype_id == 2)
            {
                CreateWeeklyTask(_scheduler);
            }

            if (_scheduler.schedulertype_id == 3)
            {
                CreateMonthlyDayJobs(_scheduler);
            }

            if (_scheduler.schedulertype_id == 4)
            {
                CreateYearlyDayJobs(_scheduler);
            }
        }


        #region--Create Daily Task Run Daily--
        private void CreateTaskRunDaily(p_GetAllFieldsForJobScheduler_Result _scheduler)
        {
            if (_scheduler != null)
            {
                if (_scheduler.schedulertype_id == 1)
                {
                    if (!(_scheduler.IsWeekDay_daily ?? false))
                    {
                        using (TaskService ts = new TaskService())
                        {
                            TaskDefinition td = ts.NewTask();
                            td.Settings.DisallowStartIfOnBatteries = false;
                            td.RegistrationInfo.Description = _scheduler.description;

                            DailyTrigger daily = new DailyTrigger();
                            daily.StartBoundary = Convert.ToDateTime(_scheduler.start_date.ToShortDateString() + " " + _scheduler.start_time.ToString());
                            if(_scheduler.end_date!=null && _scheduler.end_time!=null)
                            {
                                daily.EndBoundary = Convert.ToDateTime((_scheduler.end_date==null?DateTime.Now.ToShortDateString():((DateTime)_scheduler.end_date).ToShortDateString()) + " " + _scheduler.end_time.ToString());                   
                            }
                            daily.DaysInterval = (short)(_scheduler.recur_days_daily == 0 ? 1 : _scheduler.recur_days_daily);
                            td.Triggers.Add(daily);

                            td.Actions.Add(new ExecAction(Helper.GetExePath(), _scheduler.scheduler_id + "," + _scheduler.name, null));
                            ts.RootFolder.RegisterTaskDefinition(_scheduler.name, td, TaskCreation.Create, @"NT AUTHORITY\SYSTEM", null, TaskLogonType.ServiceAccount, null);
                        }
                    }
                }
            }
        }

        private void CreateTaskRunWeeklyForDaily(p_GetAllFieldsForJobScheduler_Result _scheduler)
        {
            if (_scheduler != null)
            {
                if (_scheduler.schedulertype_id == 1)
                {
                    if ((_scheduler.IsWeekDay_daily ?? false))
                    {
                        using (TaskService ts = new TaskService())
                        {
                            TaskDefinition td = ts.NewTask();
                            td.Settings.DisallowStartIfOnBatteries = false;
                            td.RegistrationInfo.Description = _scheduler.description;

                            WeeklyTrigger week = new WeeklyTrigger();
                            
                            week.StartBoundary = Convert.ToDateTime(_scheduler.start_date.ToShortDateString() + " " + _scheduler.start_time.ToString());
                            if (_scheduler.end_date != null && _scheduler.end_time != null)
                            {
                                week.EndBoundary = Convert.ToDateTime((_scheduler.end_date == null ? DateTime.Now.ToShortDateString() : ((DateTime)_scheduler.end_date).ToShortDateString()) + " " + _scheduler.end_time.ToString());
                            }
                            week.WeeksInterval = 1;
                            week.DaysOfWeek = Microsoft.Win32.TaskScheduler.DaysOfTheWeek.Monday | Microsoft.Win32.TaskScheduler.DaysOfTheWeek.Tuesday | Microsoft.Win32.TaskScheduler.DaysOfTheWeek.Wednesday | Microsoft.Win32.TaskScheduler.DaysOfTheWeek.Thursday | Microsoft.Win32.TaskScheduler.DaysOfTheWeek.Friday;
                            td.Triggers.Add(week);

                            td.Actions.Add(new ExecAction(AppSettings.EXEPath, _scheduler.scheduler_id + "," + _scheduler.name, null));
                            ts.RootFolder.RegisterTaskDefinition(_scheduler.name, td, TaskCreation.Create, @"NT AUTHORITY\SYSTEM", null, TaskLogonType.ServiceAccount, null);
                        }
                    }
                }
            }
        }

        #endregion

        #region--Create Weekly Task--
        public void CreateWeeklyTask(p_GetAllFieldsForJobScheduler_Result _scheduler)
        {
            if (_scheduler != null)
            {
                if (_scheduler.schedulertype_id == 2)
                {
                    using (TaskService ts = new TaskService())
                    {
                        TaskDefinition td = ts.NewTask();
                        td.Settings.DisallowStartIfOnBatteries = false;
                        td.RegistrationInfo.Description = _scheduler.description;

                        WeeklyTrigger week = new WeeklyTrigger();
                        week.StartBoundary = Convert.ToDateTime(_scheduler.start_date.ToShortDateString() + " " + _scheduler.start_time.ToString());
                        if (_scheduler.end_date != null && _scheduler.end_time != null)
                        {
                            week.EndBoundary = Convert.ToDateTime((_scheduler.end_date == null ? DateTime.Now.ToShortDateString() : ((DateTime)_scheduler.end_date).ToShortDateString()) + " " + _scheduler.end_time.ToString());
                        }
                        week.WeeksInterval = 1;
                        if (_scheduler.weekly_monday)
                        {
                            week.DaysOfWeek = week.DaysOfWeek | Microsoft.Win32.TaskScheduler.DaysOfTheWeek.Monday;
                        }
                        if (_scheduler.weekly_tuesday)
                        {
                            week.DaysOfWeek = week.DaysOfWeek | Microsoft.Win32.TaskScheduler.DaysOfTheWeek.Tuesday;
                        }
                        if (_scheduler.weekly_wednesday)
                        {
                            week.DaysOfWeek = week.DaysOfWeek | Microsoft.Win32.TaskScheduler.DaysOfTheWeek.Wednesday;
                        }
                        if (_scheduler.weekly_thursday)
                        {
                            week.DaysOfWeek = week.DaysOfWeek | Microsoft.Win32.TaskScheduler.DaysOfTheWeek.Thursday;
                        }
                        if (_scheduler.weekly_friday)
                        {
                            week.DaysOfWeek = week.DaysOfWeek | Microsoft.Win32.TaskScheduler.DaysOfTheWeek.Friday;
                        }
                        if (_scheduler.weekly_saturday)
                        {
                            week.DaysOfWeek = week.DaysOfWeek | Microsoft.Win32.TaskScheduler.DaysOfTheWeek.Saturday;
                        }
                        if (_scheduler.weekly_sunday)
                        {
                            week.DaysOfWeek = week.DaysOfWeek | Microsoft.Win32.TaskScheduler.DaysOfTheWeek.Sunday;
                        }

                        td.Triggers.Add(week);

                        td.Actions.Add(new ExecAction(AppSettings.EXEPath, _scheduler.scheduler_id + "," + _scheduler.name, null));
                        ts.RootFolder.RegisterTaskDefinition(_scheduler.name, td, TaskCreation.Create, @"NT AUTHORITY\SYSTEM", null, TaskLogonType.ServiceAccount, null);
                    }
                }
            }
        }
        #endregion

        #region--Monthly Day Jobs--
        public void CreateMonthlyDayJobs(p_GetAllFieldsForJobScheduler_Result _scheduler)
        {
            if (_scheduler != null)
            {
                if (_scheduler.schedulertype_id == 3)
                {
                    if (!_scheduler.monthly_isweekday)
                    {
                        using (TaskService ts = new TaskService())
                        {
                            TaskDefinition td = ts.NewTask();
                            td.Settings.DisallowStartIfOnBatteries = false;
                            td.RegistrationInfo.Description = _scheduler.description;
                            MonthlyTrigger mTrigger = new MonthlyTrigger();
                            mTrigger.StartBoundary = Convert.ToDateTime(_scheduler.start_date.ToShortDateString() + " " + _scheduler.start_time.ToString());
                            if (_scheduler.end_date != null && _scheduler.end_time != null)
                            {
                                mTrigger.EndBoundary = Convert.ToDateTime((_scheduler.end_date == null ? DateTime.Now.ToShortDateString() : ((DateTime)_scheduler.end_date).ToShortDateString()) + " " + _scheduler.end_time.ToString());
                            }

                            mTrigger.DaysOfMonth = new int[] { _scheduler.monthly_nominal_day };


                            int currentmonth = DateTime.Now.Month;

                            if (_scheduler.monthly_nominal_month == 1)
                            {
                                mTrigger.MonthsOfYear = MonthsOfTheYear.AllMonths;
                            }

                            if (_scheduler.monthly_nominal_month == 2 || _scheduler.monthly_nominal_month == 3 || _scheduler.monthly_nominal_month == 4)
                            {
                                mTrigger.MonthsOfYear = GetMonthsOfYear(currentmonth, _scheduler.monthly_nominal_month);
                            }


                            // mTrigger.RunOnLastDayOfMonth = true; // V2 only
                            td.Triggers.Add(mTrigger);

                            td.Actions.Add(new ExecAction(AppSettings.EXEPath, _scheduler.scheduler_id + " " + _scheduler.name, null));
                            ts.RootFolder.RegisterTaskDefinition(_scheduler.name, td, TaskCreation.Create, @"NT AUTHORITY\SYSTEM", null, TaskLogonType.ServiceAccount, null);
                        }
                    }
                    else
                    {
                        CreateMonthlyWeekJobs(_scheduler);
                    }
                }
            }
        }
        #endregion

        #region--Monthly Week Jobs--
        public void CreateMonthlyWeekJobs(p_GetAllFieldsForJobScheduler_Result _scheduler)
        {
            if (_scheduler != null)
            {
                if (_scheduler.schedulertype_id == 3)
                {
                    if (_scheduler.monthly_isweekday)
                    {
                        using (TaskService ts = new TaskService())
                        {
                            TaskDefinition td = ts.NewTask();
                            td.Settings.DisallowStartIfOnBatteries = false;

                            td.RegistrationInfo.Description = _scheduler.description;
                            MonthlyDOWTrigger mTrigger = new MonthlyDOWTrigger();
                            mTrigger.StartBoundary = Convert.ToDateTime(_scheduler.start_date.ToShortDateString() + " " + _scheduler.start_time.ToString());
                            if (_scheduler.end_date != null && _scheduler.end_time != null)
                            {
                                mTrigger.EndBoundary = Convert.ToDateTime((_scheduler.end_date == null ? DateTime.Now.ToShortDateString() : ((DateTime)_scheduler.end_date).ToShortDateString()) + " " + _scheduler.end_time.ToString());
                            }
                            mTrigger.DaysOfWeek = GetWeekDayBySeqNo(_scheduler.monthly_week_of_day);

                            mTrigger.WeeksOfMonth = GetWeekBySeqNo(_scheduler.monthly_week_of_day);
                            int currentmonth = DateTime.Now.Month;

                            if (_scheduler.monthly_freq == 1)
                            {
                                mTrigger.MonthsOfYear = MonthsOfTheYear.AllMonths;
                            }

                            if (_scheduler.monthly_freq == 2 || _scheduler.monthly_freq == 3 || _scheduler.monthly_freq == 4)
                            {
                                mTrigger.MonthsOfYear = GetMonthsOfYear(currentmonth, _scheduler.monthly_nominal_month);
                            }

                            td.Triggers.Add(mTrigger);

                            td.Actions.Add(new ExecAction(AppSettings.EXEPath, _scheduler.scheduler_id + " " + _scheduler.name, null));
                            ts.RootFolder.RegisterTaskDefinition(_scheduler.name, td, TaskCreation.Create, @"NT AUTHORITY\SYSTEM", null, TaskLogonType.ServiceAccount, null);

                        }
                    }
                }
            }
        }
        #endregion

        #region--Yearly Job--
        public void CreateYearlyDayJobs(p_GetAllFieldsForJobScheduler_Result _scheduler)
        {
            if (_scheduler != null)
            {
                if (_scheduler.schedulertype_id == 4)
                {
                    if (!_scheduler.yearly_isweekday)
                    {
                        using (TaskService ts = new TaskService())
                        {
                            TaskDefinition td = ts.NewTask();
                            td.Settings.DisallowStartIfOnBatteries = false;
                            td.RegistrationInfo.Description = _scheduler.description;
                            MonthlyTrigger mTrigger = new MonthlyTrigger();
                            mTrigger.StartBoundary = Convert.ToDateTime(_scheduler.start_date.ToShortDateString() + " " + _scheduler.start_time.ToString());
                            if (_scheduler.end_date != null && _scheduler.end_time != null)
                            {
                                mTrigger.EndBoundary = Convert.ToDateTime((_scheduler.end_date == null ? DateTime.Now.ToShortDateString() : ((DateTime)_scheduler.end_date).ToShortDateString()) + " " + _scheduler.end_time.ToString());
                            }
                            mTrigger.DaysOfMonth = new int[] { _scheduler.yearly_nominal_day };

                            mTrigger.MonthsOfYear = GetMonthBySeqNo(_scheduler.yearly_nominal_month);
                            // mTrigger.RunOnLastDayOfMonth = true; // V2 only
                            td.Triggers.Add(mTrigger);
                            td.Actions.Add(new ExecAction(AppSettings.EXEPath, _scheduler.scheduler_id + " " + _scheduler.name, null));
                            ts.RootFolder.RegisterTaskDefinition(_scheduler.name, td, TaskCreation.Create, @"NT AUTHORITY\SYSTEM", null, TaskLogonType.ServiceAccount, null);

                        }
                    }
                    else
                    {
                        CreateYearlyWeekJobs(_scheduler);
                    }
                }
            }
        }

        #endregion

        #region--Yearly Week Job--
        public void CreateYearlyWeekJobs(p_GetAllFieldsForJobScheduler_Result _scheduler)
        {
            if (_scheduler != null)
            {
                if (_scheduler.schedulertype_id == 4)
                {
                    if (_scheduler.yearly_isweekday)
                    {
                        using (TaskService ts = new TaskService())
                        {
                            TaskDefinition td = ts.NewTask();
                            td.Settings.DisallowStartIfOnBatteries = false;
                            td.RegistrationInfo.Description = _scheduler.description;
                            MonthlyDOWTrigger mTrigger = new MonthlyDOWTrigger();
                            mTrigger.StartBoundary = Convert.ToDateTime(_scheduler.start_date.ToShortDateString() + " " + _scheduler.start_time.ToString());
                            if (_scheduler.end_date != null && _scheduler.end_time != null)
                            {
                                mTrigger.EndBoundary = Convert.ToDateTime((_scheduler.end_date == null ? DateTime.Now.ToShortDateString() : ((DateTime)_scheduler.end_date).ToShortDateString()) + " " + _scheduler.end_time.ToString());
                            }
                            mTrigger.WeeksOfMonth = GetWeekBySeqNo(_scheduler.yearly_week_of_day);
                            mTrigger.DaysOfWeek = GetWeekDayBySeqNo(_scheduler.yearly_day);
                            mTrigger.MonthsOfYear = GetMonthBySeqNo(_scheduler.yearly_month);
                            // mTrigger.RunOnLastDayOfMonth = true; // V2 only
                            td.Triggers.Add(mTrigger);
                            td.Actions.Add(new ExecAction(AppSettings.EXEPath, _scheduler.scheduler_id + " " + _scheduler.name, null));
                            ts.RootFolder.RegisterTaskDefinition(_scheduler.name, td, TaskCreation.Create, @"NT AUTHORITY\SYSTEM", null, TaskLogonType.ServiceAccount, null);

                        }
                    }
                }
            }
        }

        #endregion

        #region--Get Week By SeqNo
        public WhichWeek GetWeekBySeqNo(int SeqNo)
        {
            if (SeqNo == 1)
            {
                return WhichWeek.FirstWeek;
            }
            if (SeqNo == 2)
            {
                return WhichWeek.SecondWeek;
            }
            if (SeqNo == 3)
            {
                return WhichWeek.ThirdWeek;
            }
            if (SeqNo == 4)
            {
                return WhichWeek.FourthWeek;
            }
            if (SeqNo == 5)
            {
                return WhichWeek.LastWeek;
            }
            return WhichWeek.AllWeeks;
        }

        #endregion
        #region--Retrun Month of Year--
        public MonthsOfTheYear GetMonthsOfYear(int CurrentMonthnum, int MonthFreq)
        {
            MonthsOfTheYear obj = new MonthsOfTheYear();
            int runningmonth = CurrentMonthnum;
            do
            {
                obj = obj | GetMonthBySeqNo(runningmonth);
                int temp = runningmonth + MonthFreq;
                if (temp > 12)
                {
                    runningmonth = 12 - runningmonth;
                    obj = obj | GetMonthBySeqNo(runningmonth);
                }

                runningmonth = runningmonth + MonthFreq;

            } while (CurrentMonthnum != runningmonth);
            return obj;
        }
        #endregion

        #region--Get Month by SeqNo--
        public MonthsOfTheYear GetMonthBySeqNo(int CurrentMonthnum)
        {
            MonthsOfTheYear obj = new MonthsOfTheYear();
            if (CurrentMonthnum == 1)
            {
                obj = MonthsOfTheYear.January;
            }
            if (CurrentMonthnum == 2)
            {
                obj = MonthsOfTheYear.February;
            }
            if (CurrentMonthnum == 3)
            {
                obj = MonthsOfTheYear.March;
            }
            if (CurrentMonthnum == 4)
            {
                obj = MonthsOfTheYear.April;
            }
            if (CurrentMonthnum == 5)
            {
                obj = MonthsOfTheYear.May;
            }
            if (CurrentMonthnum == 6)
            {
                obj = MonthsOfTheYear.June;
            }
            if (CurrentMonthnum == 7)
            {
                obj = MonthsOfTheYear.July;
            }
            if (CurrentMonthnum == 8)
            {
                obj = MonthsOfTheYear.August;
            }
            if (CurrentMonthnum == 9)
            {
                obj = MonthsOfTheYear.September;
            }
            if (CurrentMonthnum == 10)
            {
                obj = MonthsOfTheYear.October;
            }
            if (CurrentMonthnum == 11)
            {
                obj = MonthsOfTheYear.November;
            }
            if (CurrentMonthnum == 12)
            {
                obj = MonthsOfTheYear.December;
            }
            return obj;
        }
        #endregion

        #region--Get Weekday by SeqNo
        public DaysOfTheWeek GetWeekDayBySeqNo(int SeqNo)
        {
            DaysOfTheWeek obj = new DaysOfTheWeek();
            if (SeqNo == 1)
            {
                obj = DaysOfTheWeek.Monday;
            }
            if (SeqNo == 2)
            {
                obj = DaysOfTheWeek.Tuesday;
            }
            if (SeqNo == 3)
            {
                obj = DaysOfTheWeek.Wednesday;
            }
            if (SeqNo == 4)
            {
                obj = DaysOfTheWeek.Thursday;
            }
            if (SeqNo == 5)
            {
                obj = DaysOfTheWeek.Friday;
            }
            if (SeqNo == 6)
            {
                obj = DaysOfTheWeek.Saturday;
            }
            if (SeqNo == 7)
            {
                obj = DaysOfTheWeek.Sunday;
            }
            return obj;
        }
        #endregion

        #region--Delete Tasks--
        private void DeleteTask(string TaskName)
        {
            using (TaskService ts = new TaskService())
            {
                if (ts.GetTask(TaskName) != null)
                {
                    ts.RootFolder.DeleteTask(TaskName);
                }
            }
        }
        #endregion
    }
}
