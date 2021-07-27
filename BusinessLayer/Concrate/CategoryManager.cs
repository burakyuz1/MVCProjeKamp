using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrate.Repositories;
using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusinessLayer.Concrate
{
    public class CategoryManager : ICategoryService
    {
        IRepository<Category> _cat;
        public CategoryManager(IRepository<Category> category)
        {
            _cat = category;
        }

        public void AddNewCategory(Category category)
        {
            _cat.Add(category);
           
        }

        public void DeleteCategory(Category category)
        {
            _cat.Delete(category);
        }

        public Category GetCategoryByID(int id)
        {
            return _cat.Get(x => x.CategoryID == id);
        }

        public void UpdateCategory(Category category)
        {
            _cat.Update(category);
        }

        public List<Category> GetCategoryList()
        {
            return _cat.List(x=>x.CategoryStatus == true);
        }
        public int GetCategoryListByStatus()
        {
            int trueStatus = _cat.List(x => x.CategoryStatus == true).Count;
            int falseStatus = _cat.List(x => x.CategoryStatus == false).Count;

            return trueStatus - falseStatus;
        }


    }
}