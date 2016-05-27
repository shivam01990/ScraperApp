using BLL;
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
        public static List<finviz_Market_Movers> GetData(int job_id,ws_JobRuns objJobRun, ws_JobScheduler objJobScheduler)
        {
            objJobRun.web_calls_total = 1;
            HtmlWeb web = new HtmlWeb();
            Console.WriteLine("Loading URL: http://finviz.com/");
            HtmlDocument doc = web.Load("http://finviz.com/");
            objJobRun.web_calls_success = 1;
            Console.WriteLine("Loading complete");
            List<finviz_Market_Movers> rType = new List<finviz_Market_Movers>();
            string EffectiveDate = DateTime.Now.ToString("yyyy.MM.dd");

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
                            decimal percent_change = 0;
                            decimal.TryParse(tr1.ChildNodes[3].InnerText, out percent_change);

                            decimal last_quote = 0;
                            decimal.TryParse(tr1.ChildNodes[2].InnerText, out last_quote);


                            int volume = 0;
                            int.TryParse(tr1.ChildNodes[4].InnerText, out volume);


                            finviz_Market_Movers temp = new finviz_Market_Movers();
                            temp.ticker = tr1.ChildNodes[1].InnerText;

                            int StockID = ws_StocksServices.Instance.StockIDByTicker(temp.ticker);

                            if (StockID == 0)
                            {
                                if (temp.ticker.ToLower() != "ticker")
                                {
                                    Console.WriteLine("Inserting a new Stock for Ticker:" + temp.ticker);
                                    StockID = UpdateNewStocks.StartUpdate(temp.ticker,objJobRun,objJobScheduler);
                                }
                            } if (StockID > 0)
                            {

                                temp.stock_id = StockID;
                                temp.last_quote = last_quote;
                                temp.percent_change = percent_change;
                                temp.volume = volume;
                                temp.signal = tr1.ChildNodes[6].InnerText;
                                temp.job_run_id = job_id;
                                temp.EffectiveDate = EffectiveDate;
                                rType.Add(temp);
                            }
                        }
                        catch
                        {
                        }
                    }

                }
            }
            finviz_Market_Movers tmp = rType.Where(r => r.ticker == "Ticker").FirstOrDefault();
            if (tmp != null)
            {
                rType.Remove(tmp);
            }
            return rType;
        }

    }
}
