using Microsoft.EntityFrameworkCore;

namespace Sea_Trips_System.Models
{
    public class ReviewRepo
    {
        //cotext==>repo // Database Context
        private SeaTripsContext context;

        // Dependency Injection // Constructor
        public ReviewRepo(SeaTripsContext _context)
        {
            context = _context;
        }


        // =====================================================
        // GET ALL REVIEWS
        // =====================================================
        public List<Review> GetAllReviews()
        {
            // Include Appointment & Destination to get full details
            return context.Reviews
                .Include(r => r.Appointment)
                    .ThenInclude(a => a.Destination)
                .ToList();
        }
    }
}
