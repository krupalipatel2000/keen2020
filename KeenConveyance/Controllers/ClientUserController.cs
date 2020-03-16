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
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult UserProfile(int id)
        {
            if (id != 0)
            {
                tblUser user = dc.tblUsers.SingleOrDefault(ob => ob.UserId == id);
                ViewBag.con = (from ob in dc.tblConsignments where ob.UserId == user.UserId select ob);
                ViewBag.conId = (from ob in dc.tblConsignments where ob.UserId == user.UserId select ob).Take(1).SingleOrDefault().ConsignmentId;
                ViewBag.House = (from ob in dc.tblAddresses where ob.UserId == user.UserId select ob).Take(1).SingleOrDefault().HouseNo;
                ViewBag.Landmark = (from ob in dc.tblAddresses where ob.UserId == user.UserId select ob).Take(1).SingleOrDefault().Landmark;
                ViewBag.Area = (from ob in dc.tblAddresses where ob.UserId == user.UserId select ob).Take(1).SingleOrDefault().Area;
                ViewBag.Source = (from ob in dc.tblAddresses where ob.UserId == user.UserId select ob).Take(1).SingleOrDefault().Address;
                ViewBag.Destination = (from ob in dc.tblAddresses where ob.UserId == user.UserId select ob).Take(1).SingleOrDefault().Address;
                ViewBag.Distance = (from ob in dc.tblConsignments where ob.UserId == user.UserId select ob).Take(1).SingleOrDefault().Distance;
                //ViewBag.TotalBid = (from ob in dc.tblBiddings where ob.ConsignmentId ==  where ob.ConsignmentId
                ViewBag.Year = user.CreatedOn.Year.ToString();
                return View(user);
            }
            else
            {
                return RedirectToAction("Login","Home");
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
            return RedirectToAction("UserProfile",new {  id = user.UserId });
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
        
    }

}