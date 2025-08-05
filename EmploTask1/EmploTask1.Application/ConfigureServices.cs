using EmploTask1.Application.Abstractions;
using EmploTask1.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EmploTask1.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeService, EmployeeService>();
            return services;
        }

    }
}
