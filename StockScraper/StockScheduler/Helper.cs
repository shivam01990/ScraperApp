using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLL;

namespace StockScheduler
{
  public class Helper
   {
      public static string GetExePath()
      {
          string EXEPath = AppDomain.CurrentDomain.BaseDirectory;
          EXEPath += AppSettings.EXEPath;
          return EXEPath;
      }

      public static ws_JobRuns SetJobRuns(ws_JobRuns jobRun,bool IsSuccess)
      {
          jobRun.web_calls_total =jobRun.web_calls_total+ 1;
          if(IsSuccess)
          {
              jobRun.web_calls_success = jobRun.web_calls_success + 1;
          }
          else
          {
              jobRun.web_calls_failures = jobRun.web_calls_failures + 1;
          }
          return jobRun;
      }
   }
}
