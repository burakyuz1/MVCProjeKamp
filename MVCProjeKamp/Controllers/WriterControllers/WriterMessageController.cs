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
            var model = mm.GetMessageInbox((string)Session["WriterMail"], "a");

            return View("Inbox",model);
        }
        public ActionResult Sendbox()
        {
            var model = mm.GetMessageSendbox((string)Session["WriterMail"], "a");
            return View(model);
        }
        [HttpGet]
        public ActionResult NewMessage(int? id)
        {
            var loggedUser = (string)Session["WriterMail"];
            var model = mm.GetMessageByID(id);
            if (model != null)
            {
                if (loggedUser != model.MessageSender)
                {
                    model.MessageReciever = model.MessageSender;
                    model.MessageSubject = "Re : " + model.MessageSubject;
                }
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult SendMessage(Message msg)
        {
            msg.MessageSender = (string)Session["WriterMail"];
            msg.MessageDate = DateTime.Now;
            msg.IsMessageRead = false;
            msg.MessageStatus = "a";
            mm.AddNewMessage(msg);

            return RedirectToAction("Sendbox","WriterMessage");
        }

        public ActionResult ReadMessageForWriter(int id)
        {
            var model = mm.GetMessageByID(id);
            model.IsMessageRead = true;
            mm.UpdateMessage(model);
            return View(model);
        }
        public PartialViewResult GetSideBarForUserMessage()
        {            var loggedUser = (string)Session["WriterMail"];

            ViewBag.UnreadMessageCount = mm.GetUnreadMessageCount(loggedUser);
            return PartialView();
        }

        public ActionResult DeleteMessage(int id)
        {
            var loggedUser = (string)Session["WriterMail"];
            var model = mm.GetMessageByID(id);
            model.IsMessageRead = true;
            if (model.MessageStatus == "a")
            {
                model.MessageStatus = "p";

                mm.UpdateMessage(model);
                if (loggedUser == model.MessageSender)
                {
                    return RedirectToAction("Sendbox","WriterMessage");
                }
                else
                {
                    return RedirectToAction("Inbox","WriterMessage");
                }

            }
            else
            {
                model.MessageStatus = "n";
                mm.UpdateMessage(model);
                return RedirectToAction("GetDeletedMessages","WriterMessage");
            }


        }
        public ActionResult GetDeletedMessages()
        {
            var loggedUser = (string)Session["WriterMail"];
            var model = mm.GetAllDeletedMessages(loggedUser, "p");

            return View(model);
        }
        public ActionResult DeleteAllMessages()
        {
            var loggedUser = (string)Session["WriterMail"];
            var model = mm.GetAllDeletedMessages(loggedUser, "p");

            for (int i = 0; i < model.Count; i++)
            {
                model[i].MessageStatus = "n";
                mm.UpdateMessage(model[i]);
            }

            return RedirectToAction("GetDeletedMessages", "WriterMessage");
        }

    }
}