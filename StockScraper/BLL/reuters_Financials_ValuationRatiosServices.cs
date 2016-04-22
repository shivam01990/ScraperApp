using DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class reuters_Financials_ValuationRatiosServices
    {
        #region--Instance--
        public static reuters_Financials_DividendsServices Instance = new reuters_Financials_DividendsServices();
        #endregion

        #region--Save Reuters Financials Dividends--
        public long Save_reuters_Financials_ValuationRatios(reuters_Financials_ValuationRatios rr)
        {
            long Reuters_FinancialsValuationRatio_Id = 0;
            using (DBEntities db = new DBEntities())
            {
                if (rr.Reuters_FinancialsValuationRatio_Id > 0)
                {
                    reuters_Financials_ValuationRatios temp = db.reuters_Financials_ValuationRatios.Where(u => u.Reuters_FinancialsValuationRatio_Id == rr.Reuters_FinancialsValuationRatio_Id).FirstOrDefault();

                    if (temp != null)
                    {
                        temp.Stock_Id = rr.Stock_Id;
                        temp.job_run_Id = rr.job_run_Id;
                        temp.EffectiveDate = rr.EffectiveDate;
                        temp.Title = rr.Title;
                        temp.Company = rr.Company;
                        temp.Industry = rr.Industry;
                        temp.Sector = rr.Sector;
                    }
                }
                else
                {
                    db.reuters_Financials_ValuationRatios.Add(rr);
                }

                int x = db.SaveChanges();
                if (x > 0)
                {
                    Reuters_FinancialsValuationRatio_Id = rr.Reuters_FinancialsValuationRatio_Id;
                }
            }

            return Reuters_FinancialsValuationRatio_Id;
        }
        #endregion
    }
}
