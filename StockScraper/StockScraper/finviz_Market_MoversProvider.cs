using DLL;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockScraper
{
    class finviz_Market_MoversProvider
    {
        public static List<fin_Market_Movers> GetData(int job_id)
        {

            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load("http://finviz.com/");
            List<fin_Market_Movers> rType = new List<fin_Market_Movers>();


            var tblrows1 = doc.DocumentNode.SelectNodes("//table[@class='t-home-table']//tr");
            if (tblrows1 != null)
            {
                for (int k = 1; k < tblrows1.Count; k++)
                {
                    HtmlNode tr1 = tblrows1[k];
                    if (tr1.ChildNodes.Count() == 8)
                    {
                        try
                        {

                            fin_Market_Movers temp = new fin_Market_Movers();
                            temp.Ticker = tr1.ChildNodes[1].InnerText;
                            temp.Last= tr1.ChildNodes[2].InnerText;
                            temp.Change = tr1.ChildNodes[3].InnerText;
                            temp.Volume = tr1.ChildNodes[4].InnerText;
                            temp.Signal = tr1.ChildNodes[6].InnerText;                           
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
