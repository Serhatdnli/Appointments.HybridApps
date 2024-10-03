using Appointments.Application.Attributes;
using Appointments.Application.MediatR.Responses.AppointmentResponses;
using Appointments.Domain.Enums.FilterTypes;

namespace Appointments.Application.MediatR.Requests.AppointmentRequests
{
	[NetworkAddress("Appointment/GetAllAppointmentsByFilter")]

	public class GetAllAppointmentsByFilterRequest : MediatRBaseRequest<GetAllAppointmentsByFilterResponse>
	{
		public int Index { get; set; }
		public int Count { get; set; }
		public Dictionary<AppointmentFilterType, string> Filter { get; set; }

	}
}