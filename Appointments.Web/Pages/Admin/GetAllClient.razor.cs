using Appointments.Application.MediatR.Requests.ClientRequests;
using Appointments.Application.MediatR.Responses.ClientResponses;
using Appointments.Domain.Models;
using Appointments.Shared.Extensions;
using Appointments.Utility;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Appointments.Web.Pages.Admin
{
	public partial class GetAllClient : ComponentBase
	{
		[Inject]
		private IJSRuntime jsRuntime { get; set; }

		private List<Client> Clients = new List<Client>();
		private Client Filter { get; set; } = new();

		private bool isFiltered = false;

		int currentPage = 0;
		int lastPage = -1;
		int totalData = -1;
		int dataPerPage = 10;
		int curDataOrder = 0;


		protected override async Task OnInitializedAsync()
		{
			await GoToPage(currentPage);
		}

		private async Task<GetAllClientsByFilterResponse> GetClientByFilterByPage()
		{

			var request = new GetAllClientsByFilterRequest
			{
				Count = dataPerPage,
				Index = currentPage * dataPerPage,
				Filter = Filter
			};

			GetAllClientsByFilterResponse response = await NetworkManager.SendAsync<GetAllClientsByFilterRequest, GetAllClientsByFilterResponse>(request);

			Clients = response.Clients;
			totalData = response.Count;
			lastPage = totalData % dataPerPage == 0 ? totalData / dataPerPage - 1 : totalData / dataPerPage;

			return response;
		}

		private async Task<GetAllClientsResponse> GetClientByPage()
		{
			var request = new GetAllClientsRequest
			{
				Count = dataPerPage,
				Index = currentPage * dataPerPage,
				RequesterId = Guid.Empty,
			};

			var response = await NetworkManager.SendAsync<GetAllClientsRequest, GetAllClientsResponse>(request);


			Clients = response.Clients;
			totalData = response.Count;
			lastPage = totalData % dataPerPage == 0 ? totalData / dataPerPage - 1 : totalData / dataPerPage;
			return response;


		}

		private async Task ApplyFilterAsync()
		{
			//ObjectWriter.Write(Filter);
			isFiltered = Filter.IsFilterValid();
			//Console.WriteLine(Filter.IsFilterValid());

			await GoToPage(0);
		}


		private async Task ConfirmDelete(Client client)
		{
			var confirmed = await jsRuntime.InvokeAsync<bool>("confirm", client.Name + " " + client.Surname + " Kullanıcısını Silmek İstedğinize Emin misiniz?");
			if (confirmed)
			{

				var request = new DeleteClientByIdRequest
				{
					RequesterId = Guid.Empty,
					Id = client.Id,
				};

				var response = await NetworkManager.SendAsync<DeleteClientByIdRequest, DeleteClientByIdResponse>(request);
				GoToPage(currentPage);
			}
		}
		private async Task GoToPage(int page = 0)
		{

			if (page > lastPage)
			{
				lastPage = page;
			}
			currentPage = page;
			if (isFiltered)
				await GetClientByFilterByPage();
			else
				await GetClientByPage();
			StateHasChanged();

		}
	}
}
