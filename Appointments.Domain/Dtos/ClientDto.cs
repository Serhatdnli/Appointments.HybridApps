using Appointments.Domain.Dtos;

namespace Appointments.Domain.Models
{
	public record ClientDto : BaseDto
	{
		public string Name { get; set; } = string.Empty;

		public string Surname { get; set; } = string.Empty;

		public string Email { get; set; } = string.Empty;

		public string TcId { get; set; } = string.Empty;


		public string PhoneNumber { get; set; } = string.Empty;


		public virtual List<Appointment> Appointments { get; set; } = new List<Appointment>();
	}
}
