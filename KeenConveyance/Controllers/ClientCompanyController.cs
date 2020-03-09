﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;
using KeenConveyance.Areas.Admin.Models;

namespace KeenConveyance.Controllers
{
    public class ClientCompanyController : Controller
    {
        // GET: ClientCompany
        dbTransportEntities4 dc = new dbTransportEntities4();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string txtEmail, string txtPwd)
        {
            tblTransportCompany company = (from ob in dc.tblTransportCompanies where ob.CompanyEmail == txtEmail && ob.Password == txtPwd select ob).Take(1).SingleOrDefault();
            if (company != null)
            {
                Session["loginId"] = company;
                //Session["LogID"] = company.CompanyId;

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
        public ActionResult Insert(FormCollection form, HttpPostedFileBase txtLogo)
        {
            string name = "txtLogo";
            if (txtLogo != null)
            {
                int size = (int)txtLogo.ContentLength / 1024;
                var extention = System.IO.Path.GetExtension(txtLogo.FileName);
                if (size <= 1024 && (extention.ToLower().Equals(".jpg") || extention.ToLower().Equals(".jpeg") || extention.ToLower().Equals(".png")))
                {
                    name = Code() + "" + extention;
                    string path = Server.MapPath("~/Images/");
                    txtLogo.SaveAs(path + "" + name);
                }
            }
            tblTransportCompany com = new tblTransportCompany();
            com.CompanyName = form["txtComName"];
            //com.Logo = form["txtLogo"];
            com.Logo = name.ToString();
            com.CompanyPhNo = form["txtComPhNo"];
            com.CompanyEmail = form["txtComEmail"];
            com.Password = form["txtPwd"];
            com.AboutCompany = form["txtAboutCompany"];
            com.ContactPersonName = form["txtContactPersonName"];
            com.ContactPersonNo = form["txtContactPersonPhNo"];
            com.WebURL = form["txtWebURL"];
            com.IsActive = true;
            com.CreatedOn = DateTime.Now;
            dc.tblTransportCompanies.Add(com);
            dc.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public string Code()
        {
            string code = DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss-ff").Replace("-", "");
            return code;
        }
    }
}


    