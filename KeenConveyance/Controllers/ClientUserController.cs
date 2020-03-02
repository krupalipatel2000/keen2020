using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KeenConveyance.Areas.Admin.Models;

namespace KeenConveyance.Controllers
{
    public class ClientUserController : Controller
    {
        // GET: User
        dbTransportEntities4 dc = new dbTransportEntities4();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insert(FormCollection form,HttpPostedFileBase txtprofile)
        {
            string name = "txtprofile";
            if(txtprofile != null)
            {
                int size = (int)txtprofile.ContentLength / 1024;
                var extention = System.IO.Path.GetExtension(txtprofile.FileName);
                if(size <= 1024 && (extention.ToLower().Equals(".jpg")|| extention.ToLower().Equals(".jpeg") || extention.ToLower().Equals(".png")))
                {
                    name = code() + "" + extention;
                    string path = Server.MapPath("~/Images/");
                    txtprofile.SaveAs(path + "" + name);
                }
            }
            tblUser user = new tblUser();
            user.FirstName = form["txtFirstName"];
            user.LastName = form["txtLastName"];
            user.EmailId = form["txtEmailId"];
            user.Password = form["txtPwd"];
            //user.Gender = form["txtgender"];
            user.ContactNo = form["txtCno"];
            user.IsActive = false;
            user.CreatedOn = DateTime.Now;
            user.IsVerified = false;
            user.IsMobileVerified = false;
            user.ProfilePic = form["txtprofile"];
            dc.tblUsers.Add(user);
            dc.SaveChanges();
            return RedirectToAction("List");
        }
       
        public ActionResult List()
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
        public string code()
        {
            string code = DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss-ff").Replace("-", "");
            return code;
        }
    }

}