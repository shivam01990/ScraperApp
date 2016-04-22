using DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ft_forecasts_pricesServices
    {
        #region--Instance--
        public static ft_forecasts_pricesServices Instance = new ft_forecasts_pricesServices();
        #endregion

        #region--Save ft_forecasts_prices--
        public long Save_ft_forecasts_prices(ft_forecasts_prices rr)
        {
            long revenue_and_gross_profit_id = 0;
            using (DBEntities db = new DBEntities())
            {
                if (rr.forecasts_prices_Id > 0)
                {
                    ft_forecasts_prices temp = db.ft_forecasts_prices.Where(u => u.forecasts_prices_Id == rr.forecasts_prices_Id).FirstOrDefault();

                    if (temp != null)
                    {
                        temp.stock_id = rr.stock_id;
                        temp.job_run_id = rr.job_run_id;
                        temp.effective_date = rr.effective_date;
                        temp.share_price_forecast = rr.share_price_forecast;
                        temp.current_price = rr.current_price;
                        temp.target_level = rr.target_level;
                        temp.target_price = rr.target_price;                        
                    }
                }
                else
                {
                    db.ft_forecasts_prices.Add(rr);
                }

                int x = db.SaveChanges();
                if (x > 0)
                {
                    revenue_and_gross_profit_id = rr.forecasts_prices_Id;
                }
            }

            return revenue_and_gross_profit_id;
        }
        #endregion
    }
}
