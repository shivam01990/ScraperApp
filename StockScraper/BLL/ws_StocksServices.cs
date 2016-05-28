using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLL;

namespace BLL
{
    public class ws_StocksServices
    {
        #region--Instance--
        public static ws_StocksServices Instance = new ws_StocksServices();
        #endregion

        #region--Get Stock--
        public List<ws_Stocks> GetStock(int stock_Id)
        {
            List<ws_Stocks> rType = new List<ws_Stocks>();
            using (DBEntities db = new DBEntities())
            {
                rType = (from s in db.ws_Stocks
                         where ((s.Stock_Id == stock_Id) || (stock_Id == 0))
                         select s).ToList();
            }
            return rType;
        }
        #endregion

        #region--Save Stock--
        public int SaveStock(ws_Stocks ss)
        {
            int Market_MoverId = 0;
            using (DBEntities db = new DBEntities())
            {
                if (ss.Stock_Id == 0)
                {
                    int count = db.ws_Stocks.Where(u => u.Ticker == ss.Ticker).Count();
                    if (count > 0)
                    {
                        return 0;
                    }
                }
                if (ss.Stock_Id > 0)
                {
                    ws_Stocks temp = db.ws_Stocks.Where(u => u.Stock_Id == ss.Stock_Id).FirstOrDefault();

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
                        temp.company_desc_finviz = ss.company_desc_finviz;
                        temp.sub_sector = ss.sub_sector;
                        temp.country = ss.country;
                        temp.Format_Issue_Symbol = temp.Format_Issue_Symbol;
                    }
                }
                else
                {
                    db.ws_Stocks.Add(ss);
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

        #region--Get StockIDByTicker--
        public int StockIDByTicker(string Ticker)
        {
            int stockid = 0;
            using (DBEntities db = new DBEntities())
            {
                try
                {
                    stockid = db.ws_Stocks.Where(s => s.Ticker == Ticker).FirstOrDefault().Stock_Id;
                }
                catch { }
            }
            return stockid;
        }
        #endregion

        #region--Get stock by FailRecords--
        public List<ws_Stocks> GetStockbyFailRecords(List<p_GetLastFailRecords_Result> failrecords)
        {
            List<int> stockids= failrecords.Select(s=>s.stock_id).ToList();
            using (DBEntities db = new DBEntities())
            {
              return db.ws_Stocks.Where(s => stockids.Contains(s.Stock_Id)).ToList();
            }
        }
        #endregion
    }
}
