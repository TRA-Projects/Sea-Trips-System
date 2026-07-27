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
        // GET: GetAllReviews.....
        [AllowAnonymous] // Allow public access to view all reviews..
        [HttpGet("GetAllReviews")]
        public IActionResult GetAllReviews()
        {
            // 1. Call the service layer to fetch all reviews mapped as DTOs
            List<ReviewDTOs.ReviewOnputDTOs> result = reviewService.GetAllReviews();

            // 2. Check if the returned list contains any review items
            if (result.Count > 0)
            {
                // Return 200 OK status code along with the list of reviews..
                return Ok(result); // 200 success
            }

            // 3. Return 204 No Content status code if the list is empty (request succeeded, but no data to return)
            return NoContent(); // 204 no data
        }

        // =====================================================
        // GET REVIEW BY ID
        // =====================================================

        // Define as an HTTP GET endpoint with a route parameter {id}
    }
}
