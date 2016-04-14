using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockScraper
{
    public class ReutersProvider
    {
        public static void StartImport()
        {
            string ticker = "MMM";
            HtmlWeb web = new HtmlWeb();
            string analyticUrl = Helper.GetReutersAnalyticsUrls(ticker);
            HtmlDocument doc = web.Load(analyticUrl);            
           //Reuters_RecommendationsRevisionsProvider.GetData(doc, 0, 0);
            Reuters_Financials_SalesEstimatesProvider.GetData(doc, 0, 0);

        }
    }
}
