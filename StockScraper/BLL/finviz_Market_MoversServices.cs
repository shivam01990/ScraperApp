using DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class finviz_Market_MoversServices
    {
        #region--Instance--
        public static finviz_Market_MoversServices Instance = new finviz_Market_MoversServices();
        #endregion

        #region--Save ft_forecasts_prices--
        public long Save_fin_Market_Movers(finviz_Market_Movers rr)
        {
            long Market_Movers_Id = 0;
            using (DBEntities db = new DBEntities())
            {
                if (rr.finviz_market_movers_id > 0)
                {
                    finviz_Market_Movers temp = db.finviz_Market_Movers.Where(u => u.finviz_market_movers_id == rr.finviz_market_movers_id).FirstOrDefault();

                    if (temp != null)
                    {

                        temp.job_run_id = rr.job_run_id;
                        temp.ticker = rr.ticker;
                        temp.last_quote = rr.last_quote;
                        temp.percent_change = rr.percent_change;
                        temp.volume = rr.volume;
                        temp.signal = rr.signal;
                    }
                }
                else
                {
                    db.finviz_Market_Movers.Add(rr);
                }

                int x = db.SaveChanges();
                if (x > 0)
                {
                    Market_Movers_Id = rr.finviz_market_movers_id;
                }
            }

            return Market_Movers_Id;
        }
        #endregion
    }
}
