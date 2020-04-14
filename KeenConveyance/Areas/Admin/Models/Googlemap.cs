using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace KeenConveyance.Areas.Admin.Models
{
    public class Googlemap
    {
        public string Title { get; set; }

        public double Lat { get; set; }

        public double Lng { get; set; }

    }
}