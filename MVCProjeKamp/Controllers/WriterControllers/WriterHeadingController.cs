using BusinessLayer.Concrate;
using BusinessLayer.FluentValidation;
using DataAccessLayer.Concrate;
using DataAccessLayer.Concrate.Repositories;
using EntityLayer.Concrate;
using EntityLayer.ViewModels;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MVCProjeKamp.Controllers.WriterControllers
{
    public class WriterHeadingController : Controller
    {
        CategoryManager cm = new CategoryManager(new GenericRepository<Category>());
        HeadingManager hm = new HeadingManager(new GenericRepository<Heading>());
        WriterLoginManager wlm = new WriterLoginManager(new GenericRepository<Writer>());

        // GET: WriterHeading
        public ActionResult Index()
        {
            var model = hm.GetHeadingsByWriterName(User.Identity.Name);

            return View(model);
        }
        public ActionResult AllHeadings()
        {
            var model = hm.GetHeadingList();

            return View(model);
        }
        [HttpGet]
        public ActionResult AddHeading()
        {
            var model = new HeadingCategoryViewModel()
            {
                Category = cm.GetCategoryList(),
                Heading = new Heading()
            };


            return View("WriterHeadingForm", model);
        }


        [HttpPost]
        public ActionResult SaveHeading(Heading heading)
        {
            string WriterLoginMail = (string)Session["WriterMail"];
            var modelForSaveChanges = wlm.GetWriterFromSession(WriterLoginMail);
            heading.WriterID = modelForSaveChanges.WriterID;
            heading.HeadingDate = DateTime.Now;
            heading.HeadingStatus = true;
            int headingID = heading.HeadingID;
            ValidationResult result = new HeadingValidator().Validate(heading);
            if (!result.IsValid)
            {
                var model = new HeadingCategoryViewModel()
                {
                    Category = cm.GetCategoryList(),
                    Heading = heading
                };
                foreach (var err in result.Errors)
                {
                    ModelState.AddModelError(err.PropertyName, err.ErrorMessage);
                }
                return View("WriterHeadingForm", model);

            }
            if (headingID == 0)
            {
                hm.AddHeading(heading);
            }
            else
            {
                hm.UpdateHeading(heading);
            }
            return RedirectToAction("Index", "WriterHeading");
        }

        [HttpGet]
        public ActionResult UpdateHeading(int id)
        {
            var model = new HeadingCategoryViewModel()
            {
                Category = cm.GetCategoryList(),
                Heading = hm.GetHeadingByID(id)
            };

            return View("WriterHeadingForm", model);
        }
        public ActionResult DeleteHeading(int id)
        {
            var model = hm.GetHeadingByID(id);
            if (model.HeadingStatus == true)
            {
                model.HeadingStatus = false;
            }       
            hm.DeleteHeading(model);
            return RedirectToAction("Index", "WriterHeading", model);
        }
    }
}