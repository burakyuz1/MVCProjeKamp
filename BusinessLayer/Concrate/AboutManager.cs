using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusinessLayer.Concrate
{
    public class AboutManager : IAboutService
    {
        IRepository<About> _about;

        public AboutManager(IRepository<About> about)
        {
            _about = about;
        }

        public void AddNewAbout(About about)
        {
            _about.Add(about);
        }

        public void DeleteAbout(About about)
        {
            _about.Delete(about);
        }

        public List<About> GetAboutList()
        {
            return _about.List();
        }

        public void UpdateAbout(About about)
        {
            _about.Update(about);
        }
    }
}