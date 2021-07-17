using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IRepository<T> // Bu interface T Class ı bekler. Bu tablolarımızdan harhangi biri olabilir.
        //Aşağıda CRUD işlemleri yapar. Ama işlevsel hale gelmesi için. ~/Repositories/GenericReposity içinde implement edildi
    {
        List<T> List();
        void Add(T p);
        void Delete(T p);
        void Update(T p);
        T Get(Expression<Func<T, bool>> filter);
        List<T> List(Expression<Func<T, bool>> find);
  



    }
}
