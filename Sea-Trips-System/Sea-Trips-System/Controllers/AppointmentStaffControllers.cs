using Microsoft.AspNetCore.Mvc;
using Sea_Trips_System.Services;

namespace Sea_Trips_System.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentStaffsController : ControllerBase
    {
        private readonly AppointmentStaffServices appointmentStaffService;

        public AppointmentStaffsController(AppointmentStaffServices _appointmentStaffService)
        {
            appointmentStaffService = _appointmentStaffService;
        }


    }
}
