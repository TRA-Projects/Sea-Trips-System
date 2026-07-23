using Microsoft.EntityFrameworkCore;

namespace Sea_Trips_System.Models
{ 
    public class TripTypeRepo
    {
        private SeaTripsContext context;

        public TripTypeRepo(SeaTripsContext context)
        {
            this.context = context;
        }

        // Get All Trip Types
        public List<TripType> GetAll()
        {
            return context.TripTypes
                .Include(t => t.Appointments)
                .ToList();
        }

        // Get Trip Type By Id
        //
        public TripType GetById(int tripTypeId)
        {
            return context.TripTypes
                .Include(t => t.Appointments)
                .FirstOrDefault(t => t.tripTypeId == tripTypeId);
        }

        // Add New Trip Type
        public void Add(TripType tripType)
        {
            context.TripTypes.Add(tripType);
            context.SaveChanges();
        }

        // Update Trip Type
        public void Update()
        {
            context.SaveChanges();
        }

        // Delete Trip Type
        public void Delete(TripType tripType)
        {
            context.TripTypes.Remove(tripType);
            context.SaveChanges();
        }

        // Search By Name
        public TripType GetByName(string typeName)
        {
            return context.TripTypes
                .FirstOrDefault(t => t.typeName == typeName);
        }
    }
}
    
