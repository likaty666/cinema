﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Repository.Repositories
{
    public interface IGenericRepository<T>
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate);
        T Get(int id);
        void AddOrUpdate(T obj);
        void Renew(T obj);
        void SaveChanges();
        void Delete(T obj);
    }
}
