using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocalGoods.DAL.Migrations
{
    public partial class AddrelationsbetweenPaymentDeliverymethodsandVendor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "PaymentMethodVendor",
                columns: table => new
                {
                    PaymentMethodsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VendorsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethodVendor", x => new { x.PaymentMethodsId, x.VendorsId });
                    table.ForeignKey(
                        name: "FK_PaymentMethodVendor_PaymentMethods_PaymentMethodsId",
                        column: x => x.PaymentMethodsId,
                        principalTable: "PaymentMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaymentMethodVendor_Vendors_VendorsId",
                        column: x => x.VendorsId,
                        principalTable: "Vendors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryMethodVendor_VendorsId",
                table: "DeliveryMethodVendor",
                column: "VendorsId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMethodVendor_VendorsId",
                table: "PaymentMethodVendor",
                column: "VendorsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeliveryMethodVendor");

            migrationBuilder.DropTable(
                name: "PaymentMethodVendor");
        }
    }
}
