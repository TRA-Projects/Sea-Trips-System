using System.ComponentModel.DataAnnotations;

namespace Sea_Trips_System.DTOs
{
    // ── Request DTOs — Data sent from Client / Frontend ───────────────────────
    // DTO لإضافة قارب جديد
    public class CreateBoatDto
    {
        [Required(ErrorMessage = "Boat name is required.")]
        [MaxLength(50, ErrorMessage = "Boat name cannot exceed 50 characters.")]
        public string boatName { get; set; } 

        [Required(ErrorMessage = "Capacity is required.")]
        [Range(1, 500, ErrorMessage = "Capacity must be between 1 and 500.")]
        public int capacity { get; set; }

        [Required(ErrorMessage = "Hourly rate is required.")]
        [Range(0.001, 999999.999, ErrorMessage = "Hourly rate must be greater than 0.")]
        public decimal hourlyRate { get; set; }

        public string status { get; set; } = "Available";
    }

    // DTO لتحديث بيانات القارب
    public class UpdateBoatDto
    {
        [Required(ErrorMessage = "Boat name is required.")]
        [MaxLength(50, ErrorMessage = "Boat name cannot exceed 50 characters.")]
        public string boatName { get; set; }

        [Required(ErrorMessage = "Capacity is required.")]
        [Range(1, 500, ErrorMessage = "Capacity must be between 1 and 500.")]
        public int capacity { get; set; }

        [Required(ErrorMessage = "Hourly rate is required.")]
        [Range(0.001, 999999.999, ErrorMessage = "Hourly rate must be greater than 0.")]
        public decimal hourlyRate { get; set; }

        public string status { get; set; } = "Available";
    }

    // ── Response DTOs — Data sent back to Frontend ───────────────────────────
    // DTO لاسترجاع بيانات القارب للفرونت إند
    public class BoatResponseDto
    {
        public int boatId { get; set; }
        public string boatName { get; set; } = string.Empty;
        public int capacity { get; set; }
        public string status { get; set; } = string.Empty;
        public decimal hourlyRate { get; set; }

        // add token to the boat 
        public string boatToken { get; set; }
    }

  
    }
