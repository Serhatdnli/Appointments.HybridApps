using Appointments.Application.Attributes;
using Appointments.Application.MediatR.Responses.AppointmentResponses;
using Appointments.Domain.Dtos;
using Appointments.Domain.Dtos.AppointmentDtos;
using Appointments.Domain.Models;
using Appointments.Shared.Attributes;

namespace Appointments.Application.MediatR.Requests.AppointmentRequests
{
	[NetworkAddress("Appointment/CreateAppointment")]

	public class CreateAppointmentRequest : MediatRBaseRequest<CreateAppointmentResponse>
	{
		public CreateAppointmentDto createDto { get; set; } = new();
    }
}
