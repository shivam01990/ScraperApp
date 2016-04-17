using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockScraper
{
    public class finvizProvider
    {
       
        public static void StartImport()
        {
            string ticker = "MMM";
            HtmlWeb web = new HtmlWeb();
            string finvizUrl = Helper.finvizUrl(ticker);
            HtmlDocument doc = web.Load(finvizUrl);
            //Finviz_FinancialsProvider.GetData(doc, 0, 0);
            //Finviz_RecommendationsProvider.GetData(doc, 0, 0);
            NewsProvider.GetData(doc, 0, 0);
         
        }
    }
}
