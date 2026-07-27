
using Sea_Trips_System.DTOs;
using Sea_Trips_System.Models;
using Sea_Trips_System.Repositories;

namespace Sea_Trips_System.Services
{
    public class TripTypeService
    {
        // TripTypeRepo repo = new TripTypeRepo();

        private TripTypeRepo repo;

        public TripTypeService(TripTypeRepo _repo)
        {
            repo = _repo;
        }

        // Get All
        public List<TripTypeOutputDTO> GetAll()
        {
            return repo.GetAll()
                       .Select(TripType => new TripTypeOutputDTO
                       {
                           tripTypeId = TripType.tripTypeId,
                           typeName = TripType.typeName,
                           basePrice = TripType.basePrice,
                           description = TripType.description
                       })
                       .ToList();
        }

        // Get By Id
        public TripTypeDetailsDTO GetById(int id)
        {
            TripType tripType = repo.GetById(id);

            if (tripType == null)
                return null;

            return new TripTypeDetailsDTO
            {
                tripTypeId = tripType.tripTypeId,
                typeName = tripType.typeName,
                basePrice = tripType.basePrice,
                description = tripType.description,
                appointmentCount = tripType.Appointments.Count
            };
        }

        // Add
        public int Create(TripTypeInputDTO dto)
        {
            TripType tripType = new TripType();

            tripType.typeName = dto.typeName;
            tripType.basePrice = dto.basePrice;
            tripType.description = dto.description;

            repo.Add(tripType);

            return tripType.tripTypeId;
        }

        // Update
        public bool Update(int id, TripTypeInputDTO dto)
        {
            TripType tripType = repo.GetById(id);

            if (tripType == null)
                return false;

            tripType.typeName = dto.typeName;
            tripType.basePrice = dto.basePrice;
            tripType.description = dto.description;

            repo.Update();

            return true;
        }

        // Delete
        public bool Delete(int id)
        {
            TripType tripType = repo.GetById(id);

            if (tripType == null)
                return false;

            repo.Delete(tripType);

            return true;
        }
    }
}