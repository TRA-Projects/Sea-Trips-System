using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sea_Trips_System.Controllers;
using static Sea_Trips_System.Models.CreateAppointmentDto;

namespace Sea_Trips_System.Models
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    //Dependency Injection
    public class AppointmentsController : BaseController
    {
            private AppointmentService appointmentService;

            public AppointmentsController(AppointmentService _appointmentService)
            {
                appointmentService = _appointmentService;
            }

            // GET: api/Appointments
            [HttpGet]
            public IActionResult GetAll()
            {
                var result = appointmentService.GetAll();
                return Ok(result);
            }

            // GET: api/Appointments/5
            [HttpGet("{id}")]
            public IActionResult GetById(int id)
            {
                var result = appointmentService.GetById(id);
                if (result == null)
                    return NotFound(new { message = $"Appointment with ID {id}  not found." });  //(Not Found 404)

                return Ok(result);
            }

            // POST: api/Appointments (اضافة)
            [HttpPost]
            public IActionResult Create([FromBody] CreateAppointmentDto dto)
            {
                //get client id from token  call authservice.getIdFromToken(extracted token from heaDER    )
                var created = appointmentService.Create(dto);
                if (created == null)
                    return BadRequest(new { message = "Failed to create appointment. Please check time validity or boat availability." });

                return Ok(created);
            }

            // PUT: api/Appointments/  (تعديل)
            [HttpPut("{id}")]
            public IActionResult Update(int id, [FromBody] UpdateAppointmentDto dto)
            {
                var updated = appointmentService.Update(id, dto);
                if (updated == null)
                    return BadRequest(new { message = "Failed to update appointment. Check data or boat availability." });

                return Ok(updated);
            }

                // POST : api/Appointments/5/confirm
                [HttpPut("{id}/confirm")]
                public IActionResult ConfirmBooking(int id)
                {
                    bool isConfirmed = appointmentService.ConfirmAppointment(id);

                    if (!isConfirmed)
                        return NotFound(new { message = $"Appointment with ID {id} was not found." });

                    return Ok(new { message = "Booking status updated to Confirmed successfully!" });
                }

            // DELETE: api/Appointments/5
            [Authorize(Roles = "Admin,Staff")]
            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
                {
                    bool deleted = appointmentService.Delete(id);
                    if (!deleted)
                        return NotFound(new { message = $"Appointment with ID {id} was not found." });

                    return NoContent();
                }
        }
    }


