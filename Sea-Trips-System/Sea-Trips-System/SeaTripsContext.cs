using Microsoft.EntityFrameworkCore;
using Sea_Trips_System.Models;

namespace Sea_Trips_System
{
    public class SeaTripsContext: DbContext
    {
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<AppointmentStaff> AppointmentStaffs { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Boat> Boats { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Maintenance> Maintenances { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<TripType> TripTypes { get; set; }
        public SeaTripsContext(DbContextOptions<SeaTripsContext> options) : base(options)
        {
        }


    }
}
