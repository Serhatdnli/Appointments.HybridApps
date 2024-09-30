using Appointments.Domain.Models;

namespace Appointments.Application.MediatR.Responses.ClientResponses
{
    public class GetAllClientByFilterResponse : MediatRBaseResponse
    {
        public List<Client> Clients { get; set; }
        public int Count { get; set; }

    }
}
