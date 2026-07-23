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


        }
}
