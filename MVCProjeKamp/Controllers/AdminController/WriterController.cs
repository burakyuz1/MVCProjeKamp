using BusinessLayer.Concrate;
using DataAccessLayer.Concrate.Repositories;
using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using EntityLayer.ViewModels;

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
            AlertViewModel alert = new AlertViewModel();
          

            if (writer.WriterID == 0)
            {
                writer.WriterStatus = true;
                alert.AlertMessage = writer.WriterName + writer.WriterSurname + " added succesfully...";

                wm.AddWriter(writer);

            }
            else
            {
                if (writer.WriterStatus)
                {
                    alert.LinkText = "   Back to Writer List";
                    alert.URL = "/Writer/Index/";
                }
                else
                {
                    alert.LinkText = "   Back to Banned Writer List";
                    alert.URL = "/Writer/GetBannedWriters/";

                }
                alert.AlertMessage = writer.WriterName + " " + writer.WriterSurname + " updated succesfully...";
                wm.UpdateWriter(writer);
            }


            alert.Status = true;
            return PartialView("_Alert", alert);

        }

        [HttpGet]
        public ActionResult UpdateWriter(int id)
        {
            var model = wm.GetWriterByID(id);
            return View("WriterForm", model);
        }


    }
}