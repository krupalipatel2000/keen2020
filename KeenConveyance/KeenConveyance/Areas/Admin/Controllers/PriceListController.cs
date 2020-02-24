using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KeenConveyance.Areas.Admin.Models;

namespace KeenConveyance.Areas.Admin.Controllers
{
    public class PriceListController : Controller
    {
        // GET: Admin/PriceList
        dbTransportEntities3 dc = new dbTransportEntities3();
        public ActionResult Index()
        {
            var joinprice = from obprice in dc.tblPriceLists
                        join obCom in dc.tblTransportCompanies on obprice.CompanyId equals obCom.CompanyId
                        select new JoinViewAll
                        {
                            price = obprice,
                            company = obCom
                        };
            return View(joinprice);
        }
        [HttpPost]
        public JsonResult Active(int id)
        {
            tblPriceList pricelist = dc.tblPriceLists.SingleOrDefault(ob => ob.PriceListId == id);
            if (pricelist.IsActive == true)
            {
                pricelist.IsActive = false;
            }
            else
            {
                pricelist.IsActive = true;
            }
            dc.SaveChanges();
            return Json(pricelist.IsActive, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Detail(int id)
        {
            tblPriceList pricelist = dc.tblPriceLists.SingleOrDefault(ob => ob.PriceListId == id);
            return View(pricelist);
        }
        public ActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insert(FormCollection form)
        {
            tblPriceList price = new tblPriceList();
            price.UnitName = form["txtUname"];
            price.MinValue = form["txtMin"];
            price.MaxValue = form["txtMax"];
            price.PricePerUnit = Convert.ToInt32(form["txtUnit"]);
            price.CompanyId = Convert.ToInt32(form["txtCompanyId"]);
            price.IsActive = true;
            dc.tblPriceLists.Add(price);
            dc.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            TempData["id"] = id;
            tblPriceList price = dc.tblPriceLists.SingleOrDefault(ob => ob.PriceListId == id);
            return View(price);
        }
        [HttpPost]
        public ActionResult Edit(FormCollection form)
        {
            int id = Convert.ToInt32(TempData["id"]);
            tblPriceList price = dc.tblPriceLists.SingleOrDefault(ob => ob.PriceListId == id);
            price.UnitName = form["txtUname"];
            price.MinValue = form["txtMin"];
            price.MaxValue = form["txtMax"];
            price.PricePerUnit = Convert.ToInt32(form["txtUnit"]);
            price.CompanyId = Convert.ToInt32(form["txtCompanyId"]);
            dc.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            tblPriceList price = dc.tblPriceLists.SingleOrDefault(ob => ob.PriceListId == id);
            dc.tblPriceLists.Remove(price);
            dc.SaveChanges();
            return RedirectToAction("Index", "PriceList");
        }
    }
}