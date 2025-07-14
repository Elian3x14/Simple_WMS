using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TKS_intern_server.Migrations
{
    /// <inheritdoc />
    public partial class Addtablephieunhapkhoandchitiet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_DM_Phieu_Nhap_Kho",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    So_Phieu_Nhap_Kho = table.Column<string>(type: "varchar(50)", nullable: false),
                    Kho_ID = table.Column<int>(type: "int", nullable: false),
                    NCC_ID = table.Column<int>(type: "int", nullable: false),
                    Ngay_Nhap_Kho = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ghi_Chu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_DM_Phieu_Nhap_Kho", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_DM_Phieu_Nhap_Kho_tbl_DM_Kho_Kho_ID",
                        column: x => x.Kho_ID,
                        principalTable: "tbl_DM_Kho",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_DM_Phieu_Nhap_Kho_tbl_DM_Nha_Cung_Cap_NCC_ID",
                        column: x => x.NCC_ID,
                        principalTable: "tbl_DM_Nha_Cung_Cap",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_DM_Nhap_Kho_Raw_Data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nhap_Kho_ID = table.Column<int>(type: "int", nullable: false),
                    San_Pham_ID = table.Column<int>(type: "int", nullable: false),
                    SL_Nhap = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Don_Gia_Nhap = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_DM_Nhap_Kho_Raw_Data", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_DM_Nhap_Kho_Raw_Data_tbl_DM_Phieu_Nhap_Kho_Nhap_Kho_ID",
                        column: x => x.Nhap_Kho_ID,
                        principalTable: "tbl_DM_Phieu_Nhap_Kho",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_DM_Nhap_Kho_Raw_Data_tbl_DM_San_Pham_San_Pham_ID",
                        column: x => x.San_Pham_ID,
                        principalTable: "tbl_DM_San_Pham",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_DM_Nhap_Kho_Raw_Data_Nhap_Kho_ID",
                table: "tbl_DM_Nhap_Kho_Raw_Data",
                column: "Nhap_Kho_ID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_DM_Nhap_Kho_Raw_Data_San_Pham_ID",
                table: "tbl_DM_Nhap_Kho_Raw_Data",
                column: "San_Pham_ID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_DM_Phieu_Nhap_Kho_Kho_ID",
                table: "tbl_DM_Phieu_Nhap_Kho",
                column: "Kho_ID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_DM_Phieu_Nhap_Kho_NCC_ID",
                table: "tbl_DM_Phieu_Nhap_Kho",
                column: "NCC_ID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_DM_Phieu_Nhap_Kho_So_Phieu_Nhap_Kho",
                table: "tbl_DM_Phieu_Nhap_Kho",
                column: "So_Phieu_Nhap_Kho",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_DM_Nhap_Kho_Raw_Data");

            migrationBuilder.DropTable(
                name: "tbl_DM_Phieu_Nhap_Kho");
        }
    }
}
