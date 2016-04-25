using DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class finviz_Insider_TradingServices
    {

        #region--Instance--
        public static finviz_Insider_TradingServices Instance = new finviz_Insider_TradingServices();
        #endregion

        #region--Save ft_forecasts_prices--
        public long Save_fin_Insider_Trading(finviz_Insider_Trading rr)
        {
            long Finviz_Insider_TradingId = 0;
            using (DBEntities db = new DBEntities())
            {
                if (rr.Finviz_Insider_TradingId > 0)
                {
                    finviz_Insider_Trading temp = db.finviz_Insider_Trading.Where(u => u.Finviz_Insider_TradingId == rr.Finviz_Insider_TradingId).FirstOrDefault();

                    if (temp != null)
                    {
                        temp.stock_Id = rr.stock_Id;
                        temp.Job_run_Id = rr.Job_run_Id;
                        temp.insider_Trading = rr.insider_Trading;
                        temp.relationship = rr.relationship;
                        temp.Date = rr.Date;
                        temp.it_transaction = rr.it_transaction;
                        temp.cost = rr.cost;
                        temp.shares = rr.shares;
                        temp.value = rr.value;
                        temp.shares_Total = rr.shares_Total;
                        temp.SEC_Form_4 = rr.SEC_Form_4;
                    }
                }
                else
                {
                    db.finviz_Insider_Trading.Add(rr);
                }

                int x = db.SaveChanges();
                if (x > 0)
                {
                    Finviz_Insider_TradingId = rr.Finviz_Insider_TradingId;
                }
            }

            return Finviz_Insider_TradingId;
        }
        #endregion
    }
}
