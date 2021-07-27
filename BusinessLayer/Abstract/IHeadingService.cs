using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IHeadingService
    {
        List<Heading> GetHeadingsByName(string categoryName);
        List<Heading> GetHeadingsByWriterName(string userName);
        void AddHeading(Heading heading);
        void UpdateHeading(Heading heading);
        void DeleteHeading(Heading heading);
        List<Heading> GetHeadingList(bool status);
        Heading GetHeadingByID(int id);

        int CategoryCount(string categoryName);



    }
}
