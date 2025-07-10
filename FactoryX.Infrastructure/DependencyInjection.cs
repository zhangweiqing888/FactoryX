using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FactoryX.Domain.Interfaces;
using FactoryX.Application.Services;

namespace FactoryX.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(connectionString));

        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}