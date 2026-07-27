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
            var result = destinationService.GetAllDestinations();

            if (result.Count > 0)
            {
                return Ok(result); 
            }

            return NoContent(); //204 no data
        }
    }
}
