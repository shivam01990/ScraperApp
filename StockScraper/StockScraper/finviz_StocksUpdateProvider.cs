using DLL;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockScraper
{
    public class finviz_StocksUpdateProvider
    {
        public static ws_Stocks GetData(HtmlDocument doc, ws_Stocks Stocks)
        {
            var tdrows1 = doc.DocumentNode.SelectNodes("//table[@class='fullview-title']//tr//td");
            if (tdrows1 != null)
            {
                if (tdrows1.Count == 3)
                {
                    string row1 = tdrows1[0].InnerText;


                    if (string.IsNullOrWhiteSpace(Stocks.Exchange_Abbr))
                    {
                        try
                        {
                            string Exchange_abbr = Helper.ExtractFromString(row1, "[", "]")[0];
                            Stocks.Exchange_Abbr = Exchange_abbr;
                        }
                        catch { }
                    }
                    if (string.IsNullOrWhiteSpace(Stocks.Company_Name))
                    {
                        try
                        {
                            Stocks.Company_Name = tdrows1[1].InnerText;
                        }
                        catch { }
                    }
                    if (string.IsNullOrWhiteSpace(Stocks.Sector))
                    {
                        try
                        {
                            Stocks.Sector = tdrows1[2].InnerText.Split('|')[0];
                        }
                        catch
                        { }
                    }
                    if (string.IsNullOrWhiteSpace(Stocks.sub_sector))
                    {
                        try
                        {
                            Stocks.sub_sector = tdrows1[2].InnerText.Split('|')[1];
                        }
                        catch
                        { }
                    }
                    if (string.IsNullOrWhiteSpace(Stocks.country))
                    {
                        try
                        {
                            Stocks.country = tdrows1[2].InnerText.Split('|')[2];
                        }
                        catch
                        { }
                    }
                }
            }

            string company_decription = "";
            try
            {
                if (string.IsNullOrWhiteSpace(Stocks.company_desc_finviz))
                {
                    company_decription = doc.DocumentNode.SelectNodes("//table//tr[@class='table-light3-row']//td")[0].InnerText;
                    Stocks.company_desc_finviz = company_decription;
                }
            }
            catch
            { }
         
            return Stocks;
        }


    }
}
