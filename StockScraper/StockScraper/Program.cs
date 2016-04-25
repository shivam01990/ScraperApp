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
            int job_id = 0;
            Helper.AddtoLog("=============Import Start " + DateTime.Now + "============");
            Console.WriteLine("=============Import Start " + DateTime.Now + "============");
            try
            {
                ws_Jobs obj = new ws_Jobs();
                obj.Start_Time = DateTime.Now;
                job_id = ws_JobsServices.Instance.SaveJob(obj);
                Helper.AddtoLog("New Job_ID=" + job_id);
                List<ws_Stocks> lststock = ws_StocksServices.Instance.GetStock(0);
                Helper.AddtoLog("Total Stocks:" + lststock.Count());
                Console.WriteLine("Total Stocks:" + lststock.Count());
                foreach (var running_stock in lststock)
                {
                    Console.WriteLine("start looping for stock_id:" + lststock.Count());
                    try
                    {
                        ReutersProvider.StartImport(job_id, running_stock);
                    }
                    catch (Exception ex)
                    {
                        Helper.AddtoLog(ex.ToString(), job_id, true, Helper.LogStatus.fail);
                    }

                    try
                    {
                        MarketsProvider.StartImport(job_id, running_stock);
                    }
                    catch (Exception ex)
                    {
                        Helper.AddtoLog(ex.ToString(), job_id, true, Helper.LogStatus.fail);
                    }

                    try
                    {
                        finvizProvider.StartImport(job_id, running_stock);
                    }
                    catch (Exception ex)
                    {
                        Helper.AddtoLog(ex.ToString(), job_id, true, Helper.LogStatus.fail);
                    }
                }

                finviz_Market_MoversProvider.GetData(0);
                Helper.AddtoLog("=============Import End " + DateTime.Now + "============");
                Console.WriteLine("=============Import End " + DateTime.Now + "============");
            }
            catch (Exception ex)
            {
                Helper.AddtoLog(ex.ToString(), job_id, true, Helper.LogStatus.fail);
            }
        }
    }
}
