//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KeenConveyance.Areas.Admin.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblInquiry
    {
        public int InquiryId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNo { get; set; }
        public string EmailId { get; set; }
        public string Subject { get; set; }
        public string Desc { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public bool IsReplied { get; set; }
        public string RepliedText { get; set; }
        public Nullable<System.DateTime> RepliedOn { get; set; }
        public Nullable<int> RepliedBy { get; set; }
    }
}
