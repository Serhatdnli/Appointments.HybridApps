﻿using Appointments.Domain.Enums;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Appointments.Domain.Models
{
    public class User : BaseEntity
    {

		public string Name { get; set; }

		public string Surname { get; set; }

		public string Email { get; set; }

		public string Password { get; set; }

		public string TcId { get; set; }

		[Phone]
		public string PhoneNumber { get; set; }

		public UserRoleType Role { get; set; }
        public virtual List<Appointment> Appointments { get; set; } = new List<Appointment>();

    }
}
