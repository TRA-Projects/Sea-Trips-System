namespace Sea_Trips_System.Models
{
    public class ReviewService
    {
        // 1. Declare the target Repository instance
        private ReviewRepo reviewRepo;

        // 2. Dependency Injection: Injecting ReviewRepo instance
        public ReviewService(ReviewRepo _reviewRepo)
        {
            reviewRepo = _reviewRepo;
        }

        // =====================================================
        // 1. GET ALL REVIEWS
        // =====================================================
        public List<ReviewDTOs.ReviewOnputDTOs> GetAllReviews()
        {
            // 1. Fetch all review entities from the database via repository
            List<Review> reviews = reviewRepo.GetAllReviews();

            // 2. Create an empty list to store the mapped Output DTOs
            List<ReviewDTOs.ReviewOnputDTOs> resultList = new List<ReviewDTOs.ReviewOnputDTOs>();


            // 3. Iterate through each entity and map it to ReviewOutputDTO
            foreach (var r in reviews)
            {
                resultList.Add(new ReviewDTOs.ReviewOnputDTOs
                {
                    reviewId = r.reviewId,
                    rating = r.rating,
                    comment = r.comment,
                    AppointmentId = r.AppointmentId,

                    // Safe-navigation access to destination name (Review -> Appointment -> Destination)//
                    destinationName = r.Appointment?.Destination?.name
                });
            }

            // 4. Return the mapped DTO list
            return resultList;
        }


        // =====================================================
        // 2. GET REVIEW BY ID
        // =====================================================

        public ReviewDTOs.ReviewOnputDTOs GetReviewById(int id)
        {
            // 1. Fetch the specific review entity by ID via repository
            Review review = reviewRepo.GetReviewById(id);

            // 2. Safety Check: If review does not exist, return null (handled as 404 in Controller)
            if (review == null)
            {
                return null;
            }
        }


    }
}
