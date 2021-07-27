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
using PagedList;
using PagedList.Mvc;

namespace MVCProjeKamp.Controllers
{
    public class WriterController : Controller
    {
        WriterManager wm = new WriterManager(new GenericRepository<Writer>());

        // GET: Writer
        public ActionResult Index(int? page, string searchForWriter)
        {
            if (searchForWriter != null)
            {
                return View(wm.GetWriterList(searchForWriter).ToPagedList(page ?? 1, 6));
            }
            else
            {
                return View(wm.GetWriterList(true).ToPagedList(page ?? 1, 6));

            }

        }

        public ActionResult GetBannedWriters(int? page, string searchForWriter)
        {
            if (searchForWriter != null)
            {
                return View(wm.GetWriterList(searchForWriter).ToPagedList(page ?? 1, 6));
            }
            else
            {
                return View(wm.GetWriterList(false).ToPagedList(page ?? 1, 6));

            }
        }

        public ActionResult BanWriter(int id)
        {
            var model = wm.GetWriterByID(id);
            if (model.WriterStatus)
            {
                model.WriterStatus = false;
                wm.UpdateWriter(model);
                return RedirectToAction("Index");
            }
            else
            {
                model.WriterStatus = true;
                wm.UpdateWriter(model);
                return RedirectToAction("GetBannedWriters");

            }
       
          
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
            writer.WriterStatus = true;

            if (!ModelState.IsValid)
            {
              
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