using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using KeenConveyance.Areas.Admin.Models;

namespace KeenConveyance.Controllers
{
    public class HomeController : Controller
    {
        dbTransportEntities4 dc = new dbTransportEntities4();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Blank()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ForgetPassword(string txtForgetEmail)
        {
            tblUser user = dc.tblUsers.SingleOrDefault(ob => ob.EmailId == txtForgetEmail);
            if (user != null)
            {
                Session["LoginUserID"] = user.UserId;
                MailMessage Msg = new MailMessage("keenconveyance@gmail.com", txtForgetEmail);
                Msg.Subject = "Password Recovery";
                Msg.Body = "Your OTP is : <h3>" + 1234 + "</h3>";
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
                Session["OTP"] = "1234";
                return View();
            }
            else
            {
                ViewBag.Error = "Account Not Found";
                return View();
            }
        }
        public ActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ChangePassword(FormCollection form)
        {
            tblUser user = dc.tblUsers.SingleOrDefault(ob => ob.UserId == Convert.ToInt32(Session["LoginUserID"]));
            user.Password = form["txtPassword"];
            dc.SaveChanges();
            return View();
        }


    }
}