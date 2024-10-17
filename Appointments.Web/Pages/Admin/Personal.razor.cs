using Appointments.Domain.Dtos.AppointmentDtos;
using Appointments.Domain.Models;
using Microsoft.AspNetCore.Components;

namespace Appointments.Web.Pages.Admin
{
	public partial class Personal : ComponentBase
	{
		[Parameter]
		public string Id { get; set; }


		private List<GetAppointmentDto> appointments { get; set; } = new();

		private GetAppointmentDto tempAppointment { get; set; }
		private DateTime orderDate = DateTime.Today.AddHours(9);



		protected async override Task OnInitializedAsync()
		{
			Console.WriteLine("id : " + Id);

		}
	}
}
