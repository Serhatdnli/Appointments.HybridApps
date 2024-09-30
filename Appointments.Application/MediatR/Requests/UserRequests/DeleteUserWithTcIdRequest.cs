using Appointments.Application.Attributes;
using Appointments.Application.MediatR.Responses.UserReponses;
using Appointments.Domain.Models;

namespace Appointments.Application.MediatR.Requests.UserRequests
{
    [NetworkAddress("User/DeleteUserWithTcId")]

    public class DeleteUserWithTcIdRequest : MediatRBaseRequest<DeleteUserWithTcIdResponse>
    {
        public string TcId { get; set; }
    }
}
