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
    
    public partial class ws_JobScheduler_Yearly
    {
        public int scheduler_yearly_id { get; set; }
        public int scheduler_id { get; set; }
        public int yearly_nominal_day { get; set; }
        public int yearly_nominal_month { get; set; }
        public int yearly_day { get; set; }
        public int yearly_week_of_day { get; set; }
        public int yearly_month { get; set; }
        public byte[] CreatedOn { get; set; }
        public bool yearly_isweekday { get; set; }
    
        public virtual ws_JobScheduler ws_JobScheduler { get; set; }
    }
}