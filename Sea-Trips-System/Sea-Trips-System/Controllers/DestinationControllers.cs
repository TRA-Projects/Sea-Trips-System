using Microsoft.AspNetCore.Mvc;

namespace Sea_Trips_System.Models
{
    [ApiController]
    [Route("Destination")]
    public class DestinationControllers:ControllerBase
    {
        private DestinationService destinationService;

        // Dependency Injection
        public DestinationControllers(DestinationService _destinationService)
        {
            destinationService = _destinationService;
        }
        // Define this action as an HTTP GET endpoint with the route "GetAllDestinations"

        [HttpGet("GetAllDestinations")]
        public IActionResult GetAllDestinations()
        {
            // 1. Call the service layer to fetch all destinations mapped as DTOs
            List<DestinationDTOs.DestinationOutputDTOs>  result = destinationService.GetAllDestinations();

            // 2. Check if the returned list contains any destination items
            if (result.Count > 0)
            {
                // Return 200 OK status code along with the list of destinations
                return Ok(result); //200 success
            }
            // 3. Return 204 No Content status code if the list is empty (request succeeded, but no data to return)
            return NoContent(); //204 no data
        }

        // Define as an HTTP GET endpoint with a route parameter {id}
        // URL Example: http://localhost:5153/destination/GetDestinationById/3
        [HttpGet("GetDestinationById/{id}")]
        public IActionResult GetDestinationById([FromRoute] int id)
        {
            // 1. Call the service layer to fetch the destination DTO by its unique ID
            DestinationDTOs.DestinationOutputDTOs destination = destinationService.GetDestinationById(id);

            if (destination == null)
            {
                return NotFound(); // 404 Not Found
            }

            return Ok(destination); // 200 OK
        }
    }
}
