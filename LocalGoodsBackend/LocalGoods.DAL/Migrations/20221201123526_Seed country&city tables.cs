using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocalGoods.DAL.Migrations
{
    public partial class Seedcountrycitytables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("6123c937-478b-43a3-98f7-4c6b6fa2fa83"), "Ukraine" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("b83484f9-092d-4b51-afcb-5dc2450e2593"), "Armenia" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[] { new Guid("43809371-4e7d-4616-ac26-d62d202d4767"), new Guid("6123c937-478b-43a3-98f7-4c6b6fa2fa83"), "Kharkiv" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[] { new Guid("e82aafbd-713b-4e12-a4a1-b38378a5a90f"), new Guid("6123c937-478b-43a3-98f7-4c6b6fa2fa83"), "Dnipro" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[] { new Guid("a146ee56-265a-4fd7-9732-5393637220bf"), new Guid("b83484f9-092d-4b51-afcb-5dc2450e2593"), "Yerevan" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("43809371-4e7d-4616-ac26-d62d202d4767"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("a146ee56-265a-4fd7-9732-5393637220bf"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("e82aafbd-713b-4e12-a4a1-b38378a5a90f"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("6123c937-478b-43a3-98f7-4c6b6fa2fa83"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("b83484f9-092d-4b51-afcb-5dc2450e2593"));
        }
    }
}
