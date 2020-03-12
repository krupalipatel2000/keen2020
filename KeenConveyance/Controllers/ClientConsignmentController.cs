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
            //string name = "txtFile";
            //if (txtFile != null)
            //{
            //    int size = (int)txtFile.ContentLength / 1024;
            //    var extention = System.IO.Path.GetExtension(txtFile.FileName);
            //    if (size <= 1024 && (extention.ToLower().Equals(".jpg") || extention.ToLower().Equals(".jpeg") || extention.ToLower().Equals(".png")))
            //    {
            //        name = code() + "" + extention;
            //        string path = Server.MapPath("~/Images/");
            //        txtFile.SaveAs(path + "" + name);
            //    }
            //}
            //tblConsignment con = new tblConsignment();
            
            return RedirectToAction("Insert2", "ClientConsignment");
        }
        public ActionResult Insert2()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insert2(FormCollection form)
        {
            tblConsignment con = new tblConsignment();
            con.Budget = Convert.ToInt32(form["txtBudget"]);
            con.MinBidValue = Convert.ToInt32(form["txtminbidvalue"]);
            con.MaxBidValue = Convert.ToInt32(form["txtmaxbidvalue"]);
            con.MinTime = form["txtmintime"];
            con.MinBidValue = Convert.ToInt32(form["txtBudget"]);
            return RedirectToAction("Insert3", "ClientConsignment");
        }
        public ActionResult Insert3()
        {
            var country = dc.CountryMasters;
            ViewBag.Country = new SelectList(country, "ID", "Name");

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
        [HttpPost]
        public ActionResult Insert3(FormCollection form)
        {
            return View();
        }
        public string code()
        {
            string code = DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss-ff").Replace("-", "");
            return code;
        }
    }
}