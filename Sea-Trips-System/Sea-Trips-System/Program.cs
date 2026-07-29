using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Sea_Trips_System.Models;
using Sea_Trips_System.Repositories;
using Sea_Trips_System.Services;
using System.Security.Claims;
using System.Text;

namespace Sea_Trips_System
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // 1. DbContext Configuration
            builder.Services.AddDbContext<SeaTripsContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // 2. Register Repositories
            builder.Services.AddScoped<AppointmentRepo>();
            builder.Services.AddScoped<AppointmentStaffRepo>();
            builder.Services.AddScoped<ClientRepo>();
            builder.Services.AddScoped<StaffRepo>();
            builder.Services.AddScoped<TripTypeRepo>();
            builder.Services.AddScoped<BoatRepo>();
            builder.Services.AddScoped<DestinationRepo>();
            builder.Services.AddScoped<ReviewRepo>();
            builder.Services.AddScoped<MaintenanceRepo>();
            builder.Services.AddScoped<PaymentRepo>();

            // 3. Register Services
            builder.Services.AddScoped<AppointmentService>();
            builder.Services.AddScoped<AppointmentStaffServices>();
            builder.Services.AddScoped<ClientService>();
            builder.Services.AddScoped<StaffService>();
            builder.Services.AddScoped<BoatService>();
            builder.Services.AddScoped<DestinationService>();
            builder.Services.AddScoped<ReviewService>();
            builder.Services.AddScoped<TripTypeService>();
            builder.Services.AddScoped<MaintenanceService>();
            builder.Services.AddScoped<PaymentService>();

            // 4. Email Service
            builder.Services.AddScoped<EmailService>();

            // ── JWT Authentication ─────────────────────────────────────────────
            builder.Services.AddScoped<AuthService>();

            var jwtKey = builder.Configuration["JwtSettings:SecretKey"] ?? "DefaultFallbackSecretKeyIfNull123456789!";
            var jwtIssuer = builder.Configuration["JwtSettings:Issuer"];
            var jwtAudience = builder.Configuration["JwtSettings:Audience"];

            builder.Services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtIssuer,
                        ValidAudience = jwtAudience,
                        RoleClaimType = ClaimTypes.Role,
                        NameClaimType = ClaimTypes.Name,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(jwtKey))
                    };

                    options.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = context =>
                        {
                            var error = context.Exception.Message;
                            return Task.CompletedTask;
                        },
                        OnTokenValidated = context =>
                        {
                            var claims = context.Principal.Claims.ToList();
                            return Task.CompletedTask;
                        },
                        OnChallenge = context =>
                        {
                            var error = context.Error;
                            var desc = context.ErrorDescription;
                            return Task.CompletedTask;
                        }
                    };
                });

            builder.Services.AddAuthorization();
            // ── end JWT Authentication ─────────────────────────────────────────────

            builder.Services.AddControllers();

            // ── Swagger with JWT support ───────────────────────────────────────
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter your JWT token in the box below"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id   = "Bearer"
                            }
                        },
                        new List<string>()
                    }
                });
            });

            // 🛠️ معالجة الأخطاء أثناء بناء الخدمة
            WebApplication app;
            try
            {
                app = builder.Build();
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n========================================");
                Console.WriteLine($"[CRASH ERROR]: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"[DETAILS]: {ex.InnerException.Message}");
                }
                Console.WriteLine("========================================\n");
                Console.WriteLine("Press ENTER to exit...");
                Console.ReadLine();
                return;
            }

            // Configure the HTTP request pipeline / middleware pipeline
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            // JWT Middlewares
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            // Run Application
            app.Run();
        }
    }
}