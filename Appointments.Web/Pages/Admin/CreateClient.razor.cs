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
        private Client Client { get; set; } = new Client();
        private async Task CreateAsync()
        {
            Client.CreateDate = DateTime.Now;
            CreateClientRequest request = new CreateClientRequest
            {
                Client = Client,
                RequesterId = Guid.Empty
            };

            try
            {
                var response = await NetworkManager.SendAsync<CreateClientRequest, CreateClientResponse>(request);
                ShowMessage(ToastType.Primary, $"{Client.Name} {Client.Surname} Isimli Hasta Başarılı Şekilde Eklendi");
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
