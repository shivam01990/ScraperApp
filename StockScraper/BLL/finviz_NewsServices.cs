using DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class finviz_NewsServices
    {
        #region--Instance--
        public static finviz_NewsServices Instance = new finviz_NewsServices();
        #endregion

        #region--Save fin_News--
        public long Save_fin_News(finviz_News rr)
        {
            long NewsId = 0;
            using (DBEntities db = new DBEntities())
            {
                if (rr.finviz_news_id > 0)
                {
                    finviz_News temp = db.finviz_News.Where(u => u.finviz_news_id == rr.finviz_news_id).FirstOrDefault();

                    if (temp != null)
                    {

                        temp.job_run_id = rr.job_run_id;
                        temp.news_date = rr.news_date;
                        temp.news_message = rr.news_message;
                        temp.news_link = rr.news_link;
                    }
                }
                else
                {
                    db.finviz_News.Add(rr);
                }

                int x = db.SaveChanges();
                if (x > 0)
                {
                    NewsId = rr.finviz_news_id;
                }
            }

            return NewsId;
        }
        #endregion
    }
}
