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
    public partial class ShowAppointment : ComponentBase
    {
        [Parameter]
        public GetAppointmentDto showedAppointment{ get; set; }

        [Parameter]
        public Action CloseAction { get; set; }

        [Inject]
        private IMapper mapper { get; set; } // IMapper'ı burada enjekte ediyoruz

        private bool isUpdated = false;
        private UpdateAppointmentDto updateDto;

        private List<Clinic> clinics = new();
        private List<Client> clients = new();
        private List<User> doctors = new();

		private Clinic selectedClinic;
        private User selectedDoctor;
        private Client selectedClient;




		protected override async Task OnParametersSetAsync()
		{
            Console.WriteLine($"Appointment dc name : {showedAppointment.Doctor}");
        }

        private void UpdateAppointment(bool isUpdated)
        {
            if (isUpdated)
            {
                updateDto = mapper.Map<UpdateAppointmentDto>(showedAppointment);
            }

            this.isUpdated = isUpdated;
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
