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
    public class MessageController : Controller
    {

        MessageManager mm = new MessageManager(new GenericRepository<Message>());

        public ActionResult Inbox()
        {
            var loggedUser = (string)Session["WriterMail"];
            var model = mm.GetMessageInbox(loggedUser, "a");

            //a -> Active
            //p -> Passive
            //n -> None

            return View(model);
        }
        public ActionResult Sendbox()
        {
            var loggedUser = (string)Session["WriterMail"];
            var model = mm.GetMessageSendbox(loggedUser, "a");
            return View(model);
        }

        //ReplyMessage ViewInı sil

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
            msg.IsMessageRead = false;
            msg.MessageStatus = "a";
            msg.MessageDate = DateTime.Now;

            //if (!ModelState.IsValid)
            //{

            //    return View();
            //}
            //else
            //{  }

            mm.AddNewMessage(msg);

            return RedirectToAction("Sendbox");
        }

        public ActionResult ReadMessageFromAdmin(int id)
        {
            var model = mm.GetMessageByID(id);
            model.IsMessageRead = true;
            mm.UpdateMessage(model);
            return View(model);
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
                    return RedirectToAction("Sendbox");
                }
                else
                {
                    return RedirectToAction("Inbox");
                }

            }
            else
            {
                model.MessageStatus = "n";
                mm.UpdateMessage(model);
                return RedirectToAction("GetDeletedMessages");
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

            return RedirectToAction("GetDeletedMessages");
        }
    }
}