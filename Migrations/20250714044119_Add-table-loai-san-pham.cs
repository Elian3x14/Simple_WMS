using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TKS_intern_shared.Migrations
{
    /// <inheritdoc />
    public partial class Addtableloaisanpham : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_DM_Loai_San_Pham",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ma_Loai_San_Pham = table.Column<string>(type: "varchar(50)", nullable: false),
                    Ten_Loai_San_Pham = table.Column<string>(type: "varchar(255)", nullable: false),
                    Ghi_Chu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_DM_Loai_San_Pham", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_DM_Loai_San_Pham_Ma_Loai_San_Pham",
                table: "tbl_DM_Loai_San_Pham",
                column: "Ma_Loai_San_Pham",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_DM_Loai_San_Pham_Ten_Loai_San_Pham",
                table: "tbl_DM_Loai_San_Pham",
                column: "Ten_Loai_San_Pham",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_DM_Loai_San_Pham");
        }
    }
}
