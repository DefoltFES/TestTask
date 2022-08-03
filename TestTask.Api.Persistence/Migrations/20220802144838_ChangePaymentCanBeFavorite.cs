using Microsoft.EntityFrameworkCore.Migrations;

namespace TestTask.Api.Persistence.Migrations
{
    public partial class ChangePaymentCanBeFavorite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Favorites_PaymentId",
                table: "Favorites");

            migrationBuilder.AddColumn<bool>(
                name: "CanBeFavorite",
                table: "Payments",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_PaymentId",
                table: "Favorites",
                column: "PaymentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Favorites_PaymentId",
                table: "Favorites");

            migrationBuilder.DropColumn(
                name: "CanBeFavorite",
                table: "Payments");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_PaymentId",
                table: "Favorites",
                column: "PaymentId",
                unique: true);
        }
    }
}
