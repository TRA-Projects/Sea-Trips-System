using Sea_Trips_System.DTOs;

namespace Sea_Trips_System.Models
{
    public class PaymentService
    {
        private PaymentRepo repo;

        // Dependency Injection
        public PaymentService(PaymentRepo _repo)
        {
            repo = _repo;
        }

        // View All Payments
        public List<PaymentResponseDto> ViewAllPayments()
        {
            return repo.GetAllPayment()
                       .Select(p => new PaymentResponseDto
                       {
                           PaymentId = p.paymentId,
                           AmountPaid = p.amountPaid,
                           PaymentMethod = p.paymentMethod,
                           PaymentStatus = p.paymentStatus,
                           TransactionDate = p.transactionDate,
                           AppointmentId = p.appointmentId
                       })
                       .ToList();
        }

        // Make Payment
        public void MakePayment(MakePaymentDto dto)
        {
            Payment payment = new Payment
            {
                paymentMethod = dto.PaymentMethod,
                appointmentId = dto.AppointmentId,

                amountPaid = 0,

                paymentStatus = "Paid",
                transactionDate = DateTime.Now
            };

            repo.AddPayment(payment);
        }

        // Refund Payment
        public bool RefundPayment(int paymentId)
        {
            return repo.RefundPayment(paymentId);
        }
    }
}