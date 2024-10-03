using Appointments.Application.Attributes;
using Appointments.Application.MediatR.Responses.UserReponses;

namespace Appointments.Application.MediatR.Requests.UserRequests
{
	[NetworkAddress("User/GetUserById")]

	public class GetUserByIdRequest : MediatRBaseRequest<GetUserByIdResponse>
	{
		public Guid Id { get; set; }
	}
}
