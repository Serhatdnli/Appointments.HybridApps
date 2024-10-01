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

			builder.HasOne(x => x.Clinic)
				.WithMany(y => y.Appointments)
				.HasForeignKey(x => x.ClinicId);

			builder.HasOne(x => x.Doctor)
				.WithMany(y => y.Appointments)
				.HasForeignKey(x => x.DoctorId);


			builder.HasOne(x => x.Client)
				.WithMany(x => x.Appointments)
				.HasForeignKey(x => x.ClientId);

			builder.HasMany(x => x.Payments)
				.WithOne(x => x.Appointment)
				.HasForeignKey(x => x.AppointmentId);

			//builder.HasData(
			//	new Appointment
			//	{
			//		Id =		Guid.Parse("d24ad965-ffa5-4da0-a881-9a8449cd1a73"),
			//		ClientId =	Guid.Parse("92a3b5ad-8c14-4532-9732-baef3c45bd7b"),
			//		DoctorId =	Guid.Parse("fd7d9a11-8915-4d50-b4de-a7bdd8635c82"),
			//		ClinicId =	Guid.Parse("e39436e5-3211-42e4-9ed9-d49089c48238"),
			//		AppointmentTime = DateTime.Now,
			//		CreateDate = DateTime.Now,
			//		IsPayed = false,
			//		Notes = "first",
			//		Price = 1000
			//	},
			//	new Appointment
			//	{
			//		Id =		Guid.Parse("bff90865-09b8-4fbc-bbf6-92432f79c196"),
			//		ClientId =	Guid.Parse("92a3b5ad-8c14-4532-9732-baef3c45bd7b"),
			//		DoctorId =	Guid.Parse("fd7d9a11-8915-4d50-b4de-a7bdd8635c82"),
			//		ClinicId =	Guid.Parse("e39436e5-3211-42e4-9ed9-d49089c48238"),
			//		AppointmentTime = DateTime.Now,
			//		CreateDate = DateTime.Now,
			//		IsPayed = false,
			//		Notes = "second",
			//		Price = 1500
			//	}
			//	);
		}
	}
}
