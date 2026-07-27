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


        // ======================================================
        // GET ALL REVIEWS
        // ======================================================

        // 1. Get all reviews with their related Appointment and Destination details
        public List<Review> GetAllReviews()
        {
            // Include Appointment & Destination to get full details
            return context.Reviews
                .Include(r => r.Appointment)
                    .ThenInclude(a => a.Destination)
                .ToList();
        }

        // =====================================================
        // GET REVIEW BY ID
        // =====================================================

        public Review GetReviewById(int id)
        {
            return context.Reviews
                .Include(r => r.Appointment)
                    .ThenInclude(a => a.Destination)
                .FirstOrDefault(r => r.reviewId == id);
        }
    }
}
