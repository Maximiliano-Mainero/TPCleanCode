
using CBTeam.Domain.Interfaces;
using CBTeam.Infrastructure.Database;
using CBTeam.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace CBTeam.Infrastructure
{
    public static class Installer
    {
        public static void InstallRepositories(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<SqlServerContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
