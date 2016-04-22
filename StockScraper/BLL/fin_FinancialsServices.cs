using DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class fin_FinancialsServices
    {
        #region--Instance--
        public static ft_forecasts_recommendationsServices Instance = new ft_forecasts_recommendationsServices();
        #endregion

        #region--Save ft_forecasts_prices--
        public long Save_fin_Financials(fin_Financials rr)
        {
            long forecast_recommendation_Id = 0;
            using (DBEntities db = new DBEntities())
            {
                if (rr.Finviz_FinancialId > 0)
                {
                    fin_Financials temp = db.fin_Financials.Where(u => u.Finviz_FinancialId == rr.Finviz_FinancialId).FirstOrDefault();

                    if (temp != null)
                    {
                        temp.Stock_Id = rr.Stock_Id;
                        temp.job_run_Id = rr.job_run_Id;
                        temp.Data_Points = rr.Data_Points;
                        temp.Descriptor = rr.Descriptor;
                        
                    }
                }
                else
                {
                    db.fin_Financials.Add(rr);
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
