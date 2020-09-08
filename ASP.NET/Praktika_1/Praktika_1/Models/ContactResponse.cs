using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Praktika_1.Models
{
    public class ContactResponse
    {
        [Required(ErrorMessage = "Please enter your first name")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Please enter your last name")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Please enter your email address")]
        [RegularExpression(@".+\@.+\..+", ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please enter your text")]
        public string Text { get; set; }
    }
}