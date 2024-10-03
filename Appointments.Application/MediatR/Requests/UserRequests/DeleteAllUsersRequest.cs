using Appointments.Application.Attributes;
using Appointments.Application.MediatR.Responses.UserReponses;

namespace Appointments.Application.MediatR.Requests.UserRequests
{
	[NetworkAddress("User/DeleteAllUsers")]

	public class DeleteAllUsersRequest : MediatRBaseRequest<DeleteAllUsersResponse>
	{

	}
}
