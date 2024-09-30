using Appointments.Application.Attributes;
using Appointments.Application.MediatR.Responses.ClientResponses;
using Appointments.Domain.Models;

namespace Appointments.Application.MediatR.Requests.ClientRequests
{
    [NetworkAddress("Client/UpdateClient")]
    public class UpdateClientRequest : MediatRBaseRequest<UpdateClientResponse>
    {
        public Client Client { get; set; }
    }
}
