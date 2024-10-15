using Appointments.Application.MediatR.Requests.AppointmentRequests;
using Appointments.Application.MediatR.Responses.AppointmentResponses;
using Appointments.Domain.Dtos;
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
        public AppointmentDto appointment { get; set; }

        [Parameter]
        public Action CloseAction { get; set; }

        [Inject]
        private IMapper mapper { get; set; } // IMapper'ı burada enjekte ediyoruz

        private List<Clinic> clinics = new();
        private List<Client> clients = new();
        private List<User> doctors = new();

        private List<DateTime> emptyHours = new();

        private DateTime firstAppointmenTime;



		protected override async Task OnParametersSetAsync()
		{
			await LoadDataAsync();
		}


		private async Task LoadDataAsync()
		{
			firstAppointmenTime = appointment.AppointmentTime;

			doctors = await UserHelper.GetAllDoctors();
			clinics = await ClinicHelper.GetAllClinics();
			clients = await ClientHelper.GetAllClients();

			Console.WriteLine("Oninitialize Appointment time : " + appointment.AppointmentTime);
			UpdateEmptyHours();
		}

        private async void UpdateEmptyHours()
        {
            if(appointment.AppointmentTime.Date != firstAppointmenTime.Date)
            {
                Console.WriteLine("Öncekinden farklı bir tarih seçti");
				appointment.AppointmentTime = emptyHours.FirstOrDefault();
			}
			else
            {
                Console.WriteLine("Öncekiyle aynı tarihi seçti");
                appointment.AppointmentTime = firstAppointmenTime.Date;
            }
            
            emptyHours = await AppointmentHelper.GetEmptyHours(appointment.Doctor.Id, appointment.AppointmentTime, appointment.Clinic.Minute, appointment.Id);

            

            StateHasChanged();
        }



        private async Task UpdateAsync()
        {
            var request = new UpdateAppointmentRequest
            {
                Appointment = mapper.Map<Appointment>(appointment),
            };


            try
            {
                var response = await NetworkManager.SendAsync<UpdateAppointmentRequest, UpdateAppointmentResponse>(request);
                
                ShowMessage(ToastType.Primary, $"{appointment.Client.Name} isimli hastanın randevusu başarılı şekilde güncellendi");
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
