using Microsoft.EntityFrameworkCore.Migrations;

namespace LocalGoods.DAL.Migrations
{
    public partial class ConfiguremissingrelationsforUnitType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_UnitType_UnitTypeId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductStorage_Products_ProductId",
                table: "ProductStorage");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductStorage_UnitType_UnitTypeId",
                table: "ProductStorage");

            migrationBuilder.DropForeignKey(
                name: "FK_VendorDeliveryMethod_DeliveryMethods_DeliveryMethodId",
                table: "VendorDeliveryMethod");

            migrationBuilder.DropForeignKey(
                name: "FK_VendorDeliveryMethod_Vendors_VendorId",
                table: "VendorDeliveryMethod");

            migrationBuilder.DropForeignKey(
                name: "FK_VendorPaymentMethod_PaymentMethods_PaymentMethodId",
                table: "VendorPaymentMethod");

            migrationBuilder.DropForeignKey(
                name: "FK_VendorPaymentMethod_Vendors_VendorId",
                table: "VendorPaymentMethod");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VendorPaymentMethod",
                table: "VendorPaymentMethod");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VendorDeliveryMethod",
                table: "VendorDeliveryMethod");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UnitType",
                table: "UnitType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductStorage",
                table: "ProductStorage");

            migrationBuilder.RenameTable(
                name: "VendorPaymentMethod",
                newName: "VendorPaymentMethods");

            migrationBuilder.RenameTable(
                name: "VendorDeliveryMethod",
                newName: "VendorDeliveryMethods");

            migrationBuilder.RenameTable(
                name: "UnitType",
                newName: "UnitTypes");

            migrationBuilder.RenameTable(
                name: "ProductStorage",
                newName: "ProductStorages");

            migrationBuilder.RenameIndex(
                name: "IX_VendorPaymentMethod_VendorId",
                table: "VendorPaymentMethods",
                newName: "IX_VendorPaymentMethods_VendorId");

            migrationBuilder.RenameIndex(
                name: "IX_VendorPaymentMethod_PaymentMethodId",
                table: "VendorPaymentMethods",
                newName: "IX_VendorPaymentMethods_PaymentMethodId");

            migrationBuilder.RenameIndex(
                name: "IX_VendorDeliveryMethod_VendorId",
                table: "VendorDeliveryMethods",
                newName: "IX_VendorDeliveryMethods_VendorId");

            migrationBuilder.RenameIndex(
                name: "IX_VendorDeliveryMethod_DeliveryMethodId",
                table: "VendorDeliveryMethods",
                newName: "IX_VendorDeliveryMethods_DeliveryMethodId");

            migrationBuilder.RenameIndex(
                name: "IX_UnitType_Name",
                table: "UnitTypes",
                newName: "IX_UnitTypes_Name");

            migrationBuilder.RenameIndex(
                name: "IX_ProductStorage_UnitTypeId",
                table: "ProductStorages",
                newName: "IX_ProductStorages_UnitTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductStorage_ProductId",
                table: "ProductStorages",
                newName: "IX_ProductStorages_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VendorPaymentMethods",
                table: "VendorPaymentMethods",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VendorDeliveryMethods",
                table: "VendorDeliveryMethods",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UnitTypes",
                table: "UnitTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductStorages",
                table: "ProductStorages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_UnitTypes_UnitTypeId",
                table: "OrderDetails",
                column: "UnitTypeId",
                principalTable: "UnitTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductStorages_Products_ProductId",
                table: "ProductStorages",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductStorages_UnitTypes_UnitTypeId",
                table: "ProductStorages",
                column: "UnitTypeId",
                principalTable: "UnitTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VendorDeliveryMethods_DeliveryMethods_DeliveryMethodId",
                table: "VendorDeliveryMethods",
                column: "DeliveryMethodId",
                principalTable: "DeliveryMethods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VendorDeliveryMethods_Vendors_VendorId",
                table: "VendorDeliveryMethods",
                column: "VendorId",
                principalTable: "Vendors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VendorPaymentMethods_PaymentMethods_PaymentMethodId",
                table: "VendorPaymentMethods",
                column: "PaymentMethodId",
                principalTable: "PaymentMethods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VendorPaymentMethods_Vendors_VendorId",
                table: "VendorPaymentMethods",
                column: "VendorId",
                principalTable: "Vendors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_UnitTypes_UnitTypeId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductStorages_Products_ProductId",
                table: "ProductStorages");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductStorages_UnitTypes_UnitTypeId",
                table: "ProductStorages");

            migrationBuilder.DropForeignKey(
                name: "FK_VendorDeliveryMethods_DeliveryMethods_DeliveryMethodId",
                table: "VendorDeliveryMethods");

            migrationBuilder.DropForeignKey(
                name: "FK_VendorDeliveryMethods_Vendors_VendorId",
                table: "VendorDeliveryMethods");

            migrationBuilder.DropForeignKey(
                name: "FK_VendorPaymentMethods_PaymentMethods_PaymentMethodId",
                table: "VendorPaymentMethods");

            migrationBuilder.DropForeignKey(
                name: "FK_VendorPaymentMethods_Vendors_VendorId",
                table: "VendorPaymentMethods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VendorPaymentMethods",
                table: "VendorPaymentMethods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VendorDeliveryMethods",
                table: "VendorDeliveryMethods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UnitTypes",
                table: "UnitTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductStorages",
                table: "ProductStorages");

            migrationBuilder.RenameTable(
                name: "VendorPaymentMethods",
                newName: "VendorPaymentMethod");

            migrationBuilder.RenameTable(
                name: "VendorDeliveryMethods",
                newName: "VendorDeliveryMethod");

            migrationBuilder.RenameTable(
                name: "UnitTypes",
                newName: "UnitType");

            migrationBuilder.RenameTable(
                name: "ProductStorages",
                newName: "ProductStorage");

            migrationBuilder.RenameIndex(
                name: "IX_VendorPaymentMethods_VendorId",
                table: "VendorPaymentMethod",
                newName: "IX_VendorPaymentMethod_VendorId");

            migrationBuilder.RenameIndex(
                name: "IX_VendorPaymentMethods_PaymentMethodId",
                table: "VendorPaymentMethod",
                newName: "IX_VendorPaymentMethod_PaymentMethodId");

            migrationBuilder.RenameIndex(
                name: "IX_VendorDeliveryMethods_VendorId",
                table: "VendorDeliveryMethod",
                newName: "IX_VendorDeliveryMethod_VendorId");

            migrationBuilder.RenameIndex(
                name: "IX_VendorDeliveryMethods_DeliveryMethodId",
                table: "VendorDeliveryMethod",
                newName: "IX_VendorDeliveryMethod_DeliveryMethodId");

            migrationBuilder.RenameIndex(
                name: "IX_UnitTypes_Name",
                table: "UnitType",
                newName: "IX_UnitType_Name");

            migrationBuilder.RenameIndex(
                name: "IX_ProductStorages_UnitTypeId",
                table: "ProductStorage",
                newName: "IX_ProductStorage_UnitTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductStorages_ProductId",
                table: "ProductStorage",
                newName: "IX_ProductStorage_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VendorPaymentMethod",
                table: "VendorPaymentMethod",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VendorDeliveryMethod",
                table: "VendorDeliveryMethod",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UnitType",
                table: "UnitType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductStorage",
                table: "ProductStorage",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_UnitType_UnitTypeId",
                table: "OrderDetails",
                column: "UnitTypeId",
                principalTable: "UnitType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductStorage_Products_ProductId",
                table: "ProductStorage",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductStorage_UnitType_UnitTypeId",
                table: "ProductStorage",
                column: "UnitTypeId",
                principalTable: "UnitType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VendorDeliveryMethod_DeliveryMethods_DeliveryMethodId",
                table: "VendorDeliveryMethod",
                column: "DeliveryMethodId",
                principalTable: "DeliveryMethods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VendorDeliveryMethod_Vendors_VendorId",
                table: "VendorDeliveryMethod",
                column: "VendorId",
                principalTable: "Vendors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VendorPaymentMethod_PaymentMethods_PaymentMethodId",
                table: "VendorPaymentMethod",
                column: "PaymentMethodId",
                principalTable: "PaymentMethods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VendorPaymentMethod_Vendors_VendorId",
                table: "VendorPaymentMethod",
                column: "VendorId",
                principalTable: "Vendors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
