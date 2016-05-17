using DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class ws_JobScheduler_WeeklyService
    {
        #region--Instance--
       public static ws_JobScheduler_WeeklyService Instance = new ws_JobScheduler_WeeklyService();
        #endregion

        #region--Save ws_JobScheduler--
       public int Save_ws_JobScheduler_Weekly(ws_JobScheduler_Weekly rr)
        {

            int scheduler_weekly_id = 0;
            using (DBEntities db = new DBEntities())
            {
                ws_JobScheduler_Weekly exists = db.ws_JobScheduler_Weekly.Where(u => u.scheduler_id == rr.scheduler_id).FirstOrDefault();
                if (exists != null)
                {
                    rr.scheduler_weekly_id = exists.scheduler_weekly_id;
                }

                if (rr.scheduler_weekly_id > 0)
                {
                    ws_JobScheduler_Weekly temp = db.ws_JobScheduler_Weekly.Where(u => u.scheduler_weekly_id == rr.scheduler_weekly_id).FirstOrDefault();

                    if (temp != null)
                    {
                        temp.scheduler_id = rr.scheduler_id;
                        temp.weekly_freq = rr.weekly_freq;
                        temp.weekly_sunday = rr.weekly_sunday;
                        temp.weekly_monday = rr.weekly_monday;
                        temp.weekly_tuesday = rr.weekly_tuesday;
                        temp.weekly_wednesday = rr.weekly_wednesday;
                        temp.weekly_thursday = rr.weekly_thursday;
                        temp.weekly_friday = rr.weekly_friday;
                        temp.weekly_saturday = rr.weekly_saturday;
                       
                    }
                }
                else
                {
                    db.ws_JobScheduler_Weekly.Add(rr);
                }

                int x = db.SaveChanges();
                if (x > 0)
                {
                    scheduler_weekly_id = rr.scheduler_weekly_id;
                }
            }

            return scheduler_weekly_id;
        }
        #endregion
    }
}
