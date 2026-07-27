using System.ComponentModel.DataAnnotations;

namespace Sea_Trips_System.Models
{
    public class ReviewDTOs
    {
        //Input DTO for receiving review data from the user/client
        public class ReviewInputDTOs
        {
            [Required(ErrorMessage = "Rating is required.")]
            [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
            public int rating { get; set; }// user input
            public string? comment { get; set; }
            public int AppointmentId { get; set; }
        }
    }
}
