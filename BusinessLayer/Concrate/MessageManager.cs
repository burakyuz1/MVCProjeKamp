using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusinessLayer.Concrate
{
    public class MessageManager : IMessageService
    {
        IRepository<Message> _message;

        public MessageManager(IRepository<Message> message)
        {
            _message = message;
        }

        public void AddNewMessage(Message message)
        {
            _message.Add(message);
        }

        public void DeleteMessage(Message message)
        {
            _message.Delete(message);
        }

        public List<Message> GetAllDeletedMessages(string userName, string status)
        {
            return _message.List(x => x.MessageStatus == status && (x.MessageSender == userName || x.MessageReciever == userName));
        }

        public Message GetMessageByID(int? id)
        {
            return _message.Get(x => x.MessageID == id);
        }

        public List<Message> GetMessageInbox(string userName, string status)
        {
            return _message.List(x => x.MessageReciever == userName && x.MessageStatus == status);
        }

  

        public List<Message> GetMessageSendbox(string userName, string status)
        {
            return _message.List(x => x.MessageSender == userName && x.MessageStatus == status);
        }

        public int GetUnreadMessageCount(string loggedUser)
        {
            return _message.List(x => x.IsMessageRead == false && x.MessageReciever == loggedUser).Count;
        }

        public void UpdateMessage(Message message)
        {
            _message.Update(message);
        }
    }
}