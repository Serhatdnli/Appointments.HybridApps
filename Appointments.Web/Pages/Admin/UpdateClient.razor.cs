using Appointments.Application.MediatR.Requests.ClientRequests;
using Appointments.Application.MediatR.Responses.ClientResponses;
using Appointments.Domain.Models;
using Appointments.Utility;
using BlazorBootstrap;
using Microsoft.AspNetCore.Components;

namespace Appointments.Web.Pages.Admin
{
	public partial class UpdateClient : ComponentBase
	{
		[Parameter]
		public string id { get; set; }

		private Client Client { get; set; } = new Client();



		protected override async Task OnInitializedAsync()
		{
			//Console.WriteLine("alınan id değeri : " + id);

			var request = new GetClientByIdRequest
			{
				Id = Guid.Parse(id)
			};

			var response = await NetworkManager.SendAsync<GetClientByIdRequest, GetClientByIdResponse>(request);

			//ObjectWriter.Write(response);
			Client = response.Client;
			//ObjectWriter.Write(Client);
		}

		private async Task UpdateAsync()
		{
			var request = new UpdateClientRequest
			{
				Client = Client,
			};


			try
			{
				await NetworkManager.SendAsync<UpdateClientRequest, UpdateClientResponse>(request);
				ShowMessage(ToastType.Primary, $"{Client.Name} {Client.Surname} Personeli Başarılı Şekilde Güncellendi");
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
