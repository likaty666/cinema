﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.DataLayer.DBLayer;
using Cinema.Repository.Repositories;
using System.Data.Entity;

namespace Cinema.Service.Services
{
    public class StatussRepository : GenericRepository<Statuss>
    {
        public StatussRepository(DbContext context) : base(context) { }
    }
}
