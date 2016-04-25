using DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ft_ConsensusServices
    {
        #region--Instance--
        public static ft_ConsensusServices Instance = new ft_ConsensusServices();
        #endregion

        #region--Save ft_forecasts_prices--
        public long Save_ft_Consensus(ft_Consensus rr)
        {
            long forecast_recommendation_Id = 0;
            using (DBEntities db = new DBEntities())
            {
                if (rr.ConsensusId > 0)
                {
                    ft_Consensus temp = db.ft_Consensus.Where(u => u.ConsensusId == rr.ConsensusId).FirstOrDefault();

                    if (temp != null)
                    {
                        temp.stock_id = rr.stock_id;
                        temp.job_run_id = rr.job_run_id;
                        temp.effective_date = rr.effective_date;
                        temp.consensus = rr.consensus;
                        temp.buy_analyst_count = rr.buy_analyst_count;
                        temp.outperform_analyst_count = rr.outperform_analyst_count;
                        temp.hold_analyst_count = rr.hold_analyst_count;
                        temp.underperform_analyst_count = rr.underperform_analyst_count;
                        temp.sell_analyst_count = rr.sell_analyst_count;
                        temp.no_opinion_analyst_count = rr.no_opinion_analyst_count;
                    }
                }
                else
                {
                    db.ft_Consensus.Add(rr);
                }

                int x = db.SaveChanges();
                if (x > 0)
                {
                    forecast_recommendation_Id = rr.ConsensusId;
                }
            }

            return forecast_recommendation_Id;
        }
        #endregion
    }
}
