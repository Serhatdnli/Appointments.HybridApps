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
using System.Net.NetworkInformation;

namespace Appointments.Web.Pages.Admin
{
    public partial class CreateClinic : ComponentBase
    {
        private Clinic Clinic { get; set; } = new Clinic();
        private string ClinicName { get; set; }

		private async Task CreateAsync()
        {

            var request = new GetAllClinicsByFilterRequest
            {
                Count = 0,
                Index = 0,
                Filter = new Clinic
                {
                    Name = ClinicName,
                }
            };

            var response = await NetworkManager.SendAsync<GetAllClinicsByFilterRequest, GetAllClinicsByFilterResponse>(request);
            if(response.Clinics?.Count > 0)
            {
                foreach (var clinic in response.Clinics)
                {
                    if(clinic.Name == ClinicName)
                    {
                        ShowMessage(ToastType.Danger, "Daha önce bu isimde bir klinik eklenmiş");
                        return;
                    }
                }
            }

         

            CreateClinicRequest createRequest = new CreateClinicRequest
            {
                RequesterId = Guid.Empty,
                Clinic = new Clinic
                {
                    Name = ClinicName,
                    CreateDate = DateTime.Now
                }
            };

            try
            {
                var response2 = await NetworkManager.SendAsync<CreateClinicRequest, CreateClinicResponse>(createRequest);
                ShowMessage(ToastType.Primary, $" {ClinicName} isimli klinik başarıyla eklendi");
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
