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

        dbTransportEntities3 dc = new dbTransportEntities3();
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
            tblComplaint com = dc.tblComplaints.SingleOrDefault(ob => ob.CompanyId == id);
            return View(com);
        }

    }
}