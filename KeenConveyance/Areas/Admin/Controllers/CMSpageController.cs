using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KeenConveyance.Areas.Admin.Models;

namespace KeenConveyance.Areas.Admin.Controllers
{
    public class CMSpageController : Controller
    {
        // GET: Admin/CMSpage
        dbTransportEntities4 dc = new dbTransportEntities4();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost,ValidateInput(false)]
        public ActionResult Index(string pageTitle,string BlogContent)
        {
            tblCMSPage cms = new tblCMSPage();
            cms.PageTitle = pageTitle;
            cms.Desc = BlogContent;
            cms.CreatedOn = DateTime.Now;
            cms.IsActive = true;
            dc.tblCMSPages.Add(cms);
            dc.SaveChanges();
            ViewBag.Content = BlogContent;
            return RedirectToAction("ViewCMS", new { Title = pageTitle });
        }
        public ActionResult ViewCMS(string Title)
        {
            tblCMSPage cms = dc.tblCMSPages.SingleOrDefault(ob => ob.PageTitle == Title);
            return View(cms);
        }
        public ActionResult List()
        {
            var cms = dc.tblCMSPages.ToList();
            return View(cms);
        }
        [HttpPost]
        public JsonResult Active(int id)
        {
            tblCMSPage cms = dc.tblCMSPages.SingleOrDefault(ob => ob.CMSPageId == id);
            if (cms.IsActive == true)
            {
                cms.IsActive = false;
            }
            else
            {
                cms.IsActive = true;
            }
            dc.SaveChanges();
            return Json(cms.IsActive, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Edit(int id)
        {
            TempData["id"] = id;
            tblCMSPage cms = dc.tblCMSPages.SingleOrDefault(ob => ob.CMSPageId == id);
            return View(cms);
        }
        [HttpPost]
        public ActionResult Edit(FormCollection form)
        {
            int id = Convert.ToInt32(TempData["id"]);
            tblCMSPage cms = dc.tblCMSPages.SingleOrDefault(ob => ob.CMSPageId == id);
            cms.PageTitle = form["txtPage"];
            cms.Desc = form["txtDesc"];
            dc.SaveChanges();
            return RedirectToAction("List", "CMSpage");
        }
        public ActionResult Delete(int id)
        {
            tblCMSPage cms = dc.tblCMSPages.SingleOrDefault(ob => ob.CMSPageId == id);
            dc.tblCMSPages.Remove(cms);
            dc.SaveChanges();
            return RedirectToAction("List", "CMSpage");
        }
    }
}