using Appointments.Application.Attributes;
using Appointments.Application.MediatR.Responses.ClientResponses;

namespace Appointments.Application.MediatR.Requests.ClientRequests
{
    [NetworkAddress("Client/GetAllClient")]
    public class GetAllClientRequest : MediatRBaseRequest<GetAllClientResponse>
    {
        public int Index { get; set; }
        public int Count { get; set; }
    }
}
