using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TKS_intern_server.Migrations
{
    /// <inheritdoc />
    public partial class ChangeKhoUserModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "tbl_DM_Kho_User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_DM_Kho_User_UserId",
                table: "tbl_DM_Kho_User",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_DM_Kho_User_Users_UserId",
                table: "tbl_DM_Kho_User",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_DM_Kho_User_Users_UserId",
                table: "tbl_DM_Kho_User");

            migrationBuilder.DropIndex(
                name: "IX_tbl_DM_Kho_User_UserId",
                table: "tbl_DM_Kho_User");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "tbl_DM_Kho_User");
        }
    }
}
