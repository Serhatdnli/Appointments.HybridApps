using Appointments.Application.MediatR.Requests.AppointmentRequests;
using Appointments.Application.MediatR.Responses.AppointmentResponses;
using Appointments.Domain.Dtos.AppointmentDtos;
using Appointments.Domain.Models;
using Appointments.Utility;
using Appointments.Utility.Helper;
using Appointments.Utiliy.Helper;
using AutoMapper;
using BlazorBootstrap;
using Microsoft.AspNetCore.Components;

namespace Appointments.Web.Pages.Admin
{
    public partial class UpdateAppointment : ComponentBase
    {
        [Parameter]
        public UpdateAppointmentDto updateDto { get; set; }

        [Parameter]
        public Action CloseAction { get; set; }

        [Inject]
        private IMapper mapper { get; set; } // IMapper'ı burada enjekte ediyoruz

        private List<Clinic> clinics = new();
        private List<Client> clients = new();
        private List<User> doctors = new();

		private Clinic selectedClinic;
        private User selectedDoctor;
        private Client selectedClient;

		private List<DateTime> emptyHours = new();

        private DateTime firstAppointmenTime;


		protected override async Task OnParametersSetAsync()
		{
			await LoadDataAsync();
		}


		private async Task LoadDataAsync()
		{
			firstAppointmenTime = updateDto.AppointmentTime;

			doctors = await UserHelper.GetAllDoctors();
			clinics = await ClinicHelper.GetAllClinics();
			clients = await ClientHelper.GetAllClients();

            selectedDoctor = doctors.FirstOrDefault();
            selectedClinic = clinics.FirstOrDefault();
            selectedClient = clients.FirstOrDefault();

            updateDto.ClinicId = selectedClinic.Id;
            updateDto.ClientId = selectedClient.Id;
            updateDto.DoctorId = selectedDoctor.Id;

			Console.WriteLine("Oninitialize Appointment time : " + updateDto.AppointmentTime);
			UpdateEmptyHours();
		}

        private async void UpdateEmptyHours()
        {
            if(updateDto.AppointmentTime.Date != firstAppointmenTime.Date)
            {
                Console.WriteLine("Öncekinden farklı bir tarih seçti");
				updateDto.AppointmentTime = emptyHours.FirstOrDefault();
			}
			else
            {
                Console.WriteLine("Öncekiyle aynı tarihi seçti");
				updateDto.AppointmentTime = firstAppointmenTime.Date;
            }

            emptyHours = await AppointmentHelper.GetEmptyHours(updateDto.DoctorId, updateDto.AppointmentTime, selectedClinic.Minute, updateDto.Id);


            StateHasChanged();
        }



        private async Task UpdateAsync()
        {
            var request = new UpdateAppointmentRequest
            {
                updateDto = updateDto
            };


			var response = await NetworkManager.SendAsync<UpdateAppointmentRequest, UpdateAppointmentResponse>(request);

            if (response.message.IsSuccessStatusCode)
            {
				ShowMessage(ToastType.Primary, $"{selectedClient.Name} isimli hastanın randevusu başarılı şekilde güncellendi");
            }
            else
            {
                ShowMessage( ToastType.Warning , $"Kullanıcıyı güncellerken hata : {response.ErrorMessage}" );
            }

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
			updateDto.DoctorId = Guid.Parse(doctorId);
			selectedDoctor = doctors.Where(x => x.Id == Guid.Parse(doctorId)).FirstOrDefault();
			UpdateEmptyHours();
		}

		private void SetClinicByClinicId(string clinicId)
		{
			updateDto.ClinicId = Guid.Parse(clinicId);
			selectedClinic = clinics.Where(x => x.Id == Guid.Parse(clinicId)).FirstOrDefault();
			UpdateEmptyHours();
		}

		private void SetClientByClientId(string clientId)
		{
			updateDto.ClientId = Guid.Parse(clientId);
			selectedClient = clients.Where(x => x.Id == Guid.Parse(clientId)).FirstOrDefault();
			UpdateEmptyHours();
		}

	}
}
