using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sea_Trips_System.DTOs;
using Sea_Trips_System.Models;

namespace Sea_Trips_System.Controllers
{
    [ApiController]
    [Route("maintenance")]
    [Authorize]
    public class MaintenanceControllers : ControllerBase
    {
        private MaintenanceService maintenanceService;


        // Dependency Injection
        public MaintenanceControllers(MaintenanceService _maintenanceService)
        {
            maintenanceService = _maintenanceService;
        }

       

        // View All Maintenance
        [AllowAnonymous]
        [HttpGet("GetAllMaintenance")]
        public IActionResult ViewAllMaintenances()
        {
            List<MaintenanceResponseDto> result =
                maintenanceService.ViewAllMaintenances();


            if (result.Count > 0)
            {
                return Ok(result); // 200 Success
            }


            return NoContent(); // 204 No Data
        }




        // Add Maintenance
        [HttpPost("AddMaintenance")]
        public IActionResult AddMaintenance(AddMaintenanceDto dto)
        {
            maintenanceService.AddMaintenance(dto);

            return Ok("Maintenance Added Successfully");
        }




        // Delete Maintenance
        [HttpDelete("DeleteMaintenance/{id}")]
        public IActionResult DeleteMaintenance(int id)
        {
            bool result = maintenanceService.DeleteMaintenance(id);


            if (result)
            {
                return Ok("Maintenance Deleted Successfully");
            }


            return NotFound("Maintenance Not Found");
        }
    }
}