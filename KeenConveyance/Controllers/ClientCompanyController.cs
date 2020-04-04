using System;
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
        dbTransportEntities5 dc = new dbTransportEntities5();
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
            return RedirectToAction("Login", "Home");
        }
        [HttpPost]
        public JsonResult CheckEmail(string id)
        {
            string response;
            tblTransportCompany company = dc.tblTransportCompanies.SingleOrDefault(ob => ob.CompanyEmail == id);
            if (company != null)
            {
                response = "true";
            }
            else
            {
                response = "false";
            }
            //dc.SaveChanges();
            return Json(response, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult CheckCom(string id)
        {
            string response;
            tblTransportCompany company = dc.tblTransportCompanies.SingleOrDefault(ob => ob.CompanyName == id);
            if (company != null)
            {
                response = "true";
            }
            else
            {
                response = "false";
            }
            //dc.SaveChanges();
            return Json(response, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CompanyProfile(int id)
        {
            if (id != 0)
            {
                tblTransportCompany com = dc.tblTransportCompanies.SingleOrDefault(ob => ob.CompanyId == id);
                //ViewBag.House = (from ob in dc.tblAddresses where ob.CompanyId == com.CompanyId select ob).Take(1).SingleOrDefault().HouseNo;
                //ViewBag.Landmark = (from ob in dc.tblAddresses where ob.CompanyId == com.CompanyId select ob).Take(1).SingleOrDefault().Landmark;
                //ViewBag.Area = (from ob in dc.tblAddresses where ob.CompanyId == com.CompanyId select ob).Take(1).SingleOrDefault().Area;
                //ViewBag.Address = (from ob in dc.tblAddresses where ob.CompanyId == com.CompanyId select ob).Take(1).SingleOrDefault().Address;
                ViewBag.Year = com.CreatedOn.Year.ToString();
                var PL = from ob in dc.tblPriceLists where ob.CompanyId == com.CompanyId select ob;
                var Address = from ob in dc.tblAddresses where ob.CompanyId == com.CompanyId select ob;
                var Bid = from ob in dc.tblBiddings where ob.CompanyId == com.CompanyId select ob;
                ViewBag.PriceList = PL;
                ViewBag.address = Address;
                ViewBag.bid = Bid;
                return View(com);
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }
        public ActionResult Edit(int id)
        {
            TempData["id"] = id;
            tblTransportCompany com = dc.tblTransportCompanies.SingleOrDefault(ob => ob.CompanyId == id);
            return View(com);
        }
        [HttpPost]
        public ActionResult Edit(FormCollection form)
        {
            int id = Convert.ToInt32(TempData["id"]);
            tblTransportCompany com = dc.tblTransportCompanies.SingleOrDefault(ob => ob.CompanyId == id);
            com.CompanyName = form["txtComName"];
            //com.Logo = form["txtLogo"];
            com.CompanyPhNo = form["txtComPhNo"];
            //com.CompanyEmail = form["txtComEmail"];
            // com.Password = form["txtPwd"];
            com.AboutCompany = form["txtAboutCompany"];
            com.ContactPersonName = form["txtContactPersonName"];
            com.ContactPersonNo = form["txtContactPersonPhNo"];
            com.WebURL = form["txtWebURL"];
            dc.SaveChanges();
            return RedirectToAction("CompanyProfile", new { id = com.CompanyId });
        }
        public string Code()
        {
            string code = DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss-ff").Replace("-", "");
            return code;
        }
        public ActionResult AddDriver()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddDriver(FormCollection form, HttpPostedFileBase txtProfile)
        {
            string name = "txtProfile";
            if (txtProfile != null)
            {
                int size = (int)txtProfile.ContentLength / 1024;
                var extention = System.IO.Path.GetExtension(txtProfile.FileName);
                if (size <= 1024 && (extention.ToLower().Equals(".jpg") || extention.ToLower().Equals(".jpeg") || extention.ToLower().Equals(".png")))
                {
                    name = Code() + "" + extention;
                    string path = Server.MapPath("~/Images/");
                    txtProfile.SaveAs(path + "" + name);
                }
            }
            tblDriver driver = new tblDriver();
            driver.CompanyId = Convert.ToInt32(Session["CompanyId"]);
            driver.DriverName = form["txtDname"];
            driver.ImageURL = name.ToString();
            driver.ContactNo = form["txtCno"];
            driver.EmailId = form["txtEmail"];
            driver.LicenseNo = form["txtLno"];
            driver.AadharcardNo = form["txtAno"];
            driver.IsActive = true;
            driver.CreatedOn = DateTime.Now;
            dc.tblDrivers.Add(driver);
            dc.SaveChanges();
            return RedirectToAction("CompanyProfile", "ClientCompany", new { id = driver.CompanyId });
        }
        public ActionResult AddVehicle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddVehicle(FormCollection form, HttpPostedFileBase txtImage, HttpPostedFileBase txtVimage)
        {
            string name = "txtImage";
            if (txtImage != null)
            {
                int size = (int)txtImage.ContentLength / 1024;
                var extention = System.IO.Path.GetExtension(txtImage.FileName);
                if (size <= 1024 && (extention.ToLower().Equals(".jpg") || extention.ToLower().Equals(".jpeg") || extention.ToLower().Equals(".png")))
                {
                    name = Code() + "" + extention;
                    string path = Server.MapPath("~/Images/");
                    txtImage.SaveAs(path + "" + name);
                }
            }
            string vehiclename = "txtVimage";
            if (txtVimage != null)
            {
                int size = (int)txtVimage.ContentLength / 1024;
                var extention = System.IO.Path.GetExtension(txtVimage.FileName);
                if (size <= 1024 && (extention.ToLower().Equals(".jpg") || extention.ToLower().Equals(".jpeg") || extention.ToLower().Equals(".png")))
                {
                    vehiclename = Code() + "" + extention;
                    string path = Server.MapPath("~/Images/");
                    txtVimage.SaveAs(path + "" + name);
                }
            }
            tblVehicle vehicle = new tblVehicle();
            vehicle.CompanyId = Convert.ToInt32(Session["CompanyId"]);
            vehicle.VehicleName = form["txtVname"];
            vehicle.RegNo = form["txtRno"];
            vehicle.DocumentImage = name.ToString();
            vehicle.Fuel = form["txtFuel"];
            vehicle.Capacity = form["txtCapacity"];
            vehicle.IsActive = true;
            vehicle.Image = vehiclename.ToString();
            dc.tblVehicles.Add(vehicle);
            dc.SaveChanges();
            return RedirectToAction("CompanyProfile", "ClientCompany", new { id = vehicle.CompanyId });
        }
    }
}


