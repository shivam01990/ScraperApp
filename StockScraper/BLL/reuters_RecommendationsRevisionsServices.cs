using DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class reuters_RecommendationsRevisionsServices
    {
        #region--Instance--
        public static reuters_RecommendationsRevisionsServices Instance = new reuters_RecommendationsRevisionsServices();
        #endregion

        #region--Save Reuters Financials Dividends--
        public long Save_reuters_RecommendationsRevisions(reuters_RecommendationsRevisions rr)
        {
            long Reuters_RecommendationsRevisions_Id = 0;
            using (DBEntities db = new DBEntities())
            {
                if (rr.Reuters_RecommendationsRevisions_Id > 0)
                {
                    reuters_RecommendationsRevisions temp = db.reuters_RecommendationsRevisions.Where(u => u.Reuters_RecommendationsRevisions_Id == rr.Reuters_RecommendationsRevisions_Id).FirstOrDefault();

                    if (temp != null)
                    {
                        temp.Stock_Id = rr.Stock_Id;
                        temp.job_run_Id = rr.job_run_Id;
                        temp.LastRecommendationDate = rr.LastRecommendationDate;
                        temp.Linear_Scale = rr.Linear_Scale;
                        temp.AnalystRecommend_Current = rr.AnalystRecommend_Current;
                        temp.AnalystRecommend_Month_1 = rr.AnalystRecommend_Month_1;
                        temp.AnalystRecommend_Month_2 = rr.AnalystRecommend_Month_2;
                        temp.AnalystRecommend_Month_3 = rr.AnalystRecommend_Month_3;                       
                    }
                }
                else
                {
                    db.reuters_RecommendationsRevisions.Add(rr);
                }

                int x = db.SaveChanges();
                if (x > 0)
                {
                    Reuters_RecommendationsRevisions_Id = rr.Reuters_RecommendationsRevisions_Id;
                }
            }

            return Reuters_RecommendationsRevisions_Id;
        }
        #endregion
    }
}
