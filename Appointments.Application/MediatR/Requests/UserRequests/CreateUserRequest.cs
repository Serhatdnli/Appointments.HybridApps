using Appointments.Application.Attributes;
using Appointments.Application.MediatR.Responses.UserReponses;
using Appointments.Domain.Enums;

namespace Appointments.Application.MediatR.Requests.UserRequests
{
	[NetworkAddress("User/CreateUser")]

	public class CreateUserRequest : MediatRBaseRequest<CreateUserResponse>
	{
		public string Name { get; set; } = string.Empty;
		public string Surname { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;

		public string Password { get; set; } = string.Empty;
		public string TcId { get; set; } = string.Empty;

		public string PhoneNumber { get; set; } = string.Empty;
		public UserRoleType Role { get; set; } = UserRoleType.None;
	}
}
