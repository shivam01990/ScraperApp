using DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ws_JobScheduler_MonthlyServices
    {
        #region--Instance--
        public static ws_JobScheduler_MonthlyServices Instance = new ws_JobScheduler_MonthlyServices();
        #endregion

        #region--Save ws_JobScheduler_Monthly--
        public int Save_ws_JobScheduler_Monthly(ws_JobScheduler_Daily rr)
        {
            int schedule_daily_id = 0;
            using (DBEntities db = new DBEntities())
            {
                if (rr.schedule_daily_id > 0)
                {
                    ws_JobScheduler_Daily temp = db.ws_JobScheduler_Daily.Where(u => u.schedule_daily_id == rr.schedule_daily_id).FirstOrDefault();

                    if (temp != null)
                    {
                        temp.scheduler_id = rr.scheduler_id;
                        temp.recur_days = rr.recur_days;
                        temp.IsWeekDay = rr.IsWeekDay;
                    }
                }
                else
                {
                    db.ws_JobScheduler_Daily.Add(rr);
                }

                int x = db.SaveChanges();
                if (x > 0)
                {
                    schedule_daily_id = rr.schedule_daily_id;
                }
            }

            return schedule_daily_id;
        }
        #endregion
    }
}
