using Microsoft.AspNetCore.Mvc;
using Sea_Trips_System.Services;

namespace Sea_Trips_System.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentStaffControllers : ControllerBase
    {

        private readonly AppointmentStaffService appointmentStaffService;

        public AppointmentStaffsController (AppointmentStaffService _appointmentStaffService)
        {
            appointmentStaffService = _appointmentStaffService;
        }



    }
}
