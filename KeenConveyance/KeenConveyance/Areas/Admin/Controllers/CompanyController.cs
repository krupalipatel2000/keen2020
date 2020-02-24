using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KeenConveyance.Areas.Admin.Models;

namespace KeenConveyance.Areas.Admin.Controllers
{
    public class CompanyController : Controller
    {
        // GET: Admin/Company
        dbTransportEntities3 dc = new dbTransportEntities3();
        
        
        public ActionResult Index()
        {
            var com = dc.tblTransportCompanies.ToList();
            return View(com);
        }
        [HttpPost]
        public JsonResult Active(int id)
        {
            tblTransportCompany com = dc.tblTransportCompanies.SingleOrDefault(ob => ob.CompanyId == id);
            if (com.IsActive == true)
            {
                com.IsActive = false;
            }
            else
            {
                com.IsActive = true;
            }
            dc.SaveChanges();
            return Json(com.IsActive, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insert(FormCollection form)
        {
            tblTransportCompany com = new tblTransportCompany();
            com.CompanyName = form["txtComName"];
            com.Logo = form["txtLogo"];
            com.CompanyPhNo = form["txtComPhNo"];
            com.CompanyEmail = form["txtComEmail"];
            com.Password = form["txtPwd"];
            com.AboutCompany = form["txtAboutCompany"];
            com.ContactPersonName = form["txtContactPersonName"];
            com.ContactPersonNo = form["txtContactPersonPhNo"];
            com.WebURL = form["txtWebURL"];
            com.IsActive = true;
            dc.tblTransportCompanies.Add(com);
            dc.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            TempData["id"] = id;
            tblTransportCompany com = dc.tblTransportCompanies.SingleOrDefault(ob => ob.CompanyId == id);
            return View(com);
        }
        [HttpPost]
        public ActionResult Edit(FormCollection form)
        {
            int id = Convert.ToInt32(TempData["id"]);
            tblTransportCompany com = dc.tblTransportCompanies.SingleOrDefault(ob => ob.CompanyId == id);
            com.CompanyName = form["txtComName"];
            com.Logo = form["txtLogo"];
            com.CompanyPhNo = form["txtComPhNo"];
            com.CompanyEmail = form["txtComEmail"];
            com.Password = form["txtPwd"];
            com.AboutCompany = form["txtAboutCompany"];
            com.ContactPersonName = form["txtContactPersonName"];
            com.ContactPersonNo = form["txtContactPersonPhNo"];
            com.WebURL = form["txtWebURL"];
            dc.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            tblTransportCompany com = dc.tblTransportCompanies.SingleOrDefault(ob => ob.CompanyId == id);
            dc.tblTransportCompanies.Remove(com);
            dc.SaveChanges();
            return RedirectToAction("Index", "Company");
        }
        public ActionResult Detail(int id)
        {
            tblTransportCompany com = dc.tblTransportCompanies.SingleOrDefault(ob => ob.CompanyId == id);
            var PL = from ob in dc.tblPriceLists where ob.CompanyId == com.CompanyId select ob;
            ViewBag.PriceList = PL;
            
            return View(com);
        }
    }
}