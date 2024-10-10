using Appointments.Domain.Enums;
using Appointments.Shared.Attributes;

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
        public DateTime AppointmentFinishTime { get; set; } = DateTime.MinValue;
        public bool IsPayed { get; set; }


        [NotShow]
        [NotFilterable]
        public virtual Clinic Clinic { get; set; }
		[NotShow]
		[NotFilterable]
		public virtual User Doctor { get; set; }
		[NotShow]
		[NotFilterable]
		public virtual Client Client { get; set; }
		[NotShow]
		[NotFilterable]
		public virtual List<Payment> Payments { get; set; } = new List<Payment>();
    }
}
