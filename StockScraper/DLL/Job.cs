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
    
    public partial class Job
    {
        public Job()
        {
            this.Finviz_Financials = new HashSet<Finviz_Financials>();
            this.Inside_Trading = new HashSet<Inside_Trading>();
            this.Logs = new HashSet<Log>();
            this.Markets_Financials = new HashSet<Markets_Financials>();
            this.News = new HashSet<News>();
            this.Reuters_Financials_Dividends = new HashSet<Reuters_Financials_Dividends>();
            this.Reuters_Financials_Efficiencies = new HashSet<Reuters_Financials_Efficiencies>();
            this.Reuters_Financials_Institutions = new HashSet<Reuters_Financials_Institutions>();
            this.Reuters_Financials_MgmtEffectiveness = new HashSet<Reuters_Financials_MgmtEffectiveness>();
            this.Reuters_Financials_Strength = new HashSet<Reuters_Financials_Strength>();
            this.Reuters_Financials_ValuationRatios = new HashSet<Reuters_Financials_ValuationRatios>();
            this.Reuters_RecommendationsRevisions = new HashSet<Reuters_RecommendationsRevisions>();
            this.Stocks_Common = new HashSet<Stocks_Common>();
            this.Reuters_Financials_SalesEstimates = new HashSet<Reuters_Financials_SalesEstimates>();
        }
    
        public int Job_id { get; set; }
        public System.DateTime Start_Time { get; set; }
    
        public virtual ICollection<Finviz_Financials> Finviz_Financials { get; set; }
        public virtual ICollection<Inside_Trading> Inside_Trading { get; set; }
        public virtual ICollection<Log> Logs { get; set; }
        public virtual ICollection<Markets_Financials> Markets_Financials { get; set; }
        public virtual ICollection<News> News { get; set; }
        public virtual ICollection<Reuters_Financials_Dividends> Reuters_Financials_Dividends { get; set; }
        public virtual ICollection<Reuters_Financials_Efficiencies> Reuters_Financials_Efficiencies { get; set; }
        public virtual ICollection<Reuters_Financials_Institutions> Reuters_Financials_Institutions { get; set; }
        public virtual ICollection<Reuters_Financials_MgmtEffectiveness> Reuters_Financials_MgmtEffectiveness { get; set; }
        public virtual ICollection<Reuters_Financials_Strength> Reuters_Financials_Strength { get; set; }
        public virtual ICollection<Reuters_Financials_ValuationRatios> Reuters_Financials_ValuationRatios { get; set; }
        public virtual ICollection<Reuters_RecommendationsRevisions> Reuters_RecommendationsRevisions { get; set; }
        public virtual ICollection<Stocks_Common> Stocks_Common { get; set; }
        public virtual ICollection<Reuters_Financials_SalesEstimates> Reuters_Financials_SalesEstimates { get; set; }
    }
}
