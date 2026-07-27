using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Sea_Trips_System.Models
{
    // Mark class as an API Controller and set the base URL route to "Review"
    [ApiController]
    [Route("Review")]
    [Authorize] // Requires authentication for all endpoints by default
    public class ReviewControllers: ControllerBase
    {
        private ReviewService reviewService;
        // Constructor Injection: Injecting ReviewService instance
        public ReviewControllers(ReviewService _reviewService)
        {
            reviewService = _reviewService;
        }

        // =====================================================
        // GET ALL REVIEWS
        // =====================================================

        // Define this action as an HTTP GET endpoint with the route "GetAllReviews"
        // GET: GetAllReviews
        [AllowAnonymous] // Allow public access to view all reviews
        [HttpGet("GetAllReviews")]
        public IActionResult GetAllReviews()
        {

        }
    }
}
