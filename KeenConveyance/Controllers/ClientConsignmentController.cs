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
        public ActionResult Insert(FormCollection form, HttpPostedFileBase txtFile)
        {
            tblConsignment con = new tblConsignment();
            con.DispatchDate = Convert.ToDateTime(form["txtDate"]);
            //con.ProfilePic = name.ToString();
            con.UnitType = form["unittype"];
            con.UnitValue = Convert.ToInt32(form["txtValue"]);
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
            dc.tblConsignments.Add(con);
            dc.SaveChanges();
            int LastID = (from ob in dc.tblConsignments orderby ob.ConsignmentId descending select ob).Take(1).SingleOrDefault().ConsignmentId;
            Session["LastID"] = LastID;
            string name = "txtFile";
            if (txtFile != null)
            {
                int size = (int)txtFile.ContentLength / 1024;
                var extention = System.IO.Path.GetExtension(txtFile.FileName);
                if (size <= 1024 && (extention.ToLower().Equals(".jpg") || extention.ToLower().Equals(".jpeg") || extention.ToLower().Equals(".png")))
                {
                    name = code() + "" + extention;
                    string path = Server.MapPath("~/Images/");
                    txtFile.SaveAs(path + "" + name);
                    tblConSignmentImage img = new tblConSignmentImage();
                    img.ConsignmentID = LastID;
                    img.ImageURL = name;
                    img.IsActive = true;
                    dc.tblConSignmentImages.Add(img);

                }
                dc.SaveChanges();
            }

            return RedirectToAction("Insert2", "ClientConsignment");
        }
        public ActionResult Insert2()
        {
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
        public ActionResult Insert3(FormCollection form,string addtype)
        {
            tblAddress fromplace = new tblAddress();
            if(addtype=="H")
            { 
            fromplace.AddressType = form["addtype"];
            }
            else
            {
                fromplace.AddressType = form["addtype"];
            }
            fromplace.HouseNo = form["txtHouseNo"];
            fromplace.Landmark = form["txtLandmark"];
            fromplace.Area = form["txtArea"];
            fromplace.Address = form["txtAddress"];
            fromplace.CityId = Convert.ToInt32(form["ddCity"]);
            fromplace.Zipcode = form["txtZip"];
            dc.tblAddresses.Add(fromplace);
            dc.SaveChanges();
            int LastFromAddressID = (from ob in dc.tblAddresses orderby ob.AddressId descending select ob).Take(1).SingleOrDefault().AddressId;


            tblAddress toplace = new tblAddress();
            if (addtype == "H")
            {
                toplace.AddressType = form["addtype"];
            }
            else
            {
                toplace.AddressType = form["addtype"];
            }
            toplace.HouseNo = form["txttoHouseNo"];
            toplace.Landmark = form["txttoLandmark"];
            toplace.Area = form["txttoArea"];
            toplace.Address = form["txttoAddress"];
            toplace.CityId = Convert.ToInt32(form["ddtoCity"]);
            toplace.Zipcode = form["txttoZip"];
            dc.tblAddresses.Add(toplace);
            dc.SaveChanges();
            int LastToAddressID = (from ob in dc.tblAddresses orderby ob.AddressId descending select ob).Take(1).SingleOrDefault().AddressId;

            tblConsignment con = dc.tblConsignments.SingleOrDefault(ob => ob.ConsignmentId == Convert.ToInt32(Session["LastID"]));
            con.SourceId = LastFromAddressID;
            con.DestinationId = LastToAddressID;
            dc.SaveChanges();

            return View();
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
    }
}