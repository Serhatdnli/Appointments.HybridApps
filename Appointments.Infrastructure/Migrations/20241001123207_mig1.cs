using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Appointments.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TcId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clinics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clinics", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DoctorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClinicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppointmentTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsPayed = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Clinics_ClinicId",
                        column: x => x.ClinicId,
                        principalTable: "Clinics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Users_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppointmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    PaymentType = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateDate", "Email", "Name", "Password", "PhoneNumber", "Role", "Surname", "TcId" },
                values: new object[,]
                {
                    { new Guid("01cb608e-6f16-4645-b1c2-33b7f5bcf76d"), new DateTime(2000, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "dayanir34@gmail.com", "Talha", "dayanir34", "05421452636", 5, "Toğuşlu", "28493040339" },
                    { new Guid("03a828c7-5d0b-439c-b96f-a7d0f6d1721b"), new DateTime(1998, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "serhatdnli@gmail.com", "Serhat", "serhat01", "05353264771", 1, "Denli", "37458542624" },
                    { new Guid("0aee18f7-4df7-414c-a2dd-cf953ee5a68a"), new DateTime(1998, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "merter61m@gmail.com", "Gürkan", "merter61", "05428564525", 2, "Merter", "27485393001" },
                    { new Guid("2f33ff03-a055-4736-b822-e140270f3932"), new DateTime(1995, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "bakirr35@gmail.com", "Ali", "bakirr35", "05489652542", 6, "Bakır", "78585458632" },
                    { new Guid("8ac75a9f-fde0-4720-915f-8ba3c2706675"), new DateTime(1998, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "kayali06@gmail.com", "Ramazan", "kayali06", "05471236549", 3, "Kayalı", "85458960214" },
                    { new Guid("c4e73501-f7cd-419f-8693-b221c0fa8d6d"), new DateTime(2000, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "ahmetilhannm@gmail.com", "Ahmet", "ahmet65.", "05432865247", 4, "İlhan", "18243593503" },
                    { new Guid("c7ba4bde-12fe-4362-9008-18f3526854fb"), new DateTime(1999, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "iboaydin34@gmail.com", "İbrahim", "iboaydin34", "05424586954", 2, "Aydın", "38492039432" },
                    { new Guid("fd7d9a11-8915-4d50-b4de-a7bdd8635c82"), new DateTime(2000, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "boyr4z.m@gmail.com", "Muhammet", "boyraz46", "05366765246", 1, "Boyraz", "25117914842" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ClientId",
                table: "Appointments",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ClinicId",
                table: "Appointments",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorId",
                table: "Appointments",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_AppointmentId",
                table: "Payments",
                column: "AppointmentId");

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
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Clinics");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
