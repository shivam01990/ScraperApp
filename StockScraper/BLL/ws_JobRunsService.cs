using DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ws_JobRunsService
    {
        #region--Initialization--
        public static ws_JobRunsService Instance = new ws_JobRunsService();
        #endregion

        #region--Get ws_JobRuns--
        public List<ws_JobRuns> Getws_JobRuns(int run_id)
        {
            List<ws_JobRuns> rType = new List<ws_JobRuns>();
            using (DBEntities db = new DBEntities())
            {
                rType = db.ws_JobRuns.Where(s=>s.run_id==run_id ||run_id==0).ToList();
            }
            return rType;
        }
        #endregion

        #region--Save ws_JobRuns--
        public long Save_ws_JobRuns(ws_JobRuns rr)
        {
            long run_id = 0;
            using (DBEntities db = new DBEntities())
            {

                if (rr.run_id > 0)
                {
                    ws_JobRuns temp = db.ws_JobRuns.Where(u => u.run_id == rr.run_id).FirstOrDefault();

                    if (temp != null)
                    {
                        temp.job_run_id = rr.job_run_id;
                        temp.web_calls_failures = rr.web_calls_failures;
                        temp.web_calls_total = rr.web_calls_total;
                        temp.web_calls_success = rr.web_calls_success;
                    }
                }
                else
                {
                    db.ws_JobRuns.Add(rr);
                }

                int x = db.SaveChanges();
                if (x > 0)
                {
                    run_id = rr.run_id;
                }
            }

            return run_id;
        }
        #endregion


    }
}
