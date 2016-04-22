using DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ft_fin_common_stock_dividendsServices
    {
        #region--Instance--
        public static ft_fin_common_stock_dividendsServices Instance = new ft_fin_common_stock_dividendsServices();
        #endregion

        #region--Save Reuters Financials Dividends--
        public long Save_ft_fin_common_stock_dividends(ft_fin_common_stock_dividends rr)
        {
            long Reuters_FinancialsDividend_Id = 0;
            using (DBEntities db = new DBEntities())
            {
                if (rr.common_stock_dividends_id > 0)
                {
                    ft_fin_common_stock_dividends temp = db.ft_fin_common_stock_dividends.Where(u => u.common_stock_dividends_id == rr.common_stock_dividends_id).FirstOrDefault();

                    if (temp != null)
                    {
                        temp.stock_id = rr.stock_id;
                        temp.job_run_id = rr.job_run_id;
                        temp.effective_date = rr.effective_date;
                        temp.Title = rr.Title;
                        temp.First_Year = rr.First_Year;
                        temp.Second_Year = rr.Second_Year;
                        temp.Third_Year = rr.Third_Year;
                    }
                }
                else
                {
                    db.ft_fin_common_stock_dividends.Add(rr);
                }

                int x = db.SaveChanges();
                if (x > 0)
                {
                    Reuters_FinancialsDividend_Id = rr.common_stock_dividends_id;
                }
            }

            return Reuters_FinancialsDividend_Id;
        }
        #endregion
    }
}
