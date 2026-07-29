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
        private  ClientService clientService;
        private  AuthService _authService;

        public ClientController(ClientService _clientService, AuthService authService)
        {
            clientService = _clientService;
            _authService = authService;
        }

        // POST client/register
        // عام — للجميع للتسجيل
        [HttpPost("register")]
        public IActionResult Register([FromBody] CreateClientDto dto)
        {
            ClientResponseDto created = clientService.CreateClient(dto);

            if (created == null)
                return BadRequest(new { message = "Email or phone number is already registered." });

            //  استدعاء إرسال إيميل الترحيب هنا فور نجاح عملية إنشاء الحساب
            _authService.SendWelcomeEmailAfterRegister(created.email, created.fullName);

            return Ok(created);
        }

        // POST client/login
        // عام — تسجيل الدخول
        [HttpPost("login")]
        public IActionResult Login([FromBody] ClientLoginDto dto)
        {
            // 1. استخدام دالة Login المكتوبة في ClientService
            ClientResponseDto client = clientService.Login(dto);

            if (client == null)
                return Unauthorized(new { message = "Invalid email or password" });


            _authService.SendLoginEmailNotification(client.email, client.fullName);
            // 2. توليد الـ JWT Token 
            // تنبيه: لاحظي الأحرف الصغيرة (clientId, email) حسب تعريف الـ DTO لديكِ
            var token = _authService.GenerateToken(client.clientId, client.email, "Admin");
            // 3. إرجاع التوكن وبيانات العميل
            return Ok(new
            {
                token = token,
                clientId = client.clientId,
                fullName = client.fullName,
                email = client.email
            });
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