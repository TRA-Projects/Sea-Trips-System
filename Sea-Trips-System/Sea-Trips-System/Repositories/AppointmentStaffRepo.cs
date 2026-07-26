using Microsoft.EntityFrameworkCore;
using Sea_Trips_System.Models;

namespace Sea_Trips_System.Repositories
{
    public class AppointmentStaffRepo
    {

        private  SeaTripsContext context;

        public AppointmentStaffRepo(SeaTripsContext _context)
        {
            context = _context;
        }

        public List<AppointmentStaff> GetAll()
        {
            return context.AppointmentStaffs
                .Include(aps => aps.Staff)
                .Include(aps => aps.Appointment)
                .ToList();
        }
    }
}
