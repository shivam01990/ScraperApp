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
    
    public partial class finviz_Recommendations
    {
        public long RecommendationId { get; set; }
        public int Job_run_id { get; set; }
        public int Stock_id { get; set; }
        public string Date { get; set; }
        public string RecommendationType { get; set; }
        public string Analyst { get; set; }
        public string Recommendation { get; set; }
        public string Target { get; set; }
        public byte[] CreatedOn { get; set; }
    
        public virtual ws_Jobs ws_Jobs { get; set; }
        public virtual ws_Stocks ws_Stocks { get; set; }
    }
}
