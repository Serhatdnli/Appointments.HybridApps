using Appointments.Domain.Dtos;

namespace Appointments.Domain.Models
{
	public record ClinicDto : BaseDto
	{
		public string Name { get; set; }
		public int Minute { get; set; } = 0;

		public virtual List<Appointment> Appointments { get; set; } = new List<Appointment>();
	}
}
