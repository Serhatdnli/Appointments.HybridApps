using Appointments.Application.MediatR.Requests.ClientRequests;
using Appointments.Application.MediatR.Responses.ClientResponses;
using Appointments.Domain.Models;
using Appointments.Utility;
using BlazorBootstrap;
using Microsoft.AspNetCore.Components;

namespace Appointments.Web.Pages.Admin
{
    public partial class CreateClient : ComponentBase
    {
        private CreateClientRequest CreateClientRequest { get; set; } = new ();
        private async Task CreateAsync()
        {

            try
            {
                var response = await NetworkManager.SendAsync<CreateClientRequest, CreateClientResponse>(CreateClientRequest);
                ShowMessage(ToastType.Primary, $"{CreateClientRequest.Name} {CreateClientRequest.Surname} Isimli Hasta Başarılı Şekilde Eklendi");
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
