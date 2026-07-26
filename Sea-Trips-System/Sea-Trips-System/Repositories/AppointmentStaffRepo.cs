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

        // 3. Find specific assignment record by primary key
        public AppointmentStaff? GetById(int id)
        {
            return context.AppointmentStaffs
                .Include(aps => aps.Staff)
                .FirstOrDefault(aps => aps.appointmentStaffId == id);
        }


        // 4. Check if a staff member is already assigned to an appointment
        public bool IsAlreadyAssigned(int appointmentId, int staffId)
        {
            return context.AppointmentStaffs
                .Any(aps => aps.appointmentId == appointmentId && aps.staffId == staffId);
        }

        // 5. Add a new staff assignment
        public void Add(AppointmentStaff appointmentStaff)
        {
            context.AppointmentStaffs.Add(appointmentStaff);
            context.SaveChanges();
        }


        // 6. Delete a staff assignment
        public void Delete(AppointmentStaff appointmentStaff)
        {
            context.AppointmentStaffs.Remove(appointmentStaff);
            context.SaveChanges();
        }

    }
}
