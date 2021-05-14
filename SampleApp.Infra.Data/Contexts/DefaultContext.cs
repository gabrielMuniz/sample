using Microsoft.EntityFrameworkCore;
using SampleApp.Domain.Entities;

namespace SampleApp.Infra.Data.Contexts
{
    public class DefaultContext : DbContext
    {

        public DbSet<Todo> Todoes { get; set; }

        public DefaultContext(DbContextOptions options) : base(options)
        {

        }

    }
}
