using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Volxyseat.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedIsPopular : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPopular",
                table: "Subscriptions",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPopular",
                table: "Subscriptions");
        }
    }
}
