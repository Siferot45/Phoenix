using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Phoenox.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddDescriptioncClient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "description",
                table: "clients",
                type: "text",
                nullable: true,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "description",
                table: "clients");
        }
    }
}
