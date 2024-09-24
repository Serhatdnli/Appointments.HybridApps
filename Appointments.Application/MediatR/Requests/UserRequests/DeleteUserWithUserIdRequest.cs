using Appointments.Application.MediatR.Responses.UserReponses;
using Appointments.Domain.Models;

namespace Appointments.Application.MediatR.Requests.UserRequests
{
    public class DeleteUserWithUserIdRequest : MediatRBaseRequest<DeleteUserWithUserIdResponse>
    {
        public Guid Id { get; set; }
    }
}
