using BusinessLayer.Concrate;
using BusinessLayer.FluentValidation;
using DataAccessLayer.Concrate.Repositories;
using EntityLayer.Concrate;
using EntityLayer.ViewModels;
using FluentValidation.Results;
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
        //WriterManager wm = new WriterManager(new GenericRepository<Writer>());
      
        public ActionResult Index()
        {
        
            return View(hm.GetHeadingList());
        }

        [HttpGet]
        public ActionResult AddHeading()
        {         

            var model = new HeadingCategoryViewModel()
            {
                Category = cm.GetCategoryList(),
                Heading = new Heading()
            };


            return View("HeadingForm",model);
        }

        [HttpPost]
        public ActionResult SaveHeading(Heading heading)
        {
             
            heading.HeadingDate = DateTime.Now;
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
                return View("HeadingForm", model);
              
            }
            if (headingID == 0)
            {
                hm.AddHeading(heading);
            }
            else
            {
                hm.UpdateHeading(heading);
            }
            return RedirectToAction("Index");
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
            if (model.HeadingStatus == false)
            {
                model.HeadingStatus = true;
            }
            else
            {
                model.HeadingStatus = false;
            }

            hm.DeleteHeading(model);

            return RedirectToAction("Index",model);
        }

    }
}