using DLL;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockScraper
{
    public class finviz_FinancialsProvider
    {
        public static List<finviz_Financials> GetData(HtmlDocument doc, int job_id, int stock_id,string URL)
        {
            List<finviz_Financials> rType = new List<finviz_Financials>();

            string EffectiveDate = DateTime.Now.ToString("yyyy.MM.dd");
            var tblrows = doc.DocumentNode.SelectNodes("//table[@class='snapshot-table2']//tr");
                if (tblrows != null)
                {
                    for (int k = 0; k < tblrows.Count; k++)
                    {
                        HtmlNode tr = tblrows[k];
                        if (tr.ChildNodes.Count() == 19)
                        {
                            try
                            {
                                {
                                    finviz_Financials temp = new finviz_Financials();
                                    temp.value = tr.ChildNodes[1].InnerText.Replace("&nbsp;", " ");
                                    temp.descriptor = tr.ChildNodes[2].InnerText;
                                    temp.job_run_Id = job_id;
                                    temp.Stock_Id = stock_id;
                                    temp.EffectiveDate = EffectiveDate;
                                    rType.Add(temp);
                                }

                                {
                                    finviz_Financials temp = new finviz_Financials();
                                    temp.value = tr.ChildNodes[4].InnerText.Replace("&nbsp;", " ");
                                    temp.descriptor = tr.ChildNodes[5].InnerText;
                                    temp.job_run_Id = job_id;
                                    temp.Stock_Id = stock_id;
                                    temp.EffectiveDate = EffectiveDate;
                                    rType.Add(temp);
                                }

                                {
                                    finviz_Financials temp = new finviz_Financials();
                                    temp.value = tr.ChildNodes[7].InnerText.Replace("&nbsp;", " ");
                                    temp.descriptor = tr.ChildNodes[8].InnerText;
                                    temp.job_run_Id = job_id;
                                    temp.Stock_Id = stock_id;
                                    temp.EffectiveDate = EffectiveDate;
                                    rType.Add(temp);
                                }

                                {
                                    finviz_Financials temp = new finviz_Financials();
                                    temp.value = tr.ChildNodes[10].InnerText.Replace("&nbsp;", " ");
                                    temp.descriptor = tr.ChildNodes[11].InnerText;
                                    temp.job_run_Id = job_id;
                                    temp.Stock_Id = stock_id;
                                    temp.EffectiveDate = EffectiveDate;
                                    rType.Add(temp);
                                }
                                {
                                    finviz_Financials temp = new finviz_Financials();
                                    temp.value = tr.ChildNodes[13].InnerText.Replace("&nbsp;", " ");
                                    temp.descriptor = tr.ChildNodes[14].InnerText;
                                    temp.job_run_Id = job_id;
                                    temp.Stock_Id = stock_id;
                                    temp.EffectiveDate = EffectiveDate;
                                    rType.Add(temp);
                                }
                                {
                                    finviz_Financials temp = new finviz_Financials();
                                    temp.value = tr.ChildNodes[16].InnerText.Replace("&nbsp;", " ");
                                    temp.descriptor = tr.ChildNodes[17].InnerText;
                                    temp.job_run_Id = job_id;
                                    temp.Stock_Id = stock_id;
                                    temp.EffectiveDate = EffectiveDate;
                                    rType.Add(temp);
                                }
                                                              
                            }
                            catch
                            {
                            }
                        }

                    }
                }
                else
                {
                    string warningmsg = Helper.GetWarningMSG(stock_id, "finviz_Financials", URL);
                    Helper.AddtoLog(warningmsg, job_id, true, Helper.LogStatus.warning);
                }
            
            return rType;
        }
 
    }
}
