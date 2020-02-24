using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KeenConveyance.Areas.Admin.Models;

namespace KeenConveyance.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin/Admin
        dbTransportEntities3 dc = new dbTransportEntities3();
        public ActionResult Index()
        {
            Session.Clear();
            return View();
        }
        
        [HttpPost]
        public ActionResult Index(string txtEmail,string txtPwd)
        {
            tblAdmin ad = (from ob in dc.tblAdmins where ob.EmailId == txtEmail && ob.Password == txtPwd select ob).Take(1).SingleOrDefault();
            if (ad != null)
            {
                Session["loginId"] = ad.Name;
                return RedirectToAction("List", "Admin");
            }
            else
            {
                return RedirectToAction("Index","Admin");
            }
        }
        public ActionResult Blank()
        {
            return View();
        }
        public ActionResult List()
        {
            if (Session["loginId"] != null)
            {
                var admin = dc.tblAdmins.ToList();
                return View(admin);
            }
            else
            {
                return RedirectToAction("Index","Admin");
            }
        }
        public ActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insert(FormCollection form)
        {
            tblAdmin ad = new tblAdmin();
            ad.Name = form["txtName"];
            ad.EmailId = form["txtEmail"];
            ad.Password = form["txtPwd"];
            ad.ContactNo = form["txtCno"];
            ad.IsActive = true;
            ad.CreatedOn = DateTime.Now;
            ad.CreatedBy = Convert.ToInt32(form["txtCreatedBy"]);
            ad.IsSuper = true;
            ad.IsInsert = true;
            ad.IsEdit = true;
            ad.IsDelete = true;
            dc.tblAdmins.Add(ad);
            dc.SaveChanges();
            return RedirectToAction("List");
        }
        [HttpPost]
        public JsonResult Active(int id)
        {
            tblAdmin ad = dc.tblAdmins.SingleOrDefault(ob => ob.AdminId == id);
            if (ad.IsActive == true)
            {
                ad.IsActive = false;
            }
            else
            {
                ad.IsActive = true;
            }
            dc.SaveChanges();
            return Json(ad.IsActive, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Edit(int id)
        {
            TempData["id"] = id;
            tblAdmin ad = dc.tblAdmins.SingleOrDefault(ob => ob.AdminId == id);
            return View(ad);
        }
        [HttpPost]
        public ActionResult Edit(FormCollection form)
        {
            int id = Convert.ToInt32(TempData["id"]);
            tblAdmin ad = dc.tblAdmins.SingleOrDefault(ob => ob.AdminId == id);
            ad.Name = form["txtName"];
            ad.EmailId = form["txtEmail"];
            ad.ContactNo = form["txtCno"];
           // ad.ImageUrl = form["txtFile"];
            dc.SaveChanges();
            return RedirectToAction("List");
        }
        public ActionResult Delete(int id)
        {
            tblAdmin ad = dc.tblAdmins.SingleOrDefault(ob => ob.AdminId == id);
            dc.tblAdmins.Remove(ad);
            dc.SaveChanges();
            return RedirectToAction("List","Admin");
        }
        public ActionResult Detail(int id)
        {
            tblAdmin ad = dc.tblAdmins.SingleOrDefault(ob => ob.AdminId == id);
            ViewBag.AdminName = (from ob in dc.tblAdmins where ob.AdminId == ad.CreatedBy select ob).Take(1).SingleOrDefault().Name;
            string Name = ViewBag.AdminName;
            return View(ad);
        }
    }
}