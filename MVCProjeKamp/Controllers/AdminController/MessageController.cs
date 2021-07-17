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
    public class MessageController : Controller
    {
      
        MessageManager mm = new MessageManager(new GenericRepository<Message>());
        MessageValidator mv = new MessageValidator();
        // GET: Message
        public ActionResult Inbox()
        {
            var loggedUser = (string)Session["AdminUserName"];
            var model = mm.GetMessageInbox(loggedUser);
            ViewBag.a = User.Identity.Name;

            return View(model);
        }
        public ActionResult Sendbox()
        {
        
            var model = mm.GetMessageSendbox(User.Identity.Name);
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
            msg.MessageSender = User.Identity.Name;
            msg.MessageDate = DateTime.Now;
            ValidationResult result = mv.Validate(msg);
            if (result.Errors.Count > 0)
            {
                foreach (var err in result.Errors)
                {
                    ModelState.AddModelError(err.PropertyName, err.ErrorMessage);
                }
                return View();
            }
            else
            {
                mm.AddNewMessage(msg);
            }

            return RedirectToAction("Inbox");
        }

        public ActionResult ReadMessageFromAdmin(int id)
        {
          
            var model = mm.GetMessageByID(id);

            return View(model);
        }
    }
}