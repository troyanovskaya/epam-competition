using Microsoft.EntityFrameworkCore.Migrations;

namespace LocalGoods.DAL.Migrations
{
    public partial class MakeDeliveryPaymentMethodnamefieldunique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_PaymentMethods_Name",
                table: "PaymentMethods",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryMethods_Name",
                table: "DeliveryMethods",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PaymentMethods_Name",
                table: "PaymentMethods");

            migrationBuilder.DropIndex(
                name: "IX_DeliveryMethods_Name",
                table: "DeliveryMethods");
        }
    }
}
