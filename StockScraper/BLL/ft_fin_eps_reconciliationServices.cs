using DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class ft_fin_eps_reconciliationServices
    {
       #region--Instance--
       public static ft_fin_eps_reconciliationServices Instance = new ft_fin_eps_reconciliationServices();
       #endregion

       #region--Save Reuters Financials Dividends--
       public long Save_ft_fin_eps_reconciliation(ft_fin_eps_reconciliation rr)
       {
           long Reuters_FinancialsDividend_Id = 0;
           using (DBEntities db = new DBEntities())
           {
               if (rr.eps_reconciliation_id > 0)
               {
                   ft_fin_eps_reconciliation temp = db.ft_fin_eps_reconciliation.Where(u => u.eps_reconciliation_id == rr.eps_reconciliation_id).FirstOrDefault();

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
                   db.ft_fin_eps_reconciliation.Add(rr);
               }

               int x = db.SaveChanges();
               if (x > 0)
               {
                   Reuters_FinancialsDividend_Id = rr.eps_reconciliation_id;
               }
           }

           return Reuters_FinancialsDividend_Id;
       }
       #endregion
  
    }
}
