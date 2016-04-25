using DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class ft_FinancialsProvider
    {
        #region--Instance--
       public static ft_FinancialsProvider Instance = new ft_FinancialsProvider();
        #endregion

        #region--Save ft_Financials--
        public long Save_ft_Financials(ft_Financials rr)
        {
            long financial_id = 0;
            using (DBEntities db = new DBEntities())
            {
              db.ft_Financials.Add(rr);
              int x = db.SaveChanges();
              if (x > 0)
              {
                  financial_id = rr.financial_id;
              }
            }
            return financial_id;
        }
        #endregion
    }
}
