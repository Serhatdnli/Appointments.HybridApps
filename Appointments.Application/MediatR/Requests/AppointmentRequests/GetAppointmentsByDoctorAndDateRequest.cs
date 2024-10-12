using Appointments.Application.Attributes;
using Appointments.Application.MediatR.Responses.AppointmentResponses;

namespace Appointments.Application.MediatR.Requests.AppointmentRequests
{
	[NetworkAddress("Appointment/GetAppointmentsByDoctorAndDateRequest")]

	public class GetAppointmentsByDoctorAndDateRequest : MediatRBaseRequest<GetAppointmentsByDoctorAndDateResponse>
	{
		public int Index { get; set; }
		public int Count { get; set; }
		public Guid DoctorId { get; set; }
		public DateTime Datetime { get; set; }
	}
}