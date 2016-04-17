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
            //HtmlDocument doc1 = web.Load(analyticUrl);
            //Reuters_RecommendationsRevisionsProvider.GetData(doc1, 0, 0);
            //Reuters_Financials_SalesEstimatesProvider.GetData(doc1, 0, 0);


            string financialHighlightsUrl = Helper.GetReutersfinancialHighlightsUrls(ticker);
            HtmlDocument doc2 = web.Load(financialHighlightsUrl);
            //Reuters_Financials_ValuationRatiosProvider.GetData(doc2, 0, 0);
            //Reuters_Financials_DividendsProvider.GetData(doc2, 0, 0);
            //Reuters_Financials_GrowthRatesProvider.GetData(doc2, 0, 0);
            //Reuters_Financials_StrengthProvider.GetData(doc2, 0, 0);
            //Reuters_Financials_ProfitabilityRatiosProvider.GetData(doc2, 0, 0);
            //Reuters_Financials_EfficienciesProvider.GetData(doc2, 0, 0);
            //Reuters_Financials_MgmtEffectivenessProvider.GetData(doc2, 0, 0);
            Reuters_Financials_InstitutionsProvider.GetData(doc2, 0, 0);
          
        }
    }
}
