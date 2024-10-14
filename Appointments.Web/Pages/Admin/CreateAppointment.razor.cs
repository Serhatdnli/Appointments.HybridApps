using Appointments.Application.MediatR.Handlers.AppointmentHandlers;
using Appointments.Application.MediatR.Requests.AppointmentRequests;
using Appointments.Application.MediatR.Requests.ClientRequests;
using Appointments.Application.MediatR.Requests.ClinicRequests;
using Appointments.Application.MediatR.Requests.UserRequests;
using Appointments.Application.MediatR.Responses.AppointmentResponses;
using Appointments.Application.MediatR.Responses.ClientResponses;
using Appointments.Application.MediatR.Responses.ClinicResponses;
using Appointments.Application.MediatR.Responses.UserReponses;
using Appointments.Domain.Dtos;
using Appointments.Domain.Enums;
using Appointments.Domain.Models;
using Appointments.Utility;
using Appointments.Utility.Helper;
using Appointments.Utiliy.Helper;
using BlazorBootstrap;
using Microsoft.AspNetCore.Components;

namespace Appointments.Web.Pages.Admin
{
	public partial class CreateAppointment : ComponentBase
	{
		private CreateAppointmentRequest CreateRequest { get; set; } = new()
		{
			AppointmentTime = DateTime.Now
		};

		private List<AppointmentDto> Appointments { get; set; } = new();
		private List<Clinic> Clinics = new();
		private List<Client> Clients = new();
		private List<User> Doctors = new();

		private Clinic Clinic;
		private User Doctor;
		private Client Client;


		private List<DateTime> emptyHours { get; set; } = new();

		private async void UpdateEmptyHours()
		{
			emptyHours = await AppointmentHelper.GetEmptyHours(CreateRequest.DoctorId, CreateRequest.AppointmentTime);

			CreateRequest.AppointmentTime = emptyHours.FirstOrDefault();
			StateHasChanged();
		}



		protected override async Task OnInitializedAsync()
		{


			Doctors = await UserHelper.GetAllDoctors();
			Clinics = await ClinicHelper.GetAllClinics();
			Clients = await ClientHelper.GetAllClients();


			CreateRequest.ClinicId = Clinics.FirstOrDefault().Id;
			CreateRequest.DoctorId = Doctors.FirstOrDefault().Id;
			CreateRequest.ClientId = Clients.FirstOrDefault().Id;

			Clinic = Clinics.FirstOrDefault();
			Doctor = Doctors.FirstOrDefault();
			Client = Clients.FirstOrDefault();

			UpdateEmptyHours();
		}

		private async Task CreateAsync()
		{
			//Console.WriteLine("Clinic : " + Clinic.Minute);
			CreateRequest.AppointmentFinishTime = CreateRequest.AppointmentTime.AddMinutes(Clinic.Minute);


			try
			{
				var response = await NetworkManager.SendAsync<CreateAppointmentRequest, CreateAppointmentResponse>(CreateRequest);

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
