using Microsoft.EntityFrameworkCore.Migrations;

namespace CoinFac.Persistence.Migrations
{
    public partial class RenameFKs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Users_UserForeignKey",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Records_Accounts_AccountForeignKey",
                table: "Records");

            migrationBuilder.RenameColumn(
                name: "AccountForeignKey",
                table: "Records",
                newName: "AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Records_AccountForeignKey",
                table: "Records",
                newName: "IX_Records_AccountId");

            migrationBuilder.RenameColumn(
                name: "UserForeignKey",
                table: "Accounts",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Accounts_UserForeignKey",
                table: "Accounts",
                newName: "IX_Accounts_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Users_UserId",
                table: "Accounts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Records_Accounts_AccountId",
                table: "Records",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Users_UserId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Records_Accounts_AccountId",
                table: "Records");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "Records",
                newName: "AccountForeignKey");

            migrationBuilder.RenameIndex(
                name: "IX_Records_AccountId",
                table: "Records",
                newName: "IX_Records_AccountForeignKey");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Accounts",
                newName: "UserForeignKey");

            migrationBuilder.RenameIndex(
                name: "IX_Accounts_UserId",
                table: "Accounts",
                newName: "IX_Accounts_UserForeignKey");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Users_UserForeignKey",
                table: "Accounts",
                column: "UserForeignKey",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Records_Accounts_AccountForeignKey",
                table: "Records",
                column: "AccountForeignKey",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
