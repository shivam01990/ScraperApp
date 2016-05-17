using DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ws_JobSchedulerServices
    {
        #region--Instance--
        public static ws_JobSchedulerServices Instance = new ws_JobSchedulerServices();
        #endregion

        #region--Save ws_JobScheduler--
        public int Save_ws_JobScheduler(ws_JobScheduler rr)
        {
            int scheduler_id = 0;
            using (DBEntities db = new DBEntities())
            {
                ws_JobScheduler exists = db.ws_JobScheduler.Where(u => u.name == rr.name && rr.scheduler_id!=u.scheduler_id).FirstOrDefault();
                if(exists!=null)
                {
                    return 0;
                }
                if (rr.scheduler_id > 0)
                {
                    ws_JobScheduler temp = db.ws_JobScheduler.Where(u => u.scheduler_id == rr.scheduler_id).FirstOrDefault();

                    if (temp != null)
                    {
                        temp.scheduler_id = rr.scheduler_id;
                        //temp.name = rr.name;
                        temp.description = rr.description;
                        temp.jobtype_id = rr.jobtype_id;
                        temp.start_date = rr.start_date;
                        temp.start_time = rr.start_time;
                        temp.end_date = rr.end_date;
                        temp.end_time = rr.end_time;
                        temp.schedulertype_id = rr.schedulertype_id;
                        temp.current_run_count = rr.current_run_count;
                        temp.max_run_count = rr.max_run_count;
                        temp.Status = rr.Status;
                    }
                }
                else
                {
                    db.ws_JobScheduler.Add(rr);
                }

                int x = db.SaveChanges();
                if (x > 0)
                {
                    scheduler_id =rr.scheduler_id;
                }
            }

            return scheduler_id;
        }
        #endregion

        #region--Get Scheduler--
        public List<p_GetJobScheduler_Result> GetScheduler(int scheduler_id,string name)
        {
            List<p_GetJobScheduler_Result> rType = new List<p_GetJobScheduler_Result>();
            using (DBEntities db = new DBEntities())
            {
                rType = db.p_GetJobScheduler(scheduler_id,name).ToList();
            }
            return rType;
        }
        #endregion


        #region--Get Scheduler--
        public List<p_GetAllFieldsForJobScheduler_Result> GetAllFieldsForScheduler(int scheduler_id)
        {
            List<p_GetAllFieldsForJobScheduler_Result> rType = new List<p_GetAllFieldsForJobScheduler_Result>();
            using (DBEntities db = new DBEntities())
            {
                rType = db.p_GetAllFieldsForJobScheduler(scheduler_id).ToList();
            }
            return rType;
        }
        #endregion
    }
}
