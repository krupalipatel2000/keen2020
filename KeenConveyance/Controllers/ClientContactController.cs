using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KeenConveyance.Areas.Admin.Models;

namespace KeenConveyance.Controllers
{
    public class ClientContactController : Controller
    {
        // GET: ClientContact
        dbTransportEntities5 dc = new dbTransportEntities5();
        public ActionResult Index()
        {
            var cities = new List<Googlemap>();
            cities.Add(new Googlemap() { Title = "Paris", Lat = 48.855901, Lng = 2.349272 });
            cities.Add(new Googlemap() { Title = "Berlin", Lat = 52.520413, Lng = 13.402794 });
            cities.Add(new Googlemap() { Title = "Rome", Lat = 41.907074, Lng = 12.498474 });
            return View(cities);
        }
        [HttpPost]
        public JsonResult GetAnswer(string question)
        {
            int index = _rnd.Next(_db.Count);
            var answer = _db[index];
            return Json(answer);
        }

        private static Random _rnd = new Random();

        private static List<string> _db = new List<string> { "Yes", "No", "Definitely, yes", "I don't know", "Looks like, yes" };

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            tblInquiry inquiry = new tblInquiry();
            inquiry.FirstName = form["txtName"];
            inquiry.EmailId = form["txtEmail"];
            inquiry.ContactNo = form["txtContact"];
            inquiry.Desc = form["txtMessage"];
            inquiry.CreatedOn = DateTime.Now;
            inquiry.IsReplied = false;
            dc.tblInquiries.Add(inquiry);
            dc.SaveChanges();
            return RedirectToAction("Blank","Home");
        }

    }
}
