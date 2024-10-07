using Appointments.Domain.Enums;
using Appointments.Shared.Attributes;

namespace Appointments.Domain.Models
{
    public class Payment : BaseEntity
    {
        public Guid AppointmentId{ get; set; }
        public float Price { get; set; }
        public PaymentType PaymentType { get; set; }

        [NotFilterable]
        [NotShow]
        public virtual Appointment Appointment { get; set; }

    }
}
