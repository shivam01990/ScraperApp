using DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ft_fin_operating_expensesServices
    {
        #region--Instance--
        public static ft_fin_operating_expensesServices Instance = new ft_fin_operating_expensesServices();
        #endregion

        #region--Save Reuters Financials Dividends--
        public long Save_ft_fin_operating_expenses(ft_fin_operating_expenses rr)
        {
            long operating_expenses_id = 0;
            using (DBEntities db = new DBEntities())
            {
                if (rr.operating_expenses_id > 0)
                {
                    ft_fin_operating_expenses temp = db.ft_fin_operating_expenses.Where(u => u.operating_expenses_id == rr.operating_expenses_id).FirstOrDefault();

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
                    db.ft_fin_operating_expenses.Add(rr);
                }

                int x = db.SaveChanges();
                if (x > 0)
                {
                    operating_expenses_id = rr.operating_expenses_id;
                }
            }

            return operating_expenses_id;
        }
        #endregion
    }
}
