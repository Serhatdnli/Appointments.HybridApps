using Appointments.Application.MediatR.Responses;

namespace Appointments.Application.MediatR.Requests.UserRequests
{
    public class GetAllUserRequest : MediatRBaseRequest<GetAllUsersResponse>
    {
        public int Index { get; set; }
        public int Count { get; set; }


    }
}
