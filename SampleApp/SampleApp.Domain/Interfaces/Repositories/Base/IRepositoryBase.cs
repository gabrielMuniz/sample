using System;
using System.Collections.Generic;

namespace SampleApp.Domain.Interfaces.Repositories.Base
{
    public interface IRepositoryBase<T> where T : class
    {

        void Save(T entity);
        T GetById(Guid id);
        IEnumerable<T> GetAll();
        T Update(T entity);
        int Delete(T entity);
    }
}