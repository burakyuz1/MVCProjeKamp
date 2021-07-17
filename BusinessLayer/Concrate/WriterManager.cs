using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusinessLayer.Concrate
{
    public class WriterManager : IWriterService
    {
        IRepository<Writer> _writer;

        public WriterManager(IRepository<Writer> writer)
        {
            _writer = writer;
        }

        public void AddWriter(Writer writer)
        {
             _writer.Add(writer);
        }

        public void DeleteWriter(Writer writer)
        {
            _writer.Delete(writer);
        }

        public List<Writer> GetWriterList()
        {
            return _writer.List();
        }

        public Writer GetWriterByID(int id)
        {
            return _writer.Get(x => x.WriterID == id);
        }

        public void UpdateWriter(Writer writer)
        {
            _writer.Update(writer);
        }

        public Writer GetWriterByEmail(string mail)
        {
            return _writer.Get(x => x.WriterMail == mail);
        }
    }
}