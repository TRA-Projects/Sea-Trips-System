using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sea_Trips_System.DTOs;
using Sea_Trips_System.Services;

namespace Sea_Trips_System.Controllers
{
    [ApiController]
    [Route("Boat")]
    public class BoatController : ControllerBase
    {
        private readonly BoatService boatService;

        public BoatController(BoatService _boatService)
        {
            boatService = _boatService;
        }

        // ── 1. Create Boat ───────────────────────────────────────────────────
        [HttpPost("CreateBoat")]
        [Authorize(Roles = "Admin,Organizer")]
        public IActionResult CreateBoat([FromBody] CreateBoatDto dto)
        {
            BoatResponseDto createdBoat = boatService.CreateBoat(dto);

            if (createdBoat == null)
                return BadRequest(new { message = "Boat name already exists." });

            return Ok(createdBoat);
        }

        // ── 2. Get Boat By ID ────────────────────────────────────────────────
        [HttpGet("GetBoatById/{id}")]
        public IActionResult GetBoatById(int id)
        {
            BoatResponseDto boat = boatService.GetBoatById(id);

            if (boat == null)
                return NotFound(new { message = $"Boat with ID {id} was not found." });

            return Ok(boat);
        }

        // ── 3. Get All Boats ─────────────────────────────────────────────────
        [HttpGet("GetAllBoats")]
        public IActionResult GetAllBoats()
        {
            List<BoatResponseDto> boats = boatService.GetAllBoats();
            return Ok(boats);
        }

        // ── 4. Update Boat ───────────────────────────────────────────────────
        [HttpPut("UpdateBoat/{id}")]
        [Authorize(Roles = "Admin,Organizer")]
        public IActionResult UpdateBoat(int id, [FromBody] UpdateBoatDto dto)
        {
            BoatResponseDto updatedBoat = boatService.UpdateBoat(id, dto);

            if (updatedBoat == null)
                return NotFound(new { message = $"Boat with ID {id} was not found." });

            return Ok(updatedBoat);
        }

        // ── 5. Delete Boat ───────────────────────────────────────────────────
        [HttpDelete("DeleteBoat/{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteBoat(int id)
        {
            bool isDeleted = boatService.DeleteBoat(id);

            if (!isDeleted)
                return NotFound(new { message = $"Boat with ID {id} was not found." });

            return Ok(new { message = "Boat deleted successfully." });
        }
    }
}