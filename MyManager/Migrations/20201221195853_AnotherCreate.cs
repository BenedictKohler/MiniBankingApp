using Microsoft.EntityFrameworkCore.Migrations;

namespace MyManagerServices.Migrations
{
    public partial class AnotherCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "BankBalance",
                table: "User",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "ReceiverName",
                table: "Transaction",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BankBalance",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ReceiverName",
                table: "Transaction");
        }
    }
}
