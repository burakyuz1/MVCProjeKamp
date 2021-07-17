using BusinessLayer.Concrate;
using DataAccessLayer.Concrate.Repositories;
using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKamp.Controllers
{
    public class AboutController : Controller
    {
        AboutManager abm = new AboutManager(new GenericRepository<About>());
        // GET: About
        public ActionResult Index()
        {
            return View(abm.GetAboutList());
        }

        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }


        [HttpPost]
        public ActionResult SaveAbout(About about)
        {
            abm.AddNewAbout(about);
            return RedirectToAction("Index");
        }
        public PartialViewResult AddAboutModalPartial()
        {
            return PartialView();
        }
    }
}