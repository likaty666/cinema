using Cinema.DataLayer.DBLayer;
using Cinema.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema.UI.Models
{
    public class ViewModelHallRepository
    {
        IGenericRepository<Hall> repohall;
        IGenericRepository<Ticket> repotic;
        IGenericRepository<SessionsDate> reposes;
        public ViewModelHallRepository(IGenericRepository<Hall> repohall,IGenericRepository<SessionsDate> reposes)
        {
           
            this.repohall = repohall;
            this.reposes = reposes;
        }



        public IEnumerable<ViewModelHall> GetAll()
        {
            return from f in reposes.GetAll().AsQueryable()
                  
                   join p in repohall.GetAll().AsQueryable() on f.hall_id equals p.hall_id into grp
                   from gr in grp.DefaultIfEmpty()

                   select new ViewModelHall
                   {
                       ses_id = f.ses_id,
                       film_id = f.film_id,
                       hall_id = f.hall_id,
                       sesDate = f.sesDate,
                       name = gr.name,
                       status_id = gr.status_id,
                       seats = gr.seats,
                     
                   };
        }
    }
}