using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocalGoods.DAL.Migrations
{
    public partial class Addcategorydataseeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("41f9836e-c0cb-43a6-a842-22e6f5a60f1d"), "Farm boxes" },
                    { new Guid("7cd2e12d-c85d-4d97-9c18-808dff6151f4"), "Produce" },
                    { new Guid("4374b672-d0b1-4f31-b512-408400ce6105"), "Meat & Seafood" },
                    { new Guid("c11d3cf5-6847-4281-9950-52b03f3811fa"), "Dairy & Eggs" },
                    { new Guid("40ff4e36-58e3-408a-b563-aa51c7db51a2"), "Bakery" },
                    { new Guid("2766062f-f160-49aa-bd48-c62ac0b2b0da"), "Pantry" },
                    { new Guid("e9a69e36-98e3-4da2-9c76-f723c4b59178"), "Drinks" },
                    { new Guid("9072ca4f-1c4b-4abe-9535-876e4d50e005"), "Easy meals" },
                    { new Guid("24735f5d-906d-4c41-9f86-89d19d6620c6"), "New & Seasonal" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("24735f5d-906d-4c41-9f86-89d19d6620c6"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2766062f-f160-49aa-bd48-c62ac0b2b0da"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("40ff4e36-58e3-408a-b563-aa51c7db51a2"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("41f9836e-c0cb-43a6-a842-22e6f5a60f1d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4374b672-d0b1-4f31-b512-408400ce6105"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7cd2e12d-c85d-4d97-9c18-808dff6151f4"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9072ca4f-1c4b-4abe-9535-876e4d50e005"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c11d3cf5-6847-4281-9950-52b03f3811fa"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e9a69e36-98e3-4da2-9c76-f723c4b59178"));
        }
    }
}
