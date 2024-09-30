using Appointments.Domain.Enums;

namespace Appointments.Domain.Models
{
    public class Payment : BaseEntity
    {
        public Guid AppointmentId{ get; set; }
        public float Price { get; set; }
        public PaymentType PaymentType { get; set; }
        public virtual Appointment Appointment { get; set; }

    }
}
