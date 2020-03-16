using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KeenConveyance.Areas.Admin.Models;

namespace KeenConveyance.Controllers
{
    public class ClientConsignmentController : Controller
    {
        // GET: ClientConsignment
        dbTransportEntities5 dc = new dbTransportEntities5();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insert(FormCollection form, HttpPostedFileBase[] txtFile)
        {
            tblConsignment con = new tblConsignment();
            con.DispatchDate = Convert.ToDateTime(form["txtDate"]);
            //con.ProfilePic = name.ToString();
            con.UnitType = form["unittype"];
            con.UnitValue = Convert.ToInt32(form["txtValue"]);
            string val = form["chkflame"];
            if (form["chkflame"] == "on")
            {
                con.IsFlamable = true;
            }
            if (form["chkdelicate"] == "on")
            {
                con.IsDelicate = true;
            }
            if (form["chkrefregerated"] == "on")
            {
                con.IsRefregreted = true;
            }
            con.Distance = form["txtDistance"];
            dc.tblConsignments.Add(con);
            dc.SaveChanges();
            int LastID = (from ob in dc.tblConsignments orderby ob.ConsignmentId descending select ob).Take(1).SingleOrDefault().ConsignmentId;
            Session["LastID"] = LastID;
            string name = "txtFile";
            if (txtFile != null)
            {
                foreach (HttpPostedFileBase file in txtFile)
                {
                    int size = (int)file.ContentLength / 1024;
                    var extention = System.IO.Path.GetExtension(file.FileName);
                    if (size <= 1024 && (extention.ToLower().Equals(".jpg") || extention.ToLower().Equals(".jpeg") || extention.ToLower().Equals(".png")))
                    {
                        name = code() + "" + extention;
                        string path = Server.MapPath("~/Images/");
                        file.SaveAs(path + "" + name);
                        tblConSignmentImage img = new tblConSignmentImage();
                        img.ConsignmentID = LastID;
                        img.ImageURL = name;
                        img.IsActive = true;
                        dc.tblConSignmentImages.Add(img);
                    }
                }
                dc.SaveChanges();
            }

            return RedirectToAction("Insert2", "ClientConsignment");
        }
        public ActionResult Insert2()
        {
            int ConID = Convert.ToInt32(Session["LastID"]);
            tblConsignment CurrentCon = dc.tblConsignments.SingleOrDefault(ob => ob.ConsignmentId == ConID);
            int distance = Convert.ToInt32(CurrentCon.Distance);
            var tblPricelist = from ob in dc.tblPriceLists where ob.UnitName == CurrentCon.UnitType || ob.UnitName == "KM" select ob;
            double AvgDistancePrice = (from ob in tblPricelist where ob.UnitName == "KM" && ob.MinValue <= distance && ob.MaxValue >= distance select ob).Average(ob=> ob.PricePerUnit);
            double AvgUnitPrice = (from ob in tblPricelist where ob.UnitName == CurrentCon.UnitType select ob).Average(ob => ob.PricePerUnit);
            double MaxDistancePrice = AvgDistancePrice * Convert.ToInt32(CurrentCon.Distance);
            double MaxUnitPrice = AvgUnitPrice * Convert.ToInt32(CurrentCon.UnitValue);
            double CalculatedValue = MaxDistancePrice + MaxUnitPrice;
            ViewBag.Budget = CalculatedValue;
            return View();
        }
        [HttpPost]
        public ActionResult Insert2(FormCollection form)
        {
            int LId = Convert.ToInt32(Session["LastID"]);
            tblConsignment con = dc.tblConsignments.SingleOrDefault(ob => ob.ConsignmentId == LId);
            con.Budget = Convert.ToInt32(form["txtBudget"]);
            con.MinBidValue = Convert.ToInt32(form["txtminbidvalue"]);
            con.MaxBidValue = Convert.ToInt32(form["txtmaxbidvalue"]);
            con.MinTime = form["txtmintime"];
            con.MaxTime = form["txtmaxtime"];
            con.ReceiverName = form["txtName"];
            con.ReceiverContactNo = form["txtCno"];
            con.ReceiverPinNo = Convert.ToInt32(form["txtPin"]);
            dc.SaveChanges();
            return RedirectToAction("Insert3", "ClientConsignment");
        }
        public ActionResult Insert3()
        {
            var country = dc.CountryMasters;
            ViewBag.Country = new SelectList(country, "ID", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Insert3(FormCollection form)
        {
            
            tblAddress fromplace = new tblAddress();
            fromplace.AddressType = form["addtype"];
            fromplace.HouseNo = form["txtHouseNo"];
            fromplace.Landmark = form["txtLandmark"];
            fromplace.Area = form["txtArea"];
            fromplace.UserId = Convert.ToInt32(Session["LogID"]);
            fromplace.Address = form["txtAddress"];
            fromplace.CityId = Convert.ToInt32(form["ddCity"]);
            fromplace.Zipcode = form["txtZip"];
            
            dc.tblAddresses.Add(fromplace);
            dc.SaveChanges();
            int LastFromAddressID = (from ob in dc.tblAddresses orderby ob.AddressId descending select ob).Take(1).SingleOrDefault().AddressId;

            tblAddress toplace = new tblAddress();
            toplace.AddressType = form["addtype"];
            toplace.HouseNo = form["txttoHouseNo"];
            toplace.Landmark = form["txttoLandmark"];
            toplace.Area = form["txttoArea"];
            toplace.UserId = Convert.ToInt32(Session["LogID"]);
            toplace.Address = form["txttoAddress"];
            toplace.CityId = Convert.ToInt32(form["ddtoCity"]);
            toplace.Zipcode = form["txttoZip"];
            dc.tblAddresses.Add(toplace);
            dc.SaveChanges();
            int LastToAddressID = (from ob in dc.tblAddresses orderby ob.AddressId descending select ob).Take(1).SingleOrDefault().AddressId;

            int LastID = Convert.ToInt32(Session["LastID"]);
            tblConsignment con = dc.tblConsignments.SingleOrDefault(ob => ob.ConsignmentId == LastID);
            con.SourceId = LastFromAddressID;
            con.DestinationId = LastToAddressID;
            dc.SaveChanges();

            return RedirectToAction("Blank", "Home");
        }
        [HttpPost]
        public JsonResult GetState(int cid)
        {
            var State = from ob in dc.StateMasters where ob.CountryID == cid select ob;
            SelectList statelist = new SelectList(State, "ID", "Name");
            return Json(statelist, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]

        public JsonResult GetCity(int sid)
        {
            var City = from ob in dc.CityMasters where ob.StateID == sid select ob;
            SelectList citylist = new SelectList(City, "ID", "Name");
            return Json(citylist, JsonRequestBehavior.AllowGet);
        }

        public string code()
        {
            string code = DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss-ff").Replace("-", "");
            return code;
        }
        public ActionResult ViewCon(int id)
        {
            tblConsignment con = dc.tblConsignments.SingleOrDefault(ob => ob.ConsignmentId == id);
            ViewBag.User = (from ob in dc.tblUsers where ob.UserId == con.UserId select ob).Take(1).SingleOrDefault().FirstName;
            ViewBag.House = (from ob in dc.tblAddresses where ob.AddressId == con.SourceId select ob).Take(1).SingleOrDefault().HouseNo;
            ViewBag.Landmark = (from ob in dc.tblAddresses where ob.AddressId == con.SourceId select ob).Take(1).SingleOrDefault().Landmark;
            ViewBag.Area = (from ob in dc.tblAddresses where ob.AddressId == con.SourceId select ob).Take(1).SingleOrDefault().Area;
            ViewBag.Source = (from ob in dc.tblAddresses where ob.AddressId == con.SourceId select ob).Take(1).SingleOrDefault().Address;
            ViewBag.Destination = (from ob in dc.tblAddresses where ob.AddressId == con.DestinationId select ob).Take(1).SingleOrDefault().Address;
            ViewBag.ConsignmentImage = from ob in dc.tblConSignmentImages where ob.ConsignmentID == id select ob;
            return View(con);
        }
        public ActionResult List(int id)
        {
            if (Session["LogID"] != null)
            {
                int Uid = Convert.ToInt32(Session["LogID"]);
                var con = from ob in dc.tblConsignments where ob.UserId == Uid select ob;//dc.tblConsignments.SingleOrDefault(ob => ob.ConsignmentId == id);
                ViewBag.UserDetail = from ob in dc.tblUsers where ob.UserId == Uid select ob;
                //var consignment = dc.tblConsignments.ToList();
                return View(con);
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public JsonResult Active(int id)
        {
            tblConsignment consignment = dc.tblConsignments.SingleOrDefault(ob => ob.ConsignmentId == id);
            if (consignment.IsActive == true)
            {
                consignment.IsActive = false;
            }
            else
            {
                consignment.IsActive = true;
            }
            dc.SaveChanges();
            return Json(consignment.IsActive, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ComList()
        {
            var consignment = dc.tblConsignments.ToList();
            return View(consignment);
        }
        public ActionResult ComConsignment(int id)
        {
            tblConsignment con = dc.tblConsignments.SingleOrDefault(ob => ob.ConsignmentId == id);
            ViewBag.User = (from ob in dc.tblUsers where ob.UserId == con.UserId select ob).Take(1).SingleOrDefault().FirstName;
            ViewBag.House = (from ob in dc.tblAddresses where ob.AddressId == con.SourceId select ob).Take(1).SingleOrDefault().HouseNo;
            ViewBag.Landmark = (from ob in dc.tblAddresses where ob.AddressId == con.SourceId select ob).Take(1).SingleOrDefault().Landmark;
            ViewBag.Area = (from ob in dc.tblAddresses where ob.AddressId == con.SourceId select ob).Take(1).SingleOrDefault().Area;
            ViewBag.Source = (from ob in dc.tblAddresses where ob.AddressId == con.SourceId select ob).Take(1).SingleOrDefault().Address;
            ViewBag.Destination = (from ob in dc.tblAddresses where ob.AddressId == con.DestinationId select ob).Take(1).SingleOrDefault().Address;
            ViewBag.ConsignmentImage = from ob in dc.tblConSignmentImages where ob.ConsignmentID == id select ob;
            return View(con);
        }
        [HttpPost]
        public ActionResult ComConsignment(FormCollection form)
        {
            int LastID = Convert.ToInt32(Session["LastID"]);
            tblBidding bid= new tblBidding();
            bid.CompanyId = Convert.ToInt32(Session["CompanyId"]);
            bid.ConsignmentId= Convert.ToInt32(Session["LastID"]);
            bid.BidAmount = Convert.ToInt32(form["txtBidAmount"]);
            bid.BidOn = DateTime.Now;
            bid.EstimatedDelivery = form["txtBidTime"];
            bid.IsModified = false;
            //bid.ModifiedOn = DateTime.Now;
            bid.IsAssigned = true;
            dc.tblBiddings.Add(bid);
            dc.SaveChanges();
            return RedirectToAction("Blank","Home");
        }
        public ActionResult EditAdd(int id)
        {
            TempData["id"] = id;
            tblAddress add = dc.tblAddresses.SingleOrDefault(ob => ob.AddressId == id);
            return View(add);
        }
        [HttpPost]
        public ActionResult EditAdd(FormCollection form)
        {
            int id = Convert.ToInt32(TempData["id"]);
            tblAddress add = dc.tblAddresses.SingleOrDefault(ob => ob.AddressId == id);
            add.AddressType = form["txtAddressType"];
            add.HouseNo = form["txtHouseNo"];
            //user.ProfilePic = form["txtprofile"];
            add.Landmark = form["txtLandMark"];
            add.Area = form["txtArea"];
            add.Address = form["txtAddress"];
            add.Address = form["txtCityId"];
            add.Zipcode = form["txtZipCode"];
            add.MapURL = form["txtMapURL"];
            dc.SaveChanges();
            return RedirectToAction("ViewCon","ClientConsignment", new { id = add.AddressId});
        }


    }
}