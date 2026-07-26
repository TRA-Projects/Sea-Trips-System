namespace Sea_Trips_System.Repositories
{
    public class AppointmentStaffRepo
    {

        private  SeaTripsContext context;

        public AppointmentStaffRepo(SeaTripsContext _context)
        {
            context = _context;
        }
    }
}
