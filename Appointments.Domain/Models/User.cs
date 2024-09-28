using Appointments.Domain.Enums;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Appointments.Domain.Models
{
    public class User : BaseEntity
    {

		[JsonPropertyName("name")]
		public string Name { get; set; }

		[JsonPropertyName("surname")]
		public string Surname { get; set; }

		[JsonPropertyName("email")]
		public string Email { get; set; }

		[JsonPropertyName("password")]
		public string Password { get; set; }

		[JsonPropertyName("tcId")]
		public string TcId { get; set; }

		[JsonPropertyName("phoneNumber")]
		[Phone]
		public string PhoneNumber { get; set; }

		[JsonPropertyName("role")]
		[JsonConverter(typeof(JsonStringEnumConverter))]

		public UserRoleType Role { get; set; } // Enum kullanıyorsanız JsonStringEnumConverter ile dönüştürmeyi unutmayın

		[JsonPropertyName("id")]
		public Guid Id { get; set; }

		[JsonPropertyName("createDate")]
		public DateTime CreateDate { get; set; }


    }
}
