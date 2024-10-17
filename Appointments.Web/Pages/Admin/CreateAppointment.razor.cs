using Appointments.Application.MediatR.Requests.AppointmentRequests;
using Appointments.Application.MediatR.Responses.AppointmentResponses;
using Appointments.Domain.Dtos.AppointmentDtos;
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
		private CreateAppointmentRequest createRequest { get; set; } = new();

		private List<GetAppointmentDto> appointments { get; set; } = new();
		private List<Clinic> clinics = new();
		private List<Client> clients = new();
		private List<User> doctors = new();

		private List<DateTime> emptyHours { get; set; } = new();

		private Client selectedClient;
		private Clinic selectedClinic;
		private User selectedDoctor;

		private async void UpdateEmptyHours()
		{
			emptyHours = await AppointmentHelper.GetEmptyHours(createRequest.createDto.DoctorId, createRequest.createDto.AppointmentTime, selectedClinic.Minute);

			createRequest.createDto.AppointmentTime = emptyHours.FirstOrDefault();
			StateHasChanged();
		}



		protected override async Task OnInitializedAsync()
		{
			createRequest.createDto.AppointmentTime = DateTime.Now;

			doctors = await UserHelper.GetAllDoctors();
			clinics = await ClinicHelper.GetAllClinics();
			clients = await ClientHelper.GetAllClients();


			selectedDoctor = doctors.FirstOrDefault();
			selectedClinic = clinics.FirstOrDefault();
			selectedClient = clients.FirstOrDefault();

			createRequest.createDto.ClinicId = selectedClinic.Id;
			createRequest.createDto.DoctorId = selectedDoctor.Id;
			createRequest.createDto.ClientId = selectedClient.Id;

			UpdateEmptyHours();
		}

		private async Task CreateAsync()
		{
			ShowMessage(ToastType.Primary, "Randevu tarihi : " + createRequest.createDto.AppointmentTime);
			createRequest.createDto.AppointmentFinishTime = createRequest.createDto.AppointmentTime.AddMinutes(selectedClinic.Minute);



			var response = await NetworkManager.SendAsync<CreateAppointmentRequest, CreateAppointmentResponse>(createRequest);

			if (response.message.IsSuccessStatusCode)
			{

				ShowMessage(ToastType.Primary, $" {selectedClient.Name} isimli hastanın randevusu Başarılı Şekilde Eklendi");
			}
			else
			{
				ShowMessage(ToastType.Warning, $" {selectedClient.Name} isimli hastayı eklerken hata : \n {response.ErrorMessage } \n {response.ErrorMessage}");
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
			createRequest.createDto.DoctorId = Guid.Parse(doctorId);
			selectedDoctor = doctors.Where(x => x.Id == Guid.Parse(doctorId)).FirstOrDefault();
			UpdateEmptyHours();
		}

		private void SetClinicByClinicId(string clinicId)
		{
			createRequest.createDto.ClinicId = Guid.Parse(clinicId);
			selectedClinic = clinics.Where(x => x.Id == Guid.Parse(clinicId)).FirstOrDefault();
			UpdateEmptyHours();
		}

		private void SetClientByClientId(string clientId)
		{
			createRequest.createDto.ClientId = Guid.Parse(clientId);
			selectedClient = clients.Where(x => x.Id == Guid.Parse(clientId)).FirstOrDefault();
			UpdateEmptyHours();
		}

	}
}
