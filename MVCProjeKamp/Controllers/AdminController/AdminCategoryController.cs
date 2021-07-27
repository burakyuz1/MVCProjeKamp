using BusinessLayer.Concrate;
using BusinessLayer.FluentValidation;
using DataAccessLayer.Concrate.Repositories;
using EntityLayer.Concrate;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKamp.Controllers
{
    //[Authorize(Roles="a,b,c")]
    public class AdminCategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new GenericRepository<Category>());
        // GET: AdminCategory

        
        public ActionResult Index()
        {
            return View(cm.GetCategoryList());
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View("CategoryForm");
        }
        [HttpPost]
        public ActionResult SaveCategory(Category category)
        {
            var categoryID = category.CategoryID;

            ValidationResult result = new CategoryValidator().Validate(category);
       
            if (result.Errors.Count > 0)
            {
                foreach (var err in result.Errors)
                {
                    ModelState.AddModelError(err.PropertyName, err.ErrorMessage);
                }
                return View("CategoryForm");
            }
            if (categoryID == 0)
            {
                cm.AddNewCategory(category);
            }
            else
            {
                cm.UpdateCategory(category);
            }
            return RedirectToAction("Index");
         
        }
        public ActionResult DeleteCategory(int id)
        {
            var model = cm.GetCategoryByID(id);
            model.CategoryStatus = false;
            cm.UpdateCategory(model);
           
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var categoryForEdit = cm.GetCategoryByID(id);
            return View("CategoryForm", categoryForEdit);
        }


    }
}