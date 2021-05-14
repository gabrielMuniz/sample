using SampleApp.Domain.Entities;
using SampleApp.Domain.Interfaces.Repositories;
using SampleApp.Domain.Interfaces.Services;
using SampleApp.Domain.Services.Base;

namespace SampleApp.Domain.Services
{
    public class TodoService : ServiceBase<Todo>, ITodoService
    {

        private ITodoRepository _todoRepository;

        public TodoService(ITodoRepository repository) : base(repository)
        {
            _todoRepository = repository;
        }
    }
}
