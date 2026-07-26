using Microsoft.EntityFrameworkCore;

namespace Sea_Trips_System.Models
{
    public class PaymentRepo
    {
        private SeaTripsContext context;

        // Dependency Injection
        public PaymentRepo(SeaTripsContext _context)
        {
            context = _context;
        }

        // View All Payments
        public List<Payment> GetAllPayment()
        {
            return context.Payments.ToList();
        }

        // Make Payment
        public void AddPayment(Payment payment)
        {
            context.Payments.Add(payment);
            context.SaveChanges();
        }

        // Get Payment By Id
        public Payment GetPaymentById(int paymentId)
        {
            return context.Payments
                          .FirstOrDefault(p => p.paymentId == paymentId);
        }

        // Refund Payment
        public bool RefundPayment(int paymentId)
        {
            Payment payment = context.Payments
                                     .FirstOrDefault(p => p.paymentId == paymentId);

            if (payment == null)
            {
                return false;
            }

            payment.paymentStatus = "Refunded";

            context.SaveChanges();

            return true;
        }
    }
}