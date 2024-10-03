using Appointments.Domain.Models;

namespace Appointments.Application.MediatR.Responses.AppointmentResponses
{
	public class GetAppointmentByIdResponse : MediatRBaseResponse
	{
		public Appointment Appointment { get; set; }
	}

}