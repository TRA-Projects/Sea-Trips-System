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


            // 2. Safety Check: If no destination was found with this ID, return a 404 response
            if (destination == null)
            {
                return NotFound(); // 404 Not Found

            }

            // 3. Return HTTP 200 OK along with the found destination DTO data
            return Ok(destination); // 200 OK
        }



        // Define as an HTTP POST endpoint for creating new destination records
        // URL Example: http://localhost:5153/destination/AddDestination

        [HttpPost("AddDestination")]
        public IActionResult AddDestination([FromBody] DestinationDTOs.DestinationInputDTOs input)
        {

            // 1. Send the input DTO to the service layer to map to an Entity and save in DB
            DestinationDTOs.DestinationOutputDTOs createdDestination = destinationService.CreateDestination(input);


            // 2. Return HTTP 200 OK with the created destination object containing its generated ID
            return Ok(createdDestination); // HTTP 200 OK
        }


        // Define as an HTTP PUT endpoint taking the target ID from Route and new data from Body
        // URL Example: http://localhost:5153/destination/UpdateDestination/3
        [HttpPut("UpdateDestination/{id}")]
        public IActionResult UpdateDestination([FromRoute] int id, [FromBody] DestinationDTOs.DestinationInputDTOs input)
        {
            bool updated = destinationService.UpdateDestination(id, input);

            if (!updated)
            {
                return NotFound(); // HTTP 404 Not Found
            }

            return Ok("Updated successfully"); // HTTP 200 OK
        }

    }
}
