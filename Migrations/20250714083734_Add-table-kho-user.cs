using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TKS_intern_server.Migrations
{
    /// <inheritdoc />
    public partial class Addtablekhouser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_DM_Kho_User",
                columns: table => new
                {
                    Ma_Dang_Nhap = table.Column<string>(type: "varchar(100)", nullable: false),
                    Kho_ID = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_DM_Kho_User", x => new { x.Ma_Dang_Nhap, x.Kho_ID });
                    table.ForeignKey(
                        name: "FK_tbl_DM_Kho_User_tbl_DM_Kho_Kho_ID",
                        column: x => x.Kho_ID,
                        principalTable: "tbl_DM_Kho",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_DM_Kho_User_Kho_ID",
                table: "tbl_DM_Kho_User",
                column: "Kho_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_DM_Kho_User");
        }
    }
}
