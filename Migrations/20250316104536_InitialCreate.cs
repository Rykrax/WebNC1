using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebNC1.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    BankID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    BankImage = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.BankID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    PasswordHash = table.Column<string>(type: "varchar(255)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    CCCD = table.Column<string>(type: "char(12)", maxLength: 12, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Email = table.Column<string>(type: "varchar(255)", nullable: false),
                    Balance = table.Column<int>(type: "int", nullable: false),
                    PinCode = table.Column<string>(type: "char(6)", maxLength: 6, nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusUser = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    RoleUser = table.Column<string>(type: "nvarchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "BankAccounts",
                columns: table => new
                {
                    AccountNumber = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    BankID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    StatusAccount = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccounts", x => new { x.AccountNumber, x.BankID });
                    table.ForeignKey(
                        name: "FK_BankAccounts_Banks_BankID",
                        column: x => x.BankID,
                        principalTable: "Banks",
                        principalColumn: "BankID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BankAccounts_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderUser = table.Column<int>(type: "int", nullable: false),
                    SenderAccount = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    SendBank = table.Column<int>(type: "int", nullable: false),
                    RecipientUser = table.Column<int>(type: "int", nullable: false),
                    RepAccount = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    RepBank = table.Column<int>(type: "int", nullable: false),
                    TransactionType = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    StatusTransaction = table.Column<string>(type: "nvarchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionID);
                    table.ForeignKey(
                        name: "FK_Transactions_BankAccounts_RepAccount_RepBank",
                        columns: x => new { x.RepAccount, x.RepBank },
                        principalTable: "BankAccounts",
                        principalColumns: new[] { "AccountNumber", "BankID" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_BankAccounts_SenderAccount_SendBank",
                        columns: x => new { x.SenderAccount, x.SendBank },
                        principalTable: "BankAccounts",
                        principalColumns: new[] { "AccountNumber", "BankID" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankAccounts_BankID",
                table: "BankAccounts",
                column: "BankID");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccounts_UserID",
                table: "BankAccounts",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_RepAccount_RepBank",
                table: "Transactions",
                columns: new[] { "RepAccount", "RepBank" });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_SenderAccount_SendBank",
                table: "Transactions",
                columns: new[] { "SenderAccount", "SendBank" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "BankAccounts");

            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
