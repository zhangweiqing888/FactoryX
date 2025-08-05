using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FactoryX.Domain.Interfaces;
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
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IProductionRecordRepository, ProductionRecordRepository>();
		services.AddScoped<IDowntimeRepository, DowntimeRepository>();
        services.AddScoped<IMaterialRepository, MaterialRepository>();
        services.AddScoped<IMaterialUsageRepository, MaterialUsageRepository>();
		services.AddScoped<IRepositoryManager, RepositoryManager>();
        //services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        

		return services;
    }
}