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
            Helper.AddtoLog("=============Import Start " + DateTime.Now + "============");
            Console.WriteLine("=============Import Start " + DateTime.Now + "============");

            int scheduler_id = 2;
            if (args.Count() > 0)
            {
                int.TryParse(args[0], out scheduler_id);
            }
            p_GetAllFieldsForJobScheduler_Result _scheduler = ws_JobSchedulerServices.Instance.GetAllFieldsForScheduler(scheduler_id).FirstOrDefault();
            ws_JobScheduler objscheduler = ws_JobSchedulerServices.Instance.Getws_JobScheduler(_scheduler.scheduler_id);
            ws_JobRuns jobRun = new ws_JobRuns();
            if (objscheduler == null)
            {
                return;
            }
            Helper.AddtoLog("scheduler_id: " + objscheduler.scheduler_id);
            int job_id = 0;
            try
            {
                ws_Jobs obj = new ws_Jobs();
                obj.Start_Time = DateTime.Now;
                obj.scheduler_id = scheduler_id;
                job_id = ws_JobsServices.Instance.SaveJob(obj);
                Helper.AddtoLog("New Job_ID=" + job_id);
               
                jobRun.job_run_id = job_id;
          
                //************Check for Company Stock*************//
                if (AppSettings.companystockjobid == objscheduler.jobtype_id)
                {
                    if ((objscheduler.current_run_count <= objscheduler.max_run_count) || (objscheduler.current_run_count==0))
                    {
                        Helper.AddtoLog("************Running for Company Stock*************");
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
                            List<finviz_Market_Movers> lst_marketmovers = finviz_Market_MoversProvider.GetData(job_id,jobRun);

                            foreach (finviz_Market_Movers item in lst_marketmovers)
                            {
                                item.EffectiveDate = EffectiveTime;
                                finviz_Market_MoversServices.Instance.Save_fin_Market_Movers(item);
                            }
                            Console.WriteLine("Total " + lst_marketmovers.Count + " records Grabbed for table: finviz_Market_Movers");

                        }
                        catch (Exception ex)
                        {
                            Helper.AddtoLog(ex.ToString(), job_id, true, Helper.LogStatus.fail);
                        }
                        _scheduler.current_run_count = _scheduler.current_run_count + 1;
                        Helper.AddtoLog("************End for Company Stock*************");

                    }
                }

               //************End for Company Stock*************//

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

                //List<ws_Stocks> lststock = ws_StocksServices.Instance.GetStock(0);
                //Helper.AddtoLog("Total Stocks:" + lststock.Count());
                //Console.WriteLine("Total Stocks:" + lststock.Count());
                //foreach (var running_stock in lststock)
                //{
                //    Console.WriteLine("start looping for stock_id:" + lststock.Count());
                //    try
                //    {
                //        ReutersProvider.StartImport(job_id, running_stock);
                //    }
                //    catch (Exception ex)
                //    {
                //        Helper.AddtoLog(ex.ToString(), job_id, true, Helper.LogStatus.fail);
                //    }

                //    try
                //    {
                //        MarketsProvider.StartImport(job_id, running_stock);
                //    }
                //    catch (Exception ex)
                //    {
                //        Helper.AddtoLog(ex.ToString(), job_id, true, Helper.LogStatus.fail);
                //    }

                //    try
                //    {
                //        finvizProvider.StartImport(job_id, running_stock);
                //    }
                //    catch (Exception ex)
                //    {
                //        Helper.AddtoLog(ex.ToString(), job_id, true, Helper.LogStatus.fail);
                //    }
                //}


                Helper.AddtoLog("=============Import End " + DateTime.Now + "============");
                Console.WriteLine("=============Import End " + DateTime.Now + "============");
                ws_JobRunsService.Instance.Save_ws_JobRuns(jobRun);
              
            }
            catch (Exception ex)
            {
                Helper.AddtoLog(ex.ToString(), job_id, true, Helper.LogStatus.fail);
            }
        }
    }
}
