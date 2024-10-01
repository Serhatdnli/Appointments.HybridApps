using Appointments.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Appointments.Infrastructure.Configrations
{

	public class PaymentConfiguration : BaseEntityConfiguration<Payment>
	{
		public override void Configure(EntityTypeBuilder<Payment> builder)
		{
			base.Configure(builder);
			builder.ToTable("Payments");

			//builder.HasData(
			//	new Payment
			//	{
			//		AppointmentId = Guid.Parse("37bc8396-a1eb-4730-bb98-46a34cb017bd"),
			//		CreateDate = DateTime.Now,
			//		Id = Guid.NewGuid(),
			//		PaymentType = Domain.Enums.PaymentType.Cash,
			//		Price = 100
			//	},

			//	new Payment
			//	{
			//		AppointmentId = Guid.Parse("6ab54c5f-1602-43a6-a1d7-99d5c7c20d67"),
			//		CreateDate = DateTime.Now,
			//		Id = Guid.NewGuid(),
			//		PaymentType = Domain.Enums.PaymentType.Credit_Card,
			//		Price = 300
			//	}

			//	);
		}
	}

}
