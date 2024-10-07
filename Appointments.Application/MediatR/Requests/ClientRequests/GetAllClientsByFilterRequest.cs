using Appointments.Application.Attributes;
using Appointments.Application.MediatR.Responses.ClientResponses;
using Appointments.Domain.Enums.FilterTypes;
using Appointments.Domain.Models;
namespace Appointments.Application.MediatR.Requests.ClientRequests
{
	[NetworkAddress("Client/GetAllClientsByFilter")]

	public class GetAllClientsByFilterRequest : MediatRBaseRequest<GetAllClientsByFilterResponse>
	{
		public int Index { get; set; }
		public int Count { get; set; }
		public Client Filter { get; set; }

	}
}