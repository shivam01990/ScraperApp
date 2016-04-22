using DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ft_fin_normalized_incomeServices
    {
        #region--Instance--
        public static ft_fin_normalized_incomeServices Instance = new ft_fin_normalized_incomeServices();
        #endregion

        #region--Save Reuters Financials Dividends--
        public long Save_ft_fin_normalized_income(ft_fin_normalized_income rr)
        {
            long Reuters_FinancialsDividend_Id = 0;
            using (DBEntities db = new DBEntities())
            {
                if (rr.normalized_income_id > 0)
                {
                    ft_fin_normalized_income temp = db.ft_fin_normalized_income.Where(u => u.normalized_income_id == rr.normalized_income_id).FirstOrDefault();

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
                    db.ft_fin_normalized_income.Add(rr);
                }

                int x = db.SaveChanges();
                if (x > 0)
                {
                    Reuters_FinancialsDividend_Id = rr.normalized_income_id;
                }
            }

            return Reuters_FinancialsDividend_Id;
        }
        #endregion
    }
}
