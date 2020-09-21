using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Picture
    {

        public int id { get; set; }

        [Display(Name = "Название")]
        public string title { get; set; }

        [Display(Name = "Год")]
        public int year { get; set; }

        [Display(Name = "Музей")]
        public string museum { get; set; }

        public byte[] canvas { get; set; }
        public string canvasType { get; set; }
        

    }
}