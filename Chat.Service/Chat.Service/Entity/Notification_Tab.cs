//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Chat.Service.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Notification_Tab
    {
        public int NoteID { get; set; }
        public string Notedet { get; set; }
        public Nullable<int> NotifyTo { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<System.DateTime> Time { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public string IP { get; set; }
        public Nullable<int> IsDeleted { get; set; }
    }
}
