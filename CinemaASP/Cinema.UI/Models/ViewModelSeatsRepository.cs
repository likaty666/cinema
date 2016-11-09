using Cinema.DataLayer.DBLayer;
using Cinema.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema.UI.Models
{
    public class ViewModelSeatsRepository
    {

        IGenericRepository<Hall> repohall;
        IGenericRepository<Ticket> repotic;

        public ViewModelSeatsRepository(IGenericRepository<Hall> repohall, IGenericRepository<Ticket> repotic)
        {
            this.repohall = repohall;
            this.repotic = repotic;
        }



        public IEnumerable<ViewModelSeat> GetAll()
        {
            return from f in repotic.GetAll().AsQueryable()
                   join p in repohall.GetAll().AsQueryable() on f.hall_id equals p.hall_id into grp
                   from gr in grp.DefaultIfEmpty()

                   select new ViewModelSeat
                   {
                       sid=f.ticket_id,
                       ses_id = f.ses_id,
                       seat=f.seat,
                       seats = gr.seats

                   };
        }
    }
}