using System;
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
        dbTransportEntities4 dc = new dbTransportEntities4();

        public ActionResult Index()
        {
            //var book = dc.tblBookings.ToList();
            var Booking = from ob in dc.tblBookings join ob2 in dc.tblConsignments on ob.ConsignmentId equals ob2.ConsignmentId
                          join ob3 in dc.tblUsers on ob2.UserId equals ob3.UserId
                          select new JoinViewAll
            {
                              user = ob3,
                              book = ob
            };
            ViewBag.Booking = Booking;
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
            ViewBag.UserName = (from ob in dc.tblUsers join ob2 in dc.tblConsignments on ob.UserId equals ob2.UserId where ob2.ConsignmentId == book.ConsignmentId select ob).Take(1).SingleOrDefault().FirstName;

            string vehicle = ViewBag.Vehicle;
            string dr = ViewBag.Driver;
            return View(book);
        }
    }
}