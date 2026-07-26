namespace Sea_Trips_System.Models
{
    public class DestinationRepo
    {
        //cotext==>repo // Database Context
        private SeaTripsContext context;


        // Dependency Injection // Constructor
        public DestinationRepo(SeaTripsContext _context)
        {
            context = _context;
        }

       
    }
}
