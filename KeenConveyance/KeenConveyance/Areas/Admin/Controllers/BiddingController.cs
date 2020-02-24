using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KeenConveyance.Areas.Admin.Models;

namespace KeenConveyance.Areas.Admin.Controllers
{
    public class BiddingController : Controller
    {
        // GET: Admin/Bidding
        dbTransportEntities3 dc = new dbTransportEntities3();
        public ActionResult Index()
        {
            var joinBid = from obBid in dc.tblBiddings
                          join obCom in dc.tblTransportCompanies on obBid.CompanyId equals obCom.CompanyId
                          select new JoinViewAll
                          {
                              bid = obBid,
                              company = obCom
                          };
            return View(joinBid);
        }
        
        public ActionResult Detail()
        {
            var joinBid = from obBid in dc.tblBiddings
                          join obCom in dc.tblTransportCompanies on obBid.CompanyId equals obCom.CompanyId
                          select new JoinViewAll
                          {
                              bid = obBid,
                              company = obCom
                          };
            return View(joinBid);
        }
    }
}