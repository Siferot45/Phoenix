using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Phoenox.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddAgeClient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "age",
                table: "clients",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "age",
                table: "clients");
        }
    }
}
