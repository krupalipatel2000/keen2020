using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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


    