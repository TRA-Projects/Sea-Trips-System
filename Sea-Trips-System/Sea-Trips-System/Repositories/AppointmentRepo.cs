namespace Sea_Trips_System.Models
{
    public class AppointmentRepo
    {
        private SeaTripsContext context;
        public AppointmentRepo(SeaTripsContext _context)
        {
            context = _context;
        }
    }
}
