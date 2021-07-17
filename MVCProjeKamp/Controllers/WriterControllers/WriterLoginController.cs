using BusinessLayer.Concrate;
using DataAccessLayer.Concrate.Repositories;
using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCProjeKamp.Controllers.WriterControllers
{
    [AllowAnonymous]
    public class WriterLoginController : Controller
    {
        WriterLoginManager wlm = new WriterLoginManager(new GenericRepository<Writer>());
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Writer writer)
        {
            var model = wlm.GetWriter(writer);
            if (model!=null)
            {
                
                FormsAuthentication.SetAuthCookie(model.WriterMail, false);
               
                Session["WriterMail"] = model.WriterMail;
                ViewBag.SessionNameSurname = wlm.GetWriterFromSession(model.WriterMail).WriterName + " " + wlm.GetWriterFromSession(model.WriterMail).WriterSurname;


                return RedirectToAction("Index", "WriterHeading");
            }
            else
            {
                return RedirectToAction("Index");
            }
          
        }
    }
}