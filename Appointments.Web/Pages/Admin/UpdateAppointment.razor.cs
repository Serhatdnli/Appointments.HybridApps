using Appointments.Application.MediatR.Requests.AppointmentRequests;
using Appointments.Application.MediatR.Responses.AppointmentResponses;
using Appointments.Domain.Models;
using Appointments.Utility;
using BlazorBootstrap;
using Microsoft.AspNetCore.Components;

namespace Appointments.Web.Pages.Admin
{
	public partial class UpdateAppointment : ComponentBase
	{
		[Parameter]
		public string id { get; set; }

		private Appointment Appointment { get; set; } = new Appointment();



		protected override async Task OnInitializedAsync()
		{
			Console.WriteLine("alınan id değeri : " + id);

			var request = new GetAppointmentByIdRequest
			{
				Id = Guid.Parse(id)
			};

			var response = await NetworkManager.SendAsync<GetAppointmentByIdRequest, GetAppointmentByIdResponse>(request);
			Appointment = response.Appointment;
			//ObjectWriter.Write(Appointment);
		}

		private async Task UpdateAsync()
		{
			var request = new UpdateAppointmentRequest
			{
				Appointment = Appointment,
			};


			try
			{
				await NetworkManager.SendAsync<UpdateAppointmentRequest, UpdateAppointmentResponse>(request);
				ShowMessage(ToastType.Primary, $"{Appointment.Client.Name} {Appointment.Client.Surname} isimli hastanın randevusu Başarılı Şekilde Güncellendi");
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
