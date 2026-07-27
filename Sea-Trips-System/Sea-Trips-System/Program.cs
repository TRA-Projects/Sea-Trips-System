
using Microsoft.EntityFrameworkCore;
using Sea_Trips_System.Models;
using Sea_Trips_System.Repositories;
using Sea_Trips_System.Services;

namespace Sea_Trips_System
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // 1 - register context
            builder.Services.AddDbContext<SeaTripsContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // service lifetime:
            //Repo
            builder.Services.AddScoped<AppointmentRepo>();   // Register AppointmentRepo in DI Container. 
            builder.Services.AddScoped<AppointmentStaffRepo>();  // Register AppointmentStaffRepo in DI Container. 
            builder.Services.AddScoped<ClientRepo>();         // Register ClientRepo in DI Container.
            builder.Services.AddScoped<StaffRepo>();          // Register StaffRepo in DI Container.
            builder.Services.AddScoped<TripTypeRepo>();         // Register TripTypeRepo in DI Container.
            builder.Services.AddScoped<EventRepo>();        // Register EventRepo in DI Container...
            builder.Services.AddScoped<BoatRepo>();         // Register BoatRepo in DI Container.
            builder.Services.AddScoped<DestinationRepo>(); // Register DestinationRepo in DI Container.
            builder.Services.AddScoped<ReviewRepo>();      // Register ReviewRepo in DI Container.







            //service
            builder.Services.AddScoped<AppointmentService>();           // Register AppointmentService in DI Container.
            builder.Services.AddScoped<AppointmentStaffServices>();  // Register AppointmentStaffServices in DI Container. 
            builder.Services.AddScoped<ClientService>();                // Register ClientService in DI Container.
            builder.Services.AddScoped<StaffService>();          // Register StaffRepo in DI Container.
            builder.Services.AddScoped<BoatService>();         // Register BoatService in DI Container.
            builder.Services.AddScoped<DestinationService>();   // Register DestinationService in DI Container.
            builder.Services.AddScoped<ReviewService>();        // Register ReviewService in DI Container.






            //controller
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
