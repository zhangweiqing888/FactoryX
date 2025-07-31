using AutoMapper;
using FactoryX.Application.DTOs;
using FactoryX.Domain.Entities;

namespace FactoryX.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Machine, MachineDto>().ReverseMap();
        CreateMap<Operator, OperatorDto>().ReverseMap();
        CreateMap<WorkOrder, WorkOrderDto>().ReverseMap();
        CreateMap<Shift, ShiftDto>().ReverseMap();
        CreateMap<Downtime, DowntimeDto>().ReverseMap();
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<Material, MaterialDto>().ReverseMap();
        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<MaterialUsage, MaterialUsageDto>().ReverseMap();
        CreateMap<ProductionRecord, ProductionRecordDto>().ReverseMap();
    }
}
