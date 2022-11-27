using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocalGoods.DAL.Migrations
{
    public partial class CreateVendorPaymentMethodtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentMethodVendor");

            migrationBuilder.AddColumn<string>(
                name: "InstagramName",
                table: "Vendors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TelegramName",
                table: "Vendors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ViberNumber",
                table: "Vendors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "VendorPaymentMethod",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VendorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentMethodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Information = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorPaymentMethod", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VendorPaymentMethod_PaymentMethods_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "PaymentMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VendorPaymentMethod_Vendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VendorPaymentMethod_PaymentMethodId",
                table: "VendorPaymentMethod",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_VendorPaymentMethod_VendorId",
                table: "VendorPaymentMethod",
                column: "VendorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VendorPaymentMethod");

            migrationBuilder.DropColumn(
                name: "InstagramName",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "TelegramName",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "ViberNumber",
                table: "Vendors");

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
                name: "IX_PaymentMethodVendor_VendorsId",
                table: "PaymentMethodVendor",
                column: "VendorsId");
        }
    }
}
