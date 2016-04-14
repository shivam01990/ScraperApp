using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDCDAL
{
    public class MarketMoverProvider
    {
        #region--Instance--
        public static MarketMoverProvider Instance = new MarketMoverProvider();
        #endregion

        #region--Save Market Mover--
        public int SaveMarketMover(MarketMover mm)
        {
            int Market_MoverId = 0;
            using (DBEntities db = new DBEntities())
            {
                if (mm.Market_MoverId==0)
                {
                  int count=  db.MarketMovers.Where(u => u.Ticker == mm.Ticker).Count();
                    if(count>0)
                    {
                        return 0;
                    }
                }
                if (mm.Market_MoverId > 0)
                {
                    MarketMover temp = db.MarketMovers.Where(u => u.Market_MoverId == mm.Market_MoverId).FirstOrDefault();

                    if (temp != null)
                    {
                        temp.Name = mm.Name;
                        temp.Ticker = mm.Ticker;
                        temp.Data_Display = mm.Data_Display;
                        temp.Exchange = mm.Exchange;
                        temp.Sector = mm.Sector;
                        temp.Industry = mm.Industry;                        
                    }
                }
                else
                {
                    db.MarketMovers.Add(mm);
                }

                int x = db.SaveChanges();
                if (x > 0)
                {
                    Market_MoverId = mm.Market_MoverId;
                }
            }

            return Market_MoverId;
        }
        #endregion
    }
}
