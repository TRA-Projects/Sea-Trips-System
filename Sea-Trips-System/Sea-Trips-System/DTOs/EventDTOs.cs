
using System.ComponentModel.DataAnnotations;
using Sea_Trips_System.Models;

namespace Sea_Trips_System.DTOs
{
    // ── Request DTOs — what the client sends ─────────────────────────────────


    public class EventInputDTO
    {
        [Required(ErrorMessage = "Event Name is required.")]
        [StringLength(100, ErrorMessage = "Event Name cannot exceed 100 characters.")]
        public string eventName { get; set; }

        [Range(0, 100, ErrorMessage = "Discount Rate must be between 0 and 100.")]
        public decimal discountRate { get; set; }

        [Required(ErrorMessage = "Event status is required.")]
        public bool isActive { get; set; }
    }


    // ── Response DTOs — what the API sends back ───────────────────────────────

    // Used when displaying all Events
    public class EventOutputDTO
    {
        public int eventId { get; set; }

        public string eventName { get; set; }

        public decimal discountRate { get; set; }

        public bool isActive { get; set; }
    }


    // Used when displaying one Event with its Appointments
    public class EventAllOutputDTO
    {
        public int eventId { get; set; }

        public string eventName { get; set; }

        public decimal discountRate { get; set; }

        public bool isActive { get; set; }

       
    }
}





