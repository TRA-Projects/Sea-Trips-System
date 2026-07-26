using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sea_Trips_System.DTOs;
using Sea_Trips_System.Models;

namespace Sea_Trips_System.Controllers
{
    [ApiController]
    [Route("payment")]
    [Authorize]
    public class PaymentControllers : ControllerBase
    {
        private PaymentService paymentService;

        // Dependency Injection
        public PaymentControllers(PaymentService _paymentService)
        {
            paymentService = _paymentService;
        }

        // View All Payments
        [AllowAnonymous]
        [HttpGet("GetAllPayment")]
        public IActionResult ViewAllPayments()
        {
            List<PaymentResponseDto> result = paymentService.ViewAllPayments();

            if (result.Count > 0)
            {
                return Ok(result);   // 200 OK
            }

            return NoContent();      // 204 No Content
        }

        // Make Payment
        [HttpPost("MakePayment")]
        public IActionResult MakePayment([FromBody] MakePaymentDto dto)
        {
            paymentService.MakePayment(dto);

            return Ok("Payment Added Successfully");
        }

        // Refund Payment
        [HttpPut("RefundPayment/{id}")]
        public IActionResult RefundPayment(int id)
        {
            bool result = paymentService.RefundPayment(id);

            if (result)
            {
                return Ok("Payment Refunded Successfully");
            }

            return NotFound("Payment Not Found");
        }
    }
}