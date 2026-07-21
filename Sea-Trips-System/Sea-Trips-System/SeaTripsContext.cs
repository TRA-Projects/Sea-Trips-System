using Microsoft.EntityFrameworkCore;
using Sea_Trips_System.Models;

namespace Sea_Trips_System
{
    public class SeaTripsContext: DbContext
    {
     public DbSet<AppointmentControllers> Appointments {  get; set; }
     public DbSet<ClientControllers> clients {  get; set; }
     public DbSet<BoatControllers> Boats {  get; set; }
     public DbSet<DestinationControllers> Destinations {  get; set; }
     public DbSet<EventControllers> Events {  get; set; }
     public DbSet<MaintenanceControllers> Maintenances {  get; set; }
     public DbSet<PaymentControllers> Payments {  get; set; }
     public DbSet<ReviewControllers> Reviews {  get; set; }
     public DbSet<StaffControllers> Staffs {  get; set; }
     public DbSet<TripTypeControllers> TripTypes {  get; set; }

        public SeaTripsContext(DbContextOptions<SeaTripsContext> options) : base(options)
        {
        }


    }
}
