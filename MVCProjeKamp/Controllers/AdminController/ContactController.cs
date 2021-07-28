using BusinessLayer.Concrate;
using DataAccessLayer.Concrate.Repositories;
using EntityLayer.Concrate;
using EntityLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKamp.Controllers
{
    public class ContactController : Controller
    {
        ContactManager contactManager = new ContactManager(new GenericRepository<Contact>());
        MessageManager mm = new MessageManager(new GenericRepository<Message>());


        // GET: Contact
        public ActionResult Index()
        {
            var model = contactManager.GetContactList();
            return View(model);
        }
        public PartialViewResult GetSideBarForMessage()
        {
            var loggedUser = (string)Session["WriterMail"];
            ViewBag.UnreadCount = contactManager.GetUnreadContactCount();
            ViewBag.UnreadMessageCount = mm.GetUnreadMessageCount(loggedUser);
            return PartialView();
        }
        public ActionResult ReadMessageFromContact(int id)
        {

            var model = contactManager.GetContactByID(id);
            model.IsContactRead = true;
            contactManager.UpdateContact(model);
            

            return View(model);
        }
    }
}