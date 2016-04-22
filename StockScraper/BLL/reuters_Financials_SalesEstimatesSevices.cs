using DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class reuters_Financials_SalesEstimatesSevices
    {
        #region--Instance--
        public static reuters_Financials_SalesEstimatesSevices Instance = new reuters_Financials_SalesEstimatesSevices();
        #endregion

        #region--Save Reuters Financials Dividends--
        public long Save_reuters_Financials_SalesEstimates(reuters_Financials_SalesEstimates rr)
        {
            long Reuters_FinancialsSalesEstimates_Id = 0;
            using (DBEntities db = new DBEntities())
            {
                if (rr.Reuters_FinancialsSalesEstimates_Id > 0)
                {
                    reuters_Financials_SalesEstimates temp = db.reuters_Financials_SalesEstimates.Where(u => u.Reuters_FinancialsSalesEstimates_Id == rr.Reuters_FinancialsSalesEstimates_Id).FirstOrDefault();

                    if (temp != null)
                    {
                        temp.Stock_Id = rr.Stock_Id;
                        temp.job_run_id = rr.job_run_id;
                        temp.EffectiveDate = rr.EffectiveDate;
                        temp.Title = rr.Title;
                        temp.Estimates = rr.Estimates;
                        temp.Mean = rr.Mean;
                        temp.High = rr.High;
                        temp.Low = rr.Low;
                        temp.Sale_Type = rr.Sale_Type;

                    }
                }
                else
                {
                    db.reuters_Financials_SalesEstimates.Add(rr);
                }

                int x = db.SaveChanges();
                if (x > 0)
                {
                    Reuters_FinancialsSalesEstimates_Id = rr.Reuters_FinancialsSalesEstimates_Id;
                }
            }

            return Reuters_FinancialsSalesEstimates_Id;
        }
        #endregion
    }
}
