using Appointments.Application.Attributes;
using Appointments.Application.MediatR.Responses.ClientResponses;

namespace Appointments.Application.MediatR.Requests.ClientRequests
{

	[NetworkAddress("Client/GetAllClients")]

	public class GetAllClientsRequest : MediatRBaseRequest<GetAllClientsResponse>
	{
		public int Index { get; set; }
		public int Count { get; set; }

	}

}

