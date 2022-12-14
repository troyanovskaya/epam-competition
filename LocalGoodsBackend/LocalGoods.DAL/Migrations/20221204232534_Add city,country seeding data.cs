using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocalGoods.DAL.Migrations
{
    public partial class Addcitycountryseedingdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { new Guid("f647d6cc-359d-4d42-aca7-3a6f5a691eae"), new Guid("6123c937-478b-43a3-98f7-4c6b6fa2fa83"), "Kyiv" },
                    { new Guid("7ce5b758-acdc-4bbd-a745-2fbd5a64b598"), new Guid("6123c937-478b-43a3-98f7-4c6b6fa2fa83"), "Lviv" },
                    { new Guid("3eff06d7-6e86-4dad-bbb7-b43f3321f83e"), new Guid("b83484f9-092d-4b51-afcb-5dc2450e2593"), "Gyumri" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("575f0725-41bc-49b7-9137-37070087ff4d"), "England" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[] { new Guid("d0dba58e-9a7f-427b-ad6e-3dba4e2a8af5"), new Guid("575f0725-41bc-49b7-9137-37070087ff4d"), "London" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[] { new Guid("07d7e41c-b329-4dc0-a9d1-7e0e84b73bba"), new Guid("575f0725-41bc-49b7-9137-37070087ff4d"), "Liverpool" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("07d7e41c-b329-4dc0-a9d1-7e0e84b73bba"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("3eff06d7-6e86-4dad-bbb7-b43f3321f83e"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("7ce5b758-acdc-4bbd-a745-2fbd5a64b598"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("d0dba58e-9a7f-427b-ad6e-3dba4e2a8af5"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("f647d6cc-359d-4d42-aca7-3a6f5a691eae"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("575f0725-41bc-49b7-9137-37070087ff4d"));
        }
    }
}
