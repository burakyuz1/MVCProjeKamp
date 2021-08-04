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

        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return View(hm.GetHeadingList(true));
            }
            else
            {
                var model = hm.GetHeadingByWriterID(id, true);
                return View(model);

            }

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
            WriterLoginManager wm = new WriterLoginManager(new GenericRepository<Writer>());
            AlertViewModel alert = new AlertViewModel();
            var loggedUser = (string)Session["WriterMail"];

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
                heading.HeadingStatus = true;
                heading.HeadingDate = DateTime.Now;
                int idWriter = wm.GetWriterFromSession(loggedUser).WriterID;
                heading.WriterID = idWriter;
                alert.AlertMessage = heading.HeadingName + " added succesfully...";
                hm.AddHeading(heading);
            }
            else
            {
                if (heading.HeadingStatus)
                {
                    alert.LinkText = "   Back to Title List";
                    alert.URL = "/Heading/Index/";
                }
                else
                {
                    alert.LinkText = "   Back to Passive Title List";
                    alert.URL = "/Heading/GetPassiveHeadings/";
                }
                alert.AlertMessage = heading.HeadingName + " updated succesfully...";
                hm.UpdateHeading(heading);
            }


            alert.Status = true;
            return PartialView("_Alert", alert);
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