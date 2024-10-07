using Appointments.Shared.Attributes;

namespace Appointments.Domain.Models
{
    public class Clinic : BaseEntity
    {
        public string Name { get; set; }

        [NotShow]
        [NotFilterable]
        public virtual List<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
