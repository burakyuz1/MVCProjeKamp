using BusinessLayer.Concrate;
using DataAccessLayer.Concrate.Repositories;
using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKamp.Controllers.WriterControllers
{
    public class WriterProfileController : Controller
    {
        WriterManager wm = new WriterManager(new GenericRepository<Writer>());
        // GET: WriterProfile
        [HttpGet]
        public ActionResult Index()
        {
            string loggedUser = (string)Session["WriterMail"];
            var model = wm.GetWriterByEmail(loggedUser);
            return View(model);
        }
        [HttpPost]
        public ActionResult SaveChanges(Writer writer)
        {
            wm.UpdateWriter(writer);
            return RedirectToAction("index");
        }
    }
}