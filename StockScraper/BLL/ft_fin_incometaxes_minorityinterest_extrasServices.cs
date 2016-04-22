using DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ft_fin_incometaxes_minorityinterest_extrasServices
    {
        #region--Instance--
        public static ft_fin_incometaxes_minorityinterest_extrasServices Instance = new ft_fin_incometaxes_minorityinterest_extrasServices();
        #endregion

        #region--Save Reuters Financials Dividends--
        public long Save_ft_fin_incometaxes_minorityinterest_extras(ft_fin_incometaxes_minorityinterest_extras rr)
        {
            long incometaxes_minorityinterest_extras_id = 0;
            using (DBEntities db = new DBEntities())
            {
                if (rr.incometaxes_minorityinterest_extras_id > 0)
                {
                    ft_fin_incometaxes_minorityinterest_extras temp = db.ft_fin_incometaxes_minorityinterest_extras.Where(u => u.incometaxes_minorityinterest_extras_id == rr.incometaxes_minorityinterest_extras_id).FirstOrDefault();

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
                    db.ft_fin_incometaxes_minorityinterest_extras.Add(rr);
                }

                int x = db.SaveChanges();
                if (x > 0)
                {
                    incometaxes_minorityinterest_extras_id = rr.incometaxes_minorityinterest_extras_id;
                }
            }

            return incometaxes_minorityinterest_extras_id;
        }
        #endregion
    }
}
