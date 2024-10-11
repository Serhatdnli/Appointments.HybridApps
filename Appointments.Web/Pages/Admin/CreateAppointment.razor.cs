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
using System.Linq.Expressions;

namespace Appointments.Web.Pages.Admin
{
	public partial class CreateAppointment : ComponentBase
	{
		private Appointment Appointment { get; set; } = new Appointment()
		{
			AppointmentTime = DateTime.Now
		};
		private List<Appointment> Appointments { get; set; } = new();
		private List<Clinic> Clinics = new();
		private List<Client> Clients = new();
		private List<User> Doctors = new();

		private Clinic Clinic;
		private User Doctor;
		private Client Client;



	



		

		private List<DateTime> emptyHours { get; set; } = new();

		private async void UpdateEmptyHours()
		{
            Console.WriteLine("fonktayız");
            emptyHours.Clear();

			var request = new GetAllAppointmentsByExpressionRequest
			{
				Count = 0,
				Index = 0,
				//Expression = (x => x.DoctorId == Appointment.DoctorId && x.AppointmentTime == Appointment.AppointmentTime.Date)
				DoctorId = Appointment.DoctorId,
				Datetime = Appointment.AppointmentTime.Date,
			};

			var response = await NetworkManager.SendAsync<GetAllAppointmentsByExpressionRequest, GetAllAppointmentsByExpressionResponse>(request);
			if (response != null)
			{
				Appointments = response.Appointments;
			}

			DateTime currentTime = new DateTime(year : Appointment.AppointmentTime.Year , month : Appointment.AppointmentTime.Month, day : Appointment.AppointmentTime.Day, hour : 9, minute : 0 , second : 0);
			
            for(int i = 0; i < 18; i++)
			{
				var fuckingAppointments =  Appointments.Where(x => x.AppointmentTime <= currentTime && x.AppointmentFinishTime >= currentTime).ToList();
				if(fuckingAppointments is null || fuckingAppointments.Count == 0)
					emptyHours.Add(currentTime);

				currentTime = currentTime.AddMinutes(30);
			}
			Appointment.AppointmentTime = emptyHours.FirstOrDefault();
			StateHasChanged();
        }
		


		protected override async Task OnInitializedAsync()
		{
			
			Doctors = await GetDoctors();
			Clinics = await GetClinics();
			Clients = await GetClients();


			Appointment.ClinicId = Clinics.FirstOrDefault().Id;
			Appointment.DoctorId = Doctors.FirstOrDefault().Id;
			Appointment.ClientId = Clients.FirstOrDefault().Id;

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
			Appointment.CreateDate = DateTime.Now;
            Console.WriteLine("Clinic : " + Clinic.Minute);
            Appointment.AppointmentFinishTime = Appointment.AppointmentTime.AddMinutes(Clinic.Minute);
			CreateAppointmentRequest request = new CreateAppointmentRequest
			{
				Appointment = Appointment,
				RequesterId = Guid.Empty
			};

			try
			{
				var response = await NetworkManager.SendAsync<CreateAppointmentRequest, CreateAppointmentResponse>(request);

				if(response is not  null)
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
