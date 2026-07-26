using Sea_Trips_System.Models;
using Sea_Trips_System.Repositories;

namespace Sea_Trips_System.Services
{
    public class AppointmentStaffServices
    {

        private  AppointmentStaffRepo appointmentStaffRepo ;
        private AppointmentRepo appointmentRepo;
        private StaffRepo staffRepo;


        public AppointmentStaffServices(AppointmentStaffRepo _appointmentStaffRepo,
                                       AppointmentRepo _appointmentRepo,
                                       StaffRepo _staffRepo)

        {
            appointmentStaffRepo = _appointmentStaffRepo;
            appointmentRepo = _appointmentRepo;
            staffRepo = _staffRepo;

        }



    }
}
