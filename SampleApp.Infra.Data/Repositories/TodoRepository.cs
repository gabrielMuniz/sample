using SampleApp.Domain.Entities;
using SampleApp.Domain.Interfaces.Repositories;
using SampleApp.Infra.Data.Contexts;
using SampleApp.Infra.Data.Repositories.Base;

namespace SampleApp.Infra.Data.Repositories
{
    public class TodoRepository : RepositoryBase<Todo>, ITodoRepository
    {
        public TodoRepository(DefaultContext context) : base(context)
        {
        }
    }
}
