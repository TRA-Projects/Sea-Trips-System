
using Sea_Trips_System.Models;
using Sea_Trips_System.Repositories;

namespace Sea_Trips_System.Models
{
    public class TripTypeService
    {
        private TripTypeRepo tripTypeRepo;

        public TripTypeService(TripTypeRepo tripTypeRepo)
        {
            this.tripTypeRepo = tripTypeRepo;
        }

        // Get All Trip Types
        public List<TripType> GetAll()
        {
            return tripTypeRepo.GetAll();
        }

        // Get Trip Type By Id
        public TripType GetById(int tripTypeId)
        {
            return tripTypeRepo.GetById(tripTypeId);
        }

        // Add New Trip Type
        public void AddTripType(string typeName, decimal basePrice, string description)
        {
            TripType tripType = new TripType();

            tripType.typeName = typeName;
            tripType.basePrice = basePrice;
            tripType.description = description;

            tripTypeRepo.Add(tripType);
        }

        // Get Last Trip Type Id
        public int GetLastTripTypeId()
        {
            List<TripType> all = tripTypeRepo.GetAll();
            return all[all.Count - 1].tripTypeId;
        }

        // Update Trip Type
        public void UpdateTripType(int tripTypeId, string typeName, decimal basePrice, string description)
        {
            TripType tripType = tripTypeRepo.GetById(tripTypeId);

            tripType.typeName = typeName;
            tripType.basePrice = basePrice;
            tripType.description = description;

            tripTypeRepo.Update();
        }

        // Delete Trip Type
        public void DeleteTripType(int tripTypeId)
        {
            TripType tripType = tripTypeRepo.GetById(tripTypeId);

            tripTypeRepo.Delete(tripType);
        }
    }
}
