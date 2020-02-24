using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KeenConveyance.Areas.Admin.Models;


namespace KeenConveyance.Areas.Admin.Controllers
{
    public class TrackingController : Controller
    {
        // GET: Admin/Tracking
        dbTransportEntities3 dc = new dbTransportEntities3();
        public ActionResult Index()
        {
            var track = dc.tblTrackings.ToList();
            return View(track);

        }
        public ActionResult Detail(int id)
        {
            tblTracking track = dc.tblTrackings.SingleOrDefault(ob => ob.TrackingId== id);
            return View(track);
        }

    }
}