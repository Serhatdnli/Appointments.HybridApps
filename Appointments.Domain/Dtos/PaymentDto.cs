using Appointments.Domain.Dtos;
using Appointments.Domain.Enums;

namespace Appointments.Domain.Models
{
	public record PaymentDto : BaseDto
	{
		public float Price { get; set; }
		public PaymentType PaymentType { get; set; }

		public virtual Appointment Appointment { get; set; }

	}
}
