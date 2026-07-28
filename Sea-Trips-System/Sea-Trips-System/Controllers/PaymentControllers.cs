using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sea_Trips_System.DTOs;
using Sea_Trips_System.Models;
using Sea_Trips_System.Services;
using System.Collections.Generic;
using System.Security.Claims;

namespace Sea_Trips_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")] 
    [Authorize]
    public class PaymentController : BaseController
    {
        private readonly PaymentService paymentService;

        // Dependency Injection
        public PaymentController(PaymentService _paymentService)
        {
            paymentService = _paymentService;
        }

        // ── 1. View All Payments ─────────────────────────────────────────────
        
        [HttpGet]
        [Authorize(Roles = "Admin,Staff")]
        public IActionResult ViewAllPayments()
        {
            List<PaymentResponseDto> result = paymentService.ViewAllPayments();

            if (result == null || result.Count == 0)
            {
                return NoContent(); // 204 No Content
            }

            return Ok(result); // 200 OK
        }

        // ── 2. Make Payment ──────────────────────────────────────────────────
       
        [HttpPost]
        public IActionResult MakePayment([FromBody] MakePaymentDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            
            var userIdClaim = User.FindFirst("userId")?.Value ?? User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            paymentService.MakePayment(dto);

            return Ok(new { message = "Payment added successfully." });
        }

        // ── 3. Refund Payment ────────────────────────────────────────────────
        
        [HttpPut("refund/{id}")]
        [Authorize(Roles = "Admin,Staff")]
        public IActionResult RefundPayment(int id)
        {
            bool result = paymentService.RefundPayment(id);

            if (result)
            {
                return Ok(new { message = "Payment refunded successfully." });
            }

            return NotFound(new { message = $"Payment record with ID {id} was not found." });
        }
    }
}