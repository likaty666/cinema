using Cinema.DataLayer.DBLayer;
using Cinema.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema.UI.Models
{
    public class ViewModelTicketRepository
    {
        IGenericRepository<Film> repofilm;
        IGenericRepository<Hall> repohall;
        IGenericRepository<Ticket> repoticket;

        public ViewModelTicketRepository(IGenericRepository<Film> repofilm,IGenericRepository<Hall> repohall,IGenericRepository<Ticket> repoticket)
        {
            this.repofilm = repofilm;
            this.repohall = repohall;
            this.repoticket = repoticket;
        }
        public IEnumerable<ViewModelTicket> GetAll()
        {
            return from t in repoticket.GetAll().AsQueryable()
                   join f in repofilm.GetAll().AsQueryable() on t.film_id equals f.film_id
                   join h in repohall.GetAll().AsQueryable() on t.hall_id equals h.hall_id
                   into grp
                   from gr in grp.DefaultIfEmpty()

                   select new ViewModelTicket
                   {
                       ticket_id=t.ticket_id,
                       name=gr.name,
                       title=f.title,
                       price=t.price,
                       sessionDate=t.sessionDate,
                       seat=t.seat
                   };

           
        }
    }
}