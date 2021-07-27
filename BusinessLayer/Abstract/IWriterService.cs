using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IWriterService
    {
        List<Writer> GetWriterList(bool status);
        void AddWriter(Writer writer);
        void DeleteWriter(Writer writer);
        void UpdateWriter(Writer writer);
        Writer GetWriterByID(int id);
        Writer GetWriterByEmail(string mail);
        List<Writer> GetWriterList(string writerForSearch);

    }
}
