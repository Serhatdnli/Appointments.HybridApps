using Appointments.Application.Filters;
using Appointments.Application.MediatR.Responses.UserReponses;

namespace Appointments.Application.MediatR.Requests.UserRequests
{
    public class GetAllUserRequest : MediatRBaseRequest<GetAllUsersResponse>
    {
        public int Index { get; set; }
        public int Count { get; set; }
        public UserFilter userFilter{ get; set; }

    }
}
