using DLL;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockScraper
{
    public class Reuters_Financials_SalesEstimatesProvider
    {
        public static List<Reuters_Financials_SalesEstimates> GetData(HtmlDocument doc, int job_id, int stock_id)
        {
            List<Reuters_Financials_SalesEstimates> rType = new List<Reuters_Financials_SalesEstimates>();
            HtmlNodeCollection rowcollection = doc.DocumentNode.SelectNodes("//div[contains(@class, 'column1') and contains(@class, 'gridPanel') and contains(@class, 'grid8')]//div[@class='module']");
            if (rowcollection.Count > 0)
            {
                string EffectiveTime = Helper.GetEffetiveTime(doc);
               
                var tblrows = rowcollection[2].SelectNodes("div[@class='moduleBody']//table[@class='dataTable']//tr");
                if (tblrows != null)
                {
                    Int16 salestype = 1;
                    for (int k = 2; k < tblrows.Count; k++)
                    {
                        HtmlNode tr = tblrows[k];
                        Reuters_Financials_SalesEstimates temp = new Reuters_Financials_SalesEstimates();
                        if (tr.ChildNodes.Count() == 13)
                        {
                            try
                            {
                                temp.Title = tr.ChildNodes[1].InnerText.Replace("&nbsp;", " ");
                                temp.SaleType = salestype;
                                temp.Estimates = tr.ChildNodes[3].InnerText;
                                temp.Mean = tr.ChildNodes[5].InnerText;
                                temp.High = tr.ChildNodes[7].InnerText;
                                temp.Low = tr.ChildNodes[9].InnerText;
                                temp.One_Year_Ago = tr.ChildNodes[11].InnerText;
                                temp.Effective_Date = EffectiveTime;
                                rType.Add(temp);
                            }
                            catch
                            {
                            }
                        }
                        else
                        {
                            salestype = 2;
                        }
                    }
                }
            }
            return rType;
        }
    }
}
