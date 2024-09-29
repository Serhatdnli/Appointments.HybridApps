using Appointments.Domain.Enums;

namespace Appointments.Application.Filters
{
	public class UserFilter
	{
		public string Name { get; set; } = null;
		public bool NameFullMatch { get; set; }
		public string Surname { get; set; } = null;
		public bool SurnameFullMatch { get; set; }
		public string Email { get; set; } = null;
		public bool EmailFullMatch { get; set; }
		public string TcId { get; set; } = null;
		public bool TcIdFullMatch { get; set; } 
		public string PhoneNumber { get; set; } = null;
		public bool PhoneNumberFullMatch { get; set; }
		public UserRoleType Role { get; set; } = UserRoleType.None;
		public bool RoleFullMatch { get; set; }
		public DateTime CreateDate { get; set; } = DateTime.MinValue;
		public bool CreateDateFullMatch { get; set; }
	}
}
