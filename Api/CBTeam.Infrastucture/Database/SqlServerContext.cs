using CBTeam.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CBTeam.Infrastructure.Database
{
    public class SqlServerContext : DbContext
    {
        public SqlServerContext(DbContextOptions<SqlServerContext> options)
            : base(options) 
        {           
        }

        //public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
