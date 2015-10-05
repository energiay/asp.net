using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNet.Models
{
    public class Reply
    {
        //свойства
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime PublishDate { get; set; }

        public int MessageId { get; set; }
        public virtual Message Message { get; set; } // что бы слинковать сообщения

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}