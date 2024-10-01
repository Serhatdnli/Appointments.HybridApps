using Appointments.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Appointments.Infrastructure.Configrations
{
	public class ClientConfiguration : BaseEntityConfiguration<Client>
	{
		public override void Configure(EntityTypeBuilder<Client> builder)
		{
			base.Configure(builder);
			builder.ToTable("Clients");

			//builder.HasData(
			//	new Client
			//	{
			//		Id =		Guid.Parse("92a3b5ad-8c14-4532-9732-baef3c45bd7b"),
			//		Name = "Cemil",
			//		Surname = "Kaşkar",
			//		CreateDate = DateTime.Now,
			//		Email = "cemil123@gmail.com",
			//		TcId = "05412563542",
			//		PhoneNumber = "05425265896",
			//	},
			//		new Client
			//		{
			//			Id =	Guid.Parse("d14d8231-4ce2-4952-9073-c640b54c2495"),
			//			Name = "Abdi",
			//			Surname = "İpekçi",
			//			CreateDate = DateTime.Now,
			//			Email = "abdi3131@gmail.com",
			//			TcId = "05412563545",
			//			PhoneNumber = "05425265894",
			//		}
			//);
		}
	}
}
