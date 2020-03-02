using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KeenConveyance.Areas.Admin.Models;

namespace KeenConveyance.Areas.Admin.Controllers
{
    public class ComplaintController : Controller
    {
        // GET: Admin/Complaint

        dbTransportEntities4 dc = new dbTransportEntities4();
        public ActionResult Index()
        {
            var joincom = from obcomplaint in dc.tblComplaints
                      join obCom in dc.tblTransportCompanies on obcomplaint.CompanyId equals obCom.CompanyId
                      select new JoinViewAll
                      {
                          complaint = obcomplaint,
                          company = obCom
                      };
            return View(joincom);

        }
        public ActionResult Detail(int id)
        {
            tblComplaint com = dc.tblComplaints.SingleOrDefault(ob => ob.ComplaintId == id);
            ViewBag.Name = (from ob in dc.tblUsers where ob.UserId == com.UserId select ob).Take(1).SingleOrDefault().FirstName;
            ViewBag.Company = (from ob in dc.tblTransportCompanies where ob.CompanyId == com.CompanyId select ob).Take(1).SingleOrDefault().CompanyName;
            string User = ViewBag.Name;
            string Name = ViewBag.Company;
            return View(com);
        }

    }
}