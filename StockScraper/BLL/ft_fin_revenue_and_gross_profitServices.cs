using DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class ft_fin_revenue_and_gross_profitServices
    {
        #region--Instance--
       public static ft_fin_revenue_and_gross_profitServices Instance = new ft_fin_revenue_and_gross_profitServices();
        #endregion

        #region--Save Reuters Financials Dividends--
       public long Save_ft_fin_revenue_and_gross_profit(ft_fin_revenue_and_gross_profit rr)
        {
            long revenue_and_gross_profit_id = 0;
            using (DBEntities db = new DBEntities())
            {
                if (rr.revenue_and_gross_profit_id > 0)
                {
                    ft_fin_revenue_and_gross_profit temp = db.ft_fin_revenue_and_gross_profit.Where(u => u.revenue_and_gross_profit_id == rr.revenue_and_gross_profit_id).FirstOrDefault();

                    if (temp != null)
                    {
                        temp.stock_id = rr.stock_id;
                        temp.job_run_id = rr.job_run_id;
                        temp.Title = rr.Title;
                        temp.First_Year = rr.First_Year;
                        temp.Second_Year = rr.Second_Year;
                        temp.Third_Year = rr.Third_Year;
                    }
                }
                else
                {
                    db.ft_fin_revenue_and_gross_profit.Add(rr);
                }

                int x = db.SaveChanges();
                if (x > 0)
                {
                    revenue_and_gross_profit_id = rr.revenue_and_gross_profit_id;
                }
            }

            return revenue_and_gross_profit_id;
        }
        #endregion
    
    }
}
