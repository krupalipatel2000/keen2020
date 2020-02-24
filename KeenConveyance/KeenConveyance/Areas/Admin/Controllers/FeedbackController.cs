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
        dbTransportEntities3 dc = new dbTransportEntities3();
        public ActionResult Index()
        {

            var joinfeedback= from obfeedback in dc.tblFeedbacks
                          join obCom in dc.tblTransportCompanies on obfeedback.CompanyId equals obCom.CompanyId
                          select new JoinViewAll
                          {
                              feedback = obfeedback,
                              company = obCom
                          };
            return View(joinfeedback);
        }
        public ActionResult Detail(int id)
        {
            tblFeedback feedback = dc.tblFeedbacks.SingleOrDefault(ob => ob.FeedbackId == id);
            return View(feedback);
        }

    }
}