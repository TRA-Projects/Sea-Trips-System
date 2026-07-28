using static Sea_Trips_System.Models.CreateAppointmentDto;

namespace Sea_Trips_System.Models
{
    public class AppointmentService
    {
        private AppointmentRepo appointmentRepo;
        private TripTypeRepo tripTypeRepo;

        public AppointmentService(AppointmentRepo _appointmentRepo, TripTypeRepo _tripTypeRepo)
 
        {
            appointmentRepo = _appointmentRepo;
            tripTypeRepo = _tripTypeRepo;
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

            // 🔍 جلب سعر الرحلة من قاعدة البيانات حسب النوع المحدد
            TripType? trip = tripTypeRepo.GetById(dto.tripTypeId);
            if (trip == null)
                return null;



            // Map DTO to Model
            Appointment appointment = new Appointment();
            appointment.startTime = dto.startTime;
            appointment.endTime = dto.endTime;
            appointment.numberOfPeople = dto.numberOfPeople;
            appointment.boatId = dto.boatId;
            appointment.tripTypeId = dto.tripTypeId;
            appointment.destinationId = dto.destinationId;
            appointment.bookingStatus = "Pending";

            //TripType trips = tripTypeRepo.GetById(dto.tripTypeId);
              
            // Calculate Total Price (Duration in hours * Number of People * Rate)
            double hours = (dto.endTime - dto.startTime).TotalHours;
            appointment.totalPrice = (decimal)(hours * dto.numberOfPeople * Convert.ToDouble( trip.basePrice));


            // Save via Repo
            appointmentRepo.Add(appointment);

            // Fetch created model with navigation props and return DTO
            Appointment? savedAppointment = appointmentRepo.GetById(appointment.appointmentId);
            return savedAppointment != null ? MapToResponseDto(savedAppointment) : null;
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
            Appointment? appointment = appointmentRepo.GetById(id);
            if (appointment == null)
                return null;

            return MapToResponseDto(appointment);
        }

        // ────*** 4. Update Appointment ****────

        //استقبال البيانات الجديدة لتحديث حجز سابق، وتطبيق شروط الأمان وحساب السعر من جديد
        public AppointmentResponseDto? Update(int id, UpdateAppointmentDto dto)
        {
            Appointment? appointment = appointmentRepo.GetById(id);  // للتاكد من وجود حجز 
            if (appointment == null)
                return null;

            // افحص توفر القارب مع استثناء الحجز الحالي

            bool isBooked = appointmentRepo.IsBoatBooked(dto.boatId, dto.startTime, dto.endTime, id);
            if (isBooked)
                return null;


            TripType? trip = tripTypeRepo.GetById(dto.tripTypeId);
            if (trip == null)
                return null;
            // تحديث بيانات الحجز بالقيم الجديدة: 

            appointment.startTime = dto.startTime;
            appointment.endTime = dto.endTime;
            appointment.numberOfPeople = dto.numberOfPeople;
            appointment.bookingStatus = dto.bookingStatus;
            appointment.boatId = dto.boatId;
            appointment.tripTypeId = dto.tripTypeId;
            appointment.destinationId = dto.destinationId;

            // Recalculate price(إعادة حساب السعر الإجمالي)
            double hours = (dto.endTime - dto.startTime).TotalHours;
            appointment.totalPrice = (decimal)(hours * dto.numberOfPeople * Convert.ToDouble(trip.basePrice));

            // 1. حفظ التعديلات في قاعدة البيانات
            appointmentRepo.Update(appointment);

            // 2. تجديد البيانات بالتفاصيل وإرجاع الـ DTO
            Appointment? updatedAppointment = appointmentRepo.GetById(id);
            return updatedAppointment != null ? MapToResponseDto(updatedAppointment) : null;
        }

        // ────*** 5. Delete Appointment ****────
        public bool Delete(int id)
        {
            Appointment? appointment = appointmentRepo.GetById(id);
            if (appointment == null)
                return false;

            appointmentRepo.Delete(appointment);
            return true;
        }

        // ────*** 6. Confirm appointment ****────

        // دالة تأكيد الحجز وتغيير حالته بعد الدفع
        public bool ConfirmAppointment(int appointmentId)
        {
            Appointment? appointment = appointmentRepo.GetById(appointmentId);

            if (appointment == null)
                return false;

            appointment.bookingStatus = "Confirmed"; 
            appointmentRepo.Update(appointment);

            return true;
        }

        // ────*** Helper Function: Map Model to Response DTO ****────

        //وظيفتها تحويل كائن قاعدة البيانات الأصلي (Appointment) إلى كائن للعرض
        //(AppointmentResponseDto) لضمان تنظيف البيانات وحمايتها قبل إرسالها للواجهة.

        private AppointmentResponseDto MapToResponseDto(Appointment a)
        {
            return new AppointmentResponseDto
            {
                appointmentId = a.appointmentId,
                startTime = a.startTime,
                endTime = a.endTime,
                bookingStatus = a.bookingStatus,
                totalPrice = a.totalPrice,
                numberOfPeople = a.numberOfPeople,


                clientId = a.clientId,
                clientName = a.Client != null ? a.Client.fullName : "Not Available",  //Ternary Operator

                boatId = a.boatId,
                boatName = a.Boat != null ? a.Boat.boatName : "Not Available", //Ternary Operator

                tripTypeId = a.tripTypeId,
                tripTypeName = a.TripType != null ? a.TripType.typeName : "Not Available",  //Ternary Operator

                destinationId = a.destinationId,
                destinationName = a.Destination != null ? a.Destination.name : "Not Available",  //Ternary Operator

         
            };
        }
    }
}
