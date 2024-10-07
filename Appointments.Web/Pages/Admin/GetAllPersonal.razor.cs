using Appointments.Application.MediatR.Requests.UserRequests;
using Appointments.Application.MediatR.Responses.UserReponses;
using Appointments.Domain.Enums;
using Appointments.Domain.Models;
using Appointments.Shared.Extensions;
using Appointments.Utility;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Data;

namespace Appointments.Web.Pages.Admin
{
	public partial class GetAllPersonal : ComponentBase
	{
		private string[] bindingValue = new string[10];
		private List<User> Users = new List<User>();
		private bool isFiltered = false;
		private User Filter { get; set; } = new();
		[Inject]
		private IJSRuntime jsRuntime { get; set; }

		int currentPage = 0;
		int lastPage = -1;
		int totalData = -1;
		int dataPerPage = 10;
		int curDataOrder = 0;

		private List<UserRoleType> RoleOptions => Enum.GetValues(typeof(UserRoleType)).Cast<UserRoleType>().ToList();

		protected override async Task OnInitializedAsync()
		{
			await GoToPage(currentPage);
		}

		private async Task<GetAllUsersByFilterResponse> GetPersonalByFilterByPage()
		{

			var request = new GetAllUsersByFilterRequest
			{
				Count = dataPerPage,
				Index = currentPage * dataPerPage,
				Filter = Filter
			};

			GetAllUsersByFilterResponse response = await NetworkManager.SendAsync<GetAllUsersByFilterRequest, GetAllUsersByFilterResponse>(request);

			Users = response.Users;
			totalData = response.Count;
			lastPage = totalData % dataPerPage == 0 ? totalData / dataPerPage - 1 : totalData / dataPerPage;

			return response;
		}

		private async Task<GetAllUsersResponse> GetPersonalByPage()
		{
			var request = new GetAllUsersRequest
			{
				Count = dataPerPage,
				Index = currentPage * dataPerPage,
				RequesterId = Guid.Empty,
			};

			var response = await NetworkManager.SendAsync<GetAllUsersRequest, GetAllUsersResponse>(request);


			Users = response.Users;
			totalData = response.Count;
			lastPage = totalData % dataPerPage == 0 ? totalData / dataPerPage - 1 : totalData / dataPerPage;
			return response;


		}

		private async Task ApplyFilterAsync()
		{
			//ObjectWriter.Write(Filter);
			isFiltered = Filter.IsFilterValid();
			Console.WriteLine(Filter.IsFilterValid());

			await GoToPage(0);
		}


		private async Task ConfirmDelete(User user)
		{
			var confirmed = await jsRuntime.InvokeAsync<bool>("confirm", user.Name + " " + user.Surname + " Kullanıcısını Silmek İstedğinize Emin misiniz?");
			if (confirmed)
			{

				var request = new DeleteUserByIdRequest
				{
					RequesterId = Guid.Empty,
					Id = user.Id,
				};

				var response = await NetworkManager.SendAsync<DeleteUserByIdRequest, DeleteUserByIdResponse>(request);
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
				await GetPersonalByFilterByPage();
			else
				await GetPersonalByPage();
			StateHasChanged();

		}
	}
}
