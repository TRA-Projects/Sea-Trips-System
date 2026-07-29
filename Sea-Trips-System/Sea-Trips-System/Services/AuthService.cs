using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Sea_Trips_System.Models;
using Sea_Trips_System.Services;

namespace Sea_Trips_System.Services
{
    public class AuthService
    {
        private readonly IConfiguration _config;
        private readonly EmailService _emailService; // 👈 إضافة خدمة الإيميل

        // Dependency Injection
        public AuthService(IConfiguration config, EmailService emailService)
        {
            _config = config;
            _emailService = emailService;
        }

        // ── 1. توليد التوكن (JWT Token) ───────────────────────────────────
        public string GenerateToken(int userId, string email, string role)
        {
            string secretKey = _config["JwtSettings:SecretKey"];
            string issuer = _config["JwtSettings:Issuer"];
            string audience = _config["JwtSettings:Audience"];
            int hours = int.Parse(_config["JwtSettings:ExpiryHours"] ?? "2"); // افتراضي 2 ساعة لو لم يحدد

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            Claim[] claims =
            {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Role, role), // للتحقق من الأدوار [Authorize(Roles = "...")]
            };

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(hours),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        // ── 2. دالة إرسال إيميل الترحيب بعد نجاح التسجيل ────────────────
        public void SendWelcomeEmailAfterRegister(string email, string fullName)
        {
            try
            {
                _emailService.SendWelcomeEmail(email, fullName);
            }
            catch (Exception ex)
            {
                // طباعة خطأ الإيميل في الـ Console في حال عدم صحة إعدادات SMTP دون أن يتوقف السيرفر
                Console.WriteLine($"[Email Exception]: {ex.Message}");
            }
        }

        // ── إرسال إيميل تنبيه عند تسجيل الدخول ────────────────
        public void SendLoginEmailNotification(string email, string fullName)
        {
            try
            {
                _emailService.SendLoginNotificationEmail(email, fullName);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Login Email Exception]: {ex.Message}");
            }
        }
    }
}