using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocalGoods.DAL.Migrations
{
    public partial class AddSeedingUserWithAdminPrivileges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("71be2e68-fa38-4de3-b253-d34f1c16cc9a"), "baf17a47-bf30-42e1-a31e-fac07868dc02", "Admin", "ADMIN" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3470262f-7571-ed11-b214-d41b81b14cb3"),
                column: "EmailConfirmed",
                value: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "CityId", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("4483ab90-887a-ed11-b7a9-0003aa002c50"), 0, new DateTime(1978, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e82aafbd-713b-4e12-a4a1-b38378a5a90f"), "361787c1-69c1-4a6b-8f6b-3ee2721a8c3e", "admin@local.goods", true, "Admin", "Admin", false, null, "ADMIN@LOCAL.GOODS", "ADMIN", "AQAAAAEAACcQAAAAEL2R6txwf1WpL6eBtlvvmcS54/Q6STqQUaZlipMREY35Xn2zXt5vxoFtta6ZbpCu9Q==", "380987654321", false, "U5IMACP6NPF4UHCNSEPQY2XRC6QIUL6K", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("71be2e68-fa38-4de3-b253-d34f1c16cc9a"), new Guid("4483ab90-887a-ed11-b7a9-0003aa002c50") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("71be2e68-fa38-4de3-b253-d34f1c16cc9a"), new Guid("4483ab90-887a-ed11-b7a9-0003aa002c50") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("71be2e68-fa38-4de3-b253-d34f1c16cc9a"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4483ab90-887a-ed11-b7a9-0003aa002c50"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3470262f-7571-ed11-b214-d41b81b14cb3"),
                column: "EmailConfirmed",
                value: false);
        }
    }
}
