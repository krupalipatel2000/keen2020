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
        dbTransportEntities4 dc = new dbTransportEntities4();
        
        
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
        public ActionResult Insert(FormCollection form,HttpPostedFileBase txtLogo)
        {
            string name = "txtLogo";
            if(txtLogo != null)
            {
                int size = (int)txtLogo.ContentLength / 1024;
                var extention = System.IO.Path.GetExtension(txtLogo.FileName);
                if (size <= 1024 && (extention.ToLower().Equals(".jpg") || extention.ToLower().Equals(".jpeg") || extention.ToLower().Equals(".png")))
                {
                    name = Code() + "" + extention;
                    string path = Server.MapPath("~/Images/");
                    txtLogo.SaveAs(path + "" + name);
                }
            }
            tblTransportCompany com = new tblTransportCompany();
            com.CompanyName = form["txtComName"];
            //com.Logo = form["txtLogo"];
            com.Logo = name.ToString();
            com.CompanyPhNo = form["txtComPhNo"];
            com.CompanyEmail = form["txtComEmail"];
            com.Password = form["txtPwd"];
            com.AboutCompany = form["txtAboutCompany"];
            com.ContactPersonName = form["txtContactPersonName"];
            com.ContactPersonNo = form["txtContactPersonPhNo"];
            com.WebURL = form["txtWebURL"];
            com.IsActive = true;
            com.CreatedOn = DateTime.Now;
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
           // com.Password = form["txtPwd"];
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
            var driver = from obdriver in dc.tblDrivers where obdriver.CompanyId == com.CompanyId select obdriver;
            var vehicle = from obvehicle in dc.tblVehicles where obvehicle.CompanyId == com.CompanyId select obvehicle;
            var service = from observice in dc.tblServices where observice.CompanyId == com.CompanyId select observice;
            ViewBag.PriceList = PL;
            ViewBag.driverlist = driver;
            ViewBag.vehiclelist = vehicle;
            ViewBag.servicelist = service;
            return View(com);
        }
        [HttpPost]
        public JsonResult CheckEmail(string id)
        {
            string response;
            tblTransportCompany company = dc.tblTransportCompanies.SingleOrDefault(ob => ob.CompanyEmail == id);
            if (company != null)
            {
                response = "true";
            }
            else
            {
                response = "false";
            }
            //dc.SaveChanges();
            return Json(response, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult CheckCom(string id)
        {
            string response;
            tblTransportCompany company = dc.tblTransportCompanies.SingleOrDefault(ob => ob.CompanyName == id);
            if (company != null)
            {
                response = "true";
            }
            else
            {
                response = "false";
            }
            //dc.SaveChanges();
            return Json(response, JsonRequestBehavior.AllowGet);
        }
        public string Code()
        {
            string code = DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss-ff").Replace("-", "");
            return code;
        }

    }
}