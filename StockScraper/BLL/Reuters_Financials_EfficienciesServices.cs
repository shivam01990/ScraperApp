using DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Reuters_Financials_EfficienciesServices
    {
        #region--Instance--
        public static Reuters_Financials_EfficienciesServices Instance = new Reuters_Financials_EfficienciesServices();
        #endregion

        #region--Save Reuters Financials Dividends--
        public int Save_Reuters_Financials_Efficiencies(Reuters_Financials_Efficiencies rr)
        {
            int Reuters_FinancialsEfficiency_Id = 0;
            using (DBEntities db = new DBEntities())
            {
                if (rr.Reuters_FinancialsEfficiency_Id > 0)
                {
                    Reuters_Financials_Efficiencies temp = db.Reuters_Financials_Efficiencies.Where(u => u.Reuters_FinancialsEfficiency_Id == rr.Reuters_FinancialsEfficiency_Id).FirstOrDefault();

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
                    db.Reuters_Financials_Efficiencies.Add(rr);
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
