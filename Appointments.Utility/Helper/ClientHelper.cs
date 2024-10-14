using Appointments.Application.MediatR.Requests.ClientRequests;
using Appointments.Application.MediatR.Responses.ClientResponses;
using Appointments.Domain.Models;

namespace Appointments.Utility.Helper
{
	public static class ClientHelper
	{
		public static async Task<List<Client>> GetAllClients(int index = 0, int count = 0)
		{
			var request = new GetAllClientsRequest
			{
				Count = count,
				Index = index,
			};

			var response = await NetworkManager.SendAsync<GetAllClientsRequest, GetAllClientsResponse>(request);
			return response.Clients;
		}
	}
}
