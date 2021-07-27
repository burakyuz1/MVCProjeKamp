using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {
        List<Message> GetMessageInbox(string userName, string status);
        List<Message> GetMessageSendbox(string userName, string status);
        List<Message> GetAllDeletedMessages(string userName, string status);
        void AddNewMessage(Message message);
        Message GetMessageByID(int? id);
        void DeleteMessage(Message message);
        void UpdateMessage(Message message);
        int GetUnreadMessageCount(string loggedUser);
    }
}
