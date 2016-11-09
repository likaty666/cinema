namespace Cinema.DataLayer.DBLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SessionsDate")]
    public partial class SessionsDate
    {
        [Key]
        public int ses_id { get; set; }

        public int? film_id { get; set; }

        public int? hall_id { get; set; }

        public DateTime? sesDate { get; set; }

        public virtual Film Film { get; set; }

        public virtual Hall Hall { get; set; }
    }
}
