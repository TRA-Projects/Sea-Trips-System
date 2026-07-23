using System.ComponentModel.DataAnnotations;

namespace Sea_Trips_System.Models
{
    public class DestinationDTOs
    {
        public class DestinationInputDTOs
        {
            [Required(ErrorMessage = "Value should not be null.")]
            [MaxLength(100, ErrorMessage = "name cannot exceed 100 characters.")]
            public string name { get; set; }

            [MaxLength(100, ErrorMessage = "coordinates cannot exceed 100 characters.")]
            public string coordinates { get; set; }
        }

        public class DestinationOutputDTOs
        {
            public int destinationId { get; set; }
            public string name { get; set; }
            public string coordinates { get; set; }
            public TimeSpan estimatedDuration { get; set; }

        }

    }
}
