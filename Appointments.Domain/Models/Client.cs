using Appointments.Shared.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Appointments.Domain.Models
{
    public class Client : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public string Surname { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string TcId { get; set; } = string.Empty;

        
        public string PhoneNumber { get; set; } = string.Empty;


        [NotFilterable]
        [NotShow]
        public virtual List<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
