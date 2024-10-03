using Appointments.Application.Attributes;
using Appointments.Application.MediatR.Responses.UserReponses;

namespace Appointments.Application.MediatR.Requests.UserRequests
{
	[NetworkAddress("User/DeleteUserById")]
	public class DeleteUserByIdRequest : MediatRBaseRequest<DeleteUserByIdResponse>
	{
		public Guid Id { get; set; }
	}
}
