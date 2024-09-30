using Appointments.Domain.Models;

namespace Appointments.Application.MediatR.Responses.ClientResponses
{
    public class GetAllClientResponse : MediatRBaseResponse
    {
        public List<Client> Clients { get; set; }
        public int Count { get; set; }
    }
}
