using Appointments.Application.Attributes;
using Appointments.Application.MediatR.Responses.UserReponses;
using Appointments.Domain.Models;

namespace Appointments.Application.MediatR.Requests.UserRequests
{
	[NetworkAddress("User/GetAllUsersByFilter")]

	public class GetAllUsersByFilterRequest : MediatRBaseRequest<GetAllUsersByFilterResponse>
	{
		public int Index { get; set; }
		public int Count { get; set; }
		public User Filter { get; set; }

	}
}