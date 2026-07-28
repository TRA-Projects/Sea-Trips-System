using Microsoft.IdentityModel.Tokens;
using Sea_Trips_System.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Sea_Trips_System.Services
{
    public class AuthService
    {
        private IConfiguration config;

        public AuthService(IConfiguration _config)
        {
            config = _config;
        }

        public string GenerateToken(Client client)
        {
            string secretKey = config["JwtSettings:SecretKey"];
            string issuer = config["JwtSettings:Issuer"];
            string audience = config["JwtSettings:Audience"];
            int hours = int.Parse(config["JwtSettings:ExpiryHours"]);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // استخدام الحقول المطابقة لموديل Client الخاص بك
            Claim[] claims =
            {
                new Claim("sub",      client.fullName),
                new Claim("clientId",   client.clientId.ToString()),
                new Claim("email",    client.email),
                new Claim("phone",    client.phone),
                new Claim("role",  "Client")   // تعيين الدور افتراضياً كـ Client
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