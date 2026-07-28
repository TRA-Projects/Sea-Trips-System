using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sea_Trips_System.DTOs;
using Sea_Trips_System.Services;
using System.Collections.Generic;

namespace Sea_Trips_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TripTypeController : BaseController
    {
        private readonly TripTypeService tripTypeService;

        public TripTypeController(TripTypeService _tripTypeService)
        {
            tripTypeService = _tripTypeService;
        }

        // ── 1. Get All Trip Types ────────────────────────────────────────────
        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAllTripTypes()
        {
            List<TripResponseDto> result = tripTypeService.GetAll();

            if (result == null || result.Count == 0)
                return NoContent();

            return Ok(result);
        }

        // ── 2. Get Trip Type By Id ──────────────────────────────────────────
        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult GetTripTypeById(int id)
        {
            // تم تعديل الاستدعاء بحرف صغير tripTypeService ليتوافق مع الـ Field
            TripResponseDto tripType = tripTypeService.GetById(id);

            if (tripType == null)
                return NotFound(new { message = $"Trip type with ID {id} was not found." });

            return Ok(tripType);
        }

        // ── 3. Add Trip Type ────────────────────────────────────────────────
        [Authorize(Roles = "Admin,Organizer")]
        [HttpPost]
        public IActionResult AddTripType([FromBody] CreateTripDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // تم تعديل الاستدعاء لاستخدام tripTypeService بحرف صغير
            int id = tripTypeService.Create(dto);

            if (id <= 0)
                return BadRequest(new { message = "Failed to create trip type. Check boat availability." });

            return CreatedAtAction(nameof(GetTripTypeById), new { id = id }, new { TripTypeId = id });
        }

        // ── 4. Update Trip Type ─────────────────────────────────────────────
        [Authorize(Roles = "Admin,Organizer")]
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] CreateTripDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            bool updated = tripTypeService.Update(id, dto);

            if (!updated)
                return NotFound(new { message = $"Trip type with ID {id} was not found." });

            return Ok(new { message = "Trip type updated successfully." });
        }

        // ── 5. Delete Trip Type ─────────────────────────────────────────────
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool deleted = tripTypeService.Delete(id);

            if (!deleted)
                return NotFound(new { message = $"Trip type with ID {id} was not found." });

            return Ok(new { message = "Trip type deleted successfully." });
        }
    }
}