using Microsoft.EntityFrameworkCore;
using SampleApp.Domain.Interfaces.Repositories.Base;
using SampleApp.Infra.Data.Contexts;
using System;
using System.Collections.Generic;

namespace SampleApp.Infra.Data.Repositories.Base
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private DefaultContext _context;

        public RepositoryBase(DefaultContext context)
        {
            _context = context;
        }

        public int Delete(T entity)
        {
            var result = _context.Set<T>().Remove(entity).State;
            _context.SaveChanges();
            return Convert.ToInt32(result);
        }

        public IEnumerable<T> GetAll()
            => _context.Set<T>();
        
        public T GetById(Guid id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Save(T entity)
        {
            _context.Add<T>(entity);
            _context.SaveChanges();
        }

        public T Update(T entity)
        {
            var result = _context.Set<T>().Update(entity);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}
