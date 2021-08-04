using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusinessLayer.Concrate
{
    public class HeadingManager : IHeadingService
    {
        IRepository<Heading> _headings;
        public HeadingManager(IRepository<Heading> heading)
        {
            _headings = heading;
        }

        public void AddHeading(Heading heading)
        {
            _headings.Add(heading);
        }

        public void DeleteHeading(Heading heading)
        {
            _headings.Update(heading);
        }

        public List<Heading> GetHeadingList(bool status)
        {
            if (status)
            {
                return _headings.List(x => x.HeadingStatus == true);
            }
            else
            {
                return _headings.List(x => x.HeadingStatus == false);
            }

        }

        public Heading GetHeadingByID(int id)
        {
            return _headings.Get(x => x.HeadingID == id);
        }

        public List<Heading> GetHeadingsByName(string categoryName)
        {
            return _headings.List(x => x.Category.CategoryName == categoryName);
        }

        public void UpdateHeading(Heading heading)
        {
            _headings.Update(heading);
        }

        public List<Heading> GetHeadingsByWriterName(string userName)
        {
            return _headings.List(x => x.Writer.WriterMail == userName && x.HeadingStatus == true);
        }

        public int CategoryCount(string categoryName)
        {
            return _headings.List(x => x.Category.CategoryName == categoryName).Count;
        }

        public List<Heading> GetHeadingByWriterID(int? id , bool status)
        {
            return _headings.List(m => m.WriterID == id && m.HeadingStatus == status);
        }
    }
}