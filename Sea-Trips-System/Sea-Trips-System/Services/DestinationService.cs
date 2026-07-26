using System.ComponentModel;

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

            return output;



        }

        // =====================================================
        // CREATE DESTINATION
        // =====================================================

        // Creates a new destination
        public DestinationDTOs.DestinationOutputDTOs CreateDestination(DestinationDTOs.DestinationInputDTOs input)
        {
            // Create a new Destination entity and map data from the Input DTO
            Destination destination = new Destination();

            destination.name = input.name;
            destination.coordinates = input.coordinates;
            destination.estimatedDuration = input.EstimatedDuration;

            // Save the new entity to the database via Repository
            repo.Add(destination);


           // Map the saved entity(which now contains the generated ID) to the Output DTO and return it
            DestinationDTOs.DestinationOutputDTOs output = new DestinationDTOs.DestinationOutputDTOs();

            output.destinationId = destination.destinationId;
            output.name = destination.name;
            output.coordinates = destination.coordinates;
            output.estimatedDuration = destination.estimatedDuration;

            return output;

        }

        // =====================================================
        // UPDATE DESTINATION
        // =====================================================

        // Updates an existing destination's details if it exists in the database
        public bool UpdateDestination(int id, DestinationDTOs.DestinationInputDTOs input)
        {
            // fetch the existing destination from DB using the provided ID
            Destination existingDestination = repo.GetDestinationById(id);

            //Validation: If destination does not exist, return false
            if (existingDestination == null)
            {
                return false;
            }

            //Update the existing entity fields with the new values from Input DTO
            existingDestination.name = input.name;
            existingDestination.coordinates = input.coordinates;
            existingDestination.estimatedDuration = input.EstimatedDuration;

            //Save updates to the database via Repository
            repo.Update();

            //Return true indicating the update operation was successful
            return true;
        }

            // =====================================================
            // DELETE DESTINATION
            // =====================================================

        }
}
