using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLL;
namespace StockScraper
{
    public class reuters_RecommendationsRevisionsProvider
    {
        public static List<reuters_RecommendationsRevisions> GetData(HtmlDocument doc, int job_id, int stock_id,string URL)
        {
            List<reuters_RecommendationsRevisions> rType = new List<reuters_RecommendationsRevisions>();
            HtmlNodeCollection rowcollection = doc.DocumentNode.SelectNodes("//div[contains(@class, 'column1') and contains(@class, 'gridPanel') and contains(@class, 'grid8')]//div[@class='module']");
            if (rowcollection != null)
            {
                if (rowcollection.Count > 0)
                {
                    DateTime? lastUpdated = null;
                    string strlastupdateddate = "";
                    try
                    {
                      strlastupdateddate = rowcollection[0].SelectNodes("div[@class='moduleBody']//table[@class='dataTable']//tr[@class='stripe']//td")[3].InnerText ?? "";

                    }
                    catch { }
                    if (strlastupdateddate != string.Empty)
                    {
                        try
                        {
                            lastUpdated = DateTime.Parse(strlastupdateddate);
                        }
                        catch
                        { }

                    }

                    var tblrows = rowcollection[1].SelectNodes("div[@class='moduleBody']//table[@class='dataTable']//tr");
                    if (tblrows != null)
                    {

                        for (int k = 1; k < tblrows.Count; k++)
                        {
                            reuters_RecommendationsRevisions temp = new reuters_RecommendationsRevisions();
                            HtmlNode tr = tblrows[k];
                            if (tr.ChildNodes.Count() == 11)
                            {
                                try
                                {
                                    temp.Linear_Scale = tr.ChildNodes[1].InnerText.Replace("&nbsp;", " ");
                                    temp.AnalystRecommend_Current = tr.ChildNodes[3].InnerText;
                                    temp.AnalystRecommend_Month_1 = tr.ChildNodes[5].InnerText;
                                    temp.AnalystRecommend_Month_2 = tr.ChildNodes[7].InnerText;
                                    temp.AnalystRecommend_Month_3 = tr.ChildNodes[9].InnerText;
                                    temp.LastRecommendationDate = lastUpdated;
                                    temp.job_run_Id = job_id;
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
            }
            else
            {
                string warningmsg = Helper.GetWarningMSG(stock_id, "reuters_RecommendationsRevisions",URL);
                Helper.AddtoLog(warningmsg, job_id, true, Helper.LogStatus.warning);
            }
            return rType;
        }
    }
}
