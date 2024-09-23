using Appointments.Application.MediatR.Responses;

namespace Appointments.Application.MediatR.Requests.UserRequests
{
    public class AddRandomUserRequest : MediatRBaseRequest<AddRandomUserResponse>
    {
        public int UserCount { get; set; }
    }
}
