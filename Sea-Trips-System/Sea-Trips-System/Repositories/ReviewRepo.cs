namespace Sea_Trips_System.Models
{
    public class ReviewRepo
    {
        //cotext==>repo // Database Context
        private SeaTripsContext context;

        // Dependency Injection // Constructor
        public ReviewRepo(SeaTripsContext _context)
        {
            context = _context;
        }
    }
}
