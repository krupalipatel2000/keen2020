using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KeenConveyance.Areas.Admin.Models;

namespace KeenConveyance.Controllers
{
    public class VisitorCompanyController : Controller
    {
        // GET: VisitorCompany
        dbTransportEntities5 dc = new dbTransportEntities5();
        public ActionResult Index()
        {
            tblTransportCompany com = new tblTransportCompany();
            ViewBag.Com = from ob in dc.tblTransportCompanies select ob;
            return View(com);
        }
    }
}