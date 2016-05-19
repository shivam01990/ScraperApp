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
            if (_scheduler.schedulertype_id == 1)
            {
                DeleteTask(_scheduler.name);
                CreateTaskRunDaily(_scheduler);
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
                            td.RegistrationInfo.Description = _scheduler.description;

                            DailyTrigger daily = new DailyTrigger();
                            daily.StartBoundary = Convert.ToDateTime(_scheduler.start_date.ToShortDateString() + " " + _scheduler.start_time.ToString());
                            daily.DaysInterval = (short)(_scheduler.recur_days_daily == 0 ? 1 : _scheduler.recur_days_daily);
                            td.Triggers.Add(daily);

                            td.Actions.Add(new ExecAction(Helper.GetExePath(), _scheduler.scheduler_id + "," + _scheduler.name, null));
                            ts.RootFolder.RegisterTaskDefinition(_scheduler.name, td);
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
                            td.RegistrationInfo.Description = _scheduler.description;

                            WeeklyTrigger week = new WeeklyTrigger();
                            week.StartBoundary = Convert.ToDateTime(_scheduler.start_date.ToShortDateString() + _scheduler.start_time.ToString("hh:mm:tt"));
                            week.WeeksInterval = 1;
                            week.DaysOfWeek = Microsoft.Win32.TaskScheduler.DaysOfTheWeek.Saturday |
                                               Microsoft.Win32.TaskScheduler.DaysOfTheWeek.Sunday;
                            td.Triggers.Add(week);

                            td.Actions.Add(new ExecAction(AppSettings.EXEPath, _scheduler.scheduler_id + "," + _scheduler.name, null));
                            ts.RootFolder.RegisterTaskDefinition(_scheduler.name, td);
                        }
                    }
                }
            }
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
