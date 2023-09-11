using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Phoenix.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddClientDesc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "clients",
                type: "text",
                nullable: true);
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
