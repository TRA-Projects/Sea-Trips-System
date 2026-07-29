using System;
using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;

namespace Sea_Trips_System.Services
{
    public class EmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        private SmtpClient GetSmtpClient()
        {
            return new SmtpClient(_config["EmailSettings:Host"])
            {
                Port = int.Parse(_config["EmailSettings:Port"] ?? "587"),
                Credentials = new NetworkCredential(
                    _config["EmailSettings:SenderEmail"],
                    _config["EmailSettings:Password"]
                ),
                EnableSsl = true,
            };
        }

        // 1. Send Welcome Email upon new user registration
        public void SendWelcomeEmail(string userEmail, string userName)
        {
            var mail = new MailMessage
            {
                From = new MailAddress(_config["EmailSettings:SenderEmail"]!, _config["EmailSettings:SenderName"]),
                Subject = "Welcome to Sea Trips System",
                Body = $@"
                    <div style='font-family: Arial, sans-serif; text-align: left;'>
                        <h2 style='color: #0056b3;'>Welcome, {userName}!</h2>
                        <p>Your account has been successfully created in <b>Sea Trips System</b>.</p>
                        <p><b>Registered Email:</b> {userEmail}</p>
                        <br>
                        <p>We wish you an unforgettable experience and smooth sailing with us!</p>
                    </div>",
                IsBodyHtml = true
            };
            mail.To.Add(userEmail);

            using var client = GetSmtpClient();
            client.Send(mail);
        }

        // 2. Send Login Notification Email
        public void SendLoginNotificationEmail(string userEmail, string userName)
        {
            var mail = new MailMessage
            {
                From = new MailAddress(_config["EmailSettings:SenderEmail"]!, _config["EmailSettings:SenderName"]),
                Subject = "Security Alert: New Login to Your Account",
                Body = $@"
                    <div style='font-family: Arial, sans-serif; text-align: left;'>
                        <h2 style='color: #0056b3;'>Hello, {userName}!</h2>
                        <p>We noticed a new login to your <b>Sea Trips System</b> account.</p>
                        <hr style='border: 1px solid #eee;'>
                        <p><b>Email:</b> {userEmail}</p>
                        <p><b>Time:</b> {DateTime.Now:yyyy-MM-dd HH:mm:ss}</p>
                        <hr style='border: 1px solid #eee;'>
                        <p>If this was you, you can safely ignore this email.</p>
                    </div>",
                IsBodyHtml = true
            };
            mail.To.Add(userEmail);

            using var client = GetSmtpClient();
            client.Send(mail);
        }

        // 3. Send Payment Receipt Email after successful payment
        public void SendPaymentReceiptEmail(string userEmail, string userName, int paymentId, decimal amount, string paymentMethod, int appointmentId)
        {
            var mail = new MailMessage
            {
                From = new MailAddress(_config["EmailSettings:SenderEmail"]!, _config["EmailSettings:SenderName"]),
                Subject = $"Payment Receipt #PAY-{paymentId}",
                Body = $@"
                    <div style='font-family: Arial, sans-serif; text-align: left;'>
                        <h2 style='color: #28a745;'>Thank you, {userName}!</h2>
                        <p>Your payment has been processed successfully. Here are your transaction details:</p>
                        <hr style='border: 1px solid #eee;'>
                        <ul style='list-style: none; padding: 0;'>
                            <li><b>Payment ID:</b> #{paymentId}</li>
                            <li><b>Appointment ID:</b> #{appointmentId}</li>
                            <li><b>Amount Paid:</b> ${amount}</li>
                            <li><b>Payment Method:</b> {paymentMethod}</li>
                            <li><b>Transaction Date:</b> {DateTime.Now:yyyy-MM-dd HH:mm}</li>
                        </ul>
                        <hr style='border: 1px solid #eee;'>
                        <p>Have a great trip!</p>
                    </div>",
                IsBodyHtml = true
            };
            mail.To.Add(userEmail);

            using var client = GetSmtpClient();
            client.Send(mail);
        }
    }
}