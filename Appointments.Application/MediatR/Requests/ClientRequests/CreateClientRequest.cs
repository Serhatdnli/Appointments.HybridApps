using Appointments.Application.Attributes;
using Appointments.Application.MediatR.Responses.ClientResponses;

namespace Appointments.Application.MediatR.Requests.ClientRequests
{
	[NetworkAddress("Client/CreateClient")]

	public class CreateClientRequest : MediatRBaseRequest<CreateClientResponse>
	{
		public string Name { get; set; } = string.Empty;

		public string Surname { get; set; } = string.Empty;

		public string Email { get; set; } = string.Empty;

		public string TcId { get; set; } = string.Empty;

		public string PhoneNumber { get; set; } = string.Empty;

	}
}
