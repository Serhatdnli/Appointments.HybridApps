using System.ComponentModel.DataAnnotations;

namespace Appointments.Domain.Models
{
    public class Client : BaseEntity
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string TcId { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        public virtual List<Appointment> Appointments { get; set; }
    }
}
