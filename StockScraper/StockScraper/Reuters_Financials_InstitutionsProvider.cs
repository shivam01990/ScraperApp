using DLL;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockScraper
{
   public class reuters_Financials_InstitutionsProvider
    {
       public static List<reuters_Financials_Institutions> GetData(HtmlDocument doc, int job_id, int stock_id)
       {
           List<reuters_Financials_Institutions> rType = new List<reuters_Financials_Institutions>();
           HtmlNodeCollection rowcollection = doc.DocumentNode.SelectNodes("//div[contains(@class, 'column2') and contains(@class, 'gridPanel') and contains(@class, 'grid4')]//div[@class='module']");
           if (rowcollection.Count > 0)
           {
               string EffectiveTime = Helper.GetEffetiveTime(doc);

               var tblrows = rowcollection[3].SelectNodes("div[@class='moduleBody']//table[@class='dataTable']//tr");
               if (tblrows != null)
               {
                   for (int k = 0; k < tblrows.Count; k++)
                   {
                       HtmlNode tr = tblrows[k];
                       reuters_Financials_Institutions temp = new reuters_Financials_Institutions();
                       if (tr.ChildNodes.Count() == 5)
                       {
                           try
                           {
                               temp.Title = tr.ChildNodes[1].InnerText.Replace("&nbsp;", " ");
                               temp.DataValue = tr.ChildNodes[3].InnerText.Replace("&nbsp;", " ");
                               temp.EffectiveDate = EffectiveTime;
                               temp.job_run_id = job_id;
                               temp.Stock_Id = stock_id;
                               rType.Add(temp);
                           }
                           catch
                           {
                           }
                       }

                   }
               }
           }
           return rType;
       }
    }
}
