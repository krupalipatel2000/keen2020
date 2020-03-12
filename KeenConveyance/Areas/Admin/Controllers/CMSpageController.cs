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
        dbTransportEntities5 dc = new dbTransportEntities5();
        public ActionResult Index()
        {
            var TitleList = from ob in dc.tblCMSPages select ob.PageTitle;
            ViewBag.Titles = TitleList;
            return View();
        }
        [HttpPost,ValidateInput(false)]
        public ActionResult Index(string txtTitle, string BlogContent)
        {
            tblCMSPage cms = new tblCMSPage();
            cms.PageTitle = txtTitle;
            cms.Desc = BlogContent;
            cms.CreatedOn = DateTime.Now;
            cms.IsActive = true;
            dc.tblCMSPages.Add(cms);
            dc.SaveChanges();
            ViewBag.Desc = BlogContent;
            return RedirectToAction("ViewCMS", new { Title = txtTitle });
        }
        public ActionResult ViewCMS(int id = 1)
        {
            var TitleList = from ob in dc.tblCMSPages select ob;
            ViewBag.CMS = TitleList;
            tblCMSPage cms = dc.tblCMSPages.SingleOrDefault(ob => ob.CMSPageId == id);
            return View(cms);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult ViewCMS(string BlogContent, int id)
        {
            tblCMSPage cms = dc.tblCMSPages.SingleOrDefault(ob => ob.CMSPageId == id);
            cms.Desc = BlogContent;
            dc.SaveChanges();
            //string myOTP = Services.GenerateOTP();
            //string UCode = Services.UniqueCode();
            return RedirectToAction("ViewCMS", "CMSpage");
        }

    }
}