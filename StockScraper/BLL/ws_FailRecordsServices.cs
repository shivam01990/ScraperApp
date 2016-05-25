using DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ws_FailRecordsServices
    {
        #region--Instance--
        public static ws_FailRecordsServices Instance = new ws_FailRecordsServices();
        #endregion

        #region--Save ws_FailRecords--
        public long Save_ws_FailRecords(ws_FailRecords rr)
        {
            long fail_record_id = 0;
            using (DBEntities db = new DBEntities())
            {

                if (rr.fail_record_id > 0)
                {
                    ws_FailRecords temp = db.ws_FailRecords.Where(u => u.fail_record_id == rr.fail_record_id).FirstOrDefault();

                    if (temp != null)
                    {
                        temp.scheduler_id = rr.scheduler_id;
                        temp.stock_id = rr.stock_id;
                        temp.run_job_id = rr.run_job_id;
                    }
                }
                else
                {
                    db.ws_FailRecords.Add(rr);
                }

                int x = db.SaveChanges();
                if (x > 0)
                {
                    fail_record_id = rr.fail_record_id;
                }
            }

            return fail_record_id;
        }
        #endregion

        #region--Get FailRecords--
        public List<ws_FailRecords> GetFailRecords(int scheduler_id, int job_id)
        {
            List<ws_FailRecords> rType = new List<ws_FailRecords>();
            using (DBEntities db = new DBEntities())
            {
                rType = db.ws_FailRecords.Where(f => (f.scheduler_id == scheduler_id || scheduler_id == 0) && (job_id == 0 || f.run_job_id == job_id)).ToList();
            }
            return rType;
        }
        #endregion
    }
}
