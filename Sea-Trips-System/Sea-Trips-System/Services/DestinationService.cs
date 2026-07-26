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

            //Fetch entities from DB and map each entity to DestinationOutputDTO
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

        // Retrieves one destination by ID
        public DestinationDTOs.DestinationOutputDTOs GetDestinationById(int id)
        {
            //search about this destination that matched this id and get it from database
            Destination destination = repo.GetDestinationById(id);
            
            //validation if destionation not found return null
            if (destination == null)
            {
                return null;
            }

            //map the entity data to the Output DTO //create new object from this entity and put data inside it
            DestinationDTOs.DestinationOutputDTOs  output = new DestinationDTOs.DestinationOutputDTOs();
            output.destinationId = destination.destinationId;
            output.name = destination.name;
            output.coordinates = destination.coordinates;
            output.estimatedDuration = destination.estimatedDuration;

                        

        }

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
