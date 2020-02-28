using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using KeenConveyance.Areas.Admin.Models;
using System.Net.Mail;

namespace KeenConveyance.Areas.Admin.Controllers
{
    public class InquiryController : Controller
    {
        // GET: Admin/Inquiry
        dbTransportEntities3 dc = new dbTransportEntities3();

        public ActionResult Index()
        {
            var Inqs = from ob in dc.tblInquiries where ob.IsReplied == false select ob;
            return View(Inqs);
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
        [HttpPost]
        public ActionResult Detail(FormCollection form, int id)
        {
            tblInquiry Inq = dc.tblInquiries.SingleOrDefault(ob => ob.InquiryId == id);
            Inq.RepliedText = form["txtReply"];
            Inq.RepliedBy = Convert.ToInt32(Session["LogID"]);
            Inq.IsReplied = true;
            dc.SaveChanges();

            // Email Code 
            MailMessage Msg = new MailMessage("keenconveyance@gmail.com", Inq.EmailId);
            Msg.Subject = "Reply of Your Inquiry";
            Msg.Body = form["txtReply"];
            Msg.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

            NetworkCredential MyCredentials = new NetworkCredential("keenconveyance@gmail.com", "nkp12345");
            smtp.Credentials = MyCredentials;

            smtp.Send(Msg);

            return RedirectToAction("Index","Inquiry");
        }
    }
}