using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace DataAccessLayer.Concrate.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T: class // T classına sahip olacağını, IRepository Interface'inden miras aldığını (Yani onun özelliklerini kullanabilir) 
    {
        Context c = new Context(); //Context yani bağlantıyı açtım.
        DbSet<T> _object; // Yukarıda gelen T sınıfına ait objeyi _object field'ının içine attım.
       
        public GenericRepository()//Consructer oluşturdum. 
        {
            _object = c.Set<T>(); //Context'in içindeki nesneyi _object field'ına öğrettim. Yani Başlık mı - Writer mı geliyor?
        }



        //CRUD işlemleri
        public void Add(T p)
        {
            var addedEntity = c.Entry(p);
            addedEntity.State = EntityState.Added;
            c.SaveChanges();
        }

        public void Delete(T p)
        {
            var deletedEntity = c.Entry(p);
            deletedEntity.State = EntityState.Deleted;
            c.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter);
        }

    

        public List<T> List()
        {
            return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> find) //Şartlı bulma işlemi, google'dan buldum.
        {
            return _object.Where(find).ToList(); //IReposity interface'inden gelen "find" değişkenini liste içinde arayıp List'e çevirip return ediyor.
                                              

        }


        public void Update(T p)
        {
            var updatedEntity = c.Entry(p);
            updatedEntity.State = EntityState.Modified;
            c.SaveChanges();
        }
    }
}