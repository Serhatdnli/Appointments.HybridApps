using Appointments.Application.Attributes;
using Appointments.Application.MediatR.Responses.ClientResponses;
using Appointments.Domain.Models;

namespace Appointments.Application.MediatR.Requests.ClientRequests
{
	[NetworkAddress("Client/CreateClient")]

	public class CreateClientRequest : MediatRBaseRequest<CreateClientResponse>
	{
		public Client Client { get; set; }
	}
}
