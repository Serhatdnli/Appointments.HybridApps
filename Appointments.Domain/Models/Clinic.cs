namespace Appointments.Domain.Models
{
    public class Clinic : BaseEntity
    {
        public string Name { get; set; }

        public virtual List<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
