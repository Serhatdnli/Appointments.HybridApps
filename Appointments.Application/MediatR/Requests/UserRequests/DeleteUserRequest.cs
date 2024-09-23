using Appointments.Application.MediatR.Responses;
using Appointments.Domain.Models;

namespace Appointments.Application.MediatR.Requests.UserRequests
{
    public class DeleteUserRequest : MediatRBaseRequest<DeleteUserResponse>
    {
        public User User { get; set; }
    }
}
