using Microsoft.AspNetCore.Mvc;

namespace Sea_Trips_System.Models
{
    //1.// Mark class as an API Controller and set the base URL route to "destination"
    [ApiController]
    [Route("Destination")]
    public class DestinationControllers:ControllerBase
    {
        private DestinationService destinationService;

        // Constructor Injection: Injecting DestinationService instance
        public DestinationControllers(DestinationService _destinationService)
        {
            destinationService = _destinationService;
        }



        // Define this action as an HTTP GET endpoint with the route "GetAllDestinations"
        // GET: GetAllDestinations
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


        // GET: GetDestinationById/3
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

        // POST: AddDestination
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
            // 1. Call the service layer to update the destination record
            bool updated = destinationService.UpdateDestination(id, input);


            // 2. Safety Check: If the destination ID does not exist in the database, return 404
            if (!updated)
            {
                return NotFound(); // HTTP 404 Not Found
            }

            // 3. Return HTTP 200 OK with a success message confirming the update
            return Ok("Updated successfully"); // HTTP 200 OK
        }



        // Define as an HTTP DELETE endpoint taking the target destination ID from Route
        // URL Example: http://localhost:5153/destination/Delete/3
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {

            // 1. Call the service layer to attempt deleting the destination record
            bool deleted = destinationService.DeleteDestination(id);

            // 2. Safety Check: If the destination ID was not found, return 404
            if (!deleted)
            {
                return NotFound(); // HTTP 404 Not Found
            }


            // 3. Return HTTP 200 OK with a confirmation message that deletion succeeded
            return Ok("Deleted successfully"); // HTTP 200 OK
        }
    }
}
