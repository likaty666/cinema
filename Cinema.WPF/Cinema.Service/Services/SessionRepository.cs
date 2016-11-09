using Cinema.DataLayer.DBLayer;
using Cinema.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Service.Services
{
    class SessionRepository : GenericRepository<SessionsDate>
    {
        public SessionRepository(DbContext context) : base(context) { }
    }
}
