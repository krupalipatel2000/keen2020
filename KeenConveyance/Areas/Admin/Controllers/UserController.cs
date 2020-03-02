using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KeenConveyance.Areas.Admin.Models;

namespace KeenConveyance.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        // GET: Admin/User
        dbTransportEntities4 dc = new dbTransportEntities4();
        public ActionResult Index()
        {
            var user = dc.tblUsers.ToList();
            return View(user);
        }
        [HttpPost]
        public JsonResult Active(int id)
        {
            tblUser user = dc.tblUsers.SingleOrDefault(ob => ob.UserId == id);
            if (user.IsActive == true)
            {
                user.IsActive = false;
            }
            else
            {
                user.IsActive = true;
            }
            dc.SaveChanges();
            return Json(user.IsActive, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Detail(int id)
        {
            tblUser user = dc.tblUsers.SingleOrDefault(ob => ob.UserId == id);
            var consignment = from ob in dc.tblConsignments where ob.UserId == user.UserId select ob;
            ViewBag.consignmentlist = consignment;
            return View(user);
        }
    }
}