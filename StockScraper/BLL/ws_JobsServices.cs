﻿using DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ws_JobsServices
    {
        #region--Instance--
        public static ws_JobsServices Instance = new ws_JobsServices();
        #endregion

        #region--Save Job--
        public int SaveJob(ws_Jobs jj)
        {
            int Job_id = 0;
            using (DBEntities db = new DBEntities())
            {
                if (jj.Job_id > 0)
                {
                    ws_Jobs temp = db.ws_Jobs.Where(u => u.Job_id == jj.Job_id).FirstOrDefault();

                    if (temp != null)
                    {
                        temp.Start_Time = DateTime.Now;
                        temp.scheduler_id = jj.scheduler_id;
                    }
                }
                else
                {
                    db.ws_Jobs.Add(jj);
                }

                int x = db.SaveChanges();
                if (x > 0)
                {
                    Job_id = jj.Job_id;
                }
            }

            return Job_id;
        }
        #endregion

        #region--Get JobRun count--
        public List<p_GetRecordCountForJob_Result> GetRecordCountForJob(int SchedulerId)
        {
            using (DBEntities db = new DBEntities())
            {
                return db.p_GetRecordCountForJob(SchedulerId).ToList();
            }
        }
        #endregion
    }
}
