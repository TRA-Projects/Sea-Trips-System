using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sea_Trips_System.Migrations
{
    /// <inheritdoc />
    public partial class FixPropertyNamesToCamelCase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Boat_BoatId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Client_ClientId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Destinations_DestinationId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Events_EventId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_TripTypes_TripTypeId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentStaffs_Appointments_AppointmentId",
                table: "AppointmentStaffs");

            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentStaffs_Staffs_StaffId",
                table: "AppointmentStaffs");

            migrationBuilder.RenameColumn(
                name: "StaffId",
                table: "AppointmentStaffs",
                newName: "staffId");

            migrationBuilder.RenameColumn(
                name: "AssignedRole",
                table: "AppointmentStaffs",
                newName: "assignedRole");

            migrationBuilder.RenameColumn(
                name: "AppointmentId",
                table: "AppointmentStaffs",
                newName: "appointmentId");

            migrationBuilder.RenameIndex(
                name: "IX_AppointmentStaffs_StaffId",
                table: "AppointmentStaffs",
                newName: "IX_AppointmentStaffs_staffId");

            migrationBuilder.RenameIndex(
                name: "IX_AppointmentStaffs_AppointmentId",
                table: "AppointmentStaffs",
                newName: "IX_AppointmentStaffs_appointmentId");

            migrationBuilder.RenameColumn(
                name: "TripTypeId",
                table: "Appointments",
                newName: "tripTypeId");

            migrationBuilder.RenameColumn(
                name: "EventId",
                table: "Appointments",
                newName: "eventId");

            migrationBuilder.RenameColumn(
                name: "DestinationId",
                table: "Appointments",
                newName: "destinationId");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "Appointments",
                newName: "clientId");

            migrationBuilder.RenameColumn(
                name: "BoatId",
                table: "Appointments",
                newName: "boatId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_TripTypeId",
                table: "Appointments",
                newName: "IX_Appointments_tripTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_EventId",
                table: "Appointments",
                newName: "IX_Appointments_eventId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_DestinationId",
                table: "Appointments",
                newName: "IX_Appointments_destinationId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_ClientId",
                table: "Appointments",
                newName: "IX_Appointments_clientId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_BoatId",
                table: "Appointments",
                newName: "IX_Appointments_boatId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Boat_boatId",
                table: "Appointments",
                column: "boatId",
                principalTable: "Boat",
                principalColumn: "boatId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Client_clientId",
                table: "Appointments",
                column: "clientId",
                principalTable: "Client",
                principalColumn: "clientId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Destinations_destinationId",
                table: "Appointments",
                column: "destinationId",
                principalTable: "Destinations",
                principalColumn: "destinationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Events_eventId",
                table: "Appointments",
                column: "eventId",
                principalTable: "Events",
                principalColumn: "eventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_TripTypes_tripTypeId",
                table: "Appointments",
                column: "tripTypeId",
                principalTable: "TripTypes",
                principalColumn: "tripTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentStaffs_Appointments_appointmentId",
                table: "AppointmentStaffs",
                column: "appointmentId",
                principalTable: "Appointments",
                principalColumn: "appointmentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentStaffs_Staffs_staffId",
                table: "AppointmentStaffs",
                column: "staffId",
                principalTable: "Staffs",
                principalColumn: "staffId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Boat_boatId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Client_clientId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Destinations_destinationId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Events_eventId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_TripTypes_tripTypeId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentStaffs_Appointments_appointmentId",
                table: "AppointmentStaffs");

            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentStaffs_Staffs_staffId",
                table: "AppointmentStaffs");

            migrationBuilder.RenameColumn(
                name: "staffId",
                table: "AppointmentStaffs",
                newName: "StaffId");

            migrationBuilder.RenameColumn(
                name: "assignedRole",
                table: "AppointmentStaffs",
                newName: "AssignedRole");

            migrationBuilder.RenameColumn(
                name: "appointmentId",
                table: "AppointmentStaffs",
                newName: "AppointmentId");

            migrationBuilder.RenameIndex(
                name: "IX_AppointmentStaffs_staffId",
                table: "AppointmentStaffs",
                newName: "IX_AppointmentStaffs_StaffId");

            migrationBuilder.RenameIndex(
                name: "IX_AppointmentStaffs_appointmentId",
                table: "AppointmentStaffs",
                newName: "IX_AppointmentStaffs_AppointmentId");

            migrationBuilder.RenameColumn(
                name: "tripTypeId",
                table: "Appointments",
                newName: "TripTypeId");

            migrationBuilder.RenameColumn(
                name: "eventId",
                table: "Appointments",
                newName: "EventId");

            migrationBuilder.RenameColumn(
                name: "destinationId",
                table: "Appointments",
                newName: "DestinationId");

            migrationBuilder.RenameColumn(
                name: "clientId",
                table: "Appointments",
                newName: "ClientId");

            migrationBuilder.RenameColumn(
                name: "boatId",
                table: "Appointments",
                newName: "BoatId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_tripTypeId",
                table: "Appointments",
                newName: "IX_Appointments_TripTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_eventId",
                table: "Appointments",
                newName: "IX_Appointments_EventId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_destinationId",
                table: "Appointments",
                newName: "IX_Appointments_DestinationId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_clientId",
                table: "Appointments",
                newName: "IX_Appointments_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_boatId",
                table: "Appointments",
                newName: "IX_Appointments_BoatId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Boat_BoatId",
                table: "Appointments",
                column: "BoatId",
                principalTable: "Boat",
                principalColumn: "boatId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Client_ClientId",
                table: "Appointments",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "clientId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Destinations_DestinationId",
                table: "Appointments",
                column: "DestinationId",
                principalTable: "Destinations",
                principalColumn: "destinationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Events_EventId",
                table: "Appointments",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "eventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_TripTypes_TripTypeId",
                table: "Appointments",
                column: "TripTypeId",
                principalTable: "TripTypes",
                principalColumn: "tripTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentStaffs_Appointments_AppointmentId",
                table: "AppointmentStaffs",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "appointmentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentStaffs_Staffs_StaffId",
                table: "AppointmentStaffs",
                column: "StaffId",
                principalTable: "Staffs",
                principalColumn: "staffId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
