using DLL;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockScraper
{
    public class Finviz_RecommendationsProvider
    {
        public static List<Finviz_Recommendations> GetData(HtmlDocument doc, int job_id, int stock_id)
        {
            List<Finviz_Recommendations> rType = new List<Finviz_Recommendations>();


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

                            Finviz_Recommendations temp = new Finviz_Recommendations();
                            temp.Date = tr1.ChildNodes[0].InnerText;
                            temp.RecommendationType = tr1.ChildNodes[1].InnerText;
                            temp.Analyst = tr1.ChildNodes[3].InnerText;
                            temp.Recommendation = tr1.ChildNodes[5].InnerText;
                            temp.Target = tr1.ChildNodes[7].InnerText;
                            temp.Stock_Id = stock_id;
                            temp.Job_Id = job_id;
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
