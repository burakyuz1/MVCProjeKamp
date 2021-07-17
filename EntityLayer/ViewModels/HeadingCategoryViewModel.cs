using EntityLayer.Concrate;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntityLayer.ViewModels
{
    public class HeadingCategoryViewModel
    {
        public IEnumerable Category { get; set; }
        public Heading Heading { get; set; }
    }
}