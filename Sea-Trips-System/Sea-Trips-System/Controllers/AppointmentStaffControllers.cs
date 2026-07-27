using Microsoft.AspNetCore.Mvc;
using Sea_Trips_System.DTOs;
using Sea_Trips_System.Services;

namespace Sea_Trips_System.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentStaffsController : ControllerBase
    {

        //يستقبل (Service) عن طريق DI  و يحفظه لاستخدامه.
        private  AppointmentStaffServices appointmentStaffService;

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

        // 3. POST: api/AppointmentStaffs
        [HttpPost]
        public IActionResult AssignStaff([FromBody] AssignStaffDto dto)  //(FromBody): ياخذ البيانات DTOs من json body
        {
            AppointmentStaffResponseDto? result = appointmentStaffService.AssignStaff(dto);
            if (result == null)
                return BadRequest(new { message = "Unable to assign staff. Ensure the appointment and staff exist and are not already linked." });

            return Ok(result);
        }


        // 4. DELETE: api/AppointmentStaffs/5
        [HttpDelete("{id}")]
        public IActionResult RemoveAssignment(int id)
        {
            bool deleted = appointmentStaffService.RemoveStaffAssignment(id);
            if (!deleted)
                return NotFound(new { message = $"Assignment with ID {id} was not found." });

            return NoContent();
        }




    }
}
