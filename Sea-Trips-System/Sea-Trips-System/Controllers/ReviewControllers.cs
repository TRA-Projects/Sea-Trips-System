using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sea_Trips_System.DTOs;
using Sea_Trips_System.Models;
using Sea_Trips_System.Services;
using System.Collections.Generic;
using System.Security.Claims;

namespace Sea_Trips_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // المسار القياسي: api/Review
    [Authorize] // Requires authentication for all endpoints by default
    public class ReviewController : ControllerBase
    {
        private readonly ReviewService reviewService;

        // Constructor Injection: Injecting ReviewService instance
        public ReviewController(ReviewService _reviewService)
        {
            reviewService = _reviewService;
        }

        // =====================================================
        // GET ALL REVIEWS
        // =====================================================
        [AllowAnonymous] // Allow public access to view all reviews
        [HttpGet]
        public IActionResult GetAllReviews()
        {
            List<ReviewDTOs.ReviewOnputDTOs> result = reviewService.GetAllReviews();

            if (result == null || result.Count == 0)
            {
                return NoContent(); // 204 No Content
            }

            return Ok(result); // 200 OK
        }

        // =====================================================
        // GET REVIEW BY ID
        // =====================================================
        [AllowAnonymous] // Allow public access to view a specific review
        [HttpGet("{id}")]
        public IActionResult GetReviewById([FromRoute] int id)
        {
            ReviewDTOs.ReviewOnputDTOs review = reviewService.GetReviewById(id);

            if (review == null)
            {
                return NotFound(new { message = $"Review with ID {id} was not found." }); // 404 Not Found
            }

            return Ok(review); // 200 OK
        }

        // =====================================================
        // GET REVIEWS BY DESTINATION ID
        // =====================================================
        [AllowAnonymous] // Allow public access to view reviews for a destination
        [HttpGet("destination/{destinationId}")]
        public IActionResult GetReviewsByDestinationId([FromRoute] int destinationId)
        {
            List<ReviewDTOs.ReviewOnputDTOs> result = reviewService.GetReviewsByDestinationId(destinationId);

            if (result == null || result.Count == 0)
            {
                return NoContent(); // 204 No Content
            }

            return Ok(result); // 200 OK
        }

        // =====================================================
        // ADD REVIEW
        // =====================================================
        [Authorize(Roles = "User,Admin")] // Allows authenticated Users or Admins to post a review
        [HttpPost]
        public IActionResult AddReview([FromBody] ReviewDTOs.ReviewInputDTOs input)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // اختيارية: إذا كنت بحاجة لربط المراجعة بالمستخدم الحالي المسجل دخول عبر الـ Token
            var userId = User.FindFirst("userId")?.Value ?? User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            ReviewDTOs.ReviewOnputDTOs createdReview = reviewService.CreateReview(input);

            if (createdReview == null)
                return BadRequest(new { message = "Failed to create review." });

            // 1. استخدام reviewId (أو اسم معرف التقييم الخاص بك في DTO)
            return CreatedAtAction(nameof(GetReviewById), new { id = createdReview.reviewId }, createdReview); // 201 Created
        }

        // =====================================================
        // UPDATE REVIEW
        // =====================================================
        [Authorize(Roles = "User,Admin")] // Allows Users or Admins to update reviews
        [HttpPut("{id}")]
        public IActionResult UpdateReview([FromRoute] int id, [FromBody] ReviewDTOs.ReviewInputDTOs input)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            bool updated = reviewService.UpdateReview(id, input);

            if (!updated)
            {
                return NotFound(new { message = $"Review with ID {id} was not found." }); // 404 Not Found
            }

            return Ok(new { message = "Review updated successfully." }); // 200 OK
        }

        // =====================================================
        // DELETE REVIEW
        // =====================================================
        [Authorize(Roles = "Admin")] // Restrict review deletion to Admins only
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            bool deleted = reviewService.DeleteReview(id);

            if (!deleted)
            {
                return NotFound(new { message = $"Review with ID {id} was not found." }); // 404 Not Found
            }

            return Ok(new { message = "Review deleted successfully." }); // 200 OK
        }
    }
}