using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KeenConveyance.Areas.Admin.Models;

namespace KeenConveyance.Controllers
{
    public class ClientBookingController : Controller
    {
        // GET: ClientBooking
        dbTransportEntities5 dc = new dbTransportEntities5();
        public ActionResult Index(int id)
        {
            var Booking = from ob in dc.tblBookings
                          join ob2 in dc.tblConsignments on ob.ConsignmentId equals ob2.ConsignmentId
                          join ob3 in dc.tblUsers on ob2.UserId equals ob3.UserId
                          join ob4 in dc.tblDrivers on ob.DriverId equals ob4.DriverId
                          join ob5 in dc.tblVehicles on ob.VehicleId equals ob5.VehicleId
                          where ob2.UserId == ob3.UserId
                          select new JoinViewAll
                          {
                              user = ob3,
                              consignment = ob2,
                              book = ob,
                              driver = ob4,
                              vehicle = ob5
                          };
            ViewBag.Booking = Booking;
            return View(Booking);
        }
        public ActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insert(FormCollection form)
        {
            tblBooking book = new tblBooking();
            
            return View();
        }
    }
}