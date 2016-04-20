using DLL;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockScraper
{
    public class finviz_RecommendationsProvider
    {
        public static List<finviz_Recommendations> GetData(HtmlDocument doc, int job_id, int stock_id)
        {
            List<finviz_Recommendations> rType = new List<finviz_Recommendations>();


            var tblrows1 = doc.DocumentNode.SelectNodes("//table[@class='fullview-ratings-outer']//tr[@class='body-table-rating-neutral']//tr");
            if (tblrows1 != null)
            {
                for (int k = 0; k < tblrows1.Count; k++)
                {
                    HtmlNode tr1 = tblrows1[k];
                    if (tr1.ChildNodes.Count() == 9)
                    {
                        try
                        {

                            finviz_Recommendations temp = new finviz_Recommendations();
                            temp.Date = tr1.ChildNodes[0].InnerText;
                            temp.RecommendationType = tr1.ChildNodes[1].InnerText;
                            temp.Analyst = tr1.ChildNodes[3].InnerText;
                            temp.Recommendation = tr1.ChildNodes[5].InnerText;
                            temp.Target = tr1.ChildNodes[7].InnerText;
                            temp.Stock_id = stock_id;
                            temp.Job_run_id = job_id;
                            rType.Add(temp);
                        }
                        catch
                        {
                        }
                    }

                }
            }

            return rType;
        }

    }
}
