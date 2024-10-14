using Appointments.Application.Attributes;
using Appointments.Application.MediatR.Responses.AppointmentResponses;
using Appointments.Domain.Dtos;
using Appointments.Domain.Models;
using Appointments.Shared.Attributes;

namespace Appointments.Application.MediatR.Requests.AppointmentRequests
{
	[NetworkAddress("Appointment/CreateAppointment")]

	public class CreateAppointmentRequest : MediatRBaseRequest<CreateAppointmentResponse>
	{
        public Guid DoctorId { get; set; }
        public Guid ClientId { get; set; }
        public Guid ClinicId { get; set; }
        public float Price { get; set; }
        public string? Notes { get; set; }
        public DateTime AppointmentTime { get; set; }
        public DateTime AppointmentFinishTime { get; set; } = DateTime.MinValue;
        public bool IsPayed { get; set; }
    }
}
