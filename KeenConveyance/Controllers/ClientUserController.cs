using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;
using KeenConveyance.Areas.Admin.Models;

namespace KeenConveyance.Controllers
{
    public class ClientUserController : Controller
    {
        // GET: User
        dbTransportEntities4 dc = new dbTransportEntities4();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string txtEmail, string txtPwd)
        {
            tblUser user = (from ob in dc.tblUsers where ob.EmailId == txtEmail && ob.Password == txtPwd select ob).Take(1).SingleOrDefault();
            if (user != null)
            {
                Session["loginId"] = user.FirstName;
                //Session["LogID"] = user.UserId;

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.message = "*Inavalid email or password";
                return View();
                //return RedirectToAction("Dashboard", "Admin");
            }
        }
        //public ActionResult Login()
        //{
        //    return View();
        //}
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
        public ActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insert(FormCollection form, HttpPostedFileBase txtprofile)
        {
            string name = "txtprofile";
            if (txtprofile != null)
            {
                int size = (int)txtprofile.ContentLength / 1024;
                var extention = System.IO.Path.GetExtension(txtprofile.FileName);
                if (size <= 1024 && (extention.ToLower().Equals(".jpg") || extention.ToLower().Equals(".jpeg") || extention.ToLower().Equals(".png")))
                {
                    name = code() + "" + extention;
                    string path = Server.MapPath("~/Images/");
                    txtprofile.SaveAs(path + "" + name);
                }
            }
            tblUser user = new tblUser();
            user.FirstName = form["txtFirstName"];
            user.LastName = form["txtLastName"];
            user.EmailId = form["txtEmailId"];
            user.Password = form["txtPwd"];
            user.Gender = form["gender"];
            user.ContactNo = form["txtCno"];
            user.IsActive = false;
            user.CreatedOn = DateTime.Now;
            user.IsVerified = false;
            user.IsMobileVerified = false;
            user.ProfilePic = name.ToString();
            dc.tblUsers.Add(user);
            dc.SaveChanges();
            return RedirectToAction("List");
        }
        public ActionResult List()
        {
            var user = dc.tblUsers.ToList();
            return View(user);
        }
        [HttpPost]
        public JsonResult Active(int id)
        {
            tblUser user = dc.tblUsers.SingleOrDefault(ob => ob.UserId == id);
            if (user.IsActive == true)
            {
                user.IsActive = false;
            }
            else
            {
                user.IsActive = true;
            }
            dc.SaveChanges();
            return Json(user.IsActive, JsonRequestBehavior.AllowGet);
        }
        public string code()
        {
            string code = DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss-ff").Replace("-", "");
            return code;
        }
    }

}