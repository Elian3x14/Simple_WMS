using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TKS_intern_server.Migrations
{
    /// <inheritdoc />
    public partial class altertablephieuxuatkho : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_DM_Phieu_Xuat_Kho_tbl_DM_Nha_Cung_Cap_NhaCungCapId",
                table: "tbl_DM_Phieu_Xuat_Kho");

            migrationBuilder.DropIndex(
                name: "IX_tbl_DM_Phieu_Xuat_Kho_NhaCungCapId",
                table: "tbl_DM_Phieu_Xuat_Kho");

            migrationBuilder.DropColumn(
                name: "NhaCungCapId",
                table: "tbl_DM_Phieu_Xuat_Kho");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NhaCungCapId",
                table: "tbl_DM_Phieu_Xuat_Kho",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_DM_Phieu_Xuat_Kho_NhaCungCapId",
                table: "tbl_DM_Phieu_Xuat_Kho",
                column: "NhaCungCapId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_DM_Phieu_Xuat_Kho_tbl_DM_Nha_Cung_Cap_NhaCungCapId",
                table: "tbl_DM_Phieu_Xuat_Kho",
                column: "NhaCungCapId",
                principalTable: "tbl_DM_Nha_Cung_Cap",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
