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
        // URL Example: http://localhost:5153/Review/GetReviewById/3..
        // GET: GetReviewById/3..
        [AllowAnonymous] // Allow public access to view a specific review
        [HttpGet("GetReviewById/{id}")]
        public IActionResult GetReviewById([FromRoute] int id)
        {
            // 1. Call the service layer to fetch the review DTO by its unique ID
            ReviewDTOs.ReviewOnputDTOs review = reviewService.GetReviewById(id);

            // 2. Safety Check: If no review was found with this ID, return a 404 response
            if (review == null)
            {
                return NotFound(); // 404 Not Found
            }

            // 3. Return HTTP 200 OK along with the found review DTO data
            return Ok(review); // 200 OK
        }

        // =====================================================
        // GET REVIEWS BY DESTINATION ID
        // =====================================================

        // Define as an HTTP GET endpoint taking destinationId from Route
        // URL Example: http://localhost:5153/Review/GetReviewsByDestination/5
        // GET: GetReviewsByDestination/5
        [AllowAnonymous] // Allow public access to view reviews for a destination
        [HttpGet("GetReviewsByDestination/{destinationId}")]
        public IActionResult GetReviewsByDestinationId([FromRoute] int destinationId)
        {
            // 1. Call the service layer to fetch reviews filtered by destination ID
            List<ReviewDTOs.ReviewOnputDTOs> result = reviewService.GetReviewsByDestinationId(destinationId);

            // 2. Check if any reviews exist for this destination
            if (result.Count > 0)
            {
                return Ok(result); // 200 success
            }
            // 3. Return 204 No Content if no reviews exist for this destination
            return NoContent(); // 204 no data

            
        }

        // =====================================================
        // ADD REVIEW
        // =====================================================

        // Define as an HTTP POST endpoint for creating new review records
        // URL Example: http://localhost:5153/Review/AddReview
        // POST: AddReview
        [Authorize(Roles = "User,Admin")] // Allows authenticated Users or Admins to post a review
        [HttpPost("AddReview")]
        public IActionResult AddReview([FromBody] ReviewDTOs.ReviewInputDTOs input)
        {
            // 1. Send the input DTO to the service layer to create and save the review in DB
            ReviewDTOs.ReviewOnputDTOs createdReview = reviewService.CreateReview(input);

            // 2. Return HTTP 200 OK with the created review object containing its generated ID
            return Ok(createdReview); // HTTP 200 OK
        }

        // =====================================================
        // UPDATE REVIEW
        // =====================================================

        // Define as an HTTP PUT endpoint taking the target ID from Route and new data from Body
        // URL Example: http://localhost:5153/Review/UpdateReview/3
        // PUT: UpdateReview/3

        [Authorize(Roles = "User,Admin")] // Allows Users or Admins to update reviews
        [HttpPut("UpdateReview/{id}")]
        public IActionResult UpdateReview([FromRoute] int id, [FromBody] ReviewDTOs.ReviewInputDTOs input)
        {
            // 1. Call the service layer to update the review record
            bool updated = reviewService.UpdateReview(id, input);

            // 2. Safety Check: If the review ID does not exist in the database, return 404
            if (!updated)
            {
                return NotFound(); // HTTP 404 Not Found
            }

            // 3. Return HTTP 200 OK with a success message confirming the update
            return Ok("Updated successfully"); // HTTP 200 OK

        }

        // =====================================================
        // DELETE REVIEW
        // =====================================================

        // Define as an HTTP DELETE endpoint taking the target review ID from Route
        // URL Example: http://localhost:5153/Review/Delete/3
        // DELETE: Delete/3
    }
}
