using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EntityLayer.Concrate
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }
        [StringLength(50)]
        public string AdminUserName { get; set; }
        [StringLength(200)]
        public string AdminPassword { get; set; }

        [StringLength(1)]
        public string Role { get; set; }
    }
}