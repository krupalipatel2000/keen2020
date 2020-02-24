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
        dbTransportEntities3 dc = new dbTransportEntities3();
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
            string Name = ViewBag.User;
            ViewBag.ConsignmentImage = from ob in dc.tblConSignmentImages where ob.ConsignmentID==id select ob;
            return View(consignment);
        }
    }
}