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

            // 3. Map the retrieved entity to Output DTO and return
            return new ReviewDTOs.ReviewOnputDTOs
            {
                reviewId = review.reviewId,
                rating = review.rating,
                comment = review.comment,
                AppointmentId = review.AppointmentId,
                destinationName = review.Appointment?.Destination?.name
            };
        }


        // =====================================================
        // 3. GET REVIEWS BY DESTINATION ID
        // =====================================================
        public List<ReviewDTOs.ReviewOnputDTOs> GetReviewsByDestinationId(int destinationId)
        {
            // 1. Fetch review entities filtered by Destination ID
            List<Review> reviews = reviewRepo.GetReviewsByDestinationId(destinationId);

            // 2. Map the list of entities to Output DTOs
            List<ReviewDTOs.ReviewOnputDTOs> resultList = new List<ReviewDTOs.ReviewOnputDTOs>();
            foreach (var r in reviews)
            {
                resultList.Add(new ReviewDTOs.ReviewOnputDTOs
                {
                    reviewId = r.reviewId,
                    rating = r.rating,
                    comment = r.comment,
                    AppointmentId = r.AppointmentId,
                    destinationName = r.Appointment?.Destination?.name
                });
            }
            return resultList;
        }


        // =====================================================
        // 4. CREATE NEW REVIEW
        // =====================================================

        public ReviewDTOs.ReviewOnputDTOs CreateReview(ReviewDTOs.ReviewInputDTOs input)
        {
            // 1. Map the incoming Input DTO to a new Review Entity
            Review newReview = new Review
            {
                rating = input.rating,
                comment = input.comment,
                AppointmentId = input.AppointmentId
            };
            // 2. Send the new entity to the repository to save in DB and generate ID
            reviewRepo.Add(newReview);

            // 3. Re-fetch the saved review by ID to return complete data including Navigation Properties
            return GetReviewById(newReview.reviewId);
        }

        // =====================================================
        // 5. UPDATE REVIEW
        // =====================================================
        public bool UpdateReview(int id, ReviewDTOs.ReviewInputDTOs input)
        {
            // 1. Find the existing review in the database
            Review existingReview = reviewRepo.GetReviewById(id);

            // 2. If review is not found, return false
            if (existingReview == null)
            {
                return false;
            }


            // 3. Update entity properties with new values from input DTO
            existingReview.rating = input.rating;
            existingReview.comment = input.comment;
            existingReview.AppointmentId = input.AppointmentId;

            // 4. Save changes in the database via repository
            reviewRepo.Update();

            return true;

        }

        // =====================================================
        // 6. DELETE REVIEW
        // =====================================================

        public bool DeleteReview(int id)
        {
            // 1. Find the target review to delete
            Review existingReview = reviewRepo.GetReviewById(id);


            // 2. If review is not found, return false
            if (existingReview == null)
            {
                return false;
            }

            // 3. Execute deletion via repository
            reviewRepo.Delete(existingReview);

            return true;
        }



    }
}
