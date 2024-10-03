using Appointments.Application.Attributes;
using Appointments.Application.MediatR.Responses.UserReponses;
using Appointments.Domain.Enums.FilterTypes;

namespace Appointments.Application.MediatR.Requests.UserRequests
{
    [NetworkAddress("User/GetAllUsersByFilter")]

	public class GetAllUsersByFilterRequest : MediatRBaseRequest<GetAllUsersByFilterResponse>
	{
		public int Index { get; set; }
		public int Count { get; set; }
		public Dictionary<UserFilterType, string> Filter { get; set; }

	}
}