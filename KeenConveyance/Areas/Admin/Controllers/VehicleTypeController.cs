using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KeenConveyance.Areas.Admin.Models;

namespace KeenConveyance.Areas.Admin.Controllers
{
    public class VehicleTypeController : Controller
    {
        // GET: Admin/VehicleType
        dbTransportEntities4 dc = new dbTransportEntities4();
        public ActionResult Index()
        {
            var type = dc.tblVehicleTypes.ToList();
            return View(type);
        }
        public ActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insert(FormCollection form,HttpPostedFileBase txtImage)
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
            tblVehicleType type = new tblVehicleType();
            type.TypeName = form["txtname"];
            //type.TypeImage = form["txtImage"];
            type.TypeImage = name.ToString();
            type.CreatedBy = Convert.ToInt32(Session["LogID"]);
            type.CreatedOn = DateTime.Now;

            dc.tblVehicleTypes.Add(type);
            dc.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public JsonResult CheckType(string id)
        {
            string response;
            tblVehicleType vehicle = dc.tblVehicleTypes.SingleOrDefault(ob => ob.TypeName == id);
            if (vehicle != null)
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
            tblVehicleType type = dc.tblVehicleTypes.SingleOrDefault(ob => ob.VehicleTypeId == id);
            return View(type);
        }
        [HttpPost]
        public ActionResult Edit(FormCollection form,HttpPostedFileBase txtImage)
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

            int id = Convert.ToInt32(TempData["id"]);
            tblVehicleType type = dc.tblVehicleTypes.SingleOrDefault(ob => ob.VehicleTypeId == id);
            type.TypeName = form["txtname"];
            type.TypeImage = name.ToString();
            dc.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            tblVehicleType type = dc.tblVehicleTypes.SingleOrDefault(ob => ob.VehicleTypeId == id);
            dc.tblVehicleTypes.Remove(type);
            dc.SaveChanges();
            return RedirectToAction("Index", "VehicleType");
        }
        public string Code()
        {
            string code = DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss-ff").Replace("-", "");
            return code;
        }
    }
}