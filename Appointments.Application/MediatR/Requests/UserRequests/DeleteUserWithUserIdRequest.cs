using Appointments.Application.Attributes;
using Appointments.Application.MediatR.Responses.UserReponses;

namespace Appointments.Application.MediatR.Requests.UserRequests
{
    [NetworkAddress("User/DeleteUserWithUserId")]

    public class DeleteUserWithUserIdRequest : MediatRBaseRequest<DeleteUserWithUserIdResponse>
    {
        public Guid Id { get; set; }
    }
}
