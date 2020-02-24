using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KeenConveyance.Areas.Admin.Models;

namespace KeenConveyance.Areas.Admin.Controllers
{
    public class ServiceController : Controller
    {
        // GET: Admin/Service
        dbTransportEntities3 dc = new dbTransportEntities3();
        public ActionResult Index()
        {
            var joinservice = from observice in dc.tblServices
                          join obCom in dc.tblTransportCompanies on observice.CompanyId equals obCom.CompanyId
                          select new JoinViewAll
                          {
                              comservice = observice,
                              company = obCom
                          };
            return View(joinservice);
        }
        [HttpPost]
        public JsonResult Active(int id)
        {
            tblService service = dc.tblServices.SingleOrDefault(ob => ob.ServiceId == id);
            if (service.IsActive == true)
            {
                service.IsActive = false;
            }
            else
            {
                service.IsActive = true;
            }
            dc.SaveChanges();
            return Json(service.IsActive, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Detail(int id)
        {
            tblService service = dc.tblServices.SingleOrDefault(ob => ob.ServiceId == id);
            return View(service);
        }
    }
}