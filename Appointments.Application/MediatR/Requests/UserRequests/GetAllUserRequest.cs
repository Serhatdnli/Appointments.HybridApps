using Appointments.Application.Attributes;
using Appointments.Application.MediatR.Responses.UserReponses;
using Appointments.Domain.Enums;
using System.Text.Json.Serialization;

namespace Appointments.Application.MediatR.Requests.UserRequests
{
    [NetworkAddress("User/GetAllUsers")]

    public class GetAllUserRequest : MediatRBaseRequest<GetAllUsersResponse>
    {
        public int Index { get; set; }
        public int Count { get; set; }

    }
}
