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
    
    public partial class ws_JobScheduler_Weekly
    {
        public int scheduler_weekly_id { get; set; }
        public int scheduler_id { get; set; }
        public int weekly_freq { get; set; }
        public bool weekly_sunday { get; set; }
        public bool weekly_monday { get; set; }
        public bool weekly_tuesday { get; set; }
        public bool weekly_wednesday { get; set; }
        public bool weekly_thursday { get; set; }
        public bool weekly_friday { get; set; }
        public bool weekly_saturday { get; set; }
        public byte[] CreatedOn { get; set; }
    
        public virtual ws_JobScheduler ws_JobScheduler { get; set; }
    }
}