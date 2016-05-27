using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLL;
using BLL;

namespace StockScraper
{
    public class ReutersProvider
    {
        public static void StartImport(int job_id, ws_Stocks stock, ws_JobScheduler objJobScheduler, ws_JobRuns jobRun)
        {
            string ticker = stock.Ticker;
            HtmlWeb web = new HtmlWeb();
            string analyticUrl = Helper.GetReutersAnalyticsUrls(ticker);
            jobRun.web_calls_total += 1;
            Console.WriteLine("Loading URL: " + analyticUrl);
            HtmlDocument doc1 = web.Load(analyticUrl);
            Console.WriteLine("Document Loaded: " + analyticUrl);
            jobRun.web_calls_success += 1;
          
            // Get reuters_RecommendationsRevisions
            //try
            //{
            //    List<reuters_RecommendationsRevisions> lst_reuters_RecommendationsRevisions = reuters_RecommendationsRevisionsProvider.GetData(doc1, job_id, stock.Stock_Id, analyticUrl);

            //    foreach (reuters_RecommendationsRevisions item in lst_reuters_RecommendationsRevisions)
            //    {
            //        reuters_RecommendationsRevisionsServices.Instance.Save_reuters_RecommendationsRevisions(item);
            //    }

            //    Console.WriteLine("Total " + lst_reuters_RecommendationsRevisions.Count + " records Grabbed for table: reuters_RecommendationsRevisions");

            //}
            //catch (Exception ex)
            //{
            //    Helper.AddtoLog(ex.ToString(), job_id, true, Helper.LogStatus.fail);
            //}

            //Get reuters_Financials
            if (objJobScheduler.schedulertype_id == AppSettings.financestatementjobid)
            {
                try
                {
                    List<reuters_Financials_SalesEstimates> lst_reuters_Financials_SalesEstimate = reuters_Financials_SalesEstimatesProvider.GetData(doc1, job_id,objJobScheduler.scheduler_id, stock.Stock_Id, analyticUrl);
                    foreach (reuters_Financials_SalesEstimates item in lst_reuters_Financials_SalesEstimate)
                    {
                        reuters_Financials_SalesEstimatesSevices.Instance.Save_reuters_Financials_SalesEstimates(item);
                    }

                    Console.WriteLine("Total " + lst_reuters_Financials_SalesEstimate.Count + " records Grabbed for table: reuters_Financials_SalesEstimate");

                }
                catch (Exception ex)
                {
                    //Helper.AddtoLog(ex.ToString(), job_id, true, Helper.LogStatus.fail);
                }

                /////////////////////////////////Financial Highlights//////////////////////////////////////////////////
                string financialHighlightsUrl = Helper.GetReutersfinancialHighlightsUrls(ticker);
                Console.WriteLine("Loading URL: " + financialHighlightsUrl);
                HtmlDocument doc2 = web.Load(financialHighlightsUrl);
                Console.WriteLine("Document Loaded: " + financialHighlightsUrl);

                // Get reuters_Financials_ValuationRatios
                try
                {
                    List<reuters_Financials_ValuationRatios> lst_reuters_Financials_ValuationRatios = reuters_Financials_ValuationRatiosProvider.GetData(doc2, job_id,objJobScheduler.scheduler_id, stock.Stock_Id, financialHighlightsUrl);
                    foreach (reuters_Financials_ValuationRatios item in lst_reuters_Financials_ValuationRatios)
                    {
                        reuters_Financials_ValuationRatiosServices.Instance.Save_reuters_Financials_ValuationRatios(item);
                    }

                    Console.WriteLine("Total " + lst_reuters_Financials_ValuationRatios.Count + " records Grabbed for table: reuters_Financials_ValuationRatios");

                }
                catch (Exception ex)
                {
                    Helper.AddtoLog(ex.ToString(), job_id,objJobScheduler.scheduler_id,stock.Stock_Id, true, Helper.LogStatus.fail);
                }

                //Get reuters_Financials_Dividends
                try
                {
                    List<reuters_Financials_Dividends> lst_reuters_Financials_Dividends = reuters_Financials_DividendsProvider.GetData(doc2, job_id,objJobScheduler.scheduler_id, stock.Stock_Id, financialHighlightsUrl);
                    foreach (reuters_Financials_Dividends item in lst_reuters_Financials_Dividends)
                    {
                        reuters_Financials_DividendsServices.Instance.Save_Reuters_Financials_Dividends(item);
                    }
                    Console.WriteLine("Total " + lst_reuters_Financials_Dividends.Count + " records Grabbed for table: reuters_Financials_Dividends");

                }
                catch (Exception ex)
                {
                    Helper.AddtoLog(ex.ToString(), job_id,objJobScheduler.scheduler_id,stock.Stock_Id, true, Helper.LogStatus.fail);
                }

                //Get reuters_Financials_GrowthRates
                try
                {
                    List<reuters_Financials_GrowthRates> lst_reuters_Financials_GrowthRates = reuters_Financials_GrowthRatesProvider.GetData(doc2, job_id,objJobScheduler.scheduler_id, stock.Stock_Id, financialHighlightsUrl);
                    foreach (reuters_Financials_GrowthRates item in lst_reuters_Financials_GrowthRates)
                    {
                        reuters_Financials_GrowthRatesRatesServices.Instance.Save_reuters_Financials_GrowthRatesRates(item);
                    }
                    Console.WriteLine("Total " + lst_reuters_Financials_GrowthRates.Count + " records Grabbed for table: reuters_Financials_GrowthRates");
                }
                catch (Exception ex)
                {
                    Helper.AddtoLog(ex.ToString(), job_id,objJobScheduler.scheduler_id,stock.Stock_Id, true, Helper.LogStatus.fail);
                }

                //Get reuters_Financials_Strength
                try
                {
                    List<reuters_Financials_Strength> lst_reuters_Financials_Strength = reuters_Financials_StrengthProvider.GetData(doc2, job_id,objJobScheduler.scheduler_id, stock.Stock_Id, financialHighlightsUrl);
                    foreach (reuters_Financials_Strength item in lst_reuters_Financials_Strength)
                    {
                        reuters_Financials_StrengthServices.Instance.Save_reuters_Financials_Strength(item);
                    }
                    Console.WriteLine("Total " + lst_reuters_Financials_Strength.Count + " records Grabbed for table: reuters_Financials_Strength");

                }
                catch (Exception ex)
                {
                    Helper.AddtoLog(ex.ToString(), job_id,objJobScheduler.scheduler_id,stock.Stock_Id, true, Helper.LogStatus.fail);
                }

                //Get reuters_Financials_ProfitabilityRatios
                try
                {
                    List<reuters_Financials_ProfitabilityRatios> lst_reuters_Financials_ProfitabilityRatios = reuters_Financials_ProfitabilityRatiosProvider.GetData(doc2, job_id,objJobScheduler.scheduler_id, stock.Stock_Id, financialHighlightsUrl);
                    foreach (reuters_Financials_ProfitabilityRatios item in lst_reuters_Financials_ProfitabilityRatios)
                    {
                        reuters_Financials_ProfitabilityRatios_Services.Instance.Save_reuters_Financials_ProfitabilityRatios(item);

                    }
                    Console.WriteLine("Total " + lst_reuters_Financials_ProfitabilityRatios.Count + " records Grabbed for table: reuters_Financials_ProfitabilityRatios");

                }
                catch (Exception ex)
                {
                    Helper.AddtoLog(ex.ToString(), job_id,objJobScheduler.scheduler_id,stock.Stock_Id, true, Helper.LogStatus.fail);
                }

                //Get reuters_Financials_Efficiencies
                try
                {
                    List<reuters_Financials_Efficiencies> lst_reuters_Financials_Efficiencies = reuters_Financials_EfficienciesProvider.GetData(doc2, job_id,objJobScheduler.scheduler_id, stock.Stock_Id, financialHighlightsUrl);
                    foreach (reuters_Financials_Efficiencies item in lst_reuters_Financials_Efficiencies)
                    {
                        reuters_Financials_EfficienciesServices.Instance.Save_Reuters_Financials_Efficiencies(item);
                    }
                    Console.WriteLine("Total " + lst_reuters_Financials_Efficiencies.Count + " records Grabbed for table: reuters_Financials_Efficiencies");

                }
                catch (Exception ex)
                {
                    Helper.AddtoLog(ex.ToString(), job_id,objJobScheduler.scheduler_id,stock.Stock_Id, true, Helper.LogStatus.fail);
                }

                //Get reuters_Financials_MgmtEffectiveness
                try
                {
                    List<reuters_Financials_MgmtEffectiveness> lst_reuters_Financials_MgmtEffectiveness = reuters_Financials_MgmtEffectivenessProvider.GetData(doc2, job_id,objJobScheduler.scheduler_id, stock.Stock_Id, financialHighlightsUrl);
                    foreach (reuters_Financials_MgmtEffectiveness item in lst_reuters_Financials_MgmtEffectiveness)
                    {
                        reuters_Financials_MgmtEffectivenessServices.Instance.Save_reuters_Financials_MgmtEffectiveness(item);
                    }
                    Console.WriteLine("Total " + lst_reuters_Financials_MgmtEffectiveness.Count + " records Grabbed for table: reuters_Financials_MgmtEffectiveness");
                }
                catch (Exception ex)
                {
                    Helper.AddtoLog(ex.ToString(), job_id,objJobScheduler.scheduler_id,stock.Stock_Id, true, Helper.LogStatus.fail);
                }

                //Get reuters_Financials_Institutions
                try
                {
                    List<reuters_Financials_Institutions> lst_reuters_Financials_Institutions = reuters_Financials_InstitutionsProvider.GetData(doc2, job_id,objJobScheduler.scheduler_id, stock.Stock_Id, financialHighlightsUrl);
                    foreach (reuters_Financials_Institutions item in lst_reuters_Financials_Institutions)
                    {
                        reuters_Financials_InstitutionsServices.Instance.Save_reuters_Financials_Institutions(item);
                    }
                    Console.WriteLine("Total " + lst_reuters_Financials_Institutions.Count + " records Grabbed for table: reuters_Financials_Institutions");

                }
                catch (Exception ex)
                {
                    Helper.AddtoLog(ex.ToString(), job_id,objJobScheduler.scheduler_id,stock.Stock_Id, true, Helper.LogStatus.fail);
                }
            }
        }
    }
}
