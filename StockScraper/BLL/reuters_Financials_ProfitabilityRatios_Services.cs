using DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class reuters_Financials_ProfitabilityRatios_Services
    {
        #region--Instance--
        public static reuters_Financials_ProfitabilityRatios_Services Instance = new reuters_Financials_ProfitabilityRatios_Services();
        #endregion

        #region--save Reuters Financials GrowthRates--
        public Int64 Save_reuters_Financials_ProfitabilityRatios(reuters_Financials_ProfitabilityRatios rr)
        {
            Int64 Reuters_Financials_ProfitabilityRatios_Id = 0;
            using (DBEntities db = new DBEntities())
            {
                if (rr.Reuters_Financials_ProfitabilityRatios_Id > 0)
                {
                    reuters_Financials_ProfitabilityRatios temp = db.reuters_Financials_ProfitabilityRatios.Where(u => u.Reuters_Financials_ProfitabilityRatios_Id == rr.Reuters_Financials_ProfitabilityRatios_Id).FirstOrDefault();

                    if (temp != null)
                    {
                        temp.Stock_Id = rr.Stock_Id;
                        temp.Job_run_Id = rr.Job_run_Id;
                        temp.EffectiveDate = rr.EffectiveDate;
                        temp.Title = rr.Title;
                        temp.Company = rr.Company;
                        temp.Industry = rr.Industry;
                        temp.Sector = rr.Sector;
                    }
                }
                else
                {
                    db.reuters_Financials_ProfitabilityRatios.Add(rr);
                }

                int x = db.SaveChanges();
                if (x > 0)
                {
                    Reuters_Financials_ProfitabilityRatios_Id = rr.Reuters_Financials_ProfitabilityRatios_Id;
                }
            }

            return Reuters_Financials_ProfitabilityRatios_Id;
        }
        #endregion
    }
}
