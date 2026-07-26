using Microsoft.EntityFrameworkCore;
using Sea_Trips_System.Models;

namespace Sea_Trips_System.Repositories
{
    public class AppointmentStaffRepo
    {

        private SeaTripsContext context;

        public AppointmentStaffRepo(SeaTripsContext _context)
        {
            context = _context;
        }


        // 1. Get all staff assignments with navigation properties loaded
        public List<AppointmentStaff> GetAll()
        {
            return context.AppointmentStaffs
                .Include(aps => aps.Staff)
                .Include(aps => aps.Appointment)
                .ToList();
        }

        // 2. Get all staff assigned to a specific appointment ID

        public List<AppointmentStaff> GetByAppointmentId(int appointmentId)
        {
            return context.AppointmentStaffs
                .Include(aps => aps.Staff)
                .Where(aps => aps.appointmentId == appointmentId)
                .ToList();
        }

        public AppointmentStaff? GetById(int id)
        {
            return context.AppointmentStaffs
                .Include(aps => aps.Staff)
                .FirstOrDefault(aps => aps.appointmentStaffId == id);
        }


    }
}
