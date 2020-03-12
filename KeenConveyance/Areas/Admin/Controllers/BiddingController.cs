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
        dbTransportEntities5 dc = new dbTransportEntities5();
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
        
        public ActionResult Detail(int id)
        {
            var joinBid = (from obBid in dc.tblBiddings
                          join obCom in dc.tblTransportCompanies on obBid.CompanyId equals obCom.CompanyId
                          where obBid.BidId == id
                          select new JoinViewAll
                          {
                              bid = obBid,
                              company = obCom
                          }).Take(1).SingleOrDefault();
            return View(joinBid);
        }
    }
}