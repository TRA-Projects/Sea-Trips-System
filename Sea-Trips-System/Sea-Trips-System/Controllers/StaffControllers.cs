using Microsoft.AspNetCore.Mvc;
using static Sea_Trips_System.Models.StaffDTOs;

namespace Sea_Trips_System.Models
{
    public class StaffControllers
    {
        [ApiController]
        [Route("api/[controller]")]
        
        public class StaffsController : ControllerBase
        {
            private StaffService staffService;
            public StaffsController (StaffService _staffService)
            {
                staffService = _staffService;
            }


            // 1. GET: api/Staffs
            [HttpGet]
            public ActionResult GetAll()
            {
                List<StaffResponseDto> result = staffService.GetAll();
                return Ok(result);
            }




        }




    }
}
