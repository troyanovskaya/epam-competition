using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocalGoods.DAL.Migrations
{
    public partial class CreateVendorDeliveryMethodtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeliveryMethodVendor");

            migrationBuilder.AddColumn<double>(
                name: "Amount",
                table: "OrderDetails",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<Guid>(
                name: "UnitTypeId",
                table: "OrderDetails",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "VendorDeliveryMethod",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VendorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeliveryMethodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Information = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorDeliveryMethod", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VendorDeliveryMethod_DeliveryMethods_DeliveryMethodId",
                        column: x => x.DeliveryMethodId,
                        principalTable: "DeliveryMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VendorDeliveryMethod_Vendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_UnitTypeId",
                table: "OrderDetails",
                column: "UnitTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VendorDeliveryMethod_DeliveryMethodId",
                table: "VendorDeliveryMethod",
                column: "DeliveryMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_VendorDeliveryMethod_VendorId",
                table: "VendorDeliveryMethod",
                column: "VendorId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_UnitType_UnitTypeId",
                table: "OrderDetails",
                column: "UnitTypeId",
                principalTable: "UnitType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_UnitType_UnitTypeId",
                table: "OrderDetails");

            migrationBuilder.DropTable(
                name: "VendorDeliveryMethod");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_UnitTypeId",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "UnitTypeId",
                table: "OrderDetails");

            migrationBuilder.CreateTable(
                name: "DeliveryMethodVendor",
                columns: table => new
                {
                    DeliveryMethodsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VendorsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryMethodVendor", x => new { x.DeliveryMethodsId, x.VendorsId });
                    table.ForeignKey(
                        name: "FK_DeliveryMethodVendor_DeliveryMethods_DeliveryMethodsId",
                        column: x => x.DeliveryMethodsId,
                        principalTable: "DeliveryMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeliveryMethodVendor_Vendors_VendorsId",
                        column: x => x.VendorsId,
                        principalTable: "Vendors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryMethodVendor_VendorsId",
                table: "DeliveryMethodVendor",
                column: "VendorsId");
        }
    }
}
