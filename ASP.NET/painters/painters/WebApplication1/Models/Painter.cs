using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Models
{
    public class Painter
    {
        public int id { get; set; }

        [Display(Name = "Фамилия и имя")]
        public string name { get; set; }

        [Display(Name = "Страна")]
        public string country { get; set; }

        [Display(Name = "Биография")]
        public string biography { get; set;}

        [Display(Name = "Фото")]
        public byte[] photo { get; set; }
        public string photoType { get; set; }

        public ICollection<Picture> pictures { get; set; } 

        //Создаем конструктор класса 
        public Painter()
        {
            this.pictures = new List<Picture>();
        }
    }
}