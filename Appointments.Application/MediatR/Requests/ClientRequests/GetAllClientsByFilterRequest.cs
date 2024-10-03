using Appointments.Application.Attributes;
using Appointments.Application.MediatR.Responses.ClientResponses;
using Appointments.Domain.Enums.FilterTypes;
namespace Appointments.Application.MediatR.Requests.ClientRequests
{
	[NetworkAddress("Client/GetAllClientsByFilter")]

	public class GetAllClientsByFilterRequest : MediatRBaseRequest<GetAllClientsByFilterResponse>
	{
		public int Index { get; set; }
		public int Count { get; set; }
		public Dictionary<ClientFilterType, string> Filter { get; set; }

	}
}