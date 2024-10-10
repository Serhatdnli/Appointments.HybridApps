using Appointments.Application.MediatR.Requests.ClinicRequests;
using Appointments.Application.MediatR.Responses.ClinicResponses;
using Appointments.Domain.Models;
using Appointments.Utility;
using BlazorBootstrap;
using Microsoft.AspNetCore.Components;

namespace Appointments.Web.Pages.Admin
{
	public partial class CreateClinic : ComponentBase
	{
		private Clinic Clinic { get; set; } = new Clinic();

		private async Task CreateAsync()
		{

			var request = new GetAllClinicsByFilterRequest
			{
				Count = 0,
				Index = 0,
				Filter = new Clinic
				{
					Name = Clinic.Name,
				}
			};

			var response = await NetworkManager.SendAsync<GetAllClinicsByFilterRequest, GetAllClinicsByFilterResponse>(request);
			if (response.Clinics?.Count > 0)
			{
				foreach (var clinic in response.Clinics)
				{
					if (clinic.Name == Clinic.Name)
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
					Name = Clinic.Name,
					CreateDate = DateTime.Now
				}
			};

			try
			{
				var response2 = await NetworkManager.SendAsync<CreateClinicRequest, CreateClinicResponse>(createRequest);
				ShowMessage(ToastType.Primary, $" {Clinic.Name} isimli klinik başarıyla eklendi");
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
