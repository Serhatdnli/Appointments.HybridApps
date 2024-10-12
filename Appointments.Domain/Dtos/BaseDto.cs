namespace Appointments.Domain.Dtos
{
	public record BaseDto
	{
		public Guid Id { get; set; }
		public DateTime CreateDate { get; set; }
	}
}
