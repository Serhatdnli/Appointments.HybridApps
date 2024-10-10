using Appointments.Application.MediatR.Requests.AppointmentRequests;
using Appointments.Application.MediatR.Requests.ClientRequests;
using Appointments.Application.MediatR.Requests.ClinicRequests;
using Appointments.Application.MediatR.Requests.UserRequests;
using Appointments.Application.MediatR.Responses.AppointmentResponses;
using Appointments.Application.MediatR.Responses.ClientResponses;
using Appointments.Application.MediatR.Responses.ClinicResponses;
using Appointments.Application.MediatR.Responses.UserReponses;
using Appointments.Domain.Enums;
using Appointments.Domain.Models;
using Appointments.Shared.Extensions;
using Appointments.Utility;
using BlazorBootstrap;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;


namespace Appointments.Web.Pages.Admin
{
	public partial class GetAllAppointment : ComponentBase
	{
		[Inject]
		private IJSRuntime jsRuntime { get; set; }

		private List<Appointment> Appointments = new List<Appointment>();
		private List<Client> Clients = new List<Client>();
		private List<Clinic> Clinics = new List<Clinic>();
		private List<User> Doctors = new List<User>();

		private Appointment Filter { get; set; } = new Appointment();
		private Clinic Clinic { get; set; } = new Clinic();
		private Client Client { get; set; } = new Client();
		private User Doctor { get; set; } = new User();



		private int CurrentPage { get; set; } = 0;
		private int LastPage { get; set; } = -1;
		private int TotalData { get; set; } = -1;
		private int DataPerPage { get; set; } = 10;
		private bool IsFiltered { get; set; } = false;


		protected override async Task OnInitializedAsync()
		{
			await GoToPage(CurrentPage);

			Clients = await GetClients();
			Clinics = await GetClinics();	
			Doctors = await GetDoctors();
		}

		private async Task<GetAllAppointmentsByFilterResponse> GetAppointmentByFilterByPage()
		{

			var request = new GetAllAppointmentsByFilterRequest
			{
				Count = DataPerPage,
				Index = CurrentPage * DataPerPage,
				Filter = Filter
			};

			GetAllAppointmentsByFilterResponse response = await NetworkManager.SendAsync<GetAllAppointmentsByFilterRequest, GetAllAppointmentsByFilterResponse>(request);

			Appointments = response.Appointments;
			TotalData = response.Count;
			LastPage = TotalData % DataPerPage == 0 ? TotalData / DataPerPage - 1 : TotalData / DataPerPage;

			return response;
		}

		private async Task<GetAllAppointmentsResponse> GetAppointmentByPage()
		{
			var request = new GetAllAppointmentsRequest
			{
				Count = DataPerPage,
				Index = CurrentPage * DataPerPage,
				RequesterId = Guid.Empty,
			};

			var response = await NetworkManager.SendAsync<GetAllAppointmentsRequest, GetAllAppointmentsResponse>(request);


			Appointments = response.Appointments;
			TotalData = response.Count;
			LastPage = TotalData % DataPerPage == 0 ? TotalData / DataPerPage - 1 : TotalData / DataPerPage;
			return response;


		}

		private async Task ApplyFilterAsync()
		{
			//ObjectWriter.Write(Filter);
			IsFiltered = Filter.IsFilterValid();
			//Console.WriteLine(Filter.IsFilterValid());

			await GoToPage(0);
		}

		private async Task ConfirmDelete(Appointment Appointment)
		{
			var confirmed = await jsRuntime.InvokeAsync<bool>("confirm", Appointment.Client.Name  + " " + Appointment.Client.Surname + " isimli hastanın randevusunu Silmek İstedğinize Emin misiniz?");
			if (confirmed)
			{

				var request = new DeleteAppointmentByIdRequest
				{
					RequesterId = Guid.Empty,
					Id = Appointment.Id,
				};

				var response = await NetworkManager.SendAsync<DeleteAppointmentByIdRequest, DeleteAppointmentByIdResponse>(request);
				GoToPage(CurrentPage);
			}
		}
		private async Task GoToPage(int page = 0)
		{

			if (page > LastPage)
			{
				LastPage = page;
			}
			CurrentPage = page;
			if (IsFiltered)
				await GetAppointmentByFilterByPage();
			else
				await GetAppointmentByPage();
			StateHasChanged();

		}


		private async Task<List<Client>> GetClients()
		{
			var request = new GetAllClientsRequest
			{
				Count = 0,
				Index = 0,
			};

			var response = await NetworkManager.SendAsync<GetAllClientsRequest, GetAllClientsResponse>(request);
			return response.Clients;
		}

		private async Task<List<Clinic>> GetClinics()
		{
			var request = new GetAllClinicsRequest
			{
				Count = 0,
				Index = 0,
			};

			var response = await NetworkManager.SendAsync<GetAllClinicsRequest, GetAllClinicsResponse>(request);
			return response.Clinics;
		}

		private async Task<List<User>> GetDoctors()
		{
			var request = new GetAllUsersByFilterRequest
			{
				Count = 0,
				Index = 0,
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
