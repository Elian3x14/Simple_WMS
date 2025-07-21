using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TKS_intern_server.Migrations
{
    /// <inheritdoc />
    public partial class Changeforeignkeytonulable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_DM_Phieu_Nhap_Kho_tbl_DM_Kho_Kho_ID",
                table: "tbl_DM_Phieu_Nhap_Kho");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_DM_Phieu_Nhap_Kho_tbl_DM_Nha_Cung_Cap_NCC_ID",
                table: "tbl_DM_Phieu_Nhap_Kho");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_DM_Phieu_Xuat_Kho_tbl_DM_Kho_Kho_ID",
                table: "tbl_DM_Phieu_Xuat_Kho");

            migrationBuilder.AlterColumn<int>(
                name: "Kho_ID",
                table: "tbl_DM_Phieu_Xuat_Kho",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "NCC_ID",
                table: "tbl_DM_Phieu_Nhap_Kho",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Kho_ID",
                table: "tbl_DM_Phieu_Nhap_Kho",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_DM_Phieu_Nhap_Kho_tbl_DM_Kho_Kho_ID",
                table: "tbl_DM_Phieu_Nhap_Kho",
                column: "Kho_ID",
                principalTable: "tbl_DM_Kho",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_DM_Phieu_Nhap_Kho_tbl_DM_Nha_Cung_Cap_NCC_ID",
                table: "tbl_DM_Phieu_Nhap_Kho",
                column: "NCC_ID",
                principalTable: "tbl_DM_Nha_Cung_Cap",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_DM_Phieu_Xuat_Kho_tbl_DM_Kho_Kho_ID",
                table: "tbl_DM_Phieu_Xuat_Kho",
                column: "Kho_ID",
                principalTable: "tbl_DM_Kho",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_DM_Phieu_Nhap_Kho_tbl_DM_Kho_Kho_ID",
                table: "tbl_DM_Phieu_Nhap_Kho");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_DM_Phieu_Nhap_Kho_tbl_DM_Nha_Cung_Cap_NCC_ID",
                table: "tbl_DM_Phieu_Nhap_Kho");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_DM_Phieu_Xuat_Kho_tbl_DM_Kho_Kho_ID",
                table: "tbl_DM_Phieu_Xuat_Kho");

            migrationBuilder.AlterColumn<int>(
                name: "Kho_ID",
                table: "tbl_DM_Phieu_Xuat_Kho",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NCC_ID",
                table: "tbl_DM_Phieu_Nhap_Kho",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Kho_ID",
                table: "tbl_DM_Phieu_Nhap_Kho",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_DM_Phieu_Nhap_Kho_tbl_DM_Kho_Kho_ID",
                table: "tbl_DM_Phieu_Nhap_Kho",
                column: "Kho_ID",
                principalTable: "tbl_DM_Kho",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_DM_Phieu_Nhap_Kho_tbl_DM_Nha_Cung_Cap_NCC_ID",
                table: "tbl_DM_Phieu_Nhap_Kho",
                column: "NCC_ID",
                principalTable: "tbl_DM_Nha_Cung_Cap",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_DM_Phieu_Xuat_Kho_tbl_DM_Kho_Kho_ID",
                table: "tbl_DM_Phieu_Xuat_Kho",
                column: "Kho_ID",
                principalTable: "tbl_DM_Kho",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
