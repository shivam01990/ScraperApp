using DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class reuters_Financials_InstitutionsServices
    {

        #region--Instance--
        public static reuters_Financials_InstitutionsServices Instance = new reuters_Financials_InstitutionsServices();
        #endregion

        #region--Save Reuters Financials Dividends--
        public long Save_reuters_Financials_Institutions(reuters_Financials_Institutions rr)
        {
            long Reuters_FinancialsInstitutions_Id = 0;
            using (DBEntities db = new DBEntities())
            {
                if (rr.Reuters_FinancialsInstitutions_Id > 0)
                {
                    reuters_Financials_Institutions temp = db.reuters_Financials_Institutions.Where(u => u.Reuters_FinancialsInstitutions_Id == rr.Reuters_FinancialsInstitutions_Id).FirstOrDefault();

                    if (temp != null)
                    {
                        temp.Stock_Id = rr.Stock_Id;
                        temp.job_run_id = rr.job_run_id;
                        temp.EffectiveDate = rr.EffectiveDate;
                        temp.Title = rr.Title;
                        temp.DataValue = rr.DataValue;                       
                    }
                }
                else
                {
                    db.reuters_Financials_Institutions.Add(rr);
                }

                int x = db.SaveChanges();
                if (x > 0)
                {
                    Reuters_FinancialsInstitutions_Id = rr.Reuters_FinancialsInstitutions_Id;
                }
            }

            return Reuters_FinancialsInstitutions_Id;
        }
        #endregion

    }
}
