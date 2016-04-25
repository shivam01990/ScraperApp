using DLL;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StockScraper
{
    public class NewsProvider
    {
        public static List<finviz_News> GetData(HtmlDocument doc, int job_id, int stock_id, string URL)
        {
            List<finviz_News> rType = new List<finviz_News>();

            var tblrows1 = doc.DocumentNode.SelectNodes("//table[@id='news-table']//tr");
            if (tblrows1 != null)
            {
                for (int k = 0; k < tblrows1.Count; k++)
                {
                    HtmlNode tr1 = tblrows1[k];
                    if (tr1.ChildNodes.Count() == 2)
                    {
                        try
                        {

                            finviz_News temp = new finviz_News();
                            string _date = tr1.ChildNodes[0].InnerText.Replace("&nbsp;", " "); ;
                            try
                            {
                                //temp.news_date = DateTime.Parse(_date);
                                temp.news_date = _date;
                            }
                            catch { }
                            temp.news_message = tr1.ChildNodes[1].InnerText;
                            try
                            {
                                temp.news_link = XElement.Parse("<th>" + tr1.ChildNodes[1].InnerHtml + "</th>")
                                                   .Descendants("a")
                                                   .Select(x => x.Attribute("href").Value)
                                                   .FirstOrDefault(); 
                            }
                            catch
                            { }
                            temp.stock_id = stock_id;
                            temp.job_run_id = job_id;
                            rType.Add(temp);
                        }
                        catch
                        {
                        }
                    }

                }
            }
            else
            {
                string warningmsg = Helper.GetWarningMSG(stock_id, "finviz_News", URL);
                Helper.AddtoLog(warningmsg, job_id, true, Helper.LogStatus.warning);
            }

            return rType;
        }

    }
}
