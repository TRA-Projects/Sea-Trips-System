namespace Sea_Trips_System.Models
{
    // Service responsible for handling business logic related to Destinations
    public class DestinationService
    {
        // Repository used to interact with the database
        private DestinationRepo repo;


        // Injects DestinationRepo using Dependency Injection

        public DestinationService(DestinationRepo _repo)
        {
            repo = _repo;
        }

        // =====================================================
        // GET ALL DESTINATIONS
        // =====================================================

        //Retrieves all destinations from the repository and maps them to Output DTOs.
        public List<DestinationDTOs.DestinationOutputDTOs> GetAllDestinations()
        {
            return repo.GetAllDestinations().Select(destintion => new DestinationDTOs.DestinationOutputDTOs
            {
                destinationId = destintion.destinationId,
                name = destintion.name,
                coordinates = destintion.coordinates,
                estimatedDuration = destintion.estimatedDuration
            }).ToList();
        }

        // =====================================================
        // GET DESTINATION BY ID
        // =====================================================


        // =====================================================
        // CREATE DESTINATION
        // =====================================================


        // =====================================================
        // UPDATE DESTINATION
        // =====================================================


        // =====================================================
        // DELETE DESTINATION
        // =====================================================

    }
}
