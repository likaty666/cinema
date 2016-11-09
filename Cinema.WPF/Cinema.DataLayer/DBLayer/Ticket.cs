namespace Cinema.DataLayer.DBLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ticket")]
    public partial class Ticket
    {
        [Key]
        public int ticket_id { get; set; }

        public int film_id { get; set; }

        public int hall_id { get; set; }

        public decimal price { get; set; }

        public DateTime? sessionDate { get; set; }

        public virtual Film Film { get; set; }

        public virtual Hall Hall { get; set; }
    }
}
