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
    
    public partial class tblReview
    {
        public int ReviewId { get; set; }
        public int UserId { get; set; }
        public int CompanyId { get; set; }
        public int ConsignmentId { get; set; }
        public string Review { get; set; }
        public string Rate { get; set; }
    }
}