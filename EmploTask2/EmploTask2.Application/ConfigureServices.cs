using EmploTask2.Application.Abstractions;
using EmploTask2.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EmploTask2.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddTransient<IEmployeeService, EmployeeService>();
        return services;
    }
}