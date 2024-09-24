using Appointments.Domain.Models;

namespace Appointments.Application.MediatR.Responses.UserReponses
{
    public class GetAllUsersResponse : MediatRBaseResponse
    {
        public List<User> Users { get; set; }
    }
}
