using Appointments.Application.Attributes;
using Appointments.Application.MediatR.Responses.ClientResponses;

namespace Appointments.Application.MediatR.Requests.ClientRequests
{
	[NetworkAddress("Client/GetClientById")]

	public class GetClientByIdRequest : MediatRBaseRequest<GetClientByIdResponse>
	{
		public Guid Id { get; set; }
	}
}
