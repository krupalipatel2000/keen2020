using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KeenConveyance.Areas.Admin.Models;



namespace KeenConveyance.Areas.Admin.Controllers
{
    public class VehicleController : Controller
    {
        // GET: Admin/Vehicle
      dbTransportEntities4 dc = new dbTransportEntities4();
        public ActionResult Index()
        {
            var vehicle = dc.tblVehicles.ToList();
            return View(vehicle);
        }
        [HttpPost]
        public JsonResult Active(int id)
        {
            tblVehicle vehicle = dc.tblVehicles.SingleOrDefault(ob => ob.VehicleId == id);
            if (vehicle.IsActive == true)
            {
                vehicle.IsActive = false;
            }
            else
            {
                vehicle.IsActive = true;
            }
            dc.SaveChanges();
            return Json(vehicle.IsActive, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Detail(int id)
        {
            tblVehicle vehicle = dc.tblVehicles.SingleOrDefault(ob => ob.VehicleId == id);
            ViewBag.CompanyName = (from ob in dc.tblTransportCompanies where ob.CompanyId == vehicle.CompanyId select ob).Take(1).SingleOrDefault().CompanyName;
            string Name = ViewBag.CompanyName;
            return View(vehicle);
        }

    }
}