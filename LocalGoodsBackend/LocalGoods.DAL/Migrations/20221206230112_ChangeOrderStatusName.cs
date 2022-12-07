using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocalGoods.DAL.Migrations
{
    public partial class ChangeOrderStatusName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: new Guid("c9cf6ba9-26c9-46cd-a660-6ae4f23a3d96"));

            migrationBuilder.UpdateData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: new Guid("6f0a355f-c0b1-46a3-a93a-94fad9aa1ed3"),
                column: "Name",
                value: "Pending");

            migrationBuilder.InsertData(
                table: "OrderStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("17cf0057-aa23-4cdf-96a4-6573c7ae96e6"), "Completed" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: new Guid("17cf0057-aa23-4cdf-96a4-6573c7ae96e6"));

            migrationBuilder.UpdateData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: new Guid("6f0a355f-c0b1-46a3-a93a-94fad9aa1ed3"),
                column: "Name",
                value: "In processing");

            migrationBuilder.InsertData(
                table: "OrderStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("c9cf6ba9-26c9-46cd-a660-6ae4f23a3d96"), "Completed" });
        }
    }
}
