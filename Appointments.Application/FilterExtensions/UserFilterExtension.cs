using Appointments.Application.Filters;
using Appointments.Domain.Enums;
using Appointments.Domain.Models;
using Microsoft.IdentityModel.Tokens;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace Appointments.Application.FilterExtensions
{
	public static class UserFilterExtension
	{
	

		public static IQueryable<User>  GetAllUsersByFilter(this IQueryable<User> users, UserFilter filter)
		{
			if (!filter.Name.IsNullOrEmpty())
			{
				users = NameFilter(users, filter.Name, filter.NameFullMatch);
			}

			if (!filter.Surname.IsNullOrEmpty())
			{
				users = SurnameFilter(users, filter.Surname, filter.SurnameFullMatch);
			}

			if (!filter.Email.IsNullOrEmpty())
			{
				users = EMailFilter(users, filter.Email, filter.EmailFullMatch);
			}

			if (!filter.TcId.IsNullOrEmpty())
			{
				users = TcIdFilter(users, filter.TcId, filter.TcIdFullMatch);
			}

			if (!filter.PhoneNumber.IsNullOrEmpty())
			{
				users = PhoneNumberFilter(users, filter.PhoneNumber, filter.PhoneNumberFullMatch);
			}

			if (!filter.Role.ToString().IsNullOrEmpty() && filter.Role != UserRoleType.None)
			{
				users = RoleFilter(users, filter.Role.ToString(), filter.RoleFullMatch);
			}

			if (!filter.CreateDate.ToString().IsNullOrEmpty() && filter.CreateDate != DateTime.MinValue)
			{
				users = CreateDateFilter(users, filter.CreateDate, filter.CreateDateFullMatch);
			}

			return users;

		}

		private static IQueryable<User> NameFilter(IQueryable<User> users, string name, bool fullMatch)
		{
			if (fullMatch)
			{
				users = users.Where(u => u.Name == name);
			}
			else
			{
				users = users.Where(u => u.Name.Contains(name));
			}
			return users;
		}


		private static IQueryable<User> SurnameFilter(IQueryable<User> users, string surname, bool fullMatch)
		{
			if (fullMatch)
			{
				users = users.Where(u => u.Surname == surname);
			}
			else
			{
				users = users.Where(u => u.Surname.Contains(surname));
			}
			return users;
		}


		private static IQueryable<User> EMailFilter(IQueryable<User> users, string email, bool fullMatch)
		{
			if (fullMatch)
			{
				users = users.Where(u => u.Email == email);
			}
			else
			{
				users = users.Where(u => u.Email.Contains(email));
			}
			return users;
		}

		
		private static IQueryable<User> TcIdFilter(IQueryable<User> users, string tcId, bool fullMatch)
		{
			if (fullMatch)
			{
				users = users.Where(u => u.TcId == tcId);
			}
			else
			{
				users = users.Where(u => u.TcId.Contains(tcId));
			}
			return users;
		}


		private static IQueryable<User> PhoneNumberFilter(IQueryable<User> users, string phoneNumber, bool fullMatch)
		{
			if (fullMatch)
			{
				users = users.Where(u => u.PhoneNumber == phoneNumber);
			}
			else
			{
				users = users.Where(u => u.PhoneNumber.Contains(phoneNumber));
			}
			return users;
		}




		private static IQueryable<User> RoleFilter(IQueryable<User> users, string role, bool fullMatch)
		{
			if (fullMatch)
			{
				users = users.Where(u => u.Role.ToString() == role);
			}
			else
			{
				users = users.Where(u => u.Role.ToString().Contains(role));
			}
			return users;
		}

		private static IQueryable<User> CreateDateFilter(IQueryable<User> users, DateTime createDate, bool fullMatch)
		{
			if (fullMatch)
			{
				users = users.Where(u => u.CreateDate.Date == createDate.Date);
			}
			else
			{
				DateTime endDate = DateTime.Now;

				users = users.Where(u => u.CreateDate >= createDate && u.CreateDate <= endDate);
			}
			return users;
		}


	}
}
