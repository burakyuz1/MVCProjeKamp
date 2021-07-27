using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrate
{
    public class Writer
    {
        [Key]
        public int WriterID { get; set; }


        [StringLength(20)]
        [Required]
     
        public string WriterName { get; set; }


        [StringLength(20)]
        [Required]       
        [DisplayName("Writer surname")]
        public string WriterSurname { get; set; }
        [StringLength(200)]
        [Required]

        public string WriterMail { get; set; }
        [StringLength(200)]
        [Required]

        public string WriterPassword { get; set; }

        [StringLength(20)]
        [Required]

        public string WriterTitle { get; set; }

        [StringLength(200)]
        [Required]
        public string WriterAbout { get; set; }

        [StringLength(200)]
        [Required]
        public string WriterPicture { get; set; }

      
        public bool WriterStatus { get; set; }

        public ICollection<Heading> Headings { get; set; }

        public ICollection<Content> Contents { get; set; }

    }
}