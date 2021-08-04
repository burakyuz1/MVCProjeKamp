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
    public class ContentController : Controller
    {
        ContentManager cm = new ContentManager(new GenericRepository<Content>());
        // GET: Content
        public ActionResult Index()
        {
            var model = cm.GetContentList();
            return View(model);
        }

        public ActionResult DeleteContent(int id)
        {
            var model = cm.GetContentById(id);
            cm.DeleteContent(model);
            return RedirectToAction("Index");
        }



    }
}