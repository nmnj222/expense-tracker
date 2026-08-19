using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpenseTracker.Migrations
{
    /// <inheritdoc />
    public partial class RenameTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reminders_transaction_groups_TransactionGroupId",
                table: "reminders");

            migrationBuilder.DropForeignKey(
                name: "FK_saving_plans_users_UserId",
                table: "saving_plans");

            migrationBuilder.DropForeignKey(
                name: "FK_transaction_groups_users_UserId",
                table: "transaction_groups");

            migrationBuilder.DropForeignKey(
                name: "FK_transactions_transaction_groups_TransactionGroupId",
                table: "transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_transactions",
                table: "transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_transaction_groups",
                table: "transaction_groups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_saving_plans",
                table: "saving_plans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_reminders",
                table: "reminders");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "user");

            migrationBuilder.RenameTable(
                name: "transactions",
                newName: "transaction");

            migrationBuilder.RenameTable(
                name: "transaction_groups",
                newName: "transaction_group");

            migrationBuilder.RenameTable(
                name: "saving_plans",
                newName: "saving_plan");

            migrationBuilder.RenameTable(
                name: "reminders",
                newName: "reminder");

            migrationBuilder.RenameIndex(
                name: "IX_transactions_TransactionGroupId",
                table: "transaction",
                newName: "IX_transaction_TransactionGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_transaction_groups_UserId",
                table: "transaction_group",
                newName: "IX_transaction_group_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_saving_plans_UserId",
                table: "saving_plan",
                newName: "IX_saving_plan_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_reminders_TransactionGroupId",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                newName: "users");

            migrationBuilder.RenameTable(
                name: "transaction_group",
                newName: "transaction_groups");

            migrationBuilder.RenameTable(
                name: "transaction",
                newName: "transactions");

            migrationBuilder.RenameTable(
                name: "saving_plan",
                newName: "saving_plans");

            migrationBuilder.RenameTable(
                name: "reminder",
                newName: "reminders");

            migrationBuilder.RenameIndex(
                name: "IX_transaction_group_UserId",
                table: "transaction_groups",
                newName: "IX_transaction_groups_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_transaction_TransactionGroupId",
                table: "transactions",
                newName: "IX_transactions_TransactionGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_saving_plan_UserId",
                table: "saving_plans",
                newName: "IX_saving_plans_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_reminder_TransactionGroupId",
                table: "reminders",
                newName: "IX_reminders_TransactionGroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_transaction_groups",
                table: "transaction_groups",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_transactions",
                table: "transactions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_saving_plans",
                table: "saving_plans",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_reminders",
                table: "reminders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_reminders_transaction_groups_TransactionGroupId",
                table: "reminders",
                column: "TransactionGroupId",
                principalTable: "transaction_groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_saving_plans_users_UserId",
                table: "saving_plans",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_transaction_groups_users_UserId",
                table: "transaction_groups",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_transactions_transaction_groups_TransactionGroupId",
                table: "transactions",
                column: "TransactionGroupId",
                principalTable: "transaction_groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
