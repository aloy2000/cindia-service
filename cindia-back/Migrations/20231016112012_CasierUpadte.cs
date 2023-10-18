using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cindia_back.Migrations
{
    /// <inheritdoc />
    public partial class CasierUpadte : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Casiers_UserCasierId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserCasierId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserCasierId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "CasierUserId",
                table: "Casiers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Casiers_CasierUserId",
                table: "Casiers",
                column: "CasierUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Casiers_Users_CasierUserId",
                table: "Casiers",
                column: "CasierUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Casiers_Users_CasierUserId",
                table: "Casiers");

            migrationBuilder.DropIndex(
                name: "IX_Casiers_CasierUserId",
                table: "Casiers");

            migrationBuilder.DropColumn(
                name: "CasierUserId",
                table: "Casiers");

            migrationBuilder.AddColumn<int>(
                name: "UserCasierId",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserCasierId",
                table: "Users",
                column: "UserCasierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Casiers_UserCasierId",
                table: "Users",
                column: "UserCasierId",
                principalTable: "Casiers",
                principalColumn: "CasierId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
