using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNet.Models
{
    public class Message
    {
        // свойства
        public int Id { get; set; } // айдишник для entity framework

        [Display(Name = "Заголовок")]
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Title { get; set; }

        [Display(Name = "Текст")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Это поле должно быть заполнено")]
        public string Text { get; set; }

        [Display(Name = "Дата")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime PublishDate { get; set; }

        public virtual ICollection<Reply> Replies { get; set; } = new List<Reply>();

        [ScaffoldColumn(false)] // Прячем поле Text2 из HTML
        public string Text2 { get; set; }

        [HiddenInput] // Поле остается в НTML, но становится скрытое для пользователя
        [NotMapped]   // Поле не будет добавляться в БД
        public string Text3  { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

    }
}