using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContentService
    {
        void AddContent(Content content);
        void DeleteContent(Content content);
        void UpdateContent(Content content);
        List<Content> GetContentList();
        List<Content> GetContentByHeadingID(int id);
        List<Content> GetContentByLoggedUser(string userName);



    }
}
