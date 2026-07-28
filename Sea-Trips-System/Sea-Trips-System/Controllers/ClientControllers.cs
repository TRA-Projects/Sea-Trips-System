using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sea_Trips_System.DTOs;
using Sea_Trips_System.Services;

namespace Sea_Trips_System.Controllers
{
    [ApiController]
    [Route("client")]
    public class ClientController : BaseController
    {
        private readonly ClientService clientService;

        public ClientController(ClientService _clientService)
        {
            clientService = _clientService;
        }

        // POST client/register
        // عام — للجميع للتسجيل
        [HttpPost("register")]
        public IActionResult Register([FromBody] CreateClientDto dto)
        {
            ClientResponseDto created = clientService.CreateClient(dto);

            if (created == null)
                return BadRequest(new { message = "Email or phone number is already registered." });

            return Ok(created);
        }

        // POST client/login
        // عام — تسجيل الدخول
        [HttpPost("login")]
        public IActionResult Login([FromBody] ClientLoginDto dto)
        {
            ClientResponseDto result = clientService.Login(dto);

            if (result == null)
                return Unauthorized(new { message = "Invalid email or credentials." });

            return Ok(result);
        }

        // GET client/GetClientData/3
        // Protected — any authenticated client or admin or organaizer 
        // محمي — يتيح للعميل رؤية بياناته، أو للمشرف/مقدم الرحلات الإطلاع عليها
        [HttpGet("GetClientData/{id}")]
        [Authorize(Roles = "Client,Admin,Organizer")]
        public IActionResult GetClientData(int id)
        {
            ClientResponseDto client = clientService.GetById(id);

            if (client == null)
                return NotFound(new { message = $"Client with ID {id} was not found." });

            return Ok(client);
        }

        // PUT client/UpdateClientData/3
        // Protected — any authenticated client or admin
        // محمي — التعديل خاص بالعميل نفسه أو Admin النظام
        [HttpPut("UpdateClientData/{id}")]
        [Authorize(Roles = "Client,Admin")]
        public IActionResult UpdateClientData(int id, [FromBody] UpdateClientDto dto)
        {
            ClientResponseDto updated = clientService.Update(id, dto);

            if (updated == null)
                return NotFound(new { message = $"Client with ID {id} was not found." });

            return Ok(updated);
        }

        // DELETE client/DeleteClient/3
        // Protected — any authenticated client or admin
        // محمي — الحذف عادةً يكون لصلاحية الـ Admin أو العميل فقط
        [HttpDelete("DeleteClient/{id}")]
        [Authorize(Roles = "Client,Admin")]
        public IActionResult DeleteClient(int id)
        {
            bool deleted = clientService.Delete(id);

            if (!deleted)
                return NotFound(new { message = $"Client with ID {id} was not found." });

            return NoContent();
        }
    }
}