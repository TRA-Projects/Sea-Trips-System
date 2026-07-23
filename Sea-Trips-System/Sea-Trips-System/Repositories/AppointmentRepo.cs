using Microsoft.EntityFrameworkCore;

namespace Sea_Trips_System.Models
{
    public class AppointmentRepo
    {
        private SeaTripsContext context;
        public AppointmentRepo(SeaTripsContext _context)
        {
            context = _context;
        }

        // 1. Get all appointments with navigation properties:
        public List<Appointment> GetAll()
        {
            return context.Appointments
                .Include(a => a.Client)
                .Include(a => a.Boat)
                .Include(a => a.TripType)
                .Include(a => a.Destination)
                .Include(a => a.Event)
                .ToList();
        }


    }
}
