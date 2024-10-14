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
        public AppointmentDto Appointment { get; set; }

        [Parameter]
        public Action CloseAction { get; set; }
        private List<Clinic> Clinics = new();
        private List<Client> Clients = new();
        private List<User> Doctors = new();

        private List<DateTime> emptyHours = new();

        private Client oldClient;


        [Inject]
        private IMapper mapper { get; set; } // IMapper'ı burada enjekte ediyoruz

        private async void UpdateEmptyHours()
        {
            emptyHours = await AppointmentHelper.GetEmptyHours(Appointment.Doctor.Id, Appointment.AppointmentTime, (oldClient.Id, Appointment.AppointmentTime));

            Appointment.AppointmentTime = emptyHours.FirstOrDefault();

            StateHasChanged();
        }

        protected override async Task OnInitializedAsync()
        {
            oldClient = Appointment.Client;

            Doctors = await UserHelper.GetAllDoctors();
            Clinics = await ClinicHelper.GetAllClinics();
            Clients = await ClientHelper.GetAllClients();
            UpdateEmptyHours();

            Console.WriteLine("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");

        }

        private async Task UpdateAsync()
        {
            var request = new UpdateAppointmentRequest
            {
                Appointment = mapper.Map<Appointment>(Appointment),
            };


            try
            {
                await NetworkManager.SendAsync<UpdateAppointmentRequest, UpdateAppointmentResponse>(request);
                ShowMessage(ToastType.Primary, $"{Appointment.Client.Name} isimli hastanın randevusu başarılı şekilde güncellendi");
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
