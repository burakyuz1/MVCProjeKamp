using BusinessLayer.Concrate;
using DataAccessLayer.Concrate.Repositories;
using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKamp.Controllers.Default
{
    public class DefaultController : Controller
    {
        HeadingManager hm = new HeadingManager(new GenericRepository<Heading>());
        ContentManager cm = new ContentManager(new GenericRepository<Content>());


        public ActionResult Headings()
        {
            var model = hm.GetHeadingList(true);
            return View(model);
        }
        public PartialViewResult Index(int id=0)
        {
            var model = cm.GetContentByHeadingID(id);
            
            return PartialView(model);
        }

      
    }
}