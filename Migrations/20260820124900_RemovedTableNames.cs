using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpenseTracker.Migrations
{
    /// <inheritdoc />
    public partial class RemovedTableNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reminder_transaction_group_TransactionGroupId",
                table: "reminder");

            migrationBuilder.DropForeignKey(
                name: "FK_saving_plan_user_UserId",
                table: "saving_plan");

            migrationBuilder.DropForeignKey(
                name: "FK_transaction_transaction_group_TransactionGroupId",
                table: "transaction");

            migrationBuilder.DropForeignKey(
                name: "FK_transaction_group_user_UserId",
                table: "transaction_group");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user",
                table: "user");

            migrationBuilder.DropPrimaryKey(
                name: "PK_transaction_group",
                table: "transaction_group");

            migrationBuilder.DropPrimaryKey(
                name: "PK_transaction",
                table: "transaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_saving_plan",
                table: "saving_plan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_reminder",
                table: "reminder");

            migrationBuilder.RenameTable(
                name: "user",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "transaction_group",
                newName: "TransactionGroups");

            migrationBuilder.RenameTable(
                name: "transaction",
                newName: "Transactions");

            migrationBuilder.RenameTable(
                name: "saving_plan",
                newName: "SavingsPlans");

            migrationBuilder.RenameTable(
                name: "reminder",
                newName: "Reminders");

            migrationBuilder.RenameIndex(
                name: "IX_transaction_group_UserId",
                table: "TransactionGroups",
                newName: "IX_TransactionGroups_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_transaction_TransactionGroupId",
                table: "Transactions",
                newName: "IX_Transactions_TransactionGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_saving_plan_UserId",
                table: "SavingsPlans",
                newName: "IX_SavingsPlans_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_reminder_TransactionGroupId",
                table: "Reminders",
                newName: "IX_Reminders_TransactionGroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransactionGroups",
                table: "TransactionGroups",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SavingsPlans",
                table: "SavingsPlans",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reminders",
                table: "Reminders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reminders_TransactionGroups_TransactionGroupId",
                table: "Reminders",
                column: "TransactionGroupId",
                principalTable: "TransactionGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SavingsPlans_Users_UserId",
                table: "SavingsPlans",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionGroups_Users_UserId",
                table: "TransactionGroups",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_TransactionGroups_TransactionGroupId",
                table: "Transactions",
                column: "TransactionGroupId",
                principalTable: "TransactionGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reminders_TransactionGroups_TransactionGroupId",
                table: "Reminders");

            migrationBuilder.DropForeignKey(
                name: "FK_SavingsPlans_Users_UserId",
                table: "SavingsPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionGroups_Users_UserId",
                table: "TransactionGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_TransactionGroups_TransactionGroupId",
                table: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TransactionGroups",
                table: "TransactionGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SavingsPlans",
                table: "SavingsPlans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reminders",
                table: "Reminders");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "user");

            migrationBuilder.RenameTable(
                name: "Transactions",
                newName: "transaction");

            migrationBuilder.RenameTable(
                name: "TransactionGroups",
                newName: "transaction_group");

            migrationBuilder.RenameTable(
                name: "SavingsPlans",
                newName: "saving_plan");

            migrationBuilder.RenameTable(
                name: "Reminders",
                newName: "reminder");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_TransactionGroupId",
                table: "transaction",
                newName: "IX_transaction_TransactionGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_TransactionGroups_UserId",
                table: "transaction_group",
                newName: "IX_transaction_group_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_SavingsPlans_UserId",
                table: "saving_plan",
                newName: "IX_saving_plan_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Reminders_TransactionGroupId",
                table: "reminder",
                newName: "IX_reminder_TransactionGroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user",
                table: "user",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_transaction",
                table: "transaction",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_transaction_group",
                table: "transaction_group",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_saving_plan",
                table: "saving_plan",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_reminder",
                table: "reminder",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_reminder_transaction_group_TransactionGroupId",
                table: "reminder",
                column: "TransactionGroupId",
                principalTable: "transaction_group",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_saving_plan_user_UserId",
                table: "saving_plan",
                column: "UserId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_transaction_transaction_group_TransactionGroupId",
                table: "transaction",
                column: "TransactionGroupId",
                principalTable: "transaction_group",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_transaction_group_user_UserId",
                table: "transaction_group",
                column: "UserId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
