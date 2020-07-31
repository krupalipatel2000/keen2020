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
        dbTransportEntities5 dc = new dbTransportEntities5();
        public ActionResult Index(int id)
        {
            if (id != 0)
            {
                tblUser user = dc.tblUsers.SingleOrDefault(ob => ob.UserId == id);
                ViewBag.Year = user.CreatedOn.Year.ToString();

                return View(user);
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }
        public ActionResult UserConsignment(int id)
        {
            tblUser user = dc.tblUsers.SingleOrDefault(ob => ob.UserId == id);
            ViewBag.con = (from ob in dc.tblConsignments where ob.UserId == user.UserId select ob);
            ViewBag.conId = (from ob in dc.tblConsignments where ob.UserId == user.UserId select ob).Take(1).SingleOrDefault().ConsignmentId;
            return View();
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
            return RedirectToAction("Login", "Home");
        }
        [HttpPost]
        public JsonResult checkEmail(string id)
        {
            string response;
            tblUser user = dc.tblUsers.SingleOrDefault(ob => ob.EmailId == id);
            if (user != null)
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

        public ActionResult Edit(int id)
        {
            TempData["id"] = id;
            tblUser user = dc.tblUsers.SingleOrDefault(ob => ob.UserId == id);
            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(FormCollection form)
        {
            int id = Convert.ToInt32(TempData["id"]);
            tblUser user = dc.tblUsers.SingleOrDefault(ob => ob.UserId == id);
            user.FirstName = form["txtFirstName"];
            user.LastName = form["txtLastName"];
            //user.ProfilePic = form["txtprofile"];
            user.EmailId = form["txtEmailId"];
            user.Gender = form["gender"];
            user.ContactNo = form["txtCno"];
            user.IsActive = false;
            user.CreatedOn = DateTime.Now;
            user.IsVerified = false;
            user.IsMobileVerified = false;
            dc.SaveChanges();
            return RedirectToAction("UserProfile", new { id = user.UserId });
        }

        //public ActionResult List()
        //{
        //    var user = dc.tblUsers.ToList();
        //    return View(user);
        //}
        //[HttpPost]
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
        [HttpPost]
        public ActionResult UploadImage(HttpPostedFileBase profimg)
        {
            int ID = Convert.ToInt32(Session["LogID"]);
            tblUser user = dc.tblUsers.SingleOrDefault(ob => ob.UserId == ID);
            user.ProfilePic = profimg.FileName;
            dc.SaveChanges();
            //string newImage = profimg.FileName;
            string path = Server.MapPath("~/Images/");
            profimg.SaveAs(path + profimg.FileName);
            return View();
        }
        public ActionResult ViewCom(int id)
        {
            tblTransportCompany com = dc.tblTransportCompanies.SingleOrDefault(ob => ob.CompanyId == id);
            //ViewBag.House = (from ob in dc.tblAddresses where ob.CompanyId == com.CompanyId select ob).Take(1).SingleOrDefault().HouseNo;
            //ViewBag.Landmark = (from ob in dc.tblAddresses where ob.CompanyId == com.CompanyId select ob).Take(1).SingleOrDefault().Landmark;
            //ViewBag.Area = (from ob in dc.tblAddresses where ob.CompanyId == com.CompanyId select ob).Take(1).SingleOrDefault().Area;
            //ViewBag.Address = (from ob in dc.tblAddresses where ob.CompanyId == com.CompanyId select ob).Take(1).SingleOrDefault().Address;
            //ViewBag.Year = com.CreatedOn.Year.ToString();
            //var PL = from ob in dc.tblPriceLists where ob.CompanyId == com.CompanyId select ob;
            //var Address = from ob in dc.tblAddresses where ob.CompanyId == com.CompanyId select ob;
            //var Bid = from ob in dc.tblBiddings where ob.CompanyId == com.CompanyId select ob;
            //ViewBag.Bids = (from ob in dc.tblBiddings where ob.CompanyId == com.CompanyId select ob).Count();
            //var CompanyId = Convert.ToInt32(Session["CompanyId"]);
            //var AcceptedBid = from obBid in dc.tblBiddings
            //                  join obBook in dc.tblBookings on obBid.BidId equals obBook.BidId
            //                  where obBid.CompanyId == CompanyId
            //                   && obBook.VehicleId == null
            //                  select obBid;
            //ViewBag.Abid = AcceptedBid.ToList().Count;
            //var consignment = from obBid in dc.tblBiddings
            //                  join obBook in dc.tblBookings on obBid.BidId equals obBook.BidId
            //                  where obBid.CompanyId == CompanyId
            //                  // && obBook.VehicleId == null
            //                  select obBid;
            //ViewBag.Consignment = consignment.ToList();
            //var rate = from ob in dc.tblReviews
            //           join obUser in dc.tblUsers on ob.UserId equals obUser.UserId
            //           where ob.CompanyId == com.CompanyId
            //           select ob;
            //ViewBag.Rate = rate;
            //var user = (from ob in dc.tblUsers
            //            join obRate in dc.tblReviews on ob.UserId equals obRate.UserId
            //            where obRate.CompanyId == com.CompanyId
            //            select ob).Take(1).SingleOrDefault().FirstName;
            //ViewBag.User = user;
            //ViewBag.PriceList = PL;
            //ViewBag.address = Address;
            //ViewBag.bid = Bid;
            return View(com);
        }
        public ActionResult CompanyDetail(int id)
        {
            tblTransportCompany com = dc.tblTransportCompanies.SingleOrDefault(ob => ob.CompanyId == id);
            ViewBag.Year = com.CreatedOn.Year.ToString();
            //var PL = from ob in dc.tblPriceLists where ob.CompanyId == com.CompanyId select ob;
            var Address = from ob in dc.tblAddresses where ob.CompanyId == com.CompanyId select ob;
            
            //ViewBag.Bids = (from ob in dc.tblBiddings where ob.CompanyId == com.CompanyId select ob).Count();
            //var CompanyId = Convert.ToInt32(Session["CompanyId"]);
            //var AcceptedBid = from obBid in dc.tblBiddings
            //                  join obBook in dc.tblBookings on obBid.BidId equals obBook.BidId
            //                  where obBid.CompanyId == CompanyId
            //                   && obBook.VehicleId == null
            //                  select obBid;
            //ViewBag.Abid = AcceptedBid.ToList().Count;
            //var consignment = from obBid in dc.tblBiddings
            //                  join obBook in dc.tblBookings on obBid.BidId equals obBook.BidId
            //                  where obBid.CompanyId == CompanyId
            //                  // && obBook.VehicleId == null
            //                  select obBid;
            //ViewBag.Consignment = consignment.ToList();
            //var rate = from ob in dc.tblReviews
            //           join obUser in dc.tblUsers on ob.UserId equals obUser.UserId
            //           where ob.CompanyId == com.CompanyId
            //           select ob;
            //ViewBag.Rate = rate;
            //var user = (from ob in dc.tblUsers
            //            join obRate in dc.tblReviews on ob.UserId equals obRate.UserId
            //            where obRate.CompanyId == com.CompanyId
            //            select ob).Take(1).SingleOrDefault().FirstName;
            //ViewBag.User = user;
            //ViewBag.PriceList = PL;
            ViewBag.address = Address;
            return View(com);
        }
        public ActionResult PriceList(int id)
        {
            tblTransportCompany com = dc.tblTransportCompanies.SingleOrDefault(ob => ob.CompanyId == id);
            var PL = from ob in dc.tblPriceLists where ob.CompanyId == com.CompanyId select ob;
            ViewBag.PriceList = PL;
            return View(com);
        }
        public ActionResult ComBid(int id)
        {
            tblTransportCompany com = dc.tblTransportCompanies.SingleOrDefault(ob => ob.CompanyId == id);
            var user = Convert.ToInt32(Session["LogID"]);
            var Bid = from ob in dc.tblUsers
                      join obCon in dc.tblConsignments on ob.UserId equals obCon.UserId
                      join obBid in dc.tblBiddings on obCon.ConsignmentId equals obBid.ConsignmentId
                      where ob.UserId == user
                      select new JoinViewAll
                      {
                          user = ob,
                          consignment = obCon,
                          bid = obBid
                      };
            ViewBag.bid = Bid;
            return View(com);
        }
        public ActionResult ViewBill(int id)
        {
            tblConsignment con = dc.tblConsignments.SingleOrDefault(ob => ob.ConsignmentId == id);
            ViewBag.UserName = (from ob in dc.tblUsers where ob.UserId == con.UserId select ob).Take(1).SingleOrDefault().FirstName;
            string Name = ViewBag.UserName;
            
            tblBidding bid = dc.tblBiddings.SingleOrDefault(ob => ob.ConsignmentId == con.ConsignmentId);
            tblBooking book = dc.tblBookings.SingleOrDefault(ob => ob.BidId == bid.BidId);
            ViewBag.Company = (from ob in dc.tblTransportCompanies where ob.CompanyId == bid.CompanyId select ob).Take(1).SingleOrDefault().CompanyName;
            ViewBag.Weburl = (from ob in dc.tblTransportCompanies where ob.CompanyId == bid.CompanyId select ob).Take(1).SingleOrDefault().WebURL;
            ViewBag.Contact = (from ob in dc.tblTransportCompanies where ob.CompanyId == bid.CompanyId select ob).Take(1).SingleOrDefault().ContactPersonNo;
            ViewBag.Desc = (from ob in dc.tblBills where ob.BookingId == book.BookingId select ob).Take(1).SingleOrDefault().Desc;
            ViewBag.Price = (from ob in dc.tblBills where ob.BookingId == book.BookingId select ob).Take(1).SingleOrDefault().Price;
            ViewBag.Tolltax = (from ob in dc.tblBills where ob.BookingId == book.BookingId select ob).Take(1).SingleOrDefault().TollTax;
            ViewBag.GST = (from ob in dc.tblBills where ob.BookingId == book.BookingId select ob).Take(1).SingleOrDefault().GST;
            ViewBag.TotalPrice = (from ob in dc.tblBills where ob.BookingId == book.BookingId select ob).Take(1).SingleOrDefault().TotalPrice;
            string Company = ViewBag.Company;
            string weburl = ViewBag.Weburl;
            string cno = ViewBag.Contact;
            return View(con);
        }
    }

}