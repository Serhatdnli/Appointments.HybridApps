


using Appointments.Application.Attributes;
using Appointments.Application.MediatR.Responses.AppointmentResponses;
using Appointments.Domain.Dtos.AppointmentDtos;
using Appointments.Domain.Models;

namespace Appointments.Application.MediatR.Requests.AppointmentRequests
{
    [NetworkAddress("Appointment/UpdateAppointment")]

	public class UpdateAppointmentRequest : MediatRBaseRequest<UpdateAppointmentResponse>
	{
        public UpdateAppointmentDto updateDto { get; set; } = new();
    }
}
