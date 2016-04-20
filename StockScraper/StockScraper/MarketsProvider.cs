using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockScraper
{
    public class MarketsProvider
    {
        public static void StartImport()
        {
            string ticker = "MBLY";
            HtmlWeb web = new HtmlWeb();
            string marketUrl = Helper.GetMarketsUrls(ticker);
            HtmlDocument doc1 = web.Load(marketUrl);
            ft_forecasts_recommendationsProvider.GetData(doc1, 0, 0);
            ft_forecasts_pricesProvider.GetData(doc1, 0, 0);

            //string marketfinancials = Helper.GetMarketsFinancialUrls(ticker);
            //HtmlDocument doc2 = web.Load(marketfinancials);
            //Markets_FinancialsProvider.GetData(doc2, 0, 0);
        }
    }
}
