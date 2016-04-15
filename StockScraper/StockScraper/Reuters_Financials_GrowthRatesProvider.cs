using DLL;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockScraper
{
  public  class Reuters_Financials_GrowthRatesProvider
    {
      public static List<Reuters_Financials_GrowthRates> GetData(HtmlDocument doc, int job_id, int stock_id)
      {
          List<Reuters_Financials_GrowthRates> rType = new List<Reuters_Financials_GrowthRates>();
          HtmlNodeCollection rowcollection = doc.DocumentNode.SelectNodes("//div[contains(@class, 'column1') and contains(@class, 'gridPanel') and contains(@class, 'grid8')]//div[@class='module']");
          if (rowcollection.Count > 0)
          {
              string EffectiveTime = Helper.GetEffetiveTime(doc);

              var tblrows = rowcollection[4].SelectNodes("div[@class='moduleBody']//table[@class='dataTable']//tr");
              if (tblrows != null)
              {
                  for (int k = 1; k < tblrows.Count; k++)
                  {
                      HtmlNode tr = tblrows[k];
                      Reuters_Financials_GrowthRates temp = new Reuters_Financials_GrowthRates();
                      if (tr.ChildNodes.Count() == 9)
                      {
                          try
                          {
                              temp.Title = tr.ChildNodes[1].InnerText.Replace("&nbsp;", " ");

                              temp.Company = tr.ChildNodes[3].InnerText;
                              temp.Industry = tr.ChildNodes[5].InnerText;
                              temp.Sector = tr.ChildNodes[7].InnerText;
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
