using Appointments.Application.MediatR.Handlers.UserHandlers;
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
        private List<User> Doctors = new();


        private Client Client { get; set; }
        private User Doctor { get; set; }
        private Clinic Clinic { get; set; }

        private string ClientTcId { get; set; }


		protected override async Task OnInitializedAsync()
		{
            Doctors = await GetDoctors();
            Clinics = await GetClinics();
		}

        private async Task ConfirmClientTC()
        {
            var request = new GetAllClientsByFilterRequest
            {
                Count = 0,
                Index = 0,
                Filter = new Client
                {
                    TcId = ClientTcId
				}
            };

            var response = await NetworkManager.SendAsync<GetAllClientsByFilterRequest, GetAllClientsByFilterResponse>(request);

            if(response.Count == 0)
            {
                Client = null;
				ShowMessage(ToastType.Danger, ClientTcId +  "'sine sahip bir hasta bulunamadı."); 
            }

            if(response.Count > 1)
            {
                Client = null;
				ShowMessage(ToastType.Danger,  "Lütfen TC yi kontrol ediniz");
			}

            Client = response.Clients.FirstOrDefault();
			ShowMessage(ToastType.Danger, "Girilen Kimlik Numarası, " + Client.Name + " " + Client.Surname + " kişisi olarak onaylandı");
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
