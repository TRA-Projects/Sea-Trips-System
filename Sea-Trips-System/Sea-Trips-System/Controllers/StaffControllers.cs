using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sea_Trips_System.DTOs; // تأكد من استدعاء مجلد DTOs الصحيح
using Sea_Trips_System.Models;
using Sea_Trips_System.Services;
using System.Collections.Generic;
using static Sea_Trips_System.Models.StaffDTOs;

namespace Sea_Trips_System.Controllers // تصحيح الـ Namespace إلى Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin,Organizer")]               // ◄◄ تقييد الوصول لإدارة الموظفين للإدارة والمشرفين فقط
    public class StaffsController : BaseController
    {
        private readonly StaffService staffService;

        public StaffsController(StaffService _staffService)
        {
            staffService = _staffService;
        }

        // 1. GET: api/Staffs
        [HttpGet]
        public IActionResult GetAll()
        {
            List<StaffResponseDto> result = staffService.GetAll();
            return Ok(result); // OK 200
        }

        // 2. GET: api/Staffs/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            StaffResponseDto? result = staffService.GetById(id);

            if (result == null)
                return NotFound(new { message = $"Staff with ID {id} was not found." }); // 404 NotFound

            return Ok(result); // 200 OK
        }

        // 3. POST: api/Staffs
        [HttpPost]
        public IActionResult Create([FromBody] CreateStaffDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            StaffResponseDto created = staffService.Create(dto);

            if (created == null)
                return BadRequest(new { message = "Failed to create staff member. Phone or details might already exist." });

            // يرجع كود 201 Created مع الرابط للحصول على الموظف المضاف
            return CreatedAtAction(nameof(GetById), new { id = created.staffId }, created);
        }

        // 4. PUT: api/Staffs/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateStaffDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            StaffResponseDto? updated = staffService.Update(id, dto);

            if (updated == null)
                return NotFound(new { message = $"Staff with ID {id} was not found." }); // 404 NotFound

            return Ok(updated); // 200 OK
        }

        // 5. DELETE: api/Staffs/5
        [Authorize(Roles = "Admin")]                  // ◄◄ حصر صلاحية حذف الموظف بـ Admin النظام فقط
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool deleted = staffService.Delete(id);
            if (!deleted)
                return NotFound(new { message = $"Staff with ID {id} was not found." });

            return NoContent(); // 204 No Content
        }
    }
}