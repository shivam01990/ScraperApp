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
    
    public partial class Recommendation
    {
        public long RecommendationId { get; set; }
        public long Time_SeriesId { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string RecommendationType { get; set; }
        public string Analyst { get; set; }
        public string Recommendation1 { get; set; }
        public string Target { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
    
        public virtual ft_Financials_MgmtEffectiveness ft_Financials_MgmtEffectiveness { get; set; }
    }
}
