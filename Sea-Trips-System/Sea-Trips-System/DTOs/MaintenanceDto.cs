using System.ComponentModel.DataAnnotations;

namespace Sea_Trips_System.DTOs
{

    // ── AddMaintenanceDto  ─────────────────────────────────────────
    public class AddMaintenanceDto
    {
        [Required(ErrorMessage = "Description is required.")]
        [MaxLength(1000)]
        public string Description { get; set; }

        public DateTime? EndDate { get; set; }

        [Required(ErrorMessage = "Boat Id is required.")]
        public int BoatId { get; set; }
    }
    // ── Update DTOs ─────────────────────────────────────────
    public class UpdateMaintenanceDto
    {
        [Required(ErrorMessage = "Description is required.")]
        [MaxLength(1000)]
        public string Description { get; set; }

        public DateTime? EndDate { get; set; }

        [Required(ErrorMessage = "Boat Id is required.")]
        public int BoatId { get; set; }
    }

    // ── Response DTOs ─────────────────────────────────────────

    public class MaintenanceResponseDto
    {
        public int MaintenanceId { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int BoatId { get; set; }
    }
}