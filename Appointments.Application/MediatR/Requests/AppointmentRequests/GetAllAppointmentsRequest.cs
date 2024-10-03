using Appointments.Application.Attributes;
using Appointments.Application.MediatR.Responses.AppointmentResponses;

namespace Appointments.Application.MediatR.Requests.AppointmentRequests
{

	[NetworkAddress("Appointment/GetAllAppointments")]

	public class GetAllAppointmentsRequest : MediatRBaseRequest<GetAllAppointmentsResponse>
	{
		public int Index { get; set; }
		public int Count { get; set; }

	}

}

