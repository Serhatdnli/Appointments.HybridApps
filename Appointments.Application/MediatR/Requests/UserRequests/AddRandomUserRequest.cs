using Appointments.Application.Attributes;
using Appointments.Application.MediatR.Responses.UserReponses;

namespace Appointments.Application.MediatR.Requests.UserRequests
{
    [NetworkAddress("User/AddRandomUser")]
    public class AddRandomUserRequest : MediatRBaseRequest<AddRandomUserResponse>
    {
        public int UserCount { get; set; }
    }
}
