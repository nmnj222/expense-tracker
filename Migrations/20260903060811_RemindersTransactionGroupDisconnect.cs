using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpenseTracker.Migrations
{
    /// <inheritdoc />
    public partial class RemindersTransactionGroupDisconnect : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reminders_TransactionGroups_TransactionGroupId",
                table: "Reminders");

            migrationBuilder.DropIndex(
                name: "IX_Reminders_TransactionGroupId",
                table: "Reminders");

            migrationBuilder.DropColumn(
                name: "TransactionGroupId",
                table: "Reminders");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TransactionGroupId",
                table: "Reminders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reminders_TransactionGroupId",
                table: "Reminders",
                column: "TransactionGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reminders_TransactionGroups_TransactionGroupId",
                table: "Reminders",
                column: "TransactionGroupId",
                principalTable: "TransactionGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
