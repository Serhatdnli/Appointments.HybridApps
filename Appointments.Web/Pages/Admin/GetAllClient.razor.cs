using Appointments.Application.MediatR.Requests.ClientRequests;
using Appointments.Application.MediatR.Responses.ClientResponses;
using Appointments.Domain.Enums.FilterTypes;
using Appointments.Domain.Models;
using Appointments.Utility;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Appointments.Web.Pages.Admin
{
	public partial class GetAllClient : ComponentBase
	{
		private string[] bindingValue = new string[10];
		private Dictionary<ClientFilterType, string> ClientFilters = new();
		private List<Client> Clients = new List<Client>();
		private bool isFiltered = false;


		[Inject]
		private IJSRuntime jsRuntime { get; set; }

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
			Console.WriteLine("Müşteriler çekiliyor");
			var request = new GetAllClientsByFilterRequest
			{
				Count = dataPerPage,
				Index = currentPage * dataPerPage,
				RequesterId = Guid.Empty,
				Filter = ClientFilters
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

		private void BindFilter(ClientFilterType filterType, string value)
		{
			Console.WriteLine("CALİSİYO");


			bool isNull = string.IsNullOrEmpty(value);
			if (!ClientFilters.Any(x => x.Key == filterType))
			{
				if (!isNull)
					ClientFilters.Add(filterType, value);

			}
			else
			{
				ClientFilters[filterType] = value;

				if (isNull)
					ClientFilters.Remove(filterType);
			}

		}

		private async Task ApplyFilterAsync()
		{
			//Console.WriteLine($"Name: {ClientFilter.Name}");
			//Console.WriteLine($"Surname: {ClientFilter.Surname}");
			//Console.WriteLine($"Email: {ClientFilter.Email}");
			//Console.WriteLine($"TC ID: {ClientFilter.TcId}");
			//Console.WriteLine($"Phone Number: {ClientFilter.PhoneNumber}");
			//Console.WriteLine($"Role: {ClientFilter.Role}");
			//Console.WriteLine($"Create Date: {ClientFilter.CreateDate}");

			isFiltered = ClientFilters.Keys.Count() > 0;
			await GoToPage(0);
		}


		private async Task ConfirmDelete(Client Client)
		{
			var confirmed = await jsRuntime.InvokeAsync<bool>("confirm", Client.Name + " " + Client.Surname + " Kullanıcısını Silmek İstedğinize Emin misiniz?");
			if (confirmed)
			{

				var request = new DeleteClientByIdRequest
				{
					RequesterId = Guid.Empty,
					Id = Client.Id,
				};

				var response = await NetworkManager.SendAsync<DeleteClientByIdRequest, DeleteClientByIdResponse>(request);

			}
		}
		private async Task GoToPage(int page)
		{
			if (page > lastPage)
			{
				lastPage = page;
			}
			currentPage = page;
			Console.WriteLine("[BOYRAZ] SAYFAYA GİDİLİYOR, CURRENT PAGE: " + currentPage);
			if (isFiltered)
				await GetClientByFilterByPage();
			else
				await GetClientByPage();
			StateHasChanged();
		}
	}
}
