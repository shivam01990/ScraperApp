using DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ft_ForecastsServices
    {
        #region--Instance--
        public static ft_ForecastsServices Instance = new ft_ForecastsServices();
        #endregion

        #region--Save ft_forecasts_prices--
        public long Save_ft_Forecasts(ft_Forecasts rr)
        {
            long revenue_and_gross_profit_id = 0;
            using (DBEntities db = new DBEntities())
            {
                if (rr.forecast_id > 0)
                {
                    ft_Forecasts temp = db.ft_Forecasts.Where(u => u.forecast_id == rr.forecast_id).FirstOrDefault();

                    if (temp != null)
                    {
                        temp.stock_id = rr.stock_id;
                        temp.job_run_id = rr.job_run_id;
                        temp.effective_date = rr.effective_date;
                        temp.forecast_description = rr.forecast_description;
                        temp.current_price = rr.current_price;
                        temp.high_target_price = rr.high_target_price;
                        temp.medium_target_price = rr.medium_target_price;
                        temp.low_target_price = rr.low_target_price;
                        temp.time_period_unit = rr.time_period_unit;
                        temp.time_period = rr.time_period;
                    }
                }
                else
                {
                    db.ft_Forecasts.Add(rr);
                }

                int x = db.SaveChanges();
                if (x > 0)
                {
                    revenue_and_gross_profit_id = rr.forecast_id;
                }
            }

            return revenue_and_gross_profit_id;
        }
        #endregion
    }
}
