using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KeenConveyance.Controllers
{
    public class ClientServiceController : Controller
    {
        // GET: ClientService
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Ocean()
        {
            return View();
        }
        public ActionResult Air()
        {
            return View();
        }
        public ActionResult Land()
        {
            return View();
        }
        public ActionResult ColdStorage()
        {
            return View();
        }
    }
}