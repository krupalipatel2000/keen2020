using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KeenConveyance.Areas.Admin.Models;

namespace KeenConveyance.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin/Admin
        dbTransportEntities3 dc = new dbTransportEntities3();
        public ActionResult Index()
        {
            Session.Clear();
            return View();
        }
        
        [HttpPost]
        public ActionResult Index(string txtEmail,string txtPwd)
        {
            tblAdmin ad = (from ob in dc.tblAdmins where ob.EmailId == txtEmail && ob.Password == txtPwd select ob).Take(1).SingleOrDefault();
            if (ad != null)
            {
                Session["loginId"] = ad.Name;
                Session["LogID"] = ad.AdminId;
                if (ad.IsSuper == true)
                {
                    Session["AdminType"] = "Super";
                    return RedirectToAction("Dashboard", "Admin");
                }
                else
                {
                    //Session["AdminType"] = "Sub";
                    return RedirectToAction("Index", "User");
                }
             
            }
            else
            {
                return RedirectToAction("Dashboard", "Admin");
            }
        }
        public ActionResult Blank()
        {
            return View();
        }
        public ActionResult List()
        {
            if (Session["loginId"] != null)
            {
                var admin = dc.tblAdmins.ToList();
                return View(admin);
            }
            else
            {
                return RedirectToAction("Index","Admin");
            }
        }
        public ActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insert(FormCollection form)
        {
            tblAdmin ad = new tblAdmin();
            ad.Name = form["txtName"];
            ad.EmailId = form["txtEmail"];
            ad.Password = form["txtPwd"];
            ad.ContactNo = form["txtCno"];
            ad.IsActive = true;
            ad.CreatedOn = DateTime.Now;
            ad.CreatedBy = Convert.ToInt32(Session["LogID"]);
            ad.IsSuper = false;
            ad.IsInsert = true;
            ad.IsEdit = true;
            ad.IsDelete = true;
            dc.tblAdmins.Add(ad);
            dc.SaveChanges();
            return RedirectToAction("List");
        }
        [HttpPost]
        public JsonResult Active(int id)
        {
            tblAdmin ad = dc.tblAdmins.SingleOrDefault(ob => ob.AdminId == id);
            if (ad.IsActive == true)
            {
                ad.IsActive = false;
            }
            else
            {
                ad.IsActive = true;
            }
            dc.SaveChanges();
            return Json(ad.IsActive, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Edit(int id)
        {
            TempData["id"] = id;
            tblAdmin ad = dc.tblAdmins.SingleOrDefault(ob => ob.AdminId == id);
            return View(ad);
        }
        [HttpPost]
        public ActionResult Edit(FormCollection form)
        {
            int id = Convert.ToInt32(TempData["id"]);
            tblAdmin ad = dc.tblAdmins.SingleOrDefault(ob => ob.AdminId == id);
            ad.Name = form["txtName"];
            ad.EmailId = form["txtEmail"];
            ad.ContactNo = form["txtCno"];
           // ad.ImageUrl = form["txtFile"];
            dc.SaveChanges();
            return RedirectToAction("List");
        }
        public ActionResult Delete(int id)
        {
            tblAdmin ad = dc.tblAdmins.SingleOrDefault(ob => ob.AdminId == id);
            dc.tblAdmins.Remove(ad);
            dc.SaveChanges();
            return RedirectToAction("List","Admin");
        }
        public ActionResult Detail(int id)
        {
            tblAdmin ad = dc.tblAdmins.SingleOrDefault(ob => ob.AdminId == id);
            ViewBag.AdminName = (from ob in dc.tblAdmins where ob.AdminId == ad.CreatedBy select ob).Take(1).SingleOrDefault().Name;
            string Name = ViewBag.AdminName;
            return View(ad);
        }
        [HttpPost]
        public JsonResult CheckEmail(string id)
        {
            string response;
            tblAdmin admin = dc.tblAdmins.SingleOrDefault(ob => ob.EmailId == id);
            if (admin != null)
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
        public ActionResult Dashboard()
        {
            ViewBag.UserCount = (from ob in dc.tblUsers select ob).ToList().Count().ToString();
            ViewBag.CompanyCount = (from ob in dc.tblTransportCompanies where ob.IsActive == true select ob).ToList().Count().ToString();
            ViewBag.BiddingCount = (from ob in dc.tblBiddings select ob).ToList().Count().ToString();
            ViewBag.ConCount = (from ob in dc.tblConsignments select ob).ToList().Count().ToString();

            return View();
        }
        public ActionResult SampleChart()
        {
            //ViewBag.Y = new List<int>() { 10, 24, 23, 47, 50, 36, 27, 18 };
            //ViewBag.X = new List<string>() { "A", "B", "C", "D", "E", "F", "G", "H" };

            var consignment = from ob in dc.tblConsignments select ob;
            string[] X = new string[consignment.ToList().Count];
            int[] Y = new int[consignment.ToList().Count];
            int i = 0;
            foreach (tblConsignment u in consignment)
            {
                X[i] = u.ConsignmentId.ToString();
                Y[i] = (from ob in dc.tblBiddings where ob.ConsignmentId == u.ConsignmentId select ob).ToList().Count;
                i++;
            }
            ViewBag.X = X;
            ViewBag.Y = Y;

            return View();
        }
        public ActionResult UserChart()
        {
            //ViewBag.Y = new List<int>() { 10, 24, 23, 47, 50, 36, 27, 18 };
            //ViewBag.X = new List<int>() {1,2,3,4,5,6,7,8,9,10,11,12};

            var user = from ob in dc.tblUsers select ob;
            int[] X = new int[] {1,2,3,4,5,6,7,8,9,10,11,12 };
            int[] Y = new int[12];
            int i = 0;
            foreach (tblUser u in user)
            {
                i++;
                
                Y[i] = (from ob in dc.tblUsers where ob.CreatedOn.Month == i select ob).ToList().Count;
                
            }
            ViewBag.X = X;
            ViewBag.Y = Y;

            return View();
        }
        public ActionResult CompanyChart()
        {
            //ViewBag.Y = new List<int>() { 10, 24, 23, 47, 50, 36, 27, 18 };
            //ViewBag.X = new List<int>() {1,2,3,4,5,6,7,8,9,10,11,12};

            var company = from ob in dc.tblTransportCompanies select ob;
            int[] X = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            int[] Y = new int[12];
            int i = 0;
            foreach (tblTransportCompany u in company)
            {
                i++;

                Y[i] = (from ob in dc.tblTransportCompanies where ob.CreatedOn.Month == i select ob).ToList().Count;

            }
            ViewBag.X = X;
            ViewBag.Y = Y;

            return View();
        }
    }
}