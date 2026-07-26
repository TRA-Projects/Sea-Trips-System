using System.ComponentModel.DataAnnotations;

namespace Sea_Trips_System.DTOs
{
    // Add Payment
    public class MakePaymentDto
    {
        [Required(ErrorMessage = "Payment Method is required")]
        public string PaymentMethod { get; set; }

        [Required(ErrorMessage = "Appointment Id is required")]
        public int AppointmentId { get; set; }
    }

    // Refund Payment
    public class RefundPaymentDto
    {
        [Required(ErrorMessage = "Payment Id is required")]
        public int PaymentId { get; set; }
    }

    // Response DTO
    public class PaymentResponseDto
    {
        public int PaymentId { get; set; }

        public decimal AmountPaid { get; set; }

        public string PaymentMethod { get; set; }

        public string PaymentStatus { get; set; }

        public DateTime TransactionDate { get; set; }

        public int AppointmentId { get; set; }
    }
}