using Appointments.Application.Attributes;
using Appointments.Application.MediatR.Responses.AppointmentResponses;

namespace Appointments.Application.MediatR.Requests.AppointmentRequests
{
	[NetworkAddress("Appointment/DeleteAllAppointments")]

	public class DeleteAllAppointmentsRequest : MediatRBaseRequest<DeleteAllAppointmentsResponse>
	{

	}
}
