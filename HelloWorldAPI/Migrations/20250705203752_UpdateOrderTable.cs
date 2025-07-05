using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelloWorldAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOrderTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2025, 5, 27, 4, 13, 7, 141, DateTimeKind.Utc).AddTicks(2842));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2025, 5, 27, 4, 13, 7, 141, DateTimeKind.Utc).AddTicks(2842));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2025, 5, 27, 4, 13, 7, 141, DateTimeKind.Utc).AddTicks(2842));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "Orders");
        }
    }
}
