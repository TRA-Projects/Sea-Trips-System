using Sea_Trips_System.DTOs;

namespace Sea_Trips_System.Models
{
    public class PaymentService
    {
        private PaymentRepo repo;
        private  AppointmentRepo appointmentRepo;

        // Dependency Injection
        public PaymentService(PaymentRepo _repo, AppointmentRepo _appointmentRepo)
        {
            repo = _repo;
            appointmentRepo = _appointmentRepo;
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
        public bool MakePayment(MakePaymentDto dto)
        {
            // 1. التحقق من وجود الحجز في قاعدة البيانات
            Appointment appointment = appointmentRepo.GetById(dto.AppointmentId);
            if (appointment == null)
            {
                return false; 
            }

            Payment payment = new Payment
            {
                paymentMethod = dto.PaymentMethod,
                appointmentId = dto.AppointmentId,
                amountPaid = appointment.totalPrice, 
                paymentStatus = "Paid",
                transactionDate = DateTime.Now
            };

            // 3. حفظ عملية الدفع
            repo.AddPayment(payment);

            // 4. تحديث حالة الحجز إلى "Confirmed"
            appointment.bookingStatus = "Confirmed";
            appointmentRepo.Update(appointment);

            return true;
        }

        // Refund Payment
        public bool RefundPayment(int paymentId)
        {
            return repo.RefundPayment(paymentId);
        }
    }
}