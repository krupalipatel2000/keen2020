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
            //tblConsignment consignment = dc.tblConsignments.SingleOrDefault(ob => ob.ConsignmentId == id);
            var consignment = from ob in dc.tblConsignments
                              join ob2 in dc.tblConSignmentImages on ob.ConsignmentId equals ob2.ConsignmentID
                              where ob.ConsignmentId == id
                              select new JoinViewAll
                              {
                                  consignment = ob,
                                  conimage = ob2
                              };

            return View(consignment);
        }
    }
}