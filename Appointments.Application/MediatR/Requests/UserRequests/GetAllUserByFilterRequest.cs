using Appointments.Application.Attributes;
using Appointments.Application.MediatR.Responses.UserReponses;
using Appointments.Domain.Enums;

namespace Appointments.Application.MediatR.Requests.UserRequests
{
    [NetworkAddress("User/GetAllUsersByFilter")]

    public class GetAllUserByFilterRequest : MediatRBaseRequest<GetAllUsersByFilterResponse>
    {
        public int Index { get; set; }
        public int Count { get; set; }
        public Dictionary<UserFilterType, string> userFilter { get; set; }

    }
}
