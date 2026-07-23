using static Sea_Trips_System.Models.CreateAppointmentDto;

namespace Sea_Trips_System.Models
{
    public class AppointmentService
    {
        private AppointmentRepo appointmentRepo;

        public AppointmentService(AppointmentRepo _appointmentRepo)
        {
            appointmentRepo = _appointmentRepo;
        }


        // ────*** 1. Create Appointment *** ────
        public AppointmentResponseDto Create(CreateAppointmentDto dto)
        {
            // Business rule: Check valid time interval
            if (dto.startTime >= dto.endTime)
                return null;

            // Business rule: Check boat availability
            bool isBooked = appointmentRepo.IsBoatBooked(dto.boatId, dto.startTime, dto.endTime);
            if (isBooked)
                return null;

            // Map DTO to Model
            Appointment appointment = new Appointment();
            appointment.startTime = dto.startTime;
            appointment.endTime = dto.endTime;
            appointment.numberOfPeople = dto.numberOfPeople;
            appointment.clientId = dto.clientId;
            appointment.boatId = dto.boatId;
            appointment.tripTypeId = dto.tripTypeId;
            appointment.destinationId = dto.destinationId;
            appointment.eventId = dto.eventId;
            appointment.bookingStatus = "Pending";

            // Calculate Total Price (Duration in hours * Number of People * Rate)
            double hours = (dto.endTime - dto.startTime).TotalHours;
            appointment.totalPrice = (decimal)(hours * dto.numberOfPeople * 5);


            // Save via Repo
            appointmentRepo.Add(appointment);

            // Fetch created model with navigation props and return DTO
            Appointment savedAppointment = appointmentRepo.GetById(appointment.appointmentId);
            return MapToResponseDto(savedAppointment);
        }


    }
