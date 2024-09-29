using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Appointments.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0cedaf38-5989-460e-9c23-0dddec5bf745"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0ff0ae3a-5d72-4faf-a82b-2244ceda1070"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2352d459-c149-4ee7-a97b-bc5bf587d88d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3c5ebf4a-86c7-4003-aab3-bf10063cf1ea"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("50141e01-7a2a-44d4-805e-f98e3023bc56"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7628ca42-a08e-4965-b381-74e1986d2cfb"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b45636a6-65fc-4601-b06e-2bab59843427"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e517e81d-961e-495b-ad76-c5442a766fbe"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateDate", "Email", "Name", "Password", "PhoneNumber", "Role", "Surname", "TcId" },
                values: new object[,]
                {
                    { new Guid("2725294a-b15e-4855-bc27-1ceb0cdc22e6"), new DateTime(2000, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "boyr4z.m@gmail.com", "Muhammet", "boyraz46", "05366765246", 1, "Boyraz", "25117914842" },
                    { new Guid("458be94a-ddec-4ecf-988c-8376534222fe"), new DateTime(1998, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "merter61m@gmail.com", "Gürkan", "merter61", "05428564525", 2, "Merter", "27485393001" },
                    { new Guid("4f6cb9ed-fa75-437b-8db8-cc28a2fac5a3"), new DateTime(2000, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "dayanir34@gmail.com", "Talha", "dayanir34", "05421452636", 5, "Toğuşlu", "28493040339" },
                    { new Guid("6c289f36-939e-4d8e-b646-d8b6758e3d81"), new DateTime(2000, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "ahmetilhannm@gmail.com", "Ahmet", "ahmet65.", "05432865247", 4, "İlhan", "18243593503" },
                    { new Guid("751685f7-b24f-4f7b-967c-66af7979b269"), new DateTime(1998, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "serhatdnli@gmail.com", "Serhat", "serhat01", "05353264771", 1, "Denli", "37458542624" },
                    { new Guid("797c2681-b631-4d10-b9cb-14814deb272a"), new DateTime(1995, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "bakirr35@gmail.com", "Ali", "bakirr35", "05489652542", 6, "Bakır", "78585458632" },
                    { new Guid("c3612b41-f6b0-408b-b700-e6d084edeaf7"), new DateTime(1999, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "iboaydin34@gmail.com", "İbrahim", "iboaydin34", "05424586954", 2, "Aydın", "38492039432" },
                    { new Guid("caf3c1a7-640a-478d-9817-ed19fffac506"), new DateTime(1998, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "kayali06@gmail.com", "Ramazan", "kayali06", "05471236549", 3, "Kayalı", "85458960214" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2725294a-b15e-4855-bc27-1ceb0cdc22e6"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("458be94a-ddec-4ecf-988c-8376534222fe"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4f6cb9ed-fa75-437b-8db8-cc28a2fac5a3"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6c289f36-939e-4d8e-b646-d8b6758e3d81"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("751685f7-b24f-4f7b-967c-66af7979b269"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("797c2681-b631-4d10-b9cb-14814deb272a"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c3612b41-f6b0-408b-b700-e6d084edeaf7"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("caf3c1a7-640a-478d-9817-ed19fffac506"));

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
        }
    }
}
