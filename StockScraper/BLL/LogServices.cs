using DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LogServices
    {
        #region--Instance--
        public static LogServices Instance = new LogServices(); 
        #endregion

        #region--Save Logs--
        public int SaveLogs(Log l)
        {
            int Log_Id = 0;
            using (DBEntities db = new DBEntities())
            {
                
                if (l.Log_Id > 0)
                {
                    Log temp = db.Logs.Where(u => u.Log_Id == l.Log_Id).FirstOrDefault();

                    if (temp != null)
                    {
                        temp.Job_Id = l.Job_Id;
                        temp.LogMsg = l.LogMsg;                        
                    }
                }
                else
                {
                    db.Logs.Add(l);
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
