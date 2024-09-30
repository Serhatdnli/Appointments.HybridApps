using Appointments.Application.Attributes;
using Appointments.Application.MediatR.Responses.ClientResponses;

namespace Appointments.Application.MediatR.Requests.ClientRequests
{
    [NetworkAddress("Clinet/CreateClient")]
    public class CreateClientRequest : MediatRBaseRequest<CreateClientResponse>
    {
    }
}
