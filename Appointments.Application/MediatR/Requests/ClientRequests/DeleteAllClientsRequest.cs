using Appointments.Application.Attributes;
using Appointments.Application.MediatR.Responses.ClientResponses;

namespace Appointments.Application.MediatR.Requests.ClientRequests
{
	[NetworkAddress("Client/DeleteAllClients")]

	public class DeleteAllClientsRequest : MediatRBaseRequest<DeleteAllClientsResponse>
	{

	}
}
