using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TKS_intern_shared.Migrations
{
    /// <inheritdoc />
    public partial class Addconstraintfortendonvitinh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "tbl_DM_Don_Vi_Tinh",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "tbl_DM_Don_Vi_Tinh",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_DM_Don_Vi_Tinh_Ten_Don_Vi_Tinh",
                table: "tbl_DM_Don_Vi_Tinh",
                column: "Ten_Don_Vi_Tinh",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tbl_DM_Don_Vi_Tinh_Ten_Don_Vi_Tinh",
                table: "tbl_DM_Don_Vi_Tinh");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "tbl_DM_Don_Vi_Tinh",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETUTCDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "tbl_DM_Don_Vi_Tinh",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETUTCDATE()");
        }
    }
}
