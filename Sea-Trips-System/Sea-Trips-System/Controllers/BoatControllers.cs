using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sea_Trips_System.DTOs;
using Sea_Trips_System.Services;
using System.Collections.Generic;

namespace Sea_Trips_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]         
    public class BoatController : BaseController
    {
        private readonly BoatService boatService;

        public BoatController(BoatService _boatService)
        {
            boatService = _boatService;
        }

        // ── 1. Create Boat ───────────────────────────────────────────────────
        [HttpPost]
        [Authorize(Roles = "Admin,Organizer,Staff")]
        public IActionResult CreateBoat([FromBody] CreateBoatDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            BoatResponseDto createdBoat = boatService.CreateBoat(dto);

            if (createdBoat == null)
                return BadRequest(new { message = "Boat name already exists or invalid data." });

            return CreatedAtAction(nameof(GetBoatById), new { id = createdBoat.boatId }, createdBoat);
        }

        // ── 2. Get Boat By ID ────────────────────────────────────────────────
        [HttpGet("{id}")]
        [AllowAnonymous]      // متاح للعملاء والزوار لتصفح تفاصيل القوارب
        public IActionResult GetBoatById(int id)
        {
            BoatResponseDto boat = boatService.GetBoatById(id);

            if (boat == null)
                return NotFound(new { message = $"Boat with ID {id} was not found." });

            return Ok(boat);
        }

        // ── 3. Get All Boats ─────────────────────────────────────────────────
        [HttpGet]
        [AllowAnonymous]             // متاح للعملاء والزوار لتصفح القوارب المتاحة
        public IActionResult GetAllBoats()
        {
            List<BoatResponseDto> boats = boatService.GetAllBoats();
            return Ok(boats);
        }

        // ── 4. Update Boat ───────────────────────────────────────────────────
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Organizer,Staff")]
        public IActionResult UpdateBoat(int id, [FromBody] UpdateBoatDto dto)
        {
            BoatResponseDto updatedBoat = boatService.UpdateBoat(id, dto);

            if (updatedBoat == null)
                return NotFound(new { message = $"Boat with ID {id} was not found." });

            return Ok(updatedBoat);
        }

        // ── 5. Delete Boat ───────────────────────────────────────────────────
        [HttpDelete("{id}")]
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