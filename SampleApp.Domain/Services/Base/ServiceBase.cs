using SampleApp.Domain.Interfaces.Repositories.Base;
using SampleApp.Domain.Interfaces.Services.Base;
using System;
using System.Collections.Generic;

namespace SampleApp.Domain.Services.Base
{
    public abstract class ServiceBase<T> : IServiceBase<T> where T : class
    {

        private IRepositoryBase<T> _repository;

        public ServiceBase(IRepositoryBase<T> repository)
        {
            _repository = repository;
        }

        public int Delete(T entity)
        {
            return _repository.Delete(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public T GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        public void Save(T entity)
        {
            _repository.Save(entity);
        }

        public T Update(T entity)
        {
            return _repository.Update(entity);
        }
    }
}
