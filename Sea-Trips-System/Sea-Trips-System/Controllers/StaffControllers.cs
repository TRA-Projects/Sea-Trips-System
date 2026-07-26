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
            public IActionResult GetAll()
            {
                List<StaffResponseDto> result = staffService.GetAll();
                return Ok(result);      // OK 200
            }


            // 2. GET: api/Staffs/5

            [HttpGet("{id}")]
            public IActionResult GetById(int id)
            {
                StaffResponseDto? result = staffService.GetById(id);

                if (result == null) //404 NotFound

                    return NotFound(new { message = $"Staff with ID {id} was not found." });

                return Ok(result);  // 200 OK
            }


            // 3. POST: api/Staffs

            [HttpPost]
            public IActionResult Create([FromBody] CreateStaffDto dto)
            {
                StaffResponseDto created = staffService.Create(dto);

                // يرجع كود 201 Created مع الرابط للحصول على الموظف المضاف
                return CreatedAtAction(nameof(GetById), new { id = created.staffId }, created);
            }


            //4. PUT: api/Staffs/5

            [HttpPut("{id}")]
            public IActionResult Update(int id, [FromBody] UpdateStaffDto dto)
            {
                StaffResponseDto? updated = staffService.Update(id, dto);

                if (updated == null)   //NotFound 404

                    return NotFound(new { message = $"Staff with ID {id} was not found." });

                return Ok(updated); // OK 200
            }



            // 5. DELETE: api/Staffs/5
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
}
