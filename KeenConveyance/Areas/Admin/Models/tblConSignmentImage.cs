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
    
    public partial class tblConSignmentImage
    {
        public int ConsignmentImageId { get; set; }
        public int ConsignmentID { get; set; }
        public string ImageURL { get; set; }
        public bool IsDefault { get; set; }
        public bool IsActive { get; set; }
    }
}
