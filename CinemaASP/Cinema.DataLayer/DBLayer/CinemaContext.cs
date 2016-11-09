namespace Cinema.DataLayer.DBLayer
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CinemaContext : DbContext
    {
        public CinemaContext()
            : base("name=CinemaContext2")
        {
        }

        public virtual DbSet<Film> Films { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Hall> Halls { get; set; }
        public virtual DbSet<Photo> Photos { get; set; }
        public virtual DbSet<SessionsDate> SessionsDates { get; set; }
        public virtual DbSet<Statuss> Statusses { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Film>()
                .HasMany(e => e.Photos)
                .WithRequired(e => e.Film)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Film>()
                .HasMany(e => e.Tickets)
                .WithRequired(e => e.Film)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Hall>()
                .HasMany(e => e.Tickets)
                .WithRequired(e => e.Hall)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SessionsDate>()
                .HasMany(e => e.Tickets)
                .WithRequired(e => e.SessionsDate)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Statuss>()
                .HasMany(e => e.Halls)
                .WithRequired(e => e.Statuss)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ticket>()
                .Property(e => e.price)
                .HasPrecision(18, 0);
        }
    }
}
