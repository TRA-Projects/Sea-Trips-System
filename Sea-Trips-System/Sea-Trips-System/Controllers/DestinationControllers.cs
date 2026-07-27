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

            return NoContent(); //204 no data
        }
    }
}
