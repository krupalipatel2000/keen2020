using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KeenConveyance.Areas.Admin.Models;

namespace KeenConveyance.Controllers
{
    public class ClientInqueryController : Controller
    {
        // GET: ClientInquery
        dbTransportEntities3 dc = new dbTransportEntities3();
       
        public ActionResult Index()
        {  
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            tblInquiry Inq = new tblInquiry();
            Inq.FirstName = form["txtFname"];
            Inq.LastName = form["txtLname"];
            Inq.ContactNo = form["txtContactNo"];
            Inq.EmailId = form["txtEmail"];
            Inq.Subject = form["txtSubject"];
            Inq.Desc = form["txtDesc"];
            Inq.CreatedOn = DateTime.Now;
            dc.tblInquiries.Add(Inq);
            dc.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

    }
}
