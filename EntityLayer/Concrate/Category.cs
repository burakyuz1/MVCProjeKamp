using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EntityLayer.Concrate
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }

        [StringLength(51)]   
        public string CategoryName { get; set; }

        [StringLength(200)]    
        public string CategoryDescription { get; set; }
        public bool CategoryStatus { get; set; }

        public ICollection<Heading> Headings { get; set; }

    }
}