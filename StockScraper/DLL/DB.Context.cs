﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DBEntities : DbContext
    {
        public DBEntities()
            : base("name=DBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<finviz_Calendar> finviz_Calendar { get; set; }
        public virtual DbSet<finviz_Financials> finviz_Financials { get; set; }
        public virtual DbSet<finviz_Insider_Trading> finviz_Insider_Trading { get; set; }
        public virtual DbSet<finviz_Market_Movers> finviz_Market_Movers { get; set; }
        public virtual DbSet<finviz_News> finviz_News { get; set; }
        public virtual DbSet<finviz_Recommendations> finviz_Recommendations { get; set; }
        public virtual DbSet<ft_Consensus> ft_Consensus { get; set; }
        public virtual DbSet<ft_Financials> ft_Financials { get; set; }
        public virtual DbSet<ft_Forecasts> ft_Forecasts { get; set; }
        public virtual DbSet<reuters_Financials_Dividends> reuters_Financials_Dividends { get; set; }
        public virtual DbSet<reuters_Financials_Efficiencies> reuters_Financials_Efficiencies { get; set; }
        public virtual DbSet<reuters_Financials_GrowthRates> reuters_Financials_GrowthRates { get; set; }
        public virtual DbSet<reuters_Financials_Institutions> reuters_Financials_Institutions { get; set; }
        public virtual DbSet<reuters_Financials_MgmtEffectiveness> reuters_Financials_MgmtEffectiveness { get; set; }
        public virtual DbSet<reuters_Financials_ProfitabilityRatios> reuters_Financials_ProfitabilityRatios { get; set; }
        public virtual DbSet<reuters_Financials_SalesEstimates> reuters_Financials_SalesEstimates { get; set; }
        public virtual DbSet<reuters_Financials_Strength> reuters_Financials_Strength { get; set; }
        public virtual DbSet<reuters_Financials_ValuationRatios> reuters_Financials_ValuationRatios { get; set; }
        public virtual DbSet<reuters_RecommendationsRevisions> reuters_RecommendationsRevisions { get; set; }
        public virtual DbSet<ws_Jobs> ws_Jobs { get; set; }
        public virtual DbSet<ws_Logs> ws_Logs { get; set; }
        public virtual DbSet<ws_Stocks> ws_Stocks { get; set; }
    }
}
