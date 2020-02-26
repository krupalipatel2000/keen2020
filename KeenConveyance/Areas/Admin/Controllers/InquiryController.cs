using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KeenConveyance.Areas.Admin.Models;

namespace KeenConveyance.Areas.Admin.Controllers
{
    public class InquiryController : Controller
    {
        // GET: Admin/Inquiry
        dbTransportEntities3 dc = new dbTransportEntities3();

        public ActionResult Index()
        {
                var inquiry = dc.tblInquiries.ToList();
                return View(inquiry);
            
        }
        [HttpPost]
        public JsonResult Active(int id)
        {
            tblInquiry com = dc.tblInquiries.SingleOrDefault(ob => ob.InquiryId == id);
            if (com.IsReplied == true)
            {
                com.IsReplied = false;
            }
            else
            {
                com.IsReplied = true;
            }
            dc.SaveChanges();
            return Json(com.IsReplied, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Detail(int id)
        {
            tblInquiry inquirie = dc.tblInquiries.SingleOrDefault(ob => ob.InquiryId == id);
            return View(inquirie);
        }

    }
}