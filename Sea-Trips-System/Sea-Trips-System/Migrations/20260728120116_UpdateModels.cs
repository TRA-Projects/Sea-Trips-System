using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sea_Trips_System.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Events_eventId",
                table: "Appointments");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_eventId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "eventId",
                table: "Appointments");

            migrationBuilder.AddColumn<int>(
                name: "boatId",
                table: "TripTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "TripTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "price",
                table: "Boat",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_TripTypes_boatId",
                table: "TripTypes",
                column: "boatId");

            migrationBuilder.AddForeignKey(
                name: "FK_TripTypes_Boat_boatId",
                table: "TripTypes",
                column: "boatId",
                principalTable: "Boat",
                principalColumn: "boatId",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TripTypes_Boat_boatId",
                table: "TripTypes");

            migrationBuilder.DropIndex(
                name: "IX_TripTypes_boatId",
                table: "TripTypes");

            migrationBuilder.DropColumn(
                name: "boatId",
                table: "TripTypes");

            migrationBuilder.DropColumn(
                name: "status",
                table: "TripTypes");

            migrationBuilder.DropColumn(
                name: "price",
                table: "Boat");

            migrationBuilder.AddColumn<int>(
                name: "eventId",
                table: "Appointments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    eventId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    discountRate = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    eventName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.eventId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_eventId",
                table: "Appointments",
                column: "eventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Events_eventId",
                table: "Appointments",
                column: "eventId",
                principalTable: "Events",
                principalColumn: "eventId");
        }
    }
}
