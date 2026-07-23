using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sea_Trips_System.DTOs;
using Sea_Trips_System.Models;
using Sea_Trips_System.Services;

namespace Sea_Trips_System.Models
{
    [ApiController]
    [Route("maintenance")]
    [Authorize]
    public class MaintenanceControllers : ControllerBase
    {
        private MaintenanceService maintenanceService;
        public MaintenanceControllers(MaintenanceService _maintenanceService) //dependency injection
        {
            maintenanceService = _maintenanceService;
        }

        [AllowAnonymous]
        [HttpGet("GetAllMaintenance")]
        public IActionResult GetAllMaintenance()
        {
            List<MaintenanceAllOutputDTO> result = maintenanceService.GetAllMaintenance();

            if (result.Count > 0)
            {
                return Ok(result); //200 sucessful
            }

            return NoContent(); //204 no data
        }
    }
}
