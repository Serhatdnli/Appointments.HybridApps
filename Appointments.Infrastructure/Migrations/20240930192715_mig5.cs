using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Appointments.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mig5 : Migration
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
                    Price = table.Column<float>(type: "real", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClinicNameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                        name: "FK_Appointments_Clinics_ClinicNameId",
                        column: x => x.ClinicNameId,
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
                    { new Guid("1d09363c-cff4-4c30-a733-21562d0fb3dd"), new DateTime(1995, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "bakirr35@gmail.com", "Ali", "bakirr35", "05489652542", 6, "Bakır", "78585458632" },
                    { new Guid("7e346200-4512-4e4e-942c-f018e940a201"), new DateTime(1999, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "iboaydin34@gmail.com", "İbrahim", "iboaydin34", "05424586954", 2, "Aydın", "38492039432" },
                    { new Guid("8dce413b-2190-426c-9502-ad77a02e283a"), new DateTime(2000, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "boyr4z.m@gmail.com", "Muhammet", "boyraz46", "05366765246", 1, "Boyraz", "25117914842" },
                    { new Guid("9932715b-07e3-4da9-9b42-e42e1f2935d6"), new DateTime(1998, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "kayali06@gmail.com", "Ramazan", "kayali06", "05471236549", 3, "Kayalı", "85458960214" },
                    { new Guid("9ae2fb47-5e6e-4a39-a71c-b21f1c183c4d"), new DateTime(2000, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "ahmetilhannm@gmail.com", "Ahmet", "ahmet65.", "05432865247", 4, "İlhan", "18243593503" },
                    { new Guid("aedc79c8-6f65-42bd-b69e-9f0f2931cad3"), new DateTime(2000, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "dayanir34@gmail.com", "Talha", "dayanir34", "05421452636", 5, "Toğuşlu", "28493040339" },
                    { new Guid("de5e6197-0a68-4c8e-bd02-8944568fb08d"), new DateTime(1998, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "serhatdnli@gmail.com", "Serhat", "serhat01", "05353264771", 1, "Denli", "37458542624" },
                    { new Guid("eb938cae-d717-451d-a2c5-9e24da0ffee0"), new DateTime(1998, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "merter61m@gmail.com", "Gürkan", "merter61", "05428564525", 2, "Merter", "27485393001" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ClientId",
                table: "Appointments",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ClinicNameId",
                table: "Appointments",
                column: "ClinicNameId");

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
