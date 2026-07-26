using Sea_Trips_System.DTOs;
using Sea_Trips_System.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Sea_Trips_System.Controllers
{
    [ApiController]
    [Route("event")]
    [Authorize]
    public class EventController : ControllerBase

    {

        private EventService eventService;

        public EventController(EventService _eventService)  //dependency injection
        {
            eventService = _eventService;
        }

    


        // Get All Events
        [AllowAnonymous]
        [HttpGet("GetAllEvents")]
        public IActionResult GetAllEvents()
        {

            List<EventOutputDTO> result =
                eventService.GetAllEvents();


            if (result.Count > 0)
            {
                return Ok(result);
            }


            return NoContent();

        }





        // Get Event By Id
        [HttpGet("GetEventById/{id}")]
        public IActionResult GetEventById([FromRoute] int id)
        {

            EventAllOutputDTO result =
                eventService.GetEventById(id);



            if (result == null)
            {
                return NotFound();
            }


            return Ok(result);

        }





        // Add Event
        [Authorize(Roles = "Admin")]
        [HttpPost("AddDTO")]
        public IActionResult AddDTO([FromBody] EventInputDTO eventDTO)
        {

            int id = eventService.Create(eventDTO);


            return Ok(new
            {
                EventId = id
            });

        }





        // Update Discount Rate
        [Authorize(Roles = "Admin")]
        [HttpPut("UpdateDiscountRate/{eventId}")]
        public IActionResult UpdateDiscountRate(
            [FromRoute] int eventId,
            [FromQuery] decimal newRate)
        {

            bool updated =
                eventService.UpdateDiscountRate(eventId, newRate);



            if (!updated)
            {
                return NotFound();
            }


            return Ok("Updated successfully");

        }





        // Delete Event
        [Authorize(Roles = "Admin")]
        [HttpDelete("Delete/{eventId}")]
        public IActionResult Delete([FromRoute] int eventId)
        {

            bool deleted =
                eventService.Delete(eventId);



            if (!deleted)
            {
                return NotFound();
            }


            return Ok("Deleted successfully");

        }

    }
}