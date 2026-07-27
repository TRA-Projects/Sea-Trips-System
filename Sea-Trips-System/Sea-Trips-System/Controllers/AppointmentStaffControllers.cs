using Microsoft.AspNetCore.Mvc;
using Sea_Trips_System.DTOs;
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


        // 1. GET: api/AppointmentStaffs

        [HttpGet]
        public IActionResult GetAll()
        {
            List<AppointmentStaffResponseDto> result = appointmentStaffService.GetAll();
            return Ok(result);
        }


        // 2. GET: api/AppointmentStaffs/appointment/5
        [HttpGet("appointment/{appointmentId}")]
        public IActionResult GetByAppointmentId(int appointmentId)
        {
            List<AppointmentStaffResponseDto> result = appointmentStaffService.GetByAppointmentId(appointmentId);
            return Ok(result);
        }


    }
}
