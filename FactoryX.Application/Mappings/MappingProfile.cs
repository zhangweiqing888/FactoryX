using AutoMapper;
using FactoryX.Application.DTOs;
using FactoryX.Application.DTOs.Requests.MachineRequests;
using FactoryX.Application.DTOs.Requests.OperatorRequests;
using FactoryX.Application.DTOs.Requests.ProductionRecordRequests;
using FactoryX.Application.DTOs.Requests.ProductRequests;
using FactoryX.Application.DTOs.Requests.ShiftRequests;
using FactoryX.Application.DTOs.Requests.WorkOrderRequests;
using FactoryX.Application.DTOs.Responses.MachineResponses;
using FactoryX.Application.DTOs.Responses.Operator;
using FactoryX.Application.DTOs.Responses.OperatorResponses;
using FactoryX.Application.DTOs.Responses.Product;
using FactoryX.Application.DTOs.Responses.ProductionRecord;
using FactoryX.Application.DTOs.Responses.ProductResponses;
using FactoryX.Application.DTOs.Responses.Shift;
using FactoryX.Application.DTOs.Responses.ShiftResponses;
using FactoryX.Application.DTOs.Responses.UserManagementResponses;
using FactoryX.Application.DTOs.Responses.WorkOrder;
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

		#region Machine Mapping
		CreateMap<Machine, GetAllMachinesResponse>().ReverseMap();
		CreateMap<Machine, GetMachineResponse?>().ReverseMap();
        CreateMap<Machine, InsertMachineResponse>().ReverseMap();
        CreateMap<Machine, InsertMachineRequest>().ReverseMap();
        CreateMap<Machine, UpdateMachineRequest>().ReverseMap();
        CreateMap<UpdateMachineRequest, GetMachineResponse>().ReverseMap();
        #endregion

        #region Operator Mapping
        CreateMap<Operator, GetAllOperatorResponse>().ReverseMap();
        CreateMap<Operator, GetOperatorResponse?>().ReverseMap();
        CreateMap<Operator, InsertOperatorRequest>().ReverseMap();
        CreateMap<Operator, InsertOperatorResponse>().ReverseMap();
        CreateMap<Operator, UpdateOperatorRequest>().ReverseMap();
        #endregion

        #region ProductionRecord Mapping
        CreateMap<ProductionRecord, InsertProductionRecordRequest>().ReverseMap();
        CreateMap<ProductionRecord, InsertProductionRecordResponse>().ReverseMap();
        CreateMap<ProductionRecord, UpdateProductionRecordRequest>().ReverseMap();
        #endregion

        #region Product Mapping
        CreateMap<Product, GetAllProductResponse>().ReverseMap();
        CreateMap<Product, GetProductResponse>().ReverseMap();
        CreateMap<Product, InsertProductRequest>().ReverseMap();
        CreateMap<Product, InsertProductResponse>().ReverseMap();
        CreateMap<Product, UpdateProductRequest>().ReverseMap();
		#endregion

		#region Shift Mapping
        CreateMap<Shift, GetAllShiftResponse>().ReverseMap();
        CreateMap<Shift, GetShiftResponse>().ReverseMap();
        CreateMap<Shift, InsertShiftRequest>().ReverseMap();
		CreateMap<Shift, InsertShiftResponse>().ReverseMap();
		CreateMap<Shift, UpdateShiftRequest>().ReverseMap();
        #endregion

        #region User Mapping
        CreateMap<GetUserProfileResponse, UserProfileDto>().ReverseMap();
		#endregion

		#region WorkOrder Mapping
		CreateMap<WorkOrder, InsertWorkOrderRequest>().ReverseMap();
		CreateMap<WorkOrder, InsertWorkOrderResponse>().ReverseMap();
        CreateMap<WorkOrder, UpdateWorkOrderRequest>().ReverseMap();
		#endregion
	}
}
