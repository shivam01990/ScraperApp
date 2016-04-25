using DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class finviz_RecommendationsServices
    {
        #region--Instance--
       public static finviz_RecommendationsServices Instance = new finviz_RecommendationsServices();
        #endregion

        #region--Save fin_News--
       public long Save_fin_Recommendations(finviz_Recommendations rr)
        {
            long RecommendationId = 0;
            using (DBEntities db = new DBEntities())
            {
                if (rr.finviz_recommendationId > 0)
                {
                    finviz_Recommendations temp = db.finviz_Recommendations.Where(u => u.finviz_recommendationId == rr.finviz_recommendationId).FirstOrDefault();

                    if (temp != null)
                    {

                        temp.job_run_id = rr.job_run_id;
                        temp.Date = rr.Date;
                        temp.stock_id = rr.stock_id;
                        temp.Date = rr.Date;
                        temp.Analyst = rr.Analyst;
                        temp.RecommendationType = rr.RecommendationType;
                        temp.Recommendation = rr.Recommendation;
                        temp.Target = rr.Target;

                    }
                }
                else
                {
                    db.finviz_Recommendations.Add(rr);
                }

                int x = db.SaveChanges();
                if (x > 0)
                {
                    RecommendationId = rr.finviz_recommendationId;
                }
            }

            return RecommendationId;
        }
        #endregion
    }
}
