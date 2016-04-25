using DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class reuters_Financials_GrowthRatesRatesServices
    {
        #region--Instance--
        public static reuters_Financials_GrowthRatesRatesServices Instance = new reuters_Financials_GrowthRatesRatesServices();
        #endregion

        #region--save Reuters Financials GrowthRates--
        public long Save_reuters_Financials_GrowthRatesRates(reuters_Financials_GrowthRates rr)
        {
            long Reuters_FinancialsEfficiency_Id = 0;
            using (DBEntities db = new DBEntities())
            {
                if (rr.Reuters_FinancialsGrowthRate_Id > 0)
                {
                    reuters_Financials_GrowthRates temp = db.reuters_Financials_GrowthRates.Where(u => u.Reuters_FinancialsGrowthRate_Id == rr.Reuters_FinancialsGrowthRate_Id).FirstOrDefault();

                    if (temp != null)
                    {
                        temp.Stock_Id = rr.Stock_Id;
                        temp.run_job_id = rr.run_job_id ;
                        temp.EffectiveDate = rr.EffectiveDate;
                        temp.Title = rr.Title;
                        temp.Company = rr.Company;
                        temp.Industry = rr.Industry;
                        temp.Sector = rr.Sector;
                    }
                }
                else
                {
                    db.reuters_Financials_GrowthRates.Add(rr);
                }

                int x = db.SaveChanges();
                if (x > 0)
                {
                    Reuters_FinancialsEfficiency_Id = rr.Reuters_FinancialsGrowthRate_Id;
                }
            }

            return Reuters_FinancialsEfficiency_Id;
        }
        #endregion
    }
}
