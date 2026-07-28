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

        // 1. Get All - جلب جميع أنواع الرحلات
        public List<TripResponseDto> GetAll()
        {
            List<TripType> tripTypes = tripRepo.GetAll();
            if (tripTypes == null)
                return new List<TripResponseDto>();

            return tripTypes.Select(tripType => new TripResponseDto
            {
                tripTypeId = tripType.tripTypeId,
                typeName = tripType.typeName,
                basePrice = tripType.basePrice,
                description = tripType.description
            }).ToList();
        }

        // 2. Get By Id - جلب تفاصيل نوع رحلة بواسطة الـ ID
        public TripTypeAllOutputDTO GetById(int id)
        {
            TripType tripType = tripRepo.GetById(id);

            if (tripType == null)
                return null;

            return new TripTypeAllOutputDTO
            {
                tripTypeId = tripType.tripTypeId,
                typeName = tripType.typeName,
                basePrice = tripType.basePrice,
                description = tripType.description,
              
            };
        }

        // 3. Add / Create TripType - إنشاء رحلة وتحديث حالة القارب وحساب السعر
        public TripResponseDto CreateTrip(CreateTripDto dto)
        {
            // 1. جلب بيانات القارب للتحقق من وجوده وحالته
            Boat boat = boatRepo.GetById(dto.boatId);

            // 2. التحقق من وجود القارب ومن أنه متاح للحجز (Available)
            if (boat == null || boat.status != "Available")
            {
                return null; // لا يمكن الحجز لأن القارب محجوز مسبقاً أو غير موجود
            }

            // 3. حساب السعر الإجمالي (السعر الأساسي + سعر القارب بالساعة * عدد الساعات)
            decimal calculatedPrice = dto.basePrice + (boat.hourlyRate * (decimal)dto.hours);

            // 4. إنشاء نوع الرحلة الجديد وحفظه
            TripType tripType = new TripType
            {
                typeName = dto.typeName,
                basePrice = dto.basePrice,
                description = dto.description
            };

            tripRepo.Add(tripType);

            // 5. تغيير حالة القارب إلى محجوز (Booked) وحفظ التعديل
            boat.status = "Booked";
            boatRepo.Update();

            // 6. إرجاع النتيجة متضمنة السعر المحسوب
            return new TripResponseDto
            {
                tripTypeId = tripType.tripTypeId,
                typeName = tripType.typeName,
                basePrice = tripType.basePrice,
                description = tripType.description,
                price = calculatedPrice, // ◄◄ السعر النهائي المحسوب
                status = "Confirmed"
            };
        }

        // 4. Update - تعديل نوع رحلة موجود
        public bool Update(int id, CreateTripDto dto)
        {
            TripType tripType = tripRepo.GetById(id);

            if (tripType == null)
                return false;

            tripType.typeName = dto.typeName;
            tripType.basePrice = dto.basePrice;
            tripType.description = dto.description;

            tripRepo.Update();

            return true;
        }

        // 5. Delete - حذف نوع رحلة
        public bool Delete(int id)
        {
            TripType tripType = tripRepo.GetById(id);

            if (tripType == null)
                return false;

            tripRepo.Delete(tripType);

            return true;
        }
    }
}