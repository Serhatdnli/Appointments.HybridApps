using Appointments.Application.Attributes;
using Appointments.Application.MediatR.Responses.ClientResponses;

namespace Appointments.Application.MediatR.Requests.ClientRequests
{
    [NetworkAddress("Client/DeleteClientById")]
    public class DeleteClientByIdRequest : MediatRBaseRequest<DeleteClientByIdResponse>
    {
        public Guid Id { get; set; }
    }
}
