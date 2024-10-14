using Appointments.Application.MediatR.Requests.ClinicRequests;
using Appointments.Application.MediatR.Responses.ClinicResponses;
using Appointments.Domain.Models;

namespace Appointments.Utility.Helper
{
	public static class ClinicHelper
	{

		public static async Task<List<Clinic>> GetAllClinics(int index = 0, int count = 0)
		{
			var request = new GetAllClinicsRequest
			{
				Count = count,
				Index = index,
			};

			var response = await NetworkManager.SendAsync<GetAllClinicsRequest, GetAllClinicsResponse>(request);
			return response.Clinics;
		}
	}
}
