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

    }
}
