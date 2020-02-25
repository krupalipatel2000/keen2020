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
        dbTransportEntities3 dc = new dbTransportEntities3();
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
    }
}