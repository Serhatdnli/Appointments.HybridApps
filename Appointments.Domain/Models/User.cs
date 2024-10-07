using Appointments.Domain.Enums;
using Appointments.Shared.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Appointments.Domain.Models
{
	public class User : BaseEntity
	{
		public string Name { get; set; } = string.Empty;
		public string Surname { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;

		[NotFilterable]
		[NotShow]
		public string Password { get; set; } = string.Empty;
		public string TcId { get; set; } = string.Empty;


		public string PhoneNumber { get; set; } = string.Empty;
		public UserRoleType Role { get; set; } = UserRoleType.None;

		[NotFilterable]
		[NotShow]
		public virtual List<Appointment> Appointments { get; set; } = new List<Appointment>();
	}
}
