using Sea_Trips_System.DTOs;
using Sea_Trips_System.Models;
using Sea_Trips_System.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;

namespace Sea_Trips_System.Services
{
    public class TripTypeService
    {
        private  BoatRepo boatRepo;
        private  TripTypeRepo tripRepo;

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
        // ◄◄ تم تغيير نوع الإرجاع إلى TripResponseDto ليتوافق مع Controller
        public TripResponseDto GetById(int id)
        {
            TripType tripType = tripRepo.GetById(id);

            if (tripType == null)
                return null;

            return new TripResponseDto
            {
                tripTypeId = tripType.tripTypeId,
                typeName = tripType.typeName,
                basePrice = tripType.basePrice,
                description = tripType.description
            };
        }

        // 3. Create TripType - إنشاء رحلة وإرجاع الـ ID
        // ◄◄ تم تغيير اسم الدالة إلى Create ونوع الإرجاع إلى int ليتوافق مع Controller
        public int Create(CreateTripDto dto)
        {
            // 1. جلب بيانات القارب للتحقق من وجوده وحالته (في حال كان DTO يحوي boatId)
            Boat boat = boatRepo.GetById(dto.boatId);

            if (boat == null || boat.status != "Available")
            {
                return 0; // القارب غير متاح
            }

            //  تحديث حالة القارب إلى محجوز
            boat.status = "Booked";

            // 2. إنشاء نوع الرحلة الجديد وحفظه
            TripType tripType = new TripType
            {
                typeName = dto.typeName,
                basePrice = dto.basePrice,
                description = dto.description,
                boatId = dto.boatId,
                status = "Active"
            };

            tripRepo.Add(tripType);

            boatRepo.Update();

            // 4. إرجاع الـ ID الخاص بالـ TripType الجديد
            return tripType.tripTypeId;
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
            tripType.status = "Active";

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