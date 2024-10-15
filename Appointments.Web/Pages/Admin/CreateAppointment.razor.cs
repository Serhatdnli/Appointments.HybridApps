using Appointments.Application.MediatR.Requests.AppointmentRequests;
using Appointments.Application.MediatR.Responses.AppointmentResponses;
using Appointments.Domain.Dtos;
using Appointments.Domain.Models;
using Appointments.Utility;
using Appointments.Utility.Helper;
using Appointments.Utiliy.Helper;
using BlazorBootstrap;
using Microsoft.AspNetCore.Components;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Appointments.Web.Pages.Admin
{
	public partial class CreateAppointment : ComponentBase
	{
		private CreateAppointmentRequest createRequest { get; set; } = new()
		{
			AppointmentTime = DateTime.Now
		};

		private List<AppointmentDto> appointments { get; set; } = new();
		private List<Clinic> clinics = new();
		private List<Client> clients = new();
		private List<User> doctors = new();

		private List<DateTime> emptyHours { get; set; } = new();

		Client selectedClient;
		Clinic selectedClinic;
		User selectedDoctor;

		private async void UpdateEmptyHours()
		{
			emptyHours = await AppointmentHelper.GetEmptyHours(createRequest.DoctorId, createRequest.AppointmentTime, selectedClinic.Minute);

			createRequest.AppointmentTime = emptyHours.FirstOrDefault();
			StateHasChanged();
		}



		protected override async Task OnInitializedAsync()
		{

			doctors = await UserHelper.GetAllDoctors();
			clinics = await ClinicHelper.GetAllClinics();
			clients = await ClientHelper.GetAllClients();

			createRequest.ClinicId = clinics.FirstOrDefault().Id;
			createRequest.DoctorId = doctors.FirstOrDefault().Id;
			createRequest.ClientId = clients.FirstOrDefault().Id;

			UpdateEmptyHours();
		}

		private async Task CreateAsync()
		{
			//Console.WriteLine("Clinic : " + Clinic.Minute);
			createRequest.AppointmentFinishTime = createRequest.AppointmentTime.AddMinutes(selectedClinic.Minute);


			try
			{
				var response = await NetworkManager.SendAsync<CreateAppointmentRequest, CreateAppointmentResponse>(createRequest);

				if (response is not null)
					ShowMessage(ToastType.Primary, $" {selectedClient.Name} isimli hastanın randevusu Başarılı Şekilde Eklendi");

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

		private void SetDoctorByDoctorId(string doctorId)
		{
			createRequest.DoctorId = Guid.Parse(doctorId);
			selectedDoctor = doctors.Where(x => x.Id == Guid.Parse(doctorId)).FirstOrDefault();
			UpdateEmptyHours();
		}

		private void SetClinicByClinicId(string clinicId)
		{
			createRequest.ClinicId = Guid.Parse(clinicId);
			selectedClinic = clinics.Where(x => x.Id == Guid.Parse(clinicId)).FirstOrDefault();
			UpdateEmptyHours();
		}

		private void SetClientByClientId(string clientId)
		{
			createRequest.ClientId = Guid.Parse(clientId);
			selectedClient = clients.Where(x => x.Id == Guid.Parse(clientId)).FirstOrDefault();
			UpdateEmptyHours();
		}

	}
}
