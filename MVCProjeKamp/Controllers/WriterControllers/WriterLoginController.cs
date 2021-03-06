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

            if (model != null)
            {
                FormsAuthentication.SetAuthCookie(model.WriterMail, false);

                Session["WriterMail"] = model.WriterMail;
                if (model.WriterRole == "u")
                {
                 
                    //ViewBag.SessionNameSurname = wlm.GetWriterFromSession(model.WriterMail).WriterName + " " + wlm.GetWriterFromSession(model.WriterMail).WriterSurname;


                    return RedirectToAction("Index", "WriterHeading");
                }
                else
                {
                  
                    return RedirectToAction("Index", "AdminCategory");
                }

            }
            else
            {
                return RedirectToAction("Index");
            }


        }

        public ActionResult GetLoggedNameSurname()
        {
            var loggedUser = (string)Session["WriterMail"];
            string loggerNameSurname = wlm.GetWriterFromSession(loggedUser).WriterName + " " + wlm.GetWriterFromSession(loggedUser).WriterSurname;
            return Content(loggerNameSurname);
        }

        public ActionResult GetLoggedUsersImage()
        {
            var loggedUser = (string)Session["WriterMail"];
            string loggerImage = wlm.GetWriterFromSession(loggedUser).WriterPicture;
            return Content(loggerImage);
        }
    }
}