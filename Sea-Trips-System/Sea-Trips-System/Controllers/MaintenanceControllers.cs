using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sea_Trips_System.DTOs;
using Sea_Trips_System.Models;
using Sea_Trips_System.Services; 
using System.Collections.Generic;

namespace Sea_Trips_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")] 
    [Authorize]
    public class MaintenanceController : ControllerBase 
    {
        private readonly MaintenanceService maintenanceService;

        // Dependency Injection
        public MaintenanceController(MaintenanceService _maintenanceService)
        {
            maintenanceService = _maintenanceService;
        }

        // ──  View All Maintenance ──────────────────────────────────────────
       
        [HttpGet]
        [Authorize(Roles = "Admin,Organizer,Staff")]
        public IActionResult ViewAllMaintenances()
        {
            List<MaintenanceResponseDto> result = maintenanceService.ViewAllMaintenances();

            if (result == null || result.Count == 0)
            {
                return NoContent(); // 204 No Data
            }

            return Ok(result); // 200 Success
        }

        // ── 2 Add Maintenance ───────────────────────────────────────────────
        [HttpPost]
        [Authorize(Roles = "Admin,Staff")] 
        public IActionResult AddMaintenance([FromBody] AddMaintenanceDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            maintenanceService.AddMaintenance(dto);

            return Ok(new { message = "Maintenance record added successfully." });
        }

        // ── 3 Delete Maintenance ────────────────────────────────────────────
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")] 
        public IActionResult DeleteMaintenance(int id)
        {
            bool result = maintenanceService.DeleteMaintenance(id);

            if (result)
            {
                return Ok(new { message = "Maintenance record deleted successfully." });
            }

            return NotFound(new { message = $"Maintenance record with ID {id} was not found." });
        }
    }
}