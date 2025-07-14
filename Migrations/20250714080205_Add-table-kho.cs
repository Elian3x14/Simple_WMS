using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TKS_intern_server.Migrations
{
    /// <inheritdoc />
    public partial class Addtablekho : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Updated_At",
                table: "tbl_DM_Nha_Cung_Cap",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "Created_At",
                table: "tbl_DM_Nha_Cung_Cap",
                newName: "CreatedAt");

            migrationBuilder.CreateTable(
                name: "tbl_DM_Kho",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten_Kho = table.Column<string>(type: "varchar(255)", nullable: false),
                    Ghi_Chu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_DM_Kho", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_DM_Nha_Cung_Cap_Ma_NCC",
                table: "tbl_DM_Nha_Cung_Cap",
                column: "Ma_NCC",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_DM_Kho_Ten_Kho",
                table: "tbl_DM_Kho",
                column: "Ten_Kho",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_DM_Kho");

            migrationBuilder.DropIndex(
                name: "IX_tbl_DM_Nha_Cung_Cap_Ma_NCC",
                table: "tbl_DM_Nha_Cung_Cap");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "tbl_DM_Nha_Cung_Cap",
                newName: "Updated_At");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "tbl_DM_Nha_Cung_Cap",
                newName: "Created_At");
        }
    }
}
