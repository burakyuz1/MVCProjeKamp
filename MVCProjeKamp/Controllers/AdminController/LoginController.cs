using BusinessLayer.Concrate;
using DataAccessLayer.Concrate.Repositories;
using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCProjeKamp.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        LoginManager lm = new LoginManager(new GenericRepository<Admin>());
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            var model = lm.GetAdmin(admin);
            if (model!=null)
            {
                //login succes
                FormsAuthentication.SetAuthCookie(model.AdminUserName, false);
                Session["AdminUserName"]= model.AdminUserName;
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                return RedirectToAction("Index");
            }           
        }
    }
}