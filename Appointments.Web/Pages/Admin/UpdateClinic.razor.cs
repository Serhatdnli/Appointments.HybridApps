using Appointments.Application.MediatR.Requests.ClinicRequests;
using Appointments.Application.MediatR.Responses.ClinicResponses;
using Appointments.Domain.Models;
using Appointments.Utility;
using BlazorBootstrap;
using Microsoft.AspNetCore.Components;

namespace Appointments.Web.Pages.Admin
{
    public partial class UpdateClinic : ComponentBase
    {
        [Parameter]
        public string id { get; set; }

        private Clinic Clinic { get; set; } = new Clinic();



        protected override async Task OnInitializedAsync()
        {
            Console.WriteLine("alınan id değeri : " + id);

            var request = new GetClinicByIdRequest
            {
                Id = Guid.Parse(id)
            };

            var response = await NetworkManager.SendAsync<GetClinicByIdRequest, GetClinicByIdResponse>(request);

            //ObjectWriter.Write(response);
            Clinic = response.Clinic;
            //ObjectWriter.Write(Client);
        }

        private async Task UpdateAsync()
        {
            var request = new UpdateClinicRequest
            {
                Clinic = Clinic,
            };


            try
            {
                await NetworkManager.SendAsync<UpdateClinicRequest, UpdateClinicResponse>(request);
                ShowMessage(ToastType.Primary, $"{Clinic.Name}  Kliniği Başarılı Şekilde Güncellendi");
            }
            catch (Exception e)
            {

                ShowMessage(ToastType.Primary, e.ToString());
                throw;
            }

            //ObjectWriter.Write(Client);
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
