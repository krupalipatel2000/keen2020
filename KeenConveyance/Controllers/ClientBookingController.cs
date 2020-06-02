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
        public ActionResult Index()
        {
            //var Booking = from ob in dc.tblBookings
            //              join ob2 in dc.tblConsignments on ob.ConsignmentId equals ob2.ConsignmentId
            //              join ob3 in dc.tblUsers on ob2.UserId equals ob3.UserId
            //              where ob2.UserId == ob3.UserId
            //              select new JoinViewAll
            //              {
            //                  user = ob3,
            //                  consignment = ob2,
            //                  book = ob
            //              };
            //ViewBag.Booking = Booking;
            //var driver = from obCom in dc.tblTransportCompanies
            //             join obDriver in dc.tblDrivers on obCom.CompanyId equals obDriver.CompanyId
            //             join obVehicle in dc.tblVehicles on obCom.CompanyId equals obVehicle.CompanyId
            //             select new JoinViewAll
            //             {
            //                 driver = obDriver,
            //                 vehicle = obVehicle
            //             };
            //ViewBag.driver= driver;
            return View();
        }
        [HttpPost]
        public ActionResult Index(int id, int id1)
        {
            tblBooking book = new tblBooking();
            book.ConsignmentId = id;
            book.BidId = id1;
            //book.IsPaid = false;
            dc.tblBookings.Add(book);
            dc.SaveChanges();
            return View();
        }
        
    }
}