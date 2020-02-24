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
        dbTransportEntities3 dc = new dbTransportEntities3();

        public ActionResult Index()
        {
            var book = dc.tblBookings.ToList();
            return View(book);

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
            return View(book);
        }
    }
}