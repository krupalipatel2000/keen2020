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
        dbTransportEntities4 dc = new dbTransportEntities4();
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
            ViewBag.Company = (from ob in dc.tblTransportCompanies where ob.CompanyId == service.CompanyId select ob).Take(1).SingleOrDefault().CompanyName;
            string Name = ViewBag.Company;
            return View(service);
        }
        public ActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insert(FormCollection form,HttpPostedFileBase txtSimage)
        {
            string name = "txtSimage";
            if (txtSimage != null)
            {
                int size = (int)txtSimage.ContentLength / 1024;
                var extention = System.IO.Path.GetExtension(txtSimage.FileName);
                if (size <= 1024 && (extention.ToLower().Equals(".jpg") || extention.ToLower().Equals(".jpeg") || extention.ToLower().Equals(".png")))
                {
                    name = Code() + "" + extention;
                    string path = Server.MapPath("~/Images/");
                    txtSimage.SaveAs(path + "" + name);
                }
            }
            tblService service = new tblService();
            service.ServiceName = form["txtSname"];
            service.ServiceDesc = form["txtDesc"];
            service.ServiceImage = name.ToString();
            service.IsActive = false;
            service.CreatedOn = DateTime.Now;

            dc.tblServices.Add(service);
            dc.SaveChanges();
            return RedirectToAction("Index","Service");
        }
        public string Code()
        {
            string code = DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss-ff").Replace("-", "");
            return code;
        }
        public ActionResult Edit(int id)
        {
            TempData["id"] = id;
            tblService service = dc.tblServices.SingleOrDefault(ob => ob.ServiceId == id);
            return View(service);
        }
        [HttpPost]
        public ActionResult Edit(FormCollection form)
        {
            int id = Convert.ToInt32(TempData["id"]);
            tblService service = dc.tblServices.SingleOrDefault(ob => ob.ServiceId == id);
            service.ServiceName = form["txtSname"];
            service.ServiceDesc = form["txtDesc"];
            service.ServiceImage = form["txtSimage"];
            dc.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            tblService service = dc.tblServices.SingleOrDefault(ob => ob.ServiceId == id);
            dc.tblServices.Remove(service);
            dc.SaveChanges();
            return RedirectToAction("Index", "Service");
        }

    }
}