using SampleApp.Domain.Entities;
using SampleApp.Domain.Interfaces.Repositories.Base;

namespace SampleApp.Domain.Interfaces.Repositories
{
    public interface ITodoRepository : IRepositoryBase<Todo>
    {
    }
}
