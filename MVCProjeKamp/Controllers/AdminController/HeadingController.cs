using BusinessLayer.Concrate;
using DataAccessLayer.Concrate.Repositories;
using EntityLayer.Concrate;
using EntityLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKamp.Controllers
{
    public class HeadingController : Controller
    {
        // GET: Heading
        HeadingManager hm = new HeadingManager(new GenericRepository<Heading>());
        CategoryManager cm = new CategoryManager(new GenericRepository<Category>());
        WriterLoginManager wm = new WriterLoginManager(new GenericRepository<Writer>());
        AlertViewModel alert = new AlertViewModel();

        public ActionResult Index()
        {

            return View(hm.GetHeadingList(true));
        }
        public ActionResult GetPassiveHeadings()
        {
            return View(hm.GetHeadingList(false));
        }

        [HttpGet]
        public ActionResult AddHeading()
        {

            var model = new HeadingCategoryViewModel()
            {
                Category = cm.GetCategoryList(),
                Heading = new Heading()
            };


            return View("HeadingForm", model);
        }

        [HttpPost]
        public ActionResult SaveHeading(Heading heading)
        {
            var loggedUser = (string)Session["WriterMail"];
            heading.HeadingStatus = true;        
            int headingID = heading.HeadingID;
            if (!ModelState.IsValid)
            {
                var model = new HeadingCategoryViewModel()
                {
                    Category = cm.GetCategoryList(),
                    Heading = heading
                };
         
                return View("HeadingForm", model);

            }
            if (headingID == 0)
            {
                heading.HeadingDate = DateTime.Now;
                int idWriter = wm.GetWriterFromSession(loggedUser).WriterID;
                heading.WriterID = idWriter;
                alert.AlertMessage = heading.HeadingName + " succesfully added..."; 
                hm.AddHeading(heading);
            }
            else
            {
                alert.AlertMessage = heading.HeadingName + " succesfully updates...";
                hm.UpdateHeading(heading);
            }

            alert.LinkText = "Back to Title List";
            alert.URL = "/Heading/Index/";
            alert.Status = true;
            return PartialView("_Alert",alert);
        }

        [HttpGet]
        public ActionResult UpdateHeading(int id)
        {
            var model = new HeadingCategoryViewModel()
            {
                Category = cm.GetCategoryList(),
                Heading = hm.GetHeadingByID(id)
            };

            return View("HeadingForm", model);
        }
        public ActionResult DeleteHeading(int id)
        {
            var model = hm.GetHeadingByID(id);
            if (model.HeadingStatus)
            {
                model.HeadingStatus = false;
                hm.DeleteHeading(model);
                return RedirectToAction("Index");
            }
            else
            {
                model.HeadingStatus = true;
                hm.DeleteHeading(model);
                return RedirectToAction("GetPassiveHeadings");

            }
        }

    }
}