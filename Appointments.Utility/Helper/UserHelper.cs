using Appointments.Application.MediatR.Requests.UserRequests;
using Appointments.Application.MediatR.Responses.UserReponses;
using Appointments.Domain.Enums;
using Appointments.Domain.Models;

namespace Appointments.Utility.Helper
{
	public static class UserHelper
	{
		public static async Task<List<User>> GetAllDoctors(int index = 0, int count = 0)
		{
			var request = new GetAllUsersByFilterRequest
			{
				Count = count,
				Index = index,
				Filter = new User
				{
					Role = UserRoleType.Doctor
				}
			};

			var response = await NetworkManager.SendAsync<GetAllUsersByFilterRequest, GetAllUsersByFilterResponse>(request);
			return response.Users;
		}
	}
}
