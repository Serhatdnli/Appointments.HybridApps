using Appointments.Domain.Enums;
using Appointments.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Appointments.Infrastructure.Configrations
{
	public class AppointmentConfiguration : BaseEntityConfiguration<Appointment>
	{
		public override void Configure(EntityTypeBuilder<Appointment> builder)
		{
			base.Configure(builder);
			builder.ToTable("Appointments");


			builder.HasOne(x => x.Doctor)
				.WithMany(y => y.Appointments)
				.HasForeignKey(x => x.DoctorId);


			builder.HasOne(x => x.Client)
				.WithMany(x => x.Appointments)
				.HasForeignKey(x => x.ClientId);

			builder.HasMany(x => x.Payments)
				.WithOne(x => x.Appointment)
				.HasForeignKey(x => x.AppointmentId);
		}
	}
}
