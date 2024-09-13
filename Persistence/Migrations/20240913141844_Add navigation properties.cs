using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Addnavigationproperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductAmounts_Orders_OrderId",
                table: "ProductAmounts");

            migrationBuilder.DropIndex(
                name: "IX_Users_PhoneNumberId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Employees_PhoneNumberId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Products");

            migrationBuilder.AlterColumn<Guid>(
                name: "OrderId",
                table: "ProductAmounts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_PhoneNumberId",
                table: "Users",
                column: "PhoneNumberId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PhoneNumberId",
                table: "Employees",
                column: "PhoneNumberId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAmounts_Orders_OrderId",
                table: "ProductAmounts",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductAmounts_Orders_OrderId",
                table: "ProductAmounts");

            migrationBuilder.DropIndex(
                name: "IX_Users_PhoneNumberId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Employees_PhoneNumberId",
                table: "Employees");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<Guid>(
                name: "OrderId",
                table: "ProductAmounts",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PhoneNumberId",
                table: "Users",
                column: "PhoneNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PhoneNumberId",
                table: "Employees",
                column: "PhoneNumberId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAmounts_Orders_OrderId",
                table: "ProductAmounts",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }
    }
}
