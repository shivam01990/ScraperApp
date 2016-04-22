using DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ft_forecasts_recommendationsServices
    {
        #region--Instance--
        public static ft_forecasts_recommendationsServices Instance = new ft_forecasts_recommendationsServices();
        #endregion

        #region--Save ft_forecasts_prices--
        public long Save_ft_forecasts_prices(ft_forecasts_recommendations rr)
        {
            long forecast_recommendation_Id = 0;
            using (DBEntities db = new DBEntities())
            {
                if (rr.forecast_recommendation_Id > 0)
                {
                    ft_forecasts_recommendations temp = db.ft_forecasts_recommendations.Where(u => u.forecast_recommendation_Id == rr.forecast_recommendation_Id).FirstOrDefault();

                    if (temp != null)
                    {
                        temp.stock_id = rr.stock_id;
                        temp.job_run_id = rr.job_run_id;
                        temp.effective_date = rr.effective_date;
                        temp.Recommendation_consensus = rr.Recommendation_consensus;
                        temp.Recommendation_type = rr.Recommendation_type;
                        temp.Recommendations = rr.Recommendations;
                        temp.Analyst = rr.Analyst;
                        temp.Target = rr.Target;
                    }
                }
                else
                {
                    db.ft_forecasts_recommendations.Add(rr);
                }

                int x = db.SaveChanges();
                if (x > 0)
                {
                    forecast_recommendation_Id = rr.forecast_recommendation_Id;
                }
            }

            return forecast_recommendation_Id;
        }
        #endregion
    }
}
