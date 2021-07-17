using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EntityLayer.Concrate
{
    public class Message
    {
        [Key]
        public int MessageID { get; set; }

        [StringLength(150)]
        public string MessageSender { get; set; }
        [StringLength(150)]
        public string MessageReciever { get; set; }
        [StringLength(20)]
        public string MessageSubject { get; set; }
        [StringLength(400)]      
        public string MessageContent { get; set; }

      
        public bool? IsMessageRead { get; set; }
        public DateTime MessageDate { get; set; }
    }
}