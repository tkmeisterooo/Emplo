using EmploTask2.Domain.Abstractions.Repositories;
using EmploTask2.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EmploTask2.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<ITeamRepository, TeamRepository>();
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql("Host=localhost;Port=5432;Database=emplo2;Username=postgres;Password=postgres");
            });
            return services;
        }
    }
}