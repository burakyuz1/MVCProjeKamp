using BusinessLayer.Concrate;
using DataAccessLayer.Concrate.Repositories;
using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKamp.Controllers.WriterControllers
{
    public class WriterMessageController : Controller
    {
        MessageManager mm = new MessageManager(new GenericRepository<Message>());
        // GET: WriterMessage
        public ActionResult Inbox()
        {
            var model = mm.GetMessageInbox((string)Session["WriterMail"]);

            return View(model);
        }
        public ActionResult Sendbox()
        {
            var model = mm.GetMessageSendbox((string)Session["WriterMail"]);
            return View(model);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SendMessage(Message msg)
        {
            msg.MessageSender = (string)Session["WriterMail"];
            msg.MessageDate = DateTime.Now;
            mm.AddNewMessage(msg);


            return RedirectToAction("Inbox");
        }

        public ActionResult ReadMessageForWriter(int id)
        {
            return View(mm.GetMessageByID(id));
        }
        public PartialViewResult GetSideBarForUserMessage()
        {
            return PartialView();
        }

    }
}