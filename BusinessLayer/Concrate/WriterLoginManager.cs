using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusinessLayer.Concrate
{
    public class WriterLoginManager : IWriterLoginService
    {
        IRepository<Writer> _writerLogin;

        public WriterLoginManager(IRepository<Writer> writerLogin)
        {
            _writerLogin = writerLogin;
        }

        public Writer GetWriter(Writer writer)
        {
            return _writerLogin.Get(x => x.WriterMail == writer.WriterMail && x.WriterPassword == writer.WriterPassword);
        }

        public Writer GetWriterFromSession(string userName)
        {
            return _writerLogin.Get(x => x.WriterMail == userName);
        }

      
    }
}