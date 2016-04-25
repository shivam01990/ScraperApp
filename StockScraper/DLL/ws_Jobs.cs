//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DLL
{
    using System;
    using System.Collections.Generic;
    
    public partial class ws_Jobs
    {
        public ws_Jobs()
        {
            this.finviz_Financials = new HashSet<finviz_Financials>();
            this.finviz_Insider_Trading = new HashSet<finviz_Insider_Trading>();
            this.finviz_Market_Movers = new HashSet<finviz_Market_Movers>();
            this.finviz_News = new HashSet<finviz_News>();
            this.finviz_Recommendations = new HashSet<finviz_Recommendations>();
            this.ft_Consensus = new HashSet<ft_Consensus>();
            this.ft_Financials = new HashSet<ft_Financials>();
            this.ft_Forecasts = new HashSet<ft_Forecasts>();
            this.reuters_Financials_Dividends = new HashSet<reuters_Financials_Dividends>();
            this.reuters_Financials_Efficiencies = new HashSet<reuters_Financials_Efficiencies>();
            this.reuters_Financials_GrowthRates = new HashSet<reuters_Financials_GrowthRates>();
            this.reuters_Financials_Institutions = new HashSet<reuters_Financials_Institutions>();
            this.reuters_Financials_MgmtEffectiveness = new HashSet<reuters_Financials_MgmtEffectiveness>();
            this.reuters_Financials_ProfitabilityRatios = new HashSet<reuters_Financials_ProfitabilityRatios>();
            this.reuters_Financials_SalesEstimates = new HashSet<reuters_Financials_SalesEstimates>();
            this.reuters_Financials_Strength = new HashSet<reuters_Financials_Strength>();
            this.reuters_Financials_ValuationRatios = new HashSet<reuters_Financials_ValuationRatios>();
            this.reuters_RecommendationsRevisions = new HashSet<reuters_RecommendationsRevisions>();
            this.ws_Logs = new HashSet<ws_Logs>();
        }
    
        public int Job_id { get; set; }
        public System.DateTime Start_Time { get; set; }
        public byte[] CreatedOn { get; set; }
    
        public virtual ICollection<finviz_Financials> finviz_Financials { get; set; }
        public virtual ICollection<finviz_Insider_Trading> finviz_Insider_Trading { get; set; }
        public virtual ICollection<finviz_Market_Movers> finviz_Market_Movers { get; set; }
        public virtual ICollection<finviz_News> finviz_News { get; set; }
        public virtual ICollection<finviz_Recommendations> finviz_Recommendations { get; set; }
        public virtual ICollection<ft_Consensus> ft_Consensus { get; set; }
        public virtual ICollection<ft_Financials> ft_Financials { get; set; }
        public virtual ICollection<ft_Forecasts> ft_Forecasts { get; set; }
        public virtual ICollection<reuters_Financials_Dividends> reuters_Financials_Dividends { get; set; }
        public virtual ICollection<reuters_Financials_Efficiencies> reuters_Financials_Efficiencies { get; set; }
        public virtual ICollection<reuters_Financials_GrowthRates> reuters_Financials_GrowthRates { get; set; }
        public virtual ICollection<reuters_Financials_Institutions> reuters_Financials_Institutions { get; set; }
        public virtual ICollection<reuters_Financials_MgmtEffectiveness> reuters_Financials_MgmtEffectiveness { get; set; }
        public virtual ICollection<reuters_Financials_ProfitabilityRatios> reuters_Financials_ProfitabilityRatios { get; set; }
        public virtual ICollection<reuters_Financials_SalesEstimates> reuters_Financials_SalesEstimates { get; set; }
        public virtual ICollection<reuters_Financials_Strength> reuters_Financials_Strength { get; set; }
        public virtual ICollection<reuters_Financials_ValuationRatios> reuters_Financials_ValuationRatios { get; set; }
        public virtual ICollection<reuters_RecommendationsRevisions> reuters_RecommendationsRevisions { get; set; }
        public virtual ICollection<ws_Logs> ws_Logs { get; set; }
    }
}
