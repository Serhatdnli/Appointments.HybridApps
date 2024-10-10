using Appointments.Application.MediatR.Requests.ClientRequests;
using Appointments.Application.MediatR.Requests.ClinicRequests;
using Appointments.Application.MediatR.Responses.ClientResponses;
using Appointments.Application.MediatR.Responses.ClinicResponses;
using Appointments.Domain.Models;
using Appointments.Shared.Extensions;
using Appointments.Utility;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Appointments.Web.Pages.Admin
{
	public partial class GetAllClinic : ComponentBase
	{
		[Inject]
		private IJSRuntime jsRuntime { get; set; }

		private List<Clinic> Clinics = new List<Clinic>();

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


		private async Task<GetAllClinicsResponse> GetClientByPage()
		{
			var request = new GetAllClinicsRequest
			{
				Count = dataPerPage,
				Index = currentPage * dataPerPage,
				RequesterId = Guid.Empty,
			};

			var response = await NetworkManager.SendAsync<GetAllClinicsRequest, GetAllClinicsResponse>(request);


            Clinics = response.Clinics;
			totalData = response.Count;
			lastPage = totalData % dataPerPage == 0 ? totalData / dataPerPage - 1 : totalData / dataPerPage;
			return response;


		}



		private async Task ConfirmDelete(Clinic clinic)
		{
			var confirmed = await jsRuntime.InvokeAsync<bool>("confirm", clinic.Name + " kliniğini Silmek İstedğinize Emin misiniz?");
			if (confirmed)
			{

				var request = new DeleteClinicByIdRequest
				{
					RequesterId = Guid.Empty,
					Id = clinic.Id,
				};

				var response = await NetworkManager.SendAsync<DeleteClinicByIdRequest, DeleteClinicByIdResponse>(request);
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
		
			await GetClientByPage();
			StateHasChanged();

		}
	}
}
