using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FactoryX.Domain.Interfaces;
using FactoryX.Application.Services;
using FactoryX.Infrastructure.Contracts;
using FactoryX.Infrastructure.Repositories;

namespace FactoryX.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(connectionString));

        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IMachineRepository, MachineRepository>();
        services.AddScoped<IOperatorRepository, OperatorRepository>();
		services.AddScoped<IShiftRepository, ShiftRepository>();
		services.AddScoped<IWorkOrderRepository, WorkOrderRepository>();
		services.AddScoped<IRepositoryManager, RepositoryManager>();
        //services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        

		return services;
    }
}