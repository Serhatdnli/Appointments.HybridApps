using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Appointments.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TcId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateDate", "Email", "Name", "Password", "PhoneNumber", "Role", "Surname", "TcId" },
                values: new object[,]
                {
                    { new Guid("36dfda88-1955-4702-8315-c231527be27b"), new DateTime(2000, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "dayanir34@gmail.com", "Talha", "dayanir34", "05421452636", 5, "Toğuşlu", "28493040339" },
                    { new Guid("37016bfc-7b63-43f7-bdab-9ca13414669d"), new DateTime(2000, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "boyr4z.m@gmail.com", "Muhammet", "boyraz46", "05366765246", 1, "Boyraz", "25117914842" },
                    { new Guid("3f148351-615c-4d5c-a72a-e4618d7da31f"), new DateTime(2000, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "ahmetilhannm@gmail.com", "Ahmet", "ahmet65.", "05432865247", 4, "İlhan", "18243593503" },
                    { new Guid("484e9254-b804-422c-b4e7-5a2a5ef6cc8a"), new DateTime(1998, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "serhatdnli@gmail.com", "Serhat", "serhat01", "05353264771", 1, "Denli", "37458542624" },
                    { new Guid("48b11b33-029f-4354-96ef-a5565952de48"), new DateTime(1998, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "kayali06@gmail.com", "Ramazan", "kayali06", "05471236549", 3, "Kayalı", "85458960214" },
                    { new Guid("69b7db5b-ddfb-4047-9d5f-68a4ebdf93e5"), new DateTime(1995, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "bakirr35@gmail.com", "Ali", "bakirr35", "05489652542", 6, "Bakır", "78585458632" },
                    { new Guid("6c62f73c-ecf6-45ff-b436-29109bda8fb2"), new DateTime(1999, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "iboaydin34@gmail.com", "İbrahim", "iboaydin34", "05424586954", 2, "Aydın", "38492039432" },
                    { new Guid("710c4838-4b9f-4d17-9622-6b232830bbc9"), new DateTime(1998, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "merter61m@gmail.com", "Gürkan", "merter61", "05428564525", 2, "Merter", "27485393001" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_TcId",
                table: "Users",
                column: "TcId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
