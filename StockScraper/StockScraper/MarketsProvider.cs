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
    public class MarketsProvider
    {
        public static void StartImport(int job_id, ws_Stocks stock, ws_JobScheduler objJobScheduler, ws_JobRuns objJobRun)
        {
            if(string.IsNullOrWhiteSpace(stock.Format_Issue_Symbol))
            {
                stock = UpdateOldStock.StartUpdate(stock);
            }
            string format_issue_symbol = string.IsNullOrWhiteSpace(stock.Format_Issue_Symbol) ? stock.Ticker : stock.Format_Issue_Symbol.Trim();
            HtmlWeb web = new HtmlWeb();
            string marketUrl = Helper.GetMarketsUrls(format_issue_symbol);
            Console.WriteLine("Loading URL: " + marketUrl);
            objJobRun.web_calls_total += 1;
            HtmlDocument doc1 = web.Load(marketUrl);
            objJobRun.web_calls_success += 1;
            Console.WriteLine("Document Loaded: " + marketUrl);
            string EffectiveDate = "";
            //try
            //{
            //    ft_Consensus _ft_Consensus = ft_ConsensusProvider.GetData(doc1, job_id, stock.Stock_Id);
            //    _ft_Consensus.effective_date = _ft_Consensus.effective_date ?? "";
            //    EffectiveDate = _ft_Consensus.effective_date;
            //    ft_ConsensusServices.Instance.Save_ft_Consensus(_ft_Consensus);
            //    Console.WriteLine(" records Grabbed for table: ft_Consensus");
            //}
            //catch (Exception ex)
            //{
            //    Helper.AddtoLog(ex.ToString(), job_id, true, Helper.LogStatus.fail);
            //}

            //try
            //{
            //    ft_Forecasts _ft_Forecasts = ft_ForecastsProvider.GetData(doc1, job_id, stock.Stock_Id);
            //    ft_ForecastsServices.Instance.Save_ft_Forecasts(_ft_Forecasts);
            //    Console.WriteLine(" records Grabbed for table: ft_Forecasts");
            //}
            //catch (Exception ex)
            //{
            //   // Helper.AddtoLog(ex.ToString(), job_id, true, Helper.LogStatus.fail);
            //}

            /////////////////////////////////////////////////////////////////////////////////////
            if (objJobScheduler.jobtype_id == AppSettings.financestatementjobid)
            {
                string marketfinancials = Helper.GetMarketsFinancialUrls(format_issue_symbol);
                Console.WriteLine("Loading URL: " + marketfinancials);
                objJobRun.web_calls_total += 1;           
                HtmlDocument doc2 = web.Load(marketfinancials);
                objJobRun.web_calls_success += 1;
           
                Console.WriteLine("Document Loaded: " + marketfinancials);
                try
                {
                    List<ft_Financials> lst_ft_Financials = Markets_FinancialsProvider.GetData(doc2, job_id, stock.Stock_Id, EffectiveDate, marketfinancials);
                    foreach (ft_Financials item in lst_ft_Financials)
                    {
                        ft_FinancialsSevices.Instance.Save_ft_Financials(item);
                    }
                    Console.WriteLine("Total " + lst_ft_Financials.Count + " records Grabbed for table: ft_Financials");

                }
                catch (Exception ex)
                {
                   // Helper.AddtoLog(ex.ToString(), job_id, true, Helper.LogStatus.fail);
                }
            }
        }
    }
}
