using Microsoft.IdentityModel.Tokens;
using Sea_Trips_System.Models;
using System;
using System.Collections.Generic;
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

      public string GenerateToken(Client client)
{
    string secretKey = config["JwtSettings:SecretKey"]!;
    string issuer = config["JwtSettings:Issuer"]!;
    string audience = config["JwtSettings:Audience"]!;
    int hours = int.Parse(config["JwtSettings:ExpiryHours"]!);

    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
    var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

    // ◄◄ الـ Claims الخاصة بالمستخدم (واضحة وصريحة)
    var claims = new List<Claim>
    {
        // 1. معرف المستخدم برمز قياسي ومخصص
        new Claim("userId", client.clientId.ToString()),
        new Claim(ClaimTypes.NameIdentifier, client.clientId.ToString()),

        // 2. الدور/الصلادحية
        new Claim(ClaimTypes.Role, "Client"),
        new Claim("role", "Client"),

        // 3. البيانات الشخصية
        new Claim(ClaimTypes.Name, client.fullName ?? string.Empty),
        new Claim(ClaimTypes.Email, client.email ?? string.Empty),
        new Claim("phone", client.phone ?? string.Empty)
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