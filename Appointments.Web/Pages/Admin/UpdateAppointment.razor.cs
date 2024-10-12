using Appointments.Application.MediatR.Requests.AppointmentRequests;
using Appointments.Application.MediatR.Responses.AppointmentResponses;
using Appointments.Domain.Dtos.AppointmentDtos;
using Appointments.Domain.Models;
using Appointments.Utility;
using AutoMapper;
using BlazorBootstrap;
using Microsoft.AspNetCore.Components;
using System.Runtime.CompilerServices;

namespace Appointments.Web.Pages.Admin
{
	public partial class UpdateAppointment : ComponentBase
	{


		[Parameter]
		public string id { get; set; }

		[Inject]
		private IMapper mapper { get; set; } // IMapper'ı burada enjekte ediyoruz
		private UpdateAppointmentDto UpdateDto { get; set; } = new UpdateAppointmentDto();


		protected override async Task OnInitializedAsync()
		{
			//Console.WriteLine("alınan id değeri : " + id);

			var request = new GetAppointmentByIdRequest
			{
				Id = Guid.Parse(id)
			};

			var response = await NetworkManager.SendAsync<GetAppointmentByIdRequest, GetAppointmentByIdResponse>(request);
			
			UpdateDto = mapper.Map<UpdateAppointmentDto>(response.Appointment);
			//ObjectWriter.Write(Appointment);
		}

		private async Task UpdateAsync()
		{
			var request = new UpdateAppointmentRequest
			{
				UpdateDto = UpdateDto,
			};


			try
			{
				await NetworkManager.SendAsync<UpdateAppointmentRequest, UpdateAppointmentResponse>(request);
				ShowMessage(ToastType.Primary, $"{UpdateDto.ClientId} id'li hastanın randevusu Başarılı Şekilde Güncellendi");
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
