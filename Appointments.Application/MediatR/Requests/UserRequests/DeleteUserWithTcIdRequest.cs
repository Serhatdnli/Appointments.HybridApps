using Appointments.Application.MediatR.Responses.UserReponses;
using Appointments.Domain.Models;

namespace Appointments.Application.MediatR.Requests.UserRequests
{
    public class DeleteUserWithTcIdRequest : MediatRBaseRequest<DeleteUserWithTcIdResponse>
    {
        public string TcId { get; set; }
    }
}
