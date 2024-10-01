using Appointments.Domain.Enums;

namespace Appointments.Domain.Models
{
    public class Appointment : BaseEntity
    {
        public Guid DoctorId { get; set; }
        public Guid ClientId { get; set; }
        public Guid ClinicId { get; set; }
        public float Price { get; set; }
        public string? Notes { get; set; }
        public DateTime AppointmentTime { get; set; }
        public bool IsPayed { get; set; }
        public virtual Clinic Clinic { get; set; }
        public virtual User Doctor { get; set; }
        public virtual Client Client { get; set; }
        public virtual List<Payment> Payments { get; set; } = new List<Payment>();
    }
}
