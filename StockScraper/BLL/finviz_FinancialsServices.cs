using DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class finviz_FinancialsServices
    {
        #region--Instance--
        public static finviz_FinancialsServices Instance = new finviz_FinancialsServices();
        #endregion

        #region--Save ft_forecasts_prices--
        public long Save_fin_Financials(finviz_Financials rr)
        {
            long forecast_recommendation_Id = 0;
            using (DBEntities db = new DBEntities())
            {
                if (rr.Finviz_FinancialId > 0)
                {
                    finviz_Financials temp = db.finviz_Financials.Where(u => u.Finviz_FinancialId == rr.Finviz_FinancialId).FirstOrDefault();

                    if (temp != null)
                    {
                        temp.Stock_Id = rr.Stock_Id;
                        temp.job_run_Id = rr.job_run_Id;
                        temp.value = rr.value;
                        temp.descriptor = rr.descriptor;
                        temp.EffectiveDate = rr.EffectiveDate;

                    }
                }
                else
                {
                    db.finviz_Financials.Add(rr);
                }

                int x = db.SaveChanges();
                if (x > 0)
                {
                    forecast_recommendation_Id = rr.Finviz_FinancialId;
                }
            }

            return forecast_recommendation_Id;
        }
        #endregion
    }
}
