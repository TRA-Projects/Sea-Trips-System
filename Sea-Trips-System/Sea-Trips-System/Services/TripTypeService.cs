using Sea_Trips_System.DTOs;
using Sea_Trips_System.Models;
using Sea_Trips_System.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Sea_Trips_System.Services
{
    public class TripTypeService
    {
        private readonly BoatRepo boatRepo;
        private readonly TripTypeRepo tripRepo;

        public TripTypeService(BoatRepo _boatRepo, TripTypeRepo _tripRepo)
        {
            this.boatRepo = _boatRepo;
            this.tripRepo = _tripRepo;
        }

        // 1. Get All
        public List<TripResponseDto> GetAll()
        {
            return tripRepo.GetAll()
                       .Select(tripType => new TripResponseDto
                       {
                           tripTypeId = tripType.tripTypeId,
                           typeName = tripType.typeName,
                           basePrice = tripType.basePrice,
                           description = tripType.description
                       })
                       .ToList();
        }

        // 2. Get By Id
        public TripTypeDetailsDTO GetById(int id)
        {
            TripType tripType = tripRepo.GetById(id);

            if (tripType == null)
                return null;

            return new TripTypeDetailsDTO
            {
                tripTypeId = tripType.tripTypeId,
                typeName = tripType.typeName,
                basePrice = tripType.basePrice,
                description = tripType.description,
                appointmentCount = tripType.Appointments?.Count ?? 0 // حماية ضد الـ null
            };
        }

        // 3. Add / Create Trip
        public TripResponseDto CreateTrip(CreateTripDto dto)
        {
            // 1. جلب بيانات القارب
            Boat boat = boatRepo.GetById(dto.boatId);

            // 2. التحقق من وجود القارب ومن أنه متاح للحجز (Available)
            if (boat == null || boat.status != "Available")
            {
                return null; // لا يمكن الحجز لأن القارب محجوز مسبقاً أو غير موجود
            }

            // 3. إنشاء نوع الرحلة وحفظه
            TripType tripType = new TripType
            {
                typeName = dto.typeName,
                basePrice = dto.basePrice,
                description = dto.description
            };

            tripRepo.Add(tripType);

            // 4. تغيير حالة القارب إلى محجوز (Booked) وحفظها في قاعدة البيانات
            boat.status = "Booked";
            boatRepo.Update();

            // 5. إرجاع النتيجة
            return new TripResponseDto
            {
                tripTypeId = tripType.tripTypeId,
                typeName = tripType.typeName,
                basePrice = tripType.basePrice,
                description = tripType.description,
                status = "Confirmed"
            };
        }

        // 4. Update
        public bool Update(int id, CreateTripDto dto)
        {
            // تصحيح: استخدام tripRepo بدلاً من repo
            TripType tripType = tripRepo.GetById(id);

            if (tripType == null)
                return false;

            tripType.typeName = dto.typeName;
            tripType.basePrice = dto.basePrice;
            tripType.description = dto.description;

            // تصحيح: يمرر الكائن tripType للدالة
            tripRepo.Update();

            return true;
        }

        // 5. Delete
        public bool Delete(int id)
        {
            // تصحيح: استخدام tripRepo بدلاً من repo
            TripType tripType = tripRepo.GetById(id);

            if (tripType == null)
                return false;

            tripRepo.Delete(tripType);

            return true;
        }
    }
}