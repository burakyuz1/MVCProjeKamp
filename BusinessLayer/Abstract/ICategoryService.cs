using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetCategoryList();
        void AddNewCategory(Category category);
        Category GetCategoryByID(int id);
        void DeleteCategory(Category category);
        void UpdateCategory(Category category);

       int GetCategoryListByStatus();
    }
}
