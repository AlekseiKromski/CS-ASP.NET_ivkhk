using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace football.Models
{
    public class Team
    {
        public int id { get; set; }
        [Display(Name = "Название команды")]
        public string Name { get; set; }
        [Display(Name = "Фамилия тренера")]

        public string Coach { get; set; }
        public ICollection<Player> Players { get; set; }
        public Team()
        {
            Players = new List<Player>();
        }
    }
}