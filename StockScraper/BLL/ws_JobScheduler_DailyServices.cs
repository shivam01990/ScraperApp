using DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class ws_JobScheduler_DailyServices
   {
       #region--Instance--
       public static ws_JobScheduler_DailyServices Instance = new ws_JobScheduler_DailyServices();
       #endregion

       #region--Save ws_JobScheduler--
       public int Save_ws_JobScheduler_Daily(ws_JobScheduler_Daily rr)
       {
           

           int schedule_daily_id = 0;
           using (DBEntities db = new DBEntities())
           {
               ws_JobScheduler_Daily exists =db.ws_JobScheduler_Daily.Where(u => u.scheduler_id == rr.scheduler_id).FirstOrDefault();
               if(exists!=null)
               {
                   rr.schedule_daily_id = exists.schedule_daily_id;
               }

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
