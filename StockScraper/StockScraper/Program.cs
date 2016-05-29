using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using DLL;
namespace StockScraper
{
    class Program
    {
        static void Main(string[] args)
        {

            int scheduler_id = 4;
            if (args.Count() > 0)
            {
                int.TryParse(args[0], out scheduler_id);
            }
            //p_GetAllFieldsForJobScheduler_Result _scheduler = ws_JobSchedulerServices.Instance.GetAllFieldsForScheduler(scheduler_id).FirstOrDefault();
            ws_JobScheduler objJobScheduler = ws_JobSchedulerServices.Instance.Getws_JobScheduler(scheduler_id);
            if (!((objJobScheduler.current_run_count < objJobScheduler.max_run_count) || (objJobScheduler.current_run_count == 0)))
            {
                objJobScheduler.Status = false;
                ws_JobSchedulerServices.Instance.Save_ws_JobScheduler(objJobScheduler);
                return;
            }
            Helper.AddtoLog("=============Import Start " + DateTime.Now + "============");
            Console.WriteLine("=============Import Start " + DateTime.Now + "============");

            ws_JobRuns objJobRun = new ws_JobRuns();
            if (objJobScheduler == null)
            {
                return;
            }
            Helper.AddtoLog("scheduler_id: " + objJobScheduler.scheduler_id);
            int job_id = 0;
            try
            {
                ws_Jobs obj = new ws_Jobs();
                obj.Start_Time = DateTime.Now;
                obj.scheduler_id = scheduler_id;
                job_id = ws_JobsServices.Instance.SaveJob(obj);
                Helper.AddtoLog("New Job_ID=" + job_id);

                objJobRun.job_run_id = job_id;

                //************Check for Company Stock Job*************//
                if (AppSettings.companystockjobid == objJobScheduler.jobtype_id)
                {
                    Helper.AddtoLog("************Running for Company Stock Job*************");
                    try
                    {
                        var timeUtc = DateTime.UtcNow;
                        TimeZoneInfo easternZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
                        DateTime easternTime = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, easternZone);
                        string EffectiveTime = "";
                        if (finviz_CalendarServices.Instance.IsEffectiveDateExist(timeUtc.ToString("dd"), timeUtc.ToString("MM"), timeUtc.ToString("yyyy")))
                        {
                            EffectiveTime = easternTime.ToString("yyyy.MM.dd-hh:mm");
                        }
                        else
                        {
                            EffectiveTime = "";
                        }
                        //Market Movers
                        List<finviz_Market_Movers> lst_marketmovers = finviz_Market_MoversProvider.GetData(job_id, objJobRun, objJobScheduler);

                        foreach (finviz_Market_Movers item in lst_marketmovers)
                        {
                            item.EffectiveDate = EffectiveTime;
                            finviz_Market_MoversServices.Instance.Save_fin_Market_Movers(item);
                        }
                        Console.WriteLine("Total " + lst_marketmovers.Count + " records Grabbed for table: finviz_Market_Movers");

                    }
                    catch (Exception ex)
                    {
                        objJobRun.web_calls_failures += 1;
                        Helper.AddtoLog(ex.ToString(), job_id, objJobScheduler.scheduler_id, 0, true, Helper.LogStatus.fail);
                    }
                    objJobScheduler.current_run_count = objJobScheduler.current_run_count + 1;
                    Helper.AddtoLog("************End for Company Stock Job*************");


                }
                //************End for Company Stock Job*************//

                //try
                //{
                //    List<finviz_Calendar> lst_Calendar = finviz_CalendarProvider.GetData(job_id);

                //    foreach (finviz_Calendar item in lst_Calendar)
                //    {
                //        finviz_CalendarServices.Instance.Save_finviz_Calendar(item);
                //    }
                //    Console.WriteLine("Total " + lst_Calendar.Count + " records Grabbed for table: finviz_Calendar");
                //}
                //catch (Exception ex)
                //{
                //    Helper.AddtoLog(ex.ToString(), job_id, true, Helper.LogStatus.fail);
                //}
                List<ws_Stocks> lststock = new List<ws_Stocks>();
                if (objJobScheduler.current_run_count == 0 || objJobScheduler.max_run_count == 0)
                {
                    lststock = ws_StocksServices.Instance.GetStock(0);
                }
                else
                {
                    List<p_GetLastFailRecords_Result> lastrunfailrecords = ws_LogsServices.Instance.GetLastFailRecords(objJobScheduler.scheduler_id);
                    lststock = ws_StocksServices.Instance.GetStockbyFailRecords(lastrunfailrecords);
                }

                Helper.AddtoLog("Total Stocks:" + lststock.Count());
                Console.WriteLine("Total Stocks:" + lststock.Count());
                foreach (var running_stock in lststock)
                {
                    Console.WriteLine("start looping for stock_id:" + lststock.Count());
                    try
                    {
                        //**************************Start Finance Statement, Forecast Job********************//       
                        if ((objJobScheduler.jobtype_id == AppSettings.financestatementjobid) || (objJobScheduler.jobtype_id == AppSettings.forecastjobid))
                        {
                            ReutersProvider.StartImport(job_id, running_stock, objJobScheduler, objJobRun);
                        }
                        //**************************End Finance Statement, Forecast Job Job********************//

                    }
                    catch (Exception ex)
                    {
                        objJobRun.web_calls_failures += 1;
                        Helper.AddtoLog(ex.ToString(), job_id, objJobScheduler.scheduler_id, running_stock.Stock_Id, true, Helper.LogStatus.fail);
                    }

                    try
                    {
                        //**************************Start Finance Statemen Job********************//       
                        if (objJobScheduler.jobtype_id == AppSettings.financestatementjobid)
                        {
                            MarketsProvider.StartImport(job_id, running_stock, objJobScheduler, objJobRun);
                        }
                        //**************************End Finance Statement Job********************//

                    }
                    catch (Exception ex)
                    {
                        objJobRun.web_calls_failures += 1;
                        Helper.AddtoLog(ex.ToString(), job_id, objJobScheduler.scheduler_id, running_stock.Stock_Id, true, Helper.LogStatus.fail);
                    }

                    try
                    {
                         //**************************Start Forecast Job********************//       
                        if (objJobScheduler.jobtype_id == AppSettings.forecastjobid)
                        {
                            finvizProvider.StartImport(job_id,running_stock,objJobScheduler,objJobRun);
                        }
                    }
                    catch (Exception ex)
                    {
                         objJobRun.web_calls_failures += 1;
                        Helper.AddtoLog(ex.ToString(), job_id,objJobScheduler.scheduler_id,running_stock.Stock_Id, true, Helper.LogStatus.fail);
                    }
                }

                Helper.AddtoLog("=============Import End " + DateTime.Now + "============");
                Console.WriteLine("=============Import End " + DateTime.Now + "============");
                ws_JobRunsService.Instance.Save_ws_JobRuns(objJobRun);
                objJobScheduler.current_run_count += 1;
                ws_JobSchedulerServices.Instance.Save_ws_JobScheduler(objJobScheduler);
            }
            catch (Exception ex)
            {
                Helper.AddtoLog(ex.ToString(), job_id, objJobScheduler.scheduler_id, 0, true, Helper.LogStatus.fail);
            }
        }
    }
}
