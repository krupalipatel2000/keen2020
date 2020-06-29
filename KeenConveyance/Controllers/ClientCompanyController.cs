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
                ViewBag.Bids = (from ob in dc.tblBiddings where ob.CompanyId == com.CompanyId select ob).Count();
                var CompanyId = Convert.ToInt32(Session["CompanyId"]);
                var AcceptedBid = from obBid in dc.tblBiddings
                                  join obBook in dc.tblBookings on obBid.BidId equals obBook.BidId
                                  where obBid.CompanyId == CompanyId
                                   && obBook.VehicleId == null
                                  select obBid;
                ViewBag.Abid = AcceptedBid.ToList().Count;
                var consignment = from obBid in dc.tblBiddings
                                  join obBook in dc.tblBookings on obBid.BidId equals obBook.BidId
                                  where obBid.CompanyId == CompanyId
                                  // && obBook.VehicleId == null
                                  select obBid;
                ViewBag.Consignment = consignment.ToList();
                //var rate = (from ob in dc.tblReviews where ob.CompanyId == CompanyId select ob).SingleOrDefault().Rate;
                //ViewBag.Rate = rate.Average();
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
        public ActionResult ViewAconsignment(int id)
        {
            int CompanyID = Convert.ToInt32(Session["CompanyId"]);
            var Aconsignment = from obCon in dc.tblConsignments
                               join obBid in dc.tblBiddings on obCon.ConsignmentId equals obBid.ConsignmentId
                              join obBook in dc.tblBookings on obBid.BidId equals obBook.BidId
                              where obBid.CompanyId == CompanyID
                              // && obBook.VehicleId == null
                              select obCon;
            ViewBag.Aconsignment = Aconsignment;
            return View();
        }
        public ActionResult EditBook(int id)
        {
            int CompanyID = Convert.ToInt32(Session["CompanyId"]);
            tblBooking book = dc.tblBookings.SingleOrDefault(ob => ob.ConsignmentId == id);
            var drivers = from obDriver in dc.tblDrivers where obDriver.CompanyId == CompanyID select obDriver;
            var vehicles = from obVehicle in dc.tblVehicles where obVehicle.CompanyId == CompanyID select obVehicle;
            ViewBag.driver = new SelectList(drivers, "DriverId", "DriverName");
            ViewBag.vehicle = new SelectList(vehicles, "VehicleId", "VehicleName");
            return View(book);
        }
        [HttpPost]
        public ActionResult EditBook(FormCollection form,int id)
        {
            tblBooking book = dc.tblBookings.SingleOrDefault(ob => ob.ConsignmentId == id);
            book.VehicleId = Convert.ToInt32(form["ddVehicle"]);
            book.DriverId = Convert.ToInt32(form["ddDriver"]);
            book.DispatchDate = Convert.ToDateTime(form["txtDispatch"]);
            book.DeliveredDate = Convert.ToDateTime(form["txtDeliver"]);
            book.TotalPayment = Convert.ToInt32(form["txtPayment"]);
            book.PaymentMode = form["txtPaymentMode"];
            book.Remarks = form["txtRemark"];
            dc.SaveChanges();

            tblBidding bidding = dc.tblBiddings.SingleOrDefault(ob => ob.ConsignmentId == id);
            bidding.IsAssigned = true;
            dc.SaveChanges();
            return RedirectToAction("bill", "ClientCompany",new { id = book.BookingId });
        }
        public ActionResult Rate()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Rate(FormCollection form,int id)
        {

            tblReview rate = dc.tblReviews.SingleOrDefault(ob => ob.CompanyId == id);
            rate.UserId = Convert.ToInt32(Session["LogID"]);
            rate.CompanyId = id;
            rate.Review = form["txtReview"];
            rate.Rate=form["txtRate"];
            dc.tblReviews.Add(rate);
            dc.SaveChanges();
            return RedirectToAction("Index", "Home");
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
            //var vehicle = from ob in dc.tblVehicles
            //              join ob2 in dc.tblVehicleTypes on ob.VehicleTypeId equals ob2.VehicleTypeId
            //              select new JoinViewAll
            //              {
            //                  vehicle = ob,
            //                  vehicletype = ob2
            //              };
            //ViewBag.vehicle = vehicle;
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
            //vehicle.VehicleTypeId = Convert.ToInt32(form["vehicletype"]);
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
        public ActionResult AddService()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddService(FormCollection form, HttpPostedFileBase txtService)
        {
            string name = "txtService";
            if (txtService != null)
            {
                int size = (int)txtService.ContentLength / 1024;
                var extention = System.IO.Path.GetExtension(txtService.FileName);
                if (size <= 1024 && (extention.ToLower().Equals(".jpg") || extention.ToLower().Equals(".jpeg") || extention.ToLower().Equals(".png")))
                {
                    name = Code() + "" + extention;
                    string path = Server.MapPath("~/Images/");
                    txtService.SaveAs(path + "" + name);
                }
            }
            tblService service = new tblService();
            service.CompanyId = Convert.ToInt32(Session["CompanyId"]);
            service.ServiceName = form["txtSname"];
            service.ServiceDesc = form["txtSDesc"];
            service.ServiceImage = name.ToString();
            service.IsActive = false;
            service.CreatedOn = DateTime.Now;
            dc.tblServices.Add(service);
            dc.SaveChanges();
            return RedirectToAction("CompanyProfile", "ClientCompany", new { id = service.CompanyId });
        }
        public ActionResult AddBid(int id, int id1)
        {
            tblBooking book = new tblBooking();
            book.ConsignmentId = id;
            book.BidId = id1;
            //book.IsPaid = false;
            dc.tblBookings.Add(book);
            dc.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult bill(int id)
        {
            tblBill bill = dc.tblBills.SingleOrDefault(ob => ob.BookingId == id);
            return View(bill);
        }
        [HttpPost]
        public ActionResult bill(FormCollection form,int id)
        {
            var user = from ob in dc.tblBookings
                       join obCon in dc.tblConsignments on ob.ConsignmentId equals obCon.ConsignmentId
                       join obUser in dc.tblUsers on obCon.UserId equals obUser.UserId
                       select obUser;
            tblBill bill = new tblBill();
            bill.BookingId = id;
            bill.UserId = Convert.ToInt32(user.First().UserId);
            bill.Desc = form["txtDesc"];
            bill.Price = Convert.ToInt32(form["txtPrice"]);
            bill.TollTax = Convert.ToInt32(form["txtToll"]);
            bill.GST = (Convert.ToInt32(form["txtPrice"]) * 18) / 100;
            bill.TotalPrice = Convert.ToInt32(form["txtPrice"]) + Convert.ToInt32(form["txtToll"]) + (Convert.ToInt32(form["txtPrice"]) * 18) / 100;
            bill.CompanyId = Convert.ToInt32(Session["CompanyId"]);
            bill.CreatedOn = DateTime.Now;
            dc.tblBills.Add(bill);
            dc.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}


