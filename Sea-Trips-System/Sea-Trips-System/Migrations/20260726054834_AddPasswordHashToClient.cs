using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sea_Trips_System.Migrations
{
    /// <inheritdoc />
    public partial class AddPasswordHashToClient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "passwordHash",
                table: "Client",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "passwordHash",
                table: "Client");
        }
    }
}
