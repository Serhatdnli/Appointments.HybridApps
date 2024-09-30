using Appointments.Domain.Enums;

namespace Appointments.Domain.Models
{
    public class Payments : BaseEntity
    {
        public float Price { get; set; }
        public PaymentType PaymentType { get; set; }
        public virtual Appointment Appointment { get; set; }
    }
}
