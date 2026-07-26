using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sea_Trips_System.DTOs;
using Sea_Trips_System.Services;

namespace Sea_Trips_System.Controllers
{
    [ApiController]
    [Route("triptype")]
    [Authorize]

    public class TripTypeController : ControllerBase


    {

       private TripTypeService tripTypeService;

    public TripTypeController(TripTypeService _tripTypeService)  //dependency injection
        {
        tripTypeService = _tripTypeService;
    }


        // Get All TripType

        [AllowAnonymous]
        [HttpGet("GetAllTripTypes")]
        public IActionResult GetAllTripTypes()
        {
            List<TripTypeOutputDTO> result = tripTypeService.GetAll();

            if (result.Count == 0)
                return NoContent();

            return Ok(result);
        }


        // Get TripType By Id

        [AllowAnonymous]
        [HttpGet("GetTripTypeById/{id}")]
        public IActionResult GetTripTypeById(int id)
        {
            TripTypeDetailsDTO tripType = tripTypeService.GetById(id);

            if (tripType == null)
                return NotFound();

            return Ok(tripType);
        }


        //Add TripType

        [Authorize(Roles = "Admin")]
        [HttpPost("AddDTO")]
        public IActionResult AddDTO([FromBody] TripTypeInputDTO dto)
        {
            int id = tripTypeService.Create(dto);

            return Ok(new { TripTypeId = id });
        }

        //// Update 

        [Authorize(Roles = "Admin")]
        [HttpPut("Update/{id}")]
        public IActionResult Update(int id, [FromBody] TripTypeInputDTO dto)
        {
            bool updated = tripTypeService.Update(id, dto);

            if (!updated)
                return NotFound();

            return Ok("Updated Successfully");
        }

        //Delete

        [Authorize(Roles = "Admin")]
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            bool deleted = tripTypeService.Delete(id);

            if (!deleted)
                return NotFound();

            return Ok("Deleted Successfully");
        }
    }
}