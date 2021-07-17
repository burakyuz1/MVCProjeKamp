using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusinessLayer.Concrate
{
    public class ContentManager : IContentService
    {
        IRepository<Content> _content;
        public ContentManager(IRepository<Content> content)
        {
            _content = content;
        }

        public void AddContent(Content content)
        {
            _content.Add(content);
        }

        public void DeleteContent(Content content)
        {
            _content.Delete(content);
        }

        public List<Content> GetContentByHeadingID(int id)
        {
            return _content.List(x => x.HeadingID == id);
        }

        public List<Content> GetContentByLoggedUser(string userName)
        {
            return _content.List(x => x.Writer.WriterMail == userName);
        }

        public List<Content> GetContentList()
        {
            return _content.List();
        }

     

        public void UpdateContent(Content content)
        {
            _content.Update(content);
        }
    }
}