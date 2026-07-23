using System.ComponentModel.DataAnnotations;

namespace Sea_Trips_System.Models
{
    // ── Request DTO — Received when creating a new appointment ─-
    public class CreateAppointmentDto
    {
        [Required(ErrorMessage = "Start time is required.")]
        public DateTime startTime { get; set; }

        [Required(ErrorMessage = "End time is required.")]
        public DateTime endTime { get; set; }

        [Required(ErrorMessage = "Number of people is required.")]
        [Range(1, 100, ErrorMessage = "Number of people must be between 1 and 100.")]
        public int numberOfPeople { get; set; }

        [Required(ErrorMessage = "Client ID is required.")]
        public int clientId { get; set; }

        [Required(ErrorMessage = "Boat ID is required.")]
        public int boatId { get; set; }

        [Required(ErrorMessage = "Trip Type ID is required.")]
        public int tripTypeId { get; set; }

        [Required(ErrorMessage = "Destination ID is required.")]
        public int destinationId { get; set; }

        // Optional discount/event selection
        public int? eventId { get; set; }


    }

}
