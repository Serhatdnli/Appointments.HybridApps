using Appointments.Application.MediatR.Handlers.AppointmentHandlers;
using Appointments.Application.MediatR.Requests.AppointmentRequests;
using Appointments.Application.MediatR.Requests.ClientRequests;
using Appointments.Application.MediatR.Requests.ClinicRequests;
using Appointments.Application.MediatR.Requests.UserRequests;
using Appointments.Application.MediatR.Responses.AppointmentResponses;
using Appointments.Application.MediatR.Responses.ClientResponses;
using Appointments.Application.MediatR.Responses.ClinicResponses;
using Appointments.Application.MediatR.Responses.UserReponses;
using Appointments.Domain.Dtos.AppointmentDtos;
using Appointments.Domain.Enums;
using Appointments.Domain.Models;
using Appointments.Utility;
using BlazorBootstrap;
using Microsoft.AspNetCore.Components;

namespace Appointments.Web.Pages.Admin
{
	public partial class CreateAppointment : ComponentBase
	{
		private CreateAppointmentDto CreateDto { get; set; } = new ()
		{
			AppointmentTime = DateTime.Now
		};

		private List<GetAppointmentDto> Appointments { get; set; } = new();
		private List<Clinic> Clinics = new();
		private List<Client> Clients = new();
		private List<User> Doctors = new();

		private Clinic Clinic;
		private User Doctor;
		private Client Client;

		private List<DateTime> emptyHours { get; set; } = new();

		private async void UpdateEmptyHours()
		{
			emptyHours.Clear();

			var request = new GetAppointmentsByDoctorAndDateRequest
			{
				Count = 0,
				Index = 0,
				DoctorId = CreateDto.DoctorId,
				Datetime = CreateDto.AppointmentTime.Date,
			};

			var response = await NetworkManager.SendAsync<GetAppointmentsByDoctorAndDateRequest, GetAppointmentsByDoctorAndDateResponse>(request);
			if (response != null)
			{
				Appointments = response.Appointments;
			}

			DateTime currentTime = new DateTime(year: CreateDto.AppointmentTime.Year, month: CreateDto.AppointmentTime.Month, day: CreateDto.AppointmentTime.Day, hour: 9, minute: 0, second: 0);

			//Console.WriteLine("Appointments Count : " + Appointments.Count);

			for (int i = 0; i < 18; i++)
			{
				var fuckingAppointments = Appointments.Where(x => x.AppointmentTime <= currentTime && x.AppointmentFinishTime >= currentTime).ToList();
				if (fuckingAppointments is null || fuckingAppointments.Count == 0)
					emptyHours.Add(currentTime);

				currentTime = currentTime.AddMinutes(30);
			}
			CreateDto.AppointmentTime = emptyHours.FirstOrDefault();
			StateHasChanged();
		}



		protected override async Task OnInitializedAsync()
		{

			Doctors = await GetDoctors();
			Clinics = await GetClinics();
			Clients = await GetClients();


			CreateDto.ClinicId = Clinics.FirstOrDefault().Id;
			CreateDto.DoctorId = Doctors.FirstOrDefault().Id;
			CreateDto.ClientId = Clients.FirstOrDefault().Id;

			Clinic = Clinics.FirstOrDefault();
			Doctor = Doctors.FirstOrDefault();
			Client = Clients.FirstOrDefault();

			UpdateEmptyHours();
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

		private async Task CreateAsync()
		{
			CreateDto.CreateDate = DateTime.Now;
			//Console.WriteLine("Clinic : " + Clinic.Minute);
			CreateDto.AppointmentFinishTime = CreateDto.AppointmentTime.AddMinutes(Clinic.Minute);
			CreateAppointmentRequest request = new CreateAppointmentRequest
			{
				CreateDto = CreateDto,
				RequesterId = Guid.Empty
			};

			try
			{
				var response = await NetworkManager.SendAsync<CreateAppointmentRequest, CreateAppointmentResponse>(request);

				if (response is not null)
					ShowMessage(ToastType.Primary, $" {Client.Name} isimli hastanın randevusu Başarılı Şekilde Eklendi");

				else
				{
					ShowMessage(ToastType.Primary, $" response null");
				}
			}
			catch (Exception e)
			{
				ShowMessage(ToastType.Primary, e.Message);
			}

			//ObjectWriter.Write(Appointment);
		}
		List<ToastMessage> messages = new List<ToastMessage>();

		private void ShowMessage(ToastType toastType, string message) => messages.Add(CreateToastMessage(toastType, message));


		private ToastMessage CreateToastMessage(ToastType toastType, string text)
		=> new ToastMessage
		{
			Type = toastType,
			Title = "Blazor Bootstrap",
			HelpText = $"{DateTime.Now}",
			Message = text,
		};

	}
}
