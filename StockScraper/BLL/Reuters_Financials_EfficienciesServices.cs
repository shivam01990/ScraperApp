using DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class reuters_Financials_EfficienciesServices
    {
        #region--Instance--
        public static reuters_Financials_EfficienciesServices Instance = new reuters_Financials_EfficienciesServices();
        #endregion

        #region--Save Reuters Financials Dividends--
        public long Save_Reuters_Financials_Efficiencies(reuters_Financials_Efficiencies rr)
        {
            long Reuters_FinancialsEfficiency_Id = 0;
            using (DBEntities db = new DBEntities())
            {
                if (rr.Reuters_FinancialsEfficiency_Id > 0)
                {
                    reuters_Financials_Efficiencies temp = db.reuters_Financials_Efficiencies.Where(u => u.Reuters_FinancialsEfficiency_Id == rr.Reuters_FinancialsEfficiency_Id).FirstOrDefault();

                    if (temp != null)
                    {
                        temp.Stock_Id = rr.Stock_Id;
                        temp.run_job_id = rr.run_job_id;
                        temp.EffectiveDate = rr.EffectiveDate;
                        temp.Title = rr.Title;
                        temp.Company = rr.Company;
                        temp.Industry = rr.Industry;
                        temp.Sector = rr.Sector;
                    }
                }
                else
                {
                    db.reuters_Financials_Efficiencies.Add(rr);
                }

                int x = db.SaveChanges();
                if (x > 0)
                {
                    Reuters_FinancialsEfficiency_Id = rr.Reuters_FinancialsEfficiency_Id;
                }
            }

            return Reuters_FinancialsEfficiency_Id;
        }
        #endregion
    }
}
