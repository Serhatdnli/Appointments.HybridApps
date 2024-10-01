using Appointments.Domain.Models;
using System.Text.Json.Serialization;

namespace Appointments.Application.MediatR.Responses.UserReponses
{
    public class GetAllUsersResponse : MediatRBaseResponse
    {

        public List<User> Users { get; set; }
        public int Count { get; set; }
    }
}
