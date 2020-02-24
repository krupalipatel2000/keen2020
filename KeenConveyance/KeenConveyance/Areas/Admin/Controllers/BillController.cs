using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KeenConveyance.Areas.Admin.Models;


namespace KeenConveyance.Areas.Admin.Controllers
{
    public class BillController : Controller
    {
        // GET: Admin/Bill
        dbTransportEntities3 dc = new dbTransportEntities3();
        public ActionResult Index()
        {
            var joinbill = from obBill in dc.tblBills
                       join obBook in dc.tblBookings on obBill.BookingId equals obBook.BookingId
                       join obUser in dc.tblUsers on obBill.UserId equals obUser.UserId
                       select new JoinViewAll
                       {
                           bil = obBill,
                           book = obBook,
                           user = obUser
                       };
            return View(joinbill);
        }
        public ActionResult Detail(int id)
        {
            tblBill bill = dc.tblBills.SingleOrDefault(ob => ob.BillId == id);
            return View(bill);
        }
    }
}