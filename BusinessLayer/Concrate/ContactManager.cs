using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusinessLayer.Concrate
{
    public class ContactManager : IContactService
    {
        IRepository<Contact> _contact;

        public ContactManager(IRepository<Contact> contact)
        {
            _contact = contact;
        }

        public void AddNewContact(Contact contact)
        {
            _contact.Add(contact);
        }

        public void DeleteContact(Contact contact)
        {
            _contact.Delete(contact);
        }

        public Contact GetContactByID(int id)
        {
            return _contact.Get(x => x.ContactID == id);

        }

        public List<Contact> GetContactList()
        {
            return _contact.List();
        }

        public int GetUnreadContactCount()
        {
            return _contact.List(x => x.IsContactRead == false).Count;
        }

        public void UpdateContact(Contact contact)
        {
            _contact.Update(contact);
        }
    }
}