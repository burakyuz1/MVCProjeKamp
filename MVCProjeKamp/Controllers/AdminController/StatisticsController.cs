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
    public class StatisticsController : Controller
    {

        CategoryManager cm = new CategoryManager(new GenericRepository<Category>());
        HeadingManager hm = new HeadingManager(new GenericRepository<Heading>());
        WriterManager wm = new WriterManager(new GenericRepository<Writer>());
        // GET: Statistics
        public ActionResult Index()
        {
            var WriterList = wm.GetWriterList();
            int sayac = 0;

            foreach (var writer in WriterList)
            {

                if (writer.WriterName.ToLower().Contains("a"))
                {
                    sayac++;
                }
            }

           
            ViewBag.WriterCount = sayac;
            ViewBag.FilteredHeadingName = hm.GetHeadingsByName("Kültür").Count;
            ViewBag.TotalCategory = cm.GetCategoryList().Count;
            ViewBag.Difference = cm.GetCategoryListByStatus();


            return View();
        }
    }
}