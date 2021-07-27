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

        public List<Writer> GetWriterList(string writerForSearch)
        {
            return _writer.List(x => x.WriterName.Contains(writerForSearch) || x.WriterSurname.Contains(writerForSearch) && x.WriterStatus == true);
        }

        public List<Writer> GetWriterList(bool status)
        {
            if (status)
            {
                return _writer.List(x => x.WriterStatus == true);
            }
            else
            {
                return _writer.List(x => x.WriterStatus == false);
            }

        }

    }
}

