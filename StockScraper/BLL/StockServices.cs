using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLL;

namespace BLL
{
    public class StockServices
    {
        #region--Instance--
        public static StockServices Instance = new StockServices();
        #endregion

        #region--Get Stock--
        public List<Stock> GetStock(int stock_Id)
        {
            List<Stock> rType = new List<Stock>();
            using (DBEntities db = new DBEntities())
            {
                rType = (from s in db.Stocks
                         where ((s.Stock_Id == stock_Id) || (stock_Id == 0))
                         select s).ToList();
            }
            return rType;
        }
        #endregion

        #region--Save Stock--
        public int SaveStock(Stock ss)
        {
            int Market_MoverId = 0;
            using (DBEntities db = new DBEntities())
            {
                if (ss.Stock_Id == 0)
                {
                    int count = db.Stocks.Where(u => u.Ticker == ss.Ticker).Count();
                    if (count > 0)
                    {
                        return 0;
                    }
                }
                if (ss.Stock_Id > 0)
                {
                    Stock temp = db.Stocks.Where(u => u.Stock_Id == ss.Stock_Id).FirstOrDefault();

                    if (temp != null)
                    {
                        temp.Ticker = ss.Ticker;
                        temp.Company_Name = ss.Company_Name;
                        temp.Exchange = ss.Exchange;
                        temp.Sector = ss.Sector;
                        temp.Industry = ss.Industry;
                        temp.Exchange_Abbr = ss.Exchange_Abbr;
                        temp.Exchange_Letter = ss.Exchange_Letter;
                        temp.StatusState_Id = ss.StatusState_Id;
                    }
                }
                else
                {
                    db.Stocks.Add(ss);
                }

                int x = db.SaveChanges();
                if (x > 0)
                {
                    Market_MoverId = ss.Stock_Id;
                }
            }

            return Market_MoverId;
        }
        #endregion
    }
}
