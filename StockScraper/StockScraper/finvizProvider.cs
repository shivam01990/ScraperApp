﻿using DLL;
using BLL;
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

        public static void StartImport(int job_id, ws_Stocks stock, ws_JobScheduler objJobScheduler, ws_JobRuns jobRun)
        {
            jobRun.web_calls_total += 1;
            string ticker = stock.Ticker;
            HtmlWeb web = new HtmlWeb();
            string finvizUrl = Helper.finvizUrl(ticker);
            Console.WriteLine("Loading URL: " + finvizUrl);
            HtmlDocument doc = web.Load(finvizUrl);
            Console.WriteLine("Document Loaded: " + finvizUrl);
            jobRun.web_calls_success += 1;

            var timeUtc = DateTime.UtcNow;
            TimeZoneInfo easternZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            DateTime easternTime = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, easternZone);
            string EffectiveTime = "";
            if (finviz_CalendarServices.Instance.IsEffectiveDateExist(timeUtc.ToString("dd"), timeUtc.ToString("MMM"), timeUtc.ToString("yyyy")))
            {
                EffectiveTime = easternTime.ToString("yyyy.MM.dd-hh:mm");
            }
            else
            {
                EffectiveTime = "";
            }

            bool IsFinvizFail = false;
            if ((objJobScheduler.jobtype_id == AppSettings.finvizjobid))
            {
                // Get finviz_Financials
                try
                {
                    List<finviz_Financials> lst_finviz_Financials = finviz_FinancialsProvider.GetData(doc, job_id, stock.Stock_Id, finvizUrl);
                    foreach (finviz_Financials item in lst_finviz_Financials)
                    {
                        item.EffectiveDate = EffectiveTime;
                        finviz_FinancialsServices.Instance.Save_fin_Financials(item);
                    }
                    Console.WriteLine("Total " + lst_finviz_Financials.Count + " records Grabbed for table: finviz_Financials");

                }
                catch (Exception ex)
                {
                    IsFinvizFail = true;
                    //Helper.AddtoLog(ex.ToString(), job_id, objJobScheduler.scheduler_id, stock.Stock_Id, true, Helper.LogStatus.fail);
                }
            }

            if ((objJobScheduler.jobtype_id == AppSettings.forecastjobid) || (objJobScheduler.jobtype_id == AppSettings.finvizjobid))
            {
                try
                {
                    List<finviz_Recommendations> lst_finviz_Recommendations = finviz_RecommendationsProvider.GetData(doc, job_id, stock.Stock_Id, finvizUrl);
                    foreach (finviz_Recommendations item in lst_finviz_Recommendations)
                    {
                        item.EffectiveDate = EffectiveTime;
                        finviz_RecommendationsServices.Instance.Save_fin_Recommendations(item);
                    }
                    Console.WriteLine("Total " + lst_finviz_Recommendations.Count + " records Grabbed for table: finviz_Recommendations");

                }
                catch (Exception ex)
                {
                    IsFinvizFail = true;
                    //Helper.AddtoLog(ex.ToString(), job_id, objJobScheduler.scheduler_id, stock.Stock_Id, true, Helper.LogStatus.fail);
                }
            }

            if (objJobScheduler.jobtype_id == AppSettings.finvizjobid)
            {
                try
                {
                    List<finviz_News> lst_finviz_News = NewsProvider.GetData(doc, job_id, stock.Stock_Id, finvizUrl);
                    foreach (finviz_News item in lst_finviz_News)
                    {
                        finviz_NewsServices.Instance.Save_fin_News(item);
                    }
                    Console.WriteLine("Total " + lst_finviz_News.Count + " records Grabbed for table: finviz_News");


                }
                catch (Exception ex)
                {
                    IsFinvizFail = true;
                    //Helper.AddtoLog(ex.ToString(), job_id, objJobScheduler.scheduler_id, stock.Stock_Id, true, Helper.LogStatus.fail);
                }

                try
                {
                    List<finviz_Insider_Trading> lst_finviz_Insider_Trading = finviz_Insider_TradingProvider.GetData(doc, job_id, stock.Stock_Id, finvizUrl);
                    foreach (finviz_Insider_Trading item in lst_finviz_Insider_Trading)
                    {
                        item.EffectiveDate = EffectiveTime;
                        finviz_Insider_TradingServices.Instance.Save_fin_Insider_Trading(item);
                    }
                    Console.WriteLine("Total " + lst_finviz_Insider_Trading.Count + " records Grabbed for table: finviz_Insider_Trading");

                }
                catch (Exception ex)
                {
                    IsFinvizFail = true;
                    //Helper.AddtoLog(ex.ToString(), job_id, objJobScheduler.scheduler_id, stock.Stock_Id, true, Helper.LogStatus.fail);
                }
            }

            try
            {
                stock = finviz_StocksUpdateProvider.GetData(doc, stock);
                ws_StocksServices.Instance.SaveStock(stock);
                Console.WriteLine("Stock Table is successfully updated.");
            }
            catch (Exception ex)
            {
                //IsFinvizFail = true;
                // Helper.AddtoLog(ex.ToString(), job_id, objJobScheduler.scheduler_id, stock.Stock_Id, true, Helper.LogStatus.fail);
            }

            if (IsFinvizFail)
            {
                Helper.AddtoLog("Fail to fetch records from Finviz table.", job_id, objJobScheduler.scheduler_id, stock.Stock_Id, true, Helper.LogStatus.fail);
            }
        }
    }
}
