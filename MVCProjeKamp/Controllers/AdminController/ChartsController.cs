using BusinessLayer.Concrate;
using DataAccessLayer.Concrate.Repositories;
using EntityLayer.Concrate;
using EntityLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKamp.Controllers.AdminController
{
    public class ChartsController : Controller
    {
        HeadingManager hm = new HeadingManager(new GenericRepository<Heading>());
        CategoryManager cm = new CategoryManager(new GenericRepository<Category>());
        // GET: Charts
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ChartsCategory()
        {
            List<CategoriesCharts> categoryChart = new List<CategoriesCharts>();
            foreach (var item in cm.GetCategoryList())
            {
                categoryChart.Add(new CategoriesCharts()
                {
                    CategoryName = item.CategoryName,
                    HeadingCount = hm.CategoryCount(item.CategoryName)
                });
            }

            return Json(categoryChart, JsonRequestBehavior.AllowGet);
        }

      
    }
}