using Appointments.Application.Attributes;
using Appointments.Application.MediatR.Responses.AppointmentResponses;
using Appointments.Domain.Models;

namespace Appointments.Application.MediatR.Requests.AppointmentRequests
{
	[NetworkAddress("Appointment/CreateAppointment")]

	public class CreateAppointmentRequest : MediatRBaseRequest<CreateAppointmentResponse>
	{
		public Appointment Appointment { get; set; }
	}
}
