using Appointments.Domain.Enums;
using Appointments.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Appointments.Infrastructure.Configrations
{
    public class UserEntityConfigration : BaseEntityConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);
            builder.ToTable("Users");
            builder.HasIndex(k => k.TcId).IsUnique();



            builder.HasData(
                new User
                {
                    Id = Guid.NewGuid(),
                    Name = "Muhammet",
                    Surname = "Boyraz",
                    Email = "boyr4z.m@gmail.com",
                    CreateDate = new DateTime(2000, 06, 15),
                    Password = "boyraz46",
                    PhoneNumber = "05366765246",
                    Role = UserRoleType.Admin,
                    TcId = "25117914842"
                },

                new User
                {
                    Id = Guid.NewGuid(),
                    Name = "Serhat",
                    Surname = "Denli",
                    Email = "serhatdnli@gmail.com",
                    CreateDate = new DateTime(1998, 08, 31),
                    Password = "serhat01",
                    PhoneNumber = "05353264771",
                    Role = UserRoleType.Admin,
                    TcId = "37458542624"
                },

                new User
                {
                    Id = Guid.NewGuid(),
                    Name = "Ahmet",
                    Surname = "İlhan",
                    Email = "ahmetilhannm@gmail.com",
                    CreateDate = new DateTime(2000, 09, 12),
                    Password = "ahmet65.",
                    PhoneNumber = "05432865247",
                    Role = UserRoleType.Doctor,
                    TcId = "18243593503"
                },

                new User
                {
                    Id = Guid.NewGuid(),
                    Name = "Gürkan",
                    Surname = "Merter",
                    Email = "merter61m@gmail.com",
                    CreateDate = new DateTime(1998, 01, 05),
                    Password = "merter61",
                    PhoneNumber = "05428564525",
                    Role = UserRoleType.Personal,
                    TcId = "27485393001"
                },

                new User
                {
                    Id = Guid.NewGuid(),
                    Name = "Talha",
                    Surname = "Toğuşlu",
                    Email = "dayanir34@gmail.com",
                    CreateDate = new DateTime(2000, 01, 31),
                    Password = "dayanir34",
                    PhoneNumber = "05421452636",
                    Role = UserRoleType.Nurse,
                    TcId = "28493040339"
                },

                new User
                {
                    Id = Guid.NewGuid(),
                    Name = "İbrahim",
                    Surname = "Aydın",
                    Email = "iboaydin34@gmail.com",
                    CreateDate = new DateTime(1999, 09, 15),
                    Password = "iboaydin34",
                    PhoneNumber = "05424586954",
                    Role = UserRoleType.Personal,
                    TcId = "38492039432"
                },


                new User
                {
                    Id = Guid.NewGuid(),
                    Name = "Ali",
                    Surname = "Bakır",
                    Email = "bakirr35@gmail.com",
                    CreateDate = new DateTime(1995, 03, 08),
                    Password = "bakirr35",
                    PhoneNumber = "05489652542",
                    Role = UserRoleType.Accountant,
                    TcId = "78585458632"
                },


                new User
                {
                    Id = Guid.NewGuid(),
                    Name = "Ramazan",
                    Surname = "Kayalı",
                    Email = "kayali06@gmail.com",
                    CreateDate = new DateTime(1998, 12, 04),
                    Password = "kayali06",
                    PhoneNumber = "05471236549",
                    Role = UserRoleType.Assistant,
                    TcId = "85458960214"
                }



            );        // admin




        }
    }
}
