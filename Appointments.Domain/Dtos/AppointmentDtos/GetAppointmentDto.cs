using Appointments.Domain.Models;

namespace Appointments.Domain.Dtos.AppointmentDtos
{
    public record GetAppointmentDto : BaseDto
    {
        public Guid DoctorId { get; set; }
        public Guid ClientId { get; set; }
        public Guid ClinicId { get; set; }
        public float Price { get; set; }
        public string? Notes { get; set; }
        public DateTime AppointmentTime { get; set; }
        public DateTime AppointmentFinishTime { get; set; } = DateTime.MinValue;
        public bool IsPayed { get; set; }
        public virtual Clinic? Clinic { get; set; }
        public virtual User? Doctor { get; set; }
        public virtual Client? Client { get; set; }
        public virtual List<Payment> Payments { get; set; } = new List<Payment>();
    }
}
