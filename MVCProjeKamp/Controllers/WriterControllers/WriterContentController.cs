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
    public class WriterContentController : Controller
    {
        ContentManager cm = new ContentManager(new GenericRepository<Content>());
        WriterLoginManager wlm = new WriterLoginManager(new GenericRepository<Writer>());

        // GET: WriterContent
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetContentsForHeading(int id)
        {
       
            return View(cm.GetContentByHeadingID(id));
        }
        public ActionResult GetContentsForWriter()
        {
            var loggedUser = (string)Session["WriterMail"];
            var model = cm.GetContentByLoggedUser(loggedUser);
            return View(model);
        }
        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.TitleID = id;
            return View();
        }
        [HttpPost]
        public ActionResult SaveContent(Content content)
        {
            content.ContentDate = DateTime.Now;
            var loggedUser = (string)Session["WriterMail"];
            content.WriterID = wlm.GetWriterFromSession(loggedUser).WriterID;
           
            cm.AddContent(content);
            return RedirectToAction("GetContentsForWriter","writerContent");
        }
    }
}