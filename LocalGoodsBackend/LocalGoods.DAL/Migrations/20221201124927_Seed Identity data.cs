using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocalGoods.DAL.Migrations
{
    public partial class SeedIdentitydata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("4096c786-5577-4bb2-80c9-9c105b90e16f"), "d9f4bb7d-7411-4706-995f-560c7e5b1972", "Buyer", "BUYER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("77f9bef5-e093-4c53-9bbe-99afb43d2229"), "9409fbda-8820-43e1-9bb0-f6c0b2ded749", "Vendor", "VENDOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "CityId", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("3470262f-7571-ed11-b214-d41b81b14cb3"), 0, new DateTime(1978, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("43809371-4e7d-4616-ac26-d62d202d4767"), "8288ed6b-3972-47c1-a4bc-fa4fa26e02f5", "smith@gmail.com", false, "John", "Smith", false, null, "SMITH@GMAIL.COM", "JOHNSMITH", "AQAAAAEAACcQAAAAEDkYL3RUU/7ScDdxXvD9hB8eYViSrUANyvEFA9M3SPX4HVqrKWaSf8GpATYde6Wibw==", "+38012345678", false, "7JBROKPX4RLYJCPXDGP2COQ25X2DFUN5", false, "JohnSmith" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("4096c786-5577-4bb2-80c9-9c105b90e16f"), new Guid("3470262f-7571-ed11-b214-d41b81b14cb3") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("77f9bef5-e093-4c53-9bbe-99afb43d2229"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4096c786-5577-4bb2-80c9-9c105b90e16f"), new Guid("3470262f-7571-ed11-b214-d41b81b14cb3") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4096c786-5577-4bb2-80c9-9c105b90e16f"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3470262f-7571-ed11-b214-d41b81b14cb3"));
        }
    }
}
