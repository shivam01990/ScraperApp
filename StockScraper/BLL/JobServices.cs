using DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class JobServices
    {
        #region--Instance--
        public JobServices Instance = new JobServices();
        #endregion

        #region--Save Job--
        public int SaveJob(Job jj)
        {
            int Job_id = 0;
            using (DBEntities db = new DBEntities())
            {
                if (jj.Job_id > 0)
                {
                    Job temp = db.Jobs.Where(u => u.Job_id == jj.Job_id).FirstOrDefault();

                    if (temp != null)
                    {
                        temp.Start_Time = DateTime.Now;


                    }
                }
                else
                {
                    db.Jobs.Add(jj);
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
    }
}
