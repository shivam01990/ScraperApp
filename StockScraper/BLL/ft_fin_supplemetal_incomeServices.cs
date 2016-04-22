using DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    class ft_fin_supplemetal_incomeServices
    {
        #region--Instance--
        public static ft_fin_supplemetal_incomeServices Instance = new ft_fin_supplemetal_incomeServices();
        #endregion

        #region--Save ft_fin_supplemetal_income--
        public long Save_ft_fin_supplemetal_income(ft_fin_supplemetal_income rr)
        {
            long revenue_and_gross_profit_id = 0;
            using (DBEntities db = new DBEntities())
            {
                if (rr.supplemetal_income_id > 0)
                {
                    ft_fin_supplemetal_income temp = db.ft_fin_supplemetal_income.Where(u => u.supplemetal_income_id == rr.supplemetal_income_id).FirstOrDefault();

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
                    db.ft_fin_supplemetal_income.Add(rr);
                }

                int x = db.SaveChanges();
                if (x > 0)
                {
                    revenue_and_gross_profit_id = rr.supplemetal_income_id;
                }
            }

            return revenue_and_gross_profit_id;
        }
        #endregion
    }
}
