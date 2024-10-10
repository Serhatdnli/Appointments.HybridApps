using Appointments.Shared.Attributes;

namespace Appointments.Domain.Models
{
    public class Clinic : BaseEntity
    {
        public string Name { get; set; }
        public int Minute { get; set; } = 0;

		[NotShow]
        [NotFilterable]
        public virtual List<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
