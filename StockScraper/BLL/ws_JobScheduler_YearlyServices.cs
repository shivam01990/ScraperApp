using DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ws_JobScheduler_YearlyServices
    {

        public static ws_JobScheduler_YearlyServices Instance = new ws_JobScheduler_YearlyServices();

        #region--Save JobScheduler YearlyServices--
        public int Save_ws_JobScheduler_Yearly(ws_JobScheduler_Yearly rr)
        {
            int scheduler_yearly_id = 0;
            using (DBEntities db = new DBEntities())
            {
                ws_JobScheduler_Yearly exists = db.ws_JobScheduler_Yearly.Where(u => u.scheduler_id == rr.scheduler_id).FirstOrDefault();
                if (exists != null)
                {
                    rr.scheduler_yearly_id = exists.scheduler_yearly_id;
                }
                if (rr.scheduler_yearly_id > 0)
                {
                    ws_JobScheduler_Yearly temp = db.ws_JobScheduler_Yearly.Where(u => u.scheduler_yearly_id == rr.scheduler_yearly_id).FirstOrDefault();

                    if (temp != null)
                    {
                        temp.scheduler_id = rr.scheduler_id;
                        temp.yearly_nominal_day = rr.yearly_nominal_day;
                        temp.yearly_nominal_month = rr.yearly_nominal_month;
                        temp.yearly_month = rr.yearly_month;
                        temp.yearly_day = rr.yearly_day;
                        temp.yearly_week_of_day = rr.yearly_week_of_day;
                        temp.yearly_month = rr.yearly_month;
                        temp.yearly_isweekday = rr.yearly_isweekday;
                    }
                }
                else
                {
                    db.ws_JobScheduler_Yearly.Add(rr);
                }

                int x = db.SaveChanges();
                if (x > 0)
                {
                    scheduler_yearly_id = rr.scheduler_yearly_id;
                }
            }

            return scheduler_yearly_id;
        }
        #endregion
    }
}
