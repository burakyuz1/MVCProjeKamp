using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EntityLayer.Concrate
{
    public class Heading
    {
        [Key]
        public int HeadingID { get; set; }
      
        [StringLength(20)] 
        [Required(ErrorMessage = "This field can not be empty !")]
        public string HeadingName { get; set; }


        public DateTime HeadingDate { get; set; }

      
        public int WriterID { get; set; }
        public virtual Writer Writer { get; set; }

        [Required(ErrorMessage = "Please choose a category ...")]
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }

        public bool HeadingStatus { get; set; }

        public ICollection<Content> Contents { get; set; }
    }
}