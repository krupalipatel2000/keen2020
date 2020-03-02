using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KeenConveyance.Areas.Admin.Models;

namespace KeenConveyance.Areas.Admin.Controllers
{
    public class DriverController : Controller
    {
        // GET: Admin/Driver
        dbTransportEntities4 dc = new dbTransportEntities4();
        public ActionResult Index()
        {

            var driver = dc.tblDrivers.ToList();
            return View(driver);

        }
        [HttpPost]
        public JsonResult Active(int id)
        {
            tblDriver driver = dc.tblDrivers.SingleOrDefault(ob => ob.DriverId == id);
            if (driver.IsActive == true)
            {
                driver.IsActive = false;
            }
            else
            {
                driver.IsActive = true;
            }
            dc.SaveChanges();
            return Json(driver.IsActive, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Detail(int id)
        {
            tblDriver driver = dc.tblDrivers.SingleOrDefault(ob => ob.DriverId == id);
            ViewBag.CompanyName = (from ob in dc.tblTransportCompanies where ob.CompanyId == driver.CompanyId select ob).Take(1).SingleOrDefault().CompanyName;
            string Name = ViewBag.CompanyName;
            return View(driver);
        }

    }
}