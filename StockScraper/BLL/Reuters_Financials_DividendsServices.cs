using DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class reuters_Financials_DividendsServices
    {
        #region--Instance--
        public static reuters_Financials_DividendsServices Instance = new reuters_Financials_DividendsServices();        
        #endregion

        #region--Save Reuters Financials Dividends--
        public int Save_Reuters_Financials_Dividends(reuters_Financials_Dividends rr)
        {
            int Reuters_FinancialsDividend_Id = 0;
            using (DBEntities db = new DBEntities())
            {               
                if (rr.Reuters_FinancialsDividend_Id > 0)
                {
                    reuters_Financials_Dividends temp = db.reuters_Financials_Dividends.Where(u => u.Reuters_FinancialsDividend_Id == rr.Reuters_FinancialsDividend_Id).FirstOrDefault();

                    if (temp != null)
                    {
                        temp.Stock_Id = rr.Stock_Id;
                        temp.run_job_Id = rr.run_job_Id;
                        temp.EffectiveDate = rr.EffectiveDate;
                        temp.Title = rr.Title;
                        temp.Company = rr.Company;
                        temp.Industry = rr.Industry;
                        temp.Sector = rr.Sector;
                    }
                }
                else
                {
                    db.reuters_Financials_Dividends.Add(rr);
                }

                int x = db.SaveChanges();
                if (x > 0)
                {
                    Reuters_FinancialsDividend_Id = rr.Reuters_FinancialsDividend_Id;
                }
            }

            return Reuters_FinancialsDividend_Id;
        }
        #endregion
    }
}
