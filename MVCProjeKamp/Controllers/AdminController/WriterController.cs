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
    public class WriterController : Controller
    {
        WriterManager wm = new WriterManager(new GenericRepository<Writer>());

        // GET: Writer
        public ActionResult Index()
        {
            return View(wm.GetWriterList());
        }

        [HttpGet]
        public ActionResult AddWriter()
        {
            return View("WriterForm");
        }
        [HttpPost]
        public ActionResult SaveWriter(Writer writer)
        {
            int writerID = writer.WriterID;

            //ValidationResult result = new WriterValidator().Validate(writer);

            if (!ModelState.IsValid)
            {
                //foreach (var err in result.Errors)
                //{
                //    ModelState.AddModelError(err.PropertyName, err.ErrorMessage);
                //}
                return View("WriterForm");
            }
            if (writerID == 0)
            {
                wm.AddWriter(writer);

            }
            else
            {
                //güncelleme
                wm.UpdateWriter(writer);
            }
            return RedirectToAction("Index");
           
        }

        [HttpGet]
        public ActionResult UpdateWriter(int id)
        {
            return View("WriterForm", wm.GetWriterByID(id));
        }

    }
}