using Appointments.Application.Attributes;
using Appointments.Application.MediatR.Responses.UserReponses;

namespace Appointments.Application.MediatR.Requests.UserRequests
{

	[NetworkAddress("User/GetAllUsers")]

	public class GetAllUsersRequest : MediatRBaseRequest<GetAllUsersResponse>
	{
		public int Index { get; set; }
		public int Count { get; set; }

	}

}

