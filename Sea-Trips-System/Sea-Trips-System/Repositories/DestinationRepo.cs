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

        // =====================================================
        // GET ALL DESTINATIONS
        // =====================================================

        public List<Destination> GetAllDestinations()
        {
            return context.Destinations.ToList();
        }

        // =====================================================
        // GET DESTINATION BY ID
        // =====================================================
        
        public Destination GetDestinationById(int id)
        {
            return context.Destinations.FirstOrDefault(d => d.destinationId == id);
        }

        // =====================================================
        // ADD DESTINATION
        // =====================================================

        public void Add(Destination destination)
        {
            //add new destination in dbset
            context.Destinations.Add(destination);
            context.SaveChanges();
        }

        // =====================================================
        // UPDATE DESTINATION
        // =====================================================

        public void Update()
        {
            context.SaveChanges();
        }

    }
}
