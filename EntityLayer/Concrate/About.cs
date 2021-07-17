using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EntityLayer.Concrate
{
    public class About
    {
        [Key] //Identity olduğunu belirtiyo. Kullanabilmem için yine NuGet package -> EntityFramework'ü projeme ekledim.
        public int AboutID { get; set; }
        [StringLength(1000)]
        public string AboutDetails1 { get; set; }
        [StringLength(1000)]
        public string AboutDetails2 { get; set; }
        [StringLength(100)]
        public string AboutImage1{ get; set; }
        [StringLength(100)]
        public string AboutImage2 { get; set; }
    }
}