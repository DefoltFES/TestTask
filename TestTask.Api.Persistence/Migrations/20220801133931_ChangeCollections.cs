using Microsoft.EntityFrameworkCore.Migrations;

namespace TestTask.Api.Persistence.Migrations
{
    public partial class ChangeCollections : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Favorites_PaymentId",
                table: "Favorites");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_PaymentId",
                table: "Favorites",
                column: "PaymentId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Favorites_PaymentId",
                table: "Favorites");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_PaymentId",
                table: "Favorites",
                column: "PaymentId");
        }
    }
}
