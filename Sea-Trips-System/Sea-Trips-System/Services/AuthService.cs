using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Sea_Trips_System.Services
{
    public class AuthService
    {
        private readonly IConfiguration config;

        public AuthService(IConfiguration _config)
        {
            config = _config;
        }

        // ── 1. توليد التوكن باستخدام البيانات المباشرة (ممتاز للـ DTOs) ──────────────
        public string GenerateToken(int userId, string email, string role)
        {
            string secretKey = config["JwtSettings:SecretKey"];
            string issuer = config["JwtSettings:Issuer"];
            string audience = config["JwtSettings:Audience"];
            int hours = int.Parse(config["JwtSettings:ExpiryHours"] ?? "2"); // افتراضي 2 ساعة لو لم يحدد

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            Claim[] claims =
            {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Role, role), // مهم جداً للتحقق من الأدوار [Authorize(Roles = "...")]
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
    }
}