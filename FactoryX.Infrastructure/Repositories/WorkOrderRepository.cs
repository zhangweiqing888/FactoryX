using FactoryX.Domain.Entities;
using FactoryX.Infrastructure.Contracts;

namespace FactoryX.Infrastructure.Repositories;

public class WorkOrderRepository : BaseRepository<WorkOrder>, IWorkOrderRepository
{
	public WorkOrderRepository(AppDbContext context) : base(context)
	{
	}
}
