using Appointments.Domain.Dtos;
using Appointments.Domain.Enums;

namespace Appointments.Domain.Models
{
	public record UserDto : BaseDto
	{
		public string Name { get; set; } = string.Empty;
		public string Surname { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;

		public string TcId { get; set; } = string.Empty;


		public string PhoneNumber { get; set; } = string.Empty;
		public UserRoleType Role { get; set; } = UserRoleType.None;

		public virtual List<Appointment> Appointments { get; set; } = new List<Appointment>();
	}
}
