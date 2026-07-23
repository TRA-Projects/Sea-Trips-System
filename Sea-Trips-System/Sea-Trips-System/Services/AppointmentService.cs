namespace Sea_Trips_System.Models
{
    public class AppointmentService
    {
        private AppointmentRepo appointmentRepo;

        public AppointmentService(AppointmentRepo _appointmentRepo)
        {
            appointmentRepo = _appointmentRepo;
        }


    }
}
