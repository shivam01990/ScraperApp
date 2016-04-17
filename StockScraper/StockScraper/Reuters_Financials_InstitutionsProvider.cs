using DLL;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockScraper
{
   public class Reuters_Financials_InstitutionsProvider
    {
       public static List<Reuters_Financials_Institutions> GetData(HtmlDocument doc, int job_id, int stock_id)
       {
           List<Reuters_Financials_Institutions> rType = new List<Reuters_Financials_Institutions>();
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
                       Reuters_Financials_Institutions temp = new Reuters_Financials_Institutions();
                       if (tr.ChildNodes.Count() == 5)
                       {
                           try
                           {
                               temp.Title = tr.ChildNodes[1].InnerText.Replace("&nbsp;", " ");
                               temp.DataValue = tr.ChildNodes[3].InnerText.Replace("&nbsp;", " ");
                               temp.EffectiveDate = EffectiveTime;
                               temp.Job_Id = job_id;
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
