using DLL;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockScraper
{
    public class reuters_Financials_SalesEstimatesProvider
    {
        public static List<reuters_Financials_SalesEstimates> GetData(HtmlDocument doc, int job_id, int stock_id,string URL)
        {
            List<reuters_Financials_SalesEstimates> rType = new List<reuters_Financials_SalesEstimates>();
            HtmlNodeCollection rowcollection = doc.DocumentNode.SelectNodes("//div[contains(@class, 'column1') and contains(@class, 'gridPanel') and contains(@class, 'grid8')]//div[@class='module']");
            if (rowcollection != null)
            {
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
                            reuters_Financials_SalesEstimates temp = new reuters_Financials_SalesEstimates();
                            if (tr.ChildNodes.Count() == 13)
                            {
                                try
                                {
                                    temp.Title = tr.ChildNodes[1].InnerText.Replace("&nbsp;", " ");
                                    temp.Sale_Type = salestype;
                                    temp.Estimates = tr.ChildNodes[3].InnerText;
                                    temp.Mean = tr.ChildNodes[5].InnerText;
                                    temp.High = tr.ChildNodes[7].InnerText;
                                    temp.Low = tr.ChildNodes[9].InnerText;
                                    //temp.One_Year_Ago = tr.ChildNodes[11].InnerText;
                                    temp.EffectiveDate = EffectiveTime;
                                    temp.job_run_id = job_id;
                                    temp.Stock_Id = stock_id;
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
            }
            else
            {

                string warningmsg = Helper.GetWarningMSG(stock_id, "reuters_Financials_SalesEstimates", URL);
                Helper.AddtoLog(warningmsg, job_id, true, Helper.LogStatus.warning);
            }
            return rType;
        }
    }
}
