using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryX.Application.DTOs.Requests.WorkOrderRequests;

public sealed record DeleteWorkOrderRequest(
	int Id
);
