using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sea_Trips_System.DTOs;
using Sea_Trips_System.Models;
using Sea_Trips_System.Services;
using System.Collections.Generic;

namespace Sea_Trips_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")] //
    public class DestinationsController : BaseController
    {
        private  DestinationService destinationService;

        // Constructor Injection: Injecting DestinationService instance
        public DestinationsController(DestinationService _destinationService)
        {
            destinationService = _destinationService;
        }

        // GET: api/Destinations
        [AllowAnonymous] 
        [HttpGet]
        public IActionResult GetAllDestinations()
        {
            // 1. Fetch all destinations mapped as DTOs
            List<DestinationDTOs.DestinationOutputDTOs> result = destinationService.GetAllDestinations();

            // 2. Check if the returned list contains any items
            if (result != null && result.Count > 0)
            {
                return Ok(result); // 200 OK
            }

            // 3. Return 204 No Content if list is empty
            return NoContent(); // 204 No Content
        }

        // GET: api/Destinations/3
        [AllowAnonymous] 
        [HttpGet("{id}")]
        public IActionResult GetDestinationById([FromRoute] int id)
        {
            // 1. Fetch destination DTO by ID
            DestinationDTOs.DestinationOutputDTOs destination = destinationService.GetDestinationById(id);

            // 2. Safety Check
            if (destination == null)
            {
                return NotFound(new { message = $"Destination with ID {id} was not found." }); // 404 Not Found
            }

            return Ok(destination); // 200 OK
        }

     
        [Authorize(Roles = "Admin,Organizer")] 
        [HttpPost]
        public IActionResult AddDestination([FromBody] DestinationDTOs.DestinationInputDTOs input)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // 1. Send input DTO to service layer
            DestinationDTOs.DestinationOutputDTOs createdDestination = destinationService.CreateDestination(input);

            if (createdDestination == null)
                return BadRequest(new { message = "Failed to create destination." });

            // 2. Return HTTP 201 Created
            return CreatedAtAction(nameof(GetDestinationById), new { id = createdDestination.destinationId }, createdDestination);
        }

       
        [Authorize(Roles = "Admin,Organizer")]
        [HttpPut("{id}")]
        public IActionResult UpdateDestination([FromRoute] int id, [FromBody] DestinationDTOs.DestinationInputDTOs input)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // 1. Update record in service layer
            bool updated = destinationService.UpdateDestination(id, input);

            // 2. Safety Check
            if (!updated)
            {
                return NotFound(new { message = $"Destination with ID {id} was not found." }); // 404 Not Found
            }

            return Ok(new { message = "Destination updated successfully." }); // 200 OK
        }

        // DELETE: api/Destinations/3
        [Authorize(Roles = "Admin")] 
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            // 1. Attempt deletion
            bool deleted = destinationService.DeleteDestination(id);

            // 2. Safety Check
            if (!deleted)
            {
                return NotFound(new { message = $"Destination with ID {id} was not found." }); // 404 Not Found
            }

            return Ok(new { message = "Destination deleted successfully." }); // 200 OK
        }
    }
}