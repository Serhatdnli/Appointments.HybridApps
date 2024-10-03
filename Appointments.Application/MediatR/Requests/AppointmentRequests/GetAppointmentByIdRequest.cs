using Appointments.Application.Attributes;
using Appointments.Application.MediatR.Responses.AppointmentResponses;

namespace Appointments.Application.MediatR.Requests.AppointmentRequests
{
	[NetworkAddress("Appointment/GetAppointmentById")]

	public class GetAppointmentByIdRequest : MediatRBaseRequest<GetAppointmentByIdResponse>
	{
		public Guid Id { get; set; }
	}
}
