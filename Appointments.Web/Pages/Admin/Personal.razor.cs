using Appointments.Application.MediatR.Requests.AppointmentRequests;
using Appointments.Application.MediatR.Responses.AppointmentResponses;
using Appointments.Domain.Dtos.AppointmentDtos;
using Appointments.Domain.Models;
using Appointments.Shared.Extensions;
using Appointments.Utility;
using BlazorBootstrap;
using Microsoft.AspNetCore.Components;

namespace Appointments.Web.Pages.Admin
{
	public partial class Personal : ComponentBase
	{
		[Parameter]
		public string Id { get; set; }

		private List<GetAppointmentDto> appointments = new();
		private GetAppointmentDto tempAppointment;

		private DateTime orderDate;

		protected async override Task OnInitializedAsync()
		{
			SetWeekDates();

			await GetAppointmentsOfSelectedWeekAsync();
		}


		public List<string> daysOfWeek = new List<string>
		{
			"Pazartesi",
			"Salı",
			"Çarşamba",
			"Perşembe",
			"Cuma"
		};

		private async Task GetAppointmentsOfSelectedWeekAsync()
		{
			orderDate = monday;

            var request = new GetAppointmentsWeeklyByDoctorIdAndDateRequest
			{
				DoctorId = Guid.Parse(Id),
				monday = monday,
				saturday = saturday
			};
			var response = await NetworkManager.SendAsync<GetAppointmentsWeeklyByDoctorIdAndDateRequest, GetAppointmentsWeeklyByDoctorIdAndDateResponse>(request);

			if (response.message.IsSuccessStatusCode)
			{
				appointments = response.Appointments;

                foreach (var item in appointments)
                {
                    Console.WriteLine(item.AppointmentTime);
                }
            }
			else
			{
                Console.WriteLine("veriler getirilirken hata");
            }

		}

		private void SetWeekDates()
		{
			today = DateTime.Today;


			thisWeekStart = today.AddDays(-(int)today.DayOfWeek + (int)DayOfWeek.Monday);
			lastWeekStart = thisWeekStart.AddDays(-7);
			nextWeekStart = thisWeekStart.AddDays(7);

			monday = thisWeekStart;
			saturday = monday.AddDays(5);
		}

		private async Task ChangedWeekAsync(string mondayDatestring)
		{
            Console.WriteLine("tarih değişti");

            monday = DateTime.Parse(mondayDatestring);
			saturday = monday.AddDays(5);

			await GetAppointmentsOfSelectedWeekAsync();
		}

		DateTime monday, saturday;
		DateTime today, thisWeekStart, lastWeekStart, nextWeekStart;
	}



}

