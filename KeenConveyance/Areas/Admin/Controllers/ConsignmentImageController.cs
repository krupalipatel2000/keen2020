using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KeenConveyance.Areas.Admin.Models;

namespace KeenConveyance.Areas.Admin.Controllers
{
    public class ConsignmentImageController : Controller
    {
        // GET: Admin/ConsignmentImage
        dbTransportEntities5 dc = new dbTransportEntities5();
        public ActionResult Index()
        {
            var image = dc.tblConSignmentImages.ToList();
            return View(image);
        }
        [HttpPost]
        public JsonResult Active(int id)
        {
            tblConSignmentImage consignment = dc.tblConSignmentImages.SingleOrDefault(ob => ob.ConsignmentImageId== id);
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
            tblConSignmentImage consignment = dc.tblConSignmentImages.SingleOrDefault(ob => ob.ConsignmentImageId == id);
            return View(consignment);
        }

    }
}