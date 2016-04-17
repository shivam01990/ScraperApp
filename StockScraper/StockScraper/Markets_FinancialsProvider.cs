using DLL;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockScraper
{
   public class Markets_FinancialsProvider
    {
       public static List<Markets_Financials> GetData(HtmlDocument doc, int job_id, int stock_id)
       {
           List<Markets_Financials> rType = new List<Markets_Financials>();
           HtmlNodeCollection rowcollection = doc.DocumentNode.SelectNodes("//div[contains(@class, 'wsodModule') and contains(@class, 'contains') and contains(@class, 'financialStatement')  and contains(@class, 'wsodModuleLastInGridColumn')]");
           if (rowcollection.Count > 0)
           {
               Int16 TypeID = 1;
               var tblrows = rowcollection[0].SelectNodes("div[@class='statementView']//table//tr");
               if (tblrows != null)
               {
                   for (int k = 1; k < tblrows.Count; k++)
                   {
                       HtmlNode tr = tblrows[k];
                       Markets_Financials temp = new Markets_Financials();
                       if (tr.ChildNodes.Count() == 4)
                       {
                           try
                           {
                               temp.Title = tr.ChildNodes[0].InnerText.Replace("&nbsp;", " ");
                               temp.First_Year = tr.ChildNodes[1].InnerText;
                               temp.Second_Year = tr.ChildNodes[2].InnerText;
                               temp.Third_Year = tr.ChildNodes[3].InnerText;
                               temp.Markets_Financials_Types_Id = TypeID;
                               temp.Job_Id = job_id;
                               temp.Stock_Id = stock_id;
                               rType.Add(temp);
                           }
                           catch
                           {
                           }
                       }
                       else
                       {
                           if (tr.ChildNodes[0].InnerText.ToUpper() == "REVENUE AND GROSS PROFIT")
                           {
                               TypeID = 1;
                           }
                           if (tr.ChildNodes[0].InnerText.ToUpper() == "OPERATING EXPENSES")
                           {
                               TypeID = 2;
                           }
                           if (tr.ChildNodes[0].InnerText.ToUpper() == "INCOME TAXES, MINORITY INTEREST AND EXTRA ITEMS")
                           {
                               TypeID = 3;
                           }
                           if (tr.ChildNodes[0].InnerText.ToUpper() == "COMMON STOCK DIVIDENDS")
                           {
                               TypeID = 4;
                           }
                           if (tr.ChildNodes[0].InnerText.ToUpper() == "PRO FORMA INCOME")
                           {
                               TypeID = 5;
                           }
                           if (tr.ChildNodes[0].InnerText.ToUpper() == "SUPPLEMENTAL INCOME")
                           {
                               TypeID = 6;
                           }
                           if (tr.ChildNodes[0].InnerText.ToUpper() == "NORMALIZED INCOME")
                           {
                               TypeID = 7;
                           }
                       }

                   }
               }
           }
           return rType;
       }
 
    }
}
