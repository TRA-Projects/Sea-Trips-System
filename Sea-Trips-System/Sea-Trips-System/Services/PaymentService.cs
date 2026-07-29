using Sea_Trips_System.DTOs;
using Sea_Trips_System.Services;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Sea_Trips_System.Models
{
    public class PaymentService
    {
        private PaymentRepo repo;
        private  AppointmentRepo appointmentRepo;
        private EmailService _emailService;

        // Dependency Injection
        public PaymentService(PaymentRepo _repo, AppointmentRepo _appointmentRepo, EmailService emailService)
        {
            repo = _repo;
            appointmentRepo = _appointmentRepo;
            _emailService = emailService;
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

            //  5.  إرسال إيصال الدفع للإيميل تلقائياً
            try
            {
                if (appointment.Client != null && !string.IsNullOrEmpty(appointment.Client.email))
                {
                    _emailService.SendPaymentReceiptEmail(
                        userEmail: appointment.Client.email,
                        userName: appointment.Client.fullName,
                        paymentId: payment.paymentId,
                        amount: payment.amountPaid,
                        paymentMethod: payment.paymentMethod,
                        appointmentId: appointment.appointmentId
                    );
                }
            }
            catch (Exception ex)
            {
                // طباعة الخطأ في حال كانت إعدادات الـ SMTP فيها مشكلة دون إيقاف السيرفر
                Console.WriteLine($"[Receipt Email Failed]: {ex.Message}");
            }

            return true;

        }

            
        

        // Refund Payment
        public bool RefundPayment(int paymentId)
        {
            return repo.RefundPayment(paymentId);
        }
    }
}