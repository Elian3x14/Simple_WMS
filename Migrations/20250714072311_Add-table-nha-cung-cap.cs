using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TKS_intern_server.Migrations
{
    /// <inheritdoc />
    public partial class Addtablenhacungcap : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_DM_Don_Vi_Tinh",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten_Don_Vi_Tinh = table.Column<string>(type: "varchar(255)", nullable: false),
                    Ghi_Chu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_DM_Don_Vi_Tinh", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "tbl_DM_Nha_Cung_Cap",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ma_NCC = table.Column<string>(type: "varchar(50)", nullable: false),
                    Ten_NCC = table.Column<string>(type: "varchar(255)", nullable: false),
                    Ghi_Chu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_DM_Nha_Cung_Cap", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_DM_San_Pham",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ma_San_Pham = table.Column<string>(type: "varchar(50)", nullable: false),
                    Ten_San_Pham = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Loai_San_Pham_ID = table.Column<int>(type: "int", nullable: false),
                    Don_Vi_Tinh_ID = table.Column<int>(type: "int", nullable: false),
                    Ghi_Chu = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_DM_San_Pham", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_DM_San_Pham_tbl_DM_Don_Vi_Tinh_Don_Vi_Tinh_ID",
                        column: x => x.Don_Vi_Tinh_ID,
                        principalTable: "tbl_DM_Don_Vi_Tinh",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_DM_San_Pham_tbl_DM_Loai_San_Pham_Loai_San_Pham_ID",
                        column: x => x.Loai_San_Pham_ID,
                        principalTable: "tbl_DM_Loai_San_Pham",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_DM_Don_Vi_Tinh_Ten_Don_Vi_Tinh",
                table: "tbl_DM_Don_Vi_Tinh",
                column: "Ten_Don_Vi_Tinh",
                unique: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_tbl_DM_Nha_Cung_Cap_Ten_NCC",
                table: "tbl_DM_Nha_Cung_Cap",
                column: "Ten_NCC",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_DM_San_Pham_Don_Vi_Tinh_ID",
                table: "tbl_DM_San_Pham",
                column: "Don_Vi_Tinh_ID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_DM_San_Pham_Loai_San_Pham_ID",
                table: "tbl_DM_San_Pham",
                column: "Loai_San_Pham_ID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_DM_San_Pham_Ma_San_Pham",
                table: "tbl_DM_San_Pham",
                column: "Ma_San_Pham",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_DM_Nha_Cung_Cap");

            migrationBuilder.DropTable(
                name: "tbl_DM_San_Pham");

            migrationBuilder.DropTable(
                name: "tbl_DM_Don_Vi_Tinh");

            migrationBuilder.DropTable(
                name: "tbl_DM_Loai_San_Pham");
        }
    }
}
