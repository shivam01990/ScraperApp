using DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Reuters_Financials_DividendsServices
    {
        #region--Instance--
        public static Reuters_Financials_DividendsServices Instance = new Reuters_Financials_DividendsServices();        
        #endregion

        #region--Save Reuters Financials Dividends--
        public int Save_Reuters_Financials_Dividends(Reuters_Financials_Dividends rr)
        {
            int Reuters_FinancialsDividend_Id = 0;
            using (DBEntities db = new DBEntities())
            {               
                if (rr.Reuters_FinancialsDividend_Id > 0)
                {
                    Reuters_Financials_Dividends temp = db.Reuters_Financials_Dividends.Where(u => u.Reuters_FinancialsDividend_Id == rr.Reuters_FinancialsDividend_Id).FirstOrDefault();

                    if (temp != null)
                    {
                        temp.Stock_Id = rr.Stock_Id;
                        temp.Job_Id = rr.Job_Id;
                        temp.EffectiveDate = rr.EffectiveDate;
                        temp.Title = rr.Title;
                        temp.Company = rr.Company;
                        temp.Industry = rr.Industry;
                        temp.Stock = rr.Stock;
                    }
                }
                else
                {
                    db.Reuters_Financials_Dividends.Add(rr);
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
