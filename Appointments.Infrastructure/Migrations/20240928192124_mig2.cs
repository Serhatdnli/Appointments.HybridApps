using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Appointments.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
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
                    { new Guid("0cedaf38-5989-460e-9c23-0dddec5bf745"), new DateTime(2000, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "boyr4z.m@gmail.com", "Muhammet", "boyraz46", "05366765246", 1, "Boyraz", "25117914842" },
                    { new Guid("0ff0ae3a-5d72-4faf-a82b-2244ceda1070"), new DateTime(1998, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "serhatdnli@gmail.com", "Serhat", "serhat01", "05353264771", 1, "Denli", "37458542624" },
                    { new Guid("2352d459-c149-4ee7-a97b-bc5bf587d88d"), new DateTime(1998, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "kayali06@gmail.com", "Ramazan", "kayali06", "05471236549", 3, "Kayalı", "85458960214" },
                    { new Guid("3c5ebf4a-86c7-4003-aab3-bf10063cf1ea"), new DateTime(1995, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "bakirr35@gmail.com", "Ali", "bakirr35", "05489652542", 6, "Bakır", "78585458632" },
                    { new Guid("50141e01-7a2a-44d4-805e-f98e3023bc56"), new DateTime(1998, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "merter61m@gmail.com", "Gürkan", "merter61", "05428564525", 2, "Merter", "27485393001" },
                    { new Guid("7628ca42-a08e-4965-b381-74e1986d2cfb"), new DateTime(2000, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "dayanir34@gmail.com", "Talha", "dayanir34", "05421452636", 5, "Toğuşlu", "28493040339" },
                    { new Guid("b45636a6-65fc-4601-b06e-2bab59843427"), new DateTime(2000, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "ahmetilhannm@gmail.com", "Ahmet", "ahmet65.", "05432865247", 4, "İlhan", "18243593503" },
                    { new Guid("e517e81d-961e-495b-ad76-c5442a766fbe"), new DateTime(1999, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "iboaydin34@gmail.com", "İbrahim", "iboaydin34", "05424586954", 2, "Aydın", "38492039432" }
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
