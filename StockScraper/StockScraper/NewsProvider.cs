using DLL;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockScraper
{
    public class NewsProvider
    {
        public static List<finviz_News> GetData(HtmlDocument doc, int job_id, int stock_id)
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
                                temp.Date = DateTime.Parse(_date);
                            }
                            catch { }
                            temp.NewsMsg = tr1.ChildNodes[1].InnerText;                            
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
