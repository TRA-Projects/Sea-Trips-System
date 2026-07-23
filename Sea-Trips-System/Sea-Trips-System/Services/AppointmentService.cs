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

        // ────*** 2. Get All Appointments ***────
        public List<AppointmentResponseDto> GetAll()
        {
            List<Appointment> appointments = appointmentRepo.GetAll();
            List<AppointmentResponseDto> responseList = new List<AppointmentResponseDto>();

            foreach (Appointment item in appointments)
            {
                responseList.Add(MapToResponseDto(item));
            }

            return responseList;
        }

        // ────*** 3. Get Appointment By ID ****────
        public AppointmentResponseDto GetById(int id)
        {
            Appointment appointment = appointmentRepo.GetById(id);
            if (appointment == null)
                return null;

            return MapToResponseDto(appointment);
        }

        // ────*** 4. Update Appointment ****────

        //استقبال البيانات الجديدة لتحديث حجز سابق، وتطبيق شروط الأمان وحساب السعر من جديد
        public AppointmentResponseDto Update(int id, UpdateAppointmentDto dto)
        {
            Appointment appointment = appointmentRepo.GetById(id);  // للتاكد من وجود حجز 
            if (appointment == null)
                return null;

            // Check boat availability ignoring current appointment ID
            // افحص توفر القارب مع استثناء الحجز الحالي

            bool isBooked = appointmentRepo.IsBoatBooked(dto.boatId, dto.startTime, dto.endTime, id);
            if (isBooked)
                return null;

            // تحديث بيانات الحجز بالقيم الجديدة: 

            appointment.startTime = dto.startTime;
            appointment.endTime = dto.endTime;
            appointment.numberOfPeople = dto.numberOfPeople;
            appointment.bookingStatus = dto.bookingStatus;
            appointment.boatId = dto.boatId;
            appointment.tripTypeId = dto.tripTypeId;
            appointment.destinationId = dto.destinationId;
            appointment.eventId = dto.eventId;

            // Recalculate price(إعادة حساب السعر الإجمالي)
            double hours = (dto.endTime - dto.startTime).TotalHours;
            appointment.totalPrice = (decimal)(hours * dto.numberOfPeople * 5);

            // 1. حفظ التعديلات في قاعدة البيانات
            appointmentRepo.Update();

            // 2. بالتفاصيل DB ارجع اجيبه من
            Appointment updatedAppointment = appointmentRepo.GetById(id);

            // 3.   وإرجاعه DTOتحويله لـ  
            return MapToResponseDto(updatedAppointment);
        }

    }
}
