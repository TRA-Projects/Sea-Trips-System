using System.ComponentModel.DataAnnotations;

namespace Sea_Trips_System.Models
{
    public class ReviewDTOs
    {
        //Input DTO for receiving review data from the user/client
        public class ReviewInputDTOs
        {
            [Required(ErrorMessage = "Rating is required.")]/
            public int rating { get; set; }
            public string? comment { get; set; }
            public int AppointmentId { get; set; }
        }
    }
}
