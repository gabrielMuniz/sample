using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SampleApp.Domain.Entities.Enums;
using SampleApp.Domain.Interfaces.Repositories;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SampleApp.SampleApi.HostedServices
{
    public class UpdateStatusTodoService : IHostedService, IDisposable
    {
        public IServiceProvider ServiceProvider { get; set; }
        private Timer _timer;

        public UpdateStatusTodoService(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(UpdatePriority, null, 0, 200000);
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        private void UpdatePriority(object state)
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                var todoRepository = scope.ServiceProvider.GetRequiredService<ITodoRepository>();

                var todoes = todoRepository.GetAll().ToList()
                    .Where(todo => todo.DueDate.Date == DateTime.Now.Date)
                    .Where(todo => todo.Priority != Priority.HIGH)
                    .ToList();

                foreach(var todo in todoes)
                {
                    todo.ChangePriority(Priority.HIGH);

                    todoRepository.Update(todo);
                }

            }
        }
    }
}
