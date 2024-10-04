using Appointments.Domain.Enums;
using Appointments.Shared.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Appointments.Domain.Models
{
    public class User : BaseEntity
    {

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }
        [NotShow]
        public string Password { get; set; }

        public string TcId { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        public UserRoleType Role { get; set; }
        public virtual List<Appointment> Appointments { get; set; } = new List<Appointment>();

    }
}
