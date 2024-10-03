using Appointments.Application.Attributes;
using Appointments.Application.MediatR.Responses.AppointmentResponses;

namespace Appointments.Application.MediatR.Requests.AppointmentRequests
{
	[NetworkAddress("Appointment/AddRandomAppointment")]

	public class AddRandomAppointmentRequest : MediatRBaseRequest<AddRandomAppointmentResponse>
	{
		public int Count { get; set; }
	}
}
