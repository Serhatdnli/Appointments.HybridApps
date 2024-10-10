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
using Appointments.Utility;
using BlazorBootstrap;
using Microsoft.AspNetCore.Components;

namespace Appointments.Web.Pages.Admin
{
	public partial class CreateAppointment : ComponentBase
	{
		private Appointment Appointment { get; set; } = new Appointment();
		private List<Clinic> Clinics = new();
		private List<Client> Clients = new();
		private List<User> Doctors = new();


		private Client Client { get; set; }
		private User Doctor { get; set; }
		private Clinic Clinic { get; set; }

		


		protected override async Task OnInitializedAsync()
		{
			Doctors = await GetDoctors();
			Clinics = await GetClinics();
			Clients = await GetClients();
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
			Appointment.CreateDate = DateTime.Now;
			CreateAppointmentRequest request = new CreateAppointmentRequest
			{
				Appointment = Appointment,
				RequesterId = Guid.Empty
			};

			try
			{
				var response = await NetworkManager.SendAsync<CreateAppointmentRequest, CreateAppointmentResponse>(request);
				ShowMessage(ToastType.Primary, $" {Client.Name} isimli hastanın randevusu Başarılı Şekilde Eklendi");
			}
			catch (Exception e)
			{

				ShowMessage(ToastType.Primary, e.ToString());
				throw;
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
