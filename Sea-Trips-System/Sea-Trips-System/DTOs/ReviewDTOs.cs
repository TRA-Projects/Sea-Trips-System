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

            [MaxLength(1000, ErrorMessage = "Comment cannot exceed 1000 characters.")]
            public string? comment { get; set; }// user input (optional)

            [Required(ErrorMessage = "Appointment ID is required.")]
            public int AppointmentId { get; set; }// foreign key input
        }


        // Output DTO for returning review data to the clien
        public class ReviewOnputDTOs
        {
            public int reviewId { get; set; } // system generated
            public int rating { get; set; }
            public string? comment { get; set; }
            public int AppointmentId { get; set; }
            public string? destinationName { get; set; }
        }
    }
}
