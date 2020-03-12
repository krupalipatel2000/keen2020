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
        public ActionResult Login(string txtEmail, string txtPwd, string usertype)
        {
            if (usertype == "U")
            {
                tblUser user = (from ob in dc.tblUsers where ob.EmailId == txtEmail && ob.Password == txtPwd select ob).Take(1).SingleOrDefault();
                if (user != null)
                {
                    //Session["UserId"] = user.FirstName;
                    Session["LogID"] = user.UserId;
                    if (Session["LogID"] != null)
                    {
                        return RedirectToAction("UserProfile", "ClientUser", new {id=user.UserId});
                    }
                    else
                    {
                        return View();
                    }
                }
                else
                {
                    ViewBag.message = "*Inavalid email or password";
                    return View();
                    //return RedirectToAction("Dashboard", "Admin");
                }
            }
            else
            {
                tblTransportCompany com = (from ob in dc.tblTransportCompanies where ob.CompanyEmail == txtEmail && ob.Password == txtPwd select ob).Take(1).SingleOrDefault();
                if (com != null)
                {
                    //Session["UserId"] = com.CompanyName;
                    Session["CompanyId"] = com.CompanyId;
                    return RedirectToAction("CompanyProfile", "ClientCompany", new { id = com.CompanyId});
                }
                else
                {
                    ViewBag.message = "*Inavalid email or password";
                    return View();
                    //return RedirectToAction("Dashboard", "Admin");
                }
            }
        }
        [HttpPost]
        public ActionResult ForgetPassword(string txtForgetEmail, string usertype)
        {
            if (usertype == "U")
            {
                tblUser user = dc.tblUsers.SingleOrDefault(ob => ob.EmailId == txtForgetEmail);
                if (user != null)
                {
                    Session["LoginUserID"] = user.UserId;
                    MailMessage Msg = new MailMessage("keenconveyance@gmail.com", txtForgetEmail);
                    Msg.Subject = "Password Recovery";
                    Msg.Body = "Your OTP is : <h3>" + Code() + "</h3>";
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
                    Session["OTP"] = Code();
                    return View();
                }
                else
                {
                    ViewBag.Error = "Account Not Found";
                    return View();
                }
            }
            else
            {
                tblTransportCompany com = dc.tblTransportCompanies.SingleOrDefault(ob => ob.CompanyEmail == txtForgetEmail);
                if (com != null)
                {
                    Session["LoginUserID"] = com.CompanyId;
                    MailMessage Msg = new MailMessage("keenconveyance@gmail.com", txtForgetEmail);
                    Msg.Subject = "Password Recovery";
                    Msg.Body = "Your OTP is : <h3>" + Code() + "</h3>";
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
                    Session["OTP"] = Code();
                    return View();
                }
                else
                {
                    ViewBag.Error = "Account Not Found";
                    return View();
                }
            }

        }
        public ActionResult LogoutUser()
        {
            Session["LogID"] = null;
            return RedirectToAction("Index");
        }
        public ActionResult LogoCompany()
        {
            Session["CompanyId"] = null;
            return RedirectToAction("Index");
        }
        public ActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ChangePassword(FormCollection form)
        {
            int ID = Convert.ToInt32(Session["LoginUserID"]);
            tblUser user = dc.tblUsers.SingleOrDefault(ob => ob.UserId == ID);
            if (user != null)
            {
                user.Password = form["txtPassword"];
                dc.SaveChanges();
                return RedirectToAction("Login");
            }
            else
            {
                return RedirectToAction("Login");
            }

        }
        public string Code()
        {
            Random R = new Random(0001);
            string OTP;
            OTP = R.Next(1111, 9999).ToString();
            return OTP;
        }
    }
}