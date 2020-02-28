﻿using System;
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
        dbTransportEntities3 dc = new dbTransportEntities3();
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
        public ActionResult Insert(FormCollection form)
        {
            tblVehicleType type = new tblVehicleType();
            type.TypeName = form["txtname"];
            type.TypeImage = form["txtImage"];
            type.CreatedBy = Convert.ToInt32(Session["LogID"]);
            type.CreatedOn = DateTime.Now;
            dc.tblVehicleTypes.Add(type);
            dc.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            TempData["id"] = id;
            tblVehicleType type = dc.tblVehicleTypes.SingleOrDefault(ob => ob.VehicleTypeId == id);
            return View(type);
        }
        [HttpPost]
        public ActionResult Edit(FormCollection form)
        {
            int id = Convert.ToInt32(TempData["id"]);
            tblVehicleType type = dc.tblVehicleTypes.SingleOrDefault(ob => ob.VehicleTypeId == id);
            type.TypeName = form["txtTname"];
            type.TypeImage = form["txtImage"];
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
    }
}