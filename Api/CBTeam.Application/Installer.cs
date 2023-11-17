using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CBTeam.Application
{
    public static class Installer
    {
        public static void AddInfrasctucture(this IServiceCollection services)
        {
            services.AddMediatR(x => x.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
