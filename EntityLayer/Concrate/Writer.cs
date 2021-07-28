using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrate
{
    public class Writer
    {
        [Key]
        public int WriterID { get; set; }


        
        [StringLength(20,ErrorMessage =("Cant more than 20 characters"))]
        [Required(ErrorMessage = "This field can not be empty")]
        [MinLength(2, ErrorMessage = "Cant less than 2 characters")]
        public string WriterName { get; set; }


        [StringLength(20, ErrorMessage = ("Cant more than 20 characters"))]
        [Required(ErrorMessage = "This field can not be empty")]       
        [DisplayName("Writer surname")]
        [MinLength(2, ErrorMessage = "Cant less than 2 characters")]
        public string WriterSurname { get; set; }

        [StringLength(200)]
        [Required]
        public string WriterMail { get; set; }
        [StringLength(200)]
        [MinLength(8, ErrorMessage = "Cant less than 8 characters")]
        [Required]

        public string WriterPassword { get; set; }

        [StringLength(20, ErrorMessage = ("Cant more than 20 characters"))]
        [Required(ErrorMessage = "This field can not be empty")]

        public string WriterTitle { get; set; }

        [StringLength(200, ErrorMessage = ("Cant more than 20 characters"))]
        [MinLength(10, ErrorMessage = "Cant less than 10 characters")]
        [Required(ErrorMessage = "This field can not be empty")]
        public string WriterAbout { get; set; }

        [StringLength(200)]
        [Required]
        public string WriterPicture { get; set; }

        [StringLength(1)]
        public string WriterRole { get; set; }

        public bool WriterStatus { get; set; }

        public ICollection<Heading> Headings { get; set; }

        public ICollection<Content> Contents { get; set; }

    }
}