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
        public int Save_ws_JobScheduler_Monthly(ws_JobScheduler_Monthly rr)
        {
            int scheduler_monthly_id = 0;
            using (DBEntities db = new DBEntities())
            {
                ws_JobScheduler_Monthly exists = db.ws_JobScheduler_Monthly.Where(u => u.schedulder_id == rr.schedulder_id).FirstOrDefault();
                if (exists != null)
                {
                    rr.scheduler_monthly_id = exists.scheduler_monthly_id;
                }
                if (rr.scheduler_monthly_id > 0)
                {
                    ws_JobScheduler_Monthly temp = db.ws_JobScheduler_Monthly.Where(u => u.scheduler_monthly_id == rr.scheduler_monthly_id).FirstOrDefault();

                    if (temp != null)
                    {
                        temp.schedulder_id = rr.schedulder_id;
                        temp.monthly_nominal_month = rr.monthly_nominal_month;
                        temp.monthly_nominal_day = rr.monthly_nominal_day;
                        temp.monthly_day = rr.monthly_day;
                        temp.monthly_week_of_day = rr.monthly_week_of_day;
                        temp.monthly_freq = rr.monthly_freq;
                        temp.monthly_isweekday = rr.monthly_isweekday;                       
                       
                    }
                }
                else
                {
                    db.ws_JobScheduler_Monthly.Add(rr);
                }

                int x = db.SaveChanges();
                if (x > 0)
                {
                    scheduler_monthly_id = rr.scheduler_monthly_id;
                }
            }

            return scheduler_monthly_id;
        }
        #endregion
    }
}
