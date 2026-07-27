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

        // 2. Get a single review by its ID
        public Review GetReviewById(int id)
        {
            return context.Reviews
                .Include(r => r.Appointment)
                .ThenInclude(a => a.Destination)
                .FirstOrDefault(r => r.reviewId == id);
        }

        // =====================================================
        // GET REVIEW BY ID
        // =====================================================

        // 3. Get all reviews for a specific destination ID
        public List<Review> GetReviewsByDestinationId(int destinationId)
        {
            return context.Reviews
                .Include(r => r.Appointment)
                .ThenInclude(a => a.Destination)
                .Where(r => r.Appointment.destinationId == destinationId) // تصفية التقييمات للوجهة المحددة
                .ToList();
        }

        // =====================================================
        // ADD REVIEW
        // =====================================================
        public void Add(Review review)
        {
            // add new review in Dbset
            context.Reviews.Add(review);
            context.SaveChanges();
        }
        // =====================================================
        // UPDATE REVIEW
        // =====================================================
        public void Update()
        {
            context.SaveChanges();
        }
        // =====================================================
        // DELETE REVIEW
        // =====================================================
        public void Delete(Review review)
        {
            context.Reviews.Remove(review);
            context.SaveChanges();
        }
    }
}
