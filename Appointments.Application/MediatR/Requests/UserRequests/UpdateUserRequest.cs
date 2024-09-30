using Appointments.Application.Attributes;
using Appointments.Application.MediatR.Responses.UserReponses;
using Appointments.Domain.Models;

namespace Appointments.Application.MediatR.Requests.UserRequests
{
    [NetworkAddress("User/UpdateUser")]

    public class UpdateUserRequest : MediatRBaseRequest<UpdateUserResponse>
    {
        public User User { get; set; }
    }
}
