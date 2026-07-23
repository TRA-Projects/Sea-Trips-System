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

        // 2. Get appointment by ID:
        public Appointment GetById(int id)
        {
            return context.Appointments
                .Include(a => a.Client)
                .Include(a => a.Boat)
                .Include(a => a.TripType)
                .Include(a => a.Destination)
                .Include(a => a.Event)
                .FirstOrDefault(a => a.appointmentId == id);
        }

        // 3. Check boat availability for the given time slot
        public bool IsBoatBooked(int boatId, DateTime start, DateTime end, int? ignoreAppointmentId = null)
        {
            // Checks if the boat is already booked during the requested time slot.
            // Time overlap conditions:
            // 1. New start time falls inside an existing trip.
            // 2. New end time falls inside an existing trip.
            // 3. New trip completely covers an existing trip.
            return context.Appointments.Any(a =>
               a.boatId == boatId &&
               a.bookingStatus != "Cancelled" &&
               (ignoreAppointmentId == null || a.appointmentId != ignoreAppointmentId) &&
               ((start >= a.startTime && start < a.endTime) ||
                (end > a.startTime && end <= a.endTime) ||
                (start <= a.startTime && end >= a.endTime)));


        }

    }
}
