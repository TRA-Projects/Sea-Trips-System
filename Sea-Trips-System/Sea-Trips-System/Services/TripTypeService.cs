
using Sea_Trips_System.DTOs;
using Sea_Trips_System.Models;

namespace Sea_Trips_System.Services
{
    public class TripTypeService
    {
        private readonly TripTypeRepo tripTypeRepo;

        public TripTypeService(TripTypeRepo tripTypeRepo)
        {
            this.tripTypeRepo = tripTypeRepo;
        }

        // Get All
        public List<TripTypeOutputDTO> GetAll()
        {
            List<TripType> tripTypes = tripTypeRepo.GetAll();

            List<TripTypeOutputDTO> result = new();

            foreach (var item in tripTypes)
            {
                result.Add(new TripTypeOutputDTO
                {
                    TripTypeId = item.tripTypeId,
                    TypeName = item.typeName,
                    BasePrice = item.basePrice,
                    Description = item.description
                });
            }

            return result;
        }

        // Get By Id
        public TripTypeDetailsDTO GetById(int id)
        {
            TripType tripType = tripTypeRepo.GetById(id);

            if (tripType == null)
                return null;

            return new TripTypeDetailsDTO
            {
                TripTypeId = tripType.tripTypeId,
                TypeName = tripType.typeName,
                BasePrice = tripType.basePrice,
                Description = tripType.description,
                AppointmentCount = tripType.Appointments.Count
            };
        }

        // Add
        public int Create(TripTypeInputDTO dto)
        {
            TripType tripType = new TripType();

            tripType.typeName = dto.typeName;
            tripType.basePrice = dto.basePrice;
            tripType.description = dto.description;

            tripTypeRepo.Add(tripType);

            return tripType.tripTypeId;
        }

        // Update
        public bool Update(int id, TripTypeInputDTO dto)
        {
            TripType tripType = tripTypeRepo.GetById(id);

            if (tripType == null)
                return false;

            tripType.typeName = dto.typeName;
            tripType.basePrice = dto.basePrice;
            tripType.description = dto.description;

            tripTypeRepo.Update();

            return true;
        }

        // Delete
        public bool Delete(int id)
        {
            TripType tripType = tripTypeRepo.GetById(id);

            if (tripType == null)
                return false;

            tripTypeRepo.Delete(tripType);

            return true;
        }
    }
}