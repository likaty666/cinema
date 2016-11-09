using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cinema.UI.Models
{
    public class ViewModelHall
    {
        [Key]
       
        public int? film_id { get; set; }

         public int ses_id { get; set; }

        public int? hall_id { get; set; }

        public DateTime? sesDate { get; set; }

        public string name { get; set; }

        public int status_id { get; set; }

        public int seats { get; set; }
        public int seatTaken { get; set; }
    }
}