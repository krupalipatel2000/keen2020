using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KeenConveyance.Areas.Admin.Models;

namespace KeenConveyance.Areas.Admin.Controllers
{
    public class ConsignmentController : Controller
    {
        // GET: Admin/Consignment
        dbTransportEntities4 dc = new dbTransportEntities4();
        public ActionResult Index()
        {
            var consignment = dc.tblConsignments.ToList();
            return View(consignment);
        }
        [HttpPost]
        public JsonResult Active(int id)
        {
           tblConsignment consignment = dc.tblConsignments.SingleOrDefault(ob => ob.ConsignmentId == id);
            if (consignment.IsActive == true)
            {
                consignment.IsActive = false;
            }
            else
            {
                consignment.IsActive = true;
            }
            dc.SaveChanges();
            return Json(consignment.IsActive, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Detail(int id)
        {
            tblConsignment consignment = dc.tblConsignments.SingleOrDefault(ob => ob.ConsignmentId == id);
            ViewBag.User = (from ob in dc.tblUsers where ob.UserId == consignment.UserId select ob).Take(1).SingleOrDefault().FirstName;
            ViewBag.Source = (from ob in dc.tblAddresses where ob.AddressId == consignment.SourceId select ob).Take(1).SingleOrDefault().Address;
            ViewBag.Destination = (from ob in dc.tblAddresses where ob.AddressId == consignment.DestinationId select ob).Take(1).SingleOrDefault().Address;
            string Name = ViewBag.User;
            string source = ViewBag.Source;
            string destination = ViewBag.Destination;
            ViewBag.ConsignmentImage = from ob in dc.tblConSignmentImages where ob.ConsignmentID==id select ob;
            return View(consignment);
        }
    }
}