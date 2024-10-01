using Appointments.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Appointments.Infrastructure.Configrations
{
	public class ClinicConfiguration : BaseEntityConfiguration<Clinic>
	{
		public override void Configure(EntityTypeBuilder<Clinic> builder)
		{
			base.Configure(builder);
			builder.ToTable("Clinics");

			//builder.HasData(
			//	 new Clinic
			//	 {
			//		 CreateDate = DateTime.Now,
			//		 Id = Guid.Parse("e39436e5-3211-42e4-9ed9-d49089c48238"),
			//		 Name = "Fizyoterapi",

			//	 },

			//	 new Clinic
			//	 {
			//		 CreateDate = DateTime.Now,
			//		 Id = Guid.Parse("7f1f0556-07a5-4207-a494-7653cf8008a7"),
			//		 Name = "Masaj",

			//	 }
			//);
		}
	}
}
