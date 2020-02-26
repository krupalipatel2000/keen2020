﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KeenConveyance.Areas.Admin.Models;

namespace KeenConveyance.Areas.Admin.Controllers
{
    public class BookingController : Controller
    {
        // GET: Admin/Booking
        dbTransportEntities3 dc = new dbTransportEntities3();

        public ActionResult Index()
        {
            //var book = dc.tblBookings.ToList();
            var Booking = from ob in dc.tblBookings select new JoinViewAll
            {
                user = (from obCon in dc.tblConsignments join obUser in dc.tblUsers on obCon.UserId equals obUser.UserId where obCon.ConsignmentId == ob.ConsignmentId select obUser).Take(1).FirstOrDefault(),
                consignment = dc.tblConsignments.FirstOrDefault(obCon => obCon.ConsignmentId == ob.ConsignmentId),
                book = dc.tblBookings.FirstOrDefault(obBook => obBook.BookingId == ob.BookingId)
                //book = dc.tblBookings.FirstOrDefault(obBook => obBook.BookingId == ob.BookingId)
            };
            return View(Booking);
        }
        [HttpPost]
        public JsonResult Active(int id)
        {
            tblBooking book = dc.tblBookings.SingleOrDefault(ob => ob.BookingId == id);
            if (book.IsPaid == true)
            {
                book.IsPaid = false;
            }
            else
            {
                book.IsPaid = true;
            }
            dc.SaveChanges();
            return Json(book.IsPaid, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Detail(int id)
        {
            tblBooking book = dc.tblBookings.SingleOrDefault(ob => ob.BookingId == id);
            ViewBag.Vehicle = (from ob in dc.tblVehicles where ob.VehicleId == book.VehicleId select ob).Take(1).SingleOrDefault().VehicleName;
            ViewBag.Driver = (from ob in dc.tblDrivers where ob.DriverId == book.DriverId select ob).Take(1).SingleOrDefault().DriverName;
            string vehicle = ViewBag.Vehicle;
            string dr = ViewBag.Driver;
            return View(book);
        }
    }
}