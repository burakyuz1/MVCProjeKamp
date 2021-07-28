using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DataAccessLayer.Concrate
{
    public class Context : DbContext //DBContext Sınıfından Miras alınıyor. Bunun için NuGET'den EntityFramework Projeye eklendi
    {
        public DbSet<About> Abouts { get; set; } //Kullanabilmem için Referanslarına EntityFramework projemi ekledim.
        //DbSet -> DbContent Sınıfına ait bir sınıf, İçerisine EntityFramework projesinde oluşturduğumuz classları verdik,
        // görevi -> içindeki değerleri migrate ettikten sonra Abouts Tablosunun içerisine basmak.
        public DbSet<Heading> Headings { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Content> Contents { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Message> Messages { get; set; }
        //public DbSet<Admin> Admins{ get; set; }
    }
}