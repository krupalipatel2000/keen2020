using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KeenConveyance.Areas.Admin.Models;

namespace KeenConveyance.Areas.Admin.Controllers
{
    public class FeedbackController : Controller
    {
        // GET: Admin/Feedback
        dbTransportEntities4 dc = new dbTransportEntities4();
        public ActionResult Index()
        {
            var feedback = dc.tblFeedbacks.ToList();
            return View(feedback);
            //var joinfeedback= from obfeedback in dc.tblFeedbacks
            //              join obCom in dc.tblTransportCompanies on obfeedback.CompanyId equals obCom.CompanyId
            //              select new JoinViewAll
            //              {
            //                  feedback = obfeedback,
            //                  company = obCom
            //              };
            //return View(joinfeedback);
        }
        public ActionResult Detail(int id)
        {
            tblFeedback feedback = dc.tblFeedbacks.SingleOrDefault(ob => ob.FeedbackId == id);
            //ViewBag.Company = (from ob in dc.tblTransportCompanies where ob.CompanyId == feedback.CompanyId select ob).Take(1).SingleOrDefault().CompanyName;
            //ViewBag.User = (from ob in dc.tblUsers where ob.UserId == feedback.UserId select ob).Take(1).SingleOrDefault().FirstName;
            //string Name = ViewBag.Company;
            //string Uname = ViewBag.User;
            return View(feedback);
        }
        [HttpPost]
        public JsonResult Active(int id)
        {
            tblFeedback feedback = dc.tblFeedbacks.SingleOrDefault(ob => ob.FeedbackId == id);
            if (feedback.IsActive == true)
            {
                feedback.IsActive = false;
            }
            else
            {
                feedback.IsActive = true;
            }
            dc.SaveChanges();
            return Json(feedback.IsActive, JsonRequestBehavior.AllowGet);
        }

    }
}