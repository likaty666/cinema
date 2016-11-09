using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cinema.UI.Models
{
    public class ViewModelSeat
    {
        [Key]
        public int sid { get; set; }

        public int ses_id { get; set; }


        public int seat { get; set; }

       

        public int seats { get; set; }
    }
}