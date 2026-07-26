using Microsoft.AspNetCore.Mvc;

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
        }
    }
}
