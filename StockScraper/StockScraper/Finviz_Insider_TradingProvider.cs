using DLL;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockScraper
{
    public class finviz_Insider_TradingProvider
    {
        public static List<finviz_Insider_Trading> GetData(HtmlDocument doc, int job_id, int stock_id)
        {
            List<finviz_Insider_Trading> rType = new List<finviz_Insider_Trading>();


            var tblrows1 = doc.DocumentNode.SelectNodes("//table[@class='body-table']//tr");
            if (tblrows1 != null)
            {
                for (int k = 1; k < tblrows1.Count; k++)
                {
                    HtmlNode tr1 = tblrows1[k];
                    if (tr1.ChildNodes.Count() == 9)
                    {
                        try
                        {

                            finviz_Insider_Trading temp = new finviz_Insider_Trading();
                            temp.Insider_Trading = tr1.ChildNodes[0].InnerText;
                            temp.Relashionship = tr1.ChildNodes[1].InnerText;
                            temp.Date = tr1.ChildNodes[2].InnerText;
                            temp.Transaction = tr1.ChildNodes[3].InnerText;
                            temp.Cost = tr1.ChildNodes[4].InnerText;
                            temp.Shares = tr1.ChildNodes[5].InnerText;
                            temp.Value = tr1.ChildNodes[6].InnerText;
                            temp.Shares_Total = tr1.ChildNodes[7].InnerText;
                            temp.SECForm4 = tr1.ChildNodes[8].InnerText;
                            temp.stock_Id = stock_id;
                            temp.Job_run_Id = job_id;
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
