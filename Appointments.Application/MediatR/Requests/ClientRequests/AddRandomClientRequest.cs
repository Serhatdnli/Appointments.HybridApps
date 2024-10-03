using Appointments.Application.Attributes;
using Appointments.Application.MediatR.Responses.ClientResponses;

namespace Appointments.Application.MediatR.Requests.ClientRequests
{
	[NetworkAddress("Client/AddRandomClient")]

	public class AddRandomClientRequest : MediatRBaseRequest<AddRandomClientResponse>
	{
		public int Count { get; set; }
	}
}
