using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocalGoods.DAL.Migrations
{
    public partial class AddseedingdataforPaymentDeliveryUnittypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DeliveryMethods",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("79af055a-7827-4e6e-943d-094f81c75fe2"), "Delivery" },
                    { new Guid("152d8dc9-6f20-44d4-82fd-c5e9f4ef299b"), "Takeaway" }
                });

            migrationBuilder.InsertData(
                table: "PaymentMethods",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("76cdcb56-30e6-4674-9085-d65a936cae25"), "Card" },
                    { new Guid("60d556a7-26d6-4c02-a824-4b6cbdcb110e"), "Cash" }
                });

            migrationBuilder.InsertData(
                table: "UnitTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("d86d983b-61ed-4e7e-9c14-faa6fde675aa"), "Item" },
                    { new Guid("c176f933-0587-4393-bc94-f5062c5f5bc2"), "Kg" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DeliveryMethods",
                keyColumn: "Id",
                keyValue: new Guid("152d8dc9-6f20-44d4-82fd-c5e9f4ef299b"));

            migrationBuilder.DeleteData(
                table: "DeliveryMethods",
                keyColumn: "Id",
                keyValue: new Guid("79af055a-7827-4e6e-943d-094f81c75fe2"));

            migrationBuilder.DeleteData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: new Guid("60d556a7-26d6-4c02-a824-4b6cbdcb110e"));

            migrationBuilder.DeleteData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: new Guid("76cdcb56-30e6-4674-9085-d65a936cae25"));

            migrationBuilder.DeleteData(
                table: "UnitTypes",
                keyColumn: "Id",
                keyValue: new Guid("c176f933-0587-4393-bc94-f5062c5f5bc2"));

            migrationBuilder.DeleteData(
                table: "UnitTypes",
                keyColumn: "Id",
                keyValue: new Guid("d86d983b-61ed-4e7e-9c14-faa6fde675aa"));
        }
    }
}
