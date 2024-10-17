using Appointments.Domain.Models;

namespace Appointments.Domain.Dtos.AppointmentDtos
{
    public record UpdateAppointmentDto : BaseDto
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
