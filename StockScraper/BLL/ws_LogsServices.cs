using DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ws_LogsServices
    {
        #region--Instance--
        public static ws_LogsServices Instance = new ws_LogsServices(); 
        #endregion

        #region--Save Logs--
        public int SaveLogs(ws_Logs l)
        {
            int Log_Id = 0;
            using (DBEntities db = new DBEntities())
            {
                
                if (l.Log_Id > 0)
                {
                    ws_Logs temp = db.ws_Logs.Where(u => u.Log_Id == l.Log_Id).FirstOrDefault();

                    if (temp != null)
                    {
                        temp.job_run_Id = l.job_run_Id;
                        temp.log_msg = l.log_msg;
                        temp.log_status = l.log_status;                        
                    }
                }
                else
                {
                    db.ws_Logs.Add(l);
                }

                int x = db.SaveChanges();
                if (x > 0)
                {
                    Log_Id = l.Log_Id;
                }
            }

            return Log_Id;
        }
        #endregion
    }
}
