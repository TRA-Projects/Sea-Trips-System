using System.ComponentModel.DataAnnotations;

namespace Sea_Trips_System.Models
{
    public class StaffDTOs
    {
        // ──*** Request DTO — Received when creating a new staff member ***─-

       public class CreateAppointmentDto
        {
            [Required(ErrorMessage ="Staff name is required.")]
            [StringLength(100)]
            public string name { get; set; }

            [Required(ErrorMessage = "Role is required.")]
            public string role { get; set; }

            [StringLength(50)]
            public string? licenseNumber { get; set; }

            [Required(ErrorMessage = "Phone number is required.")]
            [StringLength(20)]
            public string phone { get; set; }
        }

        // ──*** Request DTO — Received when updating existing staff member ***─-

        public class UpdateStaffDto
        {
            [Required(ErrorMessage = "Staff name is required.")]
            [StringLength(100)]
            public string name { get; set; }

            [Required(ErrorMessage = "Role is required.")]
            public string role { get; set; }

            [StringLength(50)]
            public string? licenseNumber { get; set; }

            [Required]
            public bool isAvailable { get; set; }

            [Required(ErrorMessage = "Phone number is required.")]
            [StringLength(20)]
            public string phone { get; set; }

        }

        // ──*** Response DTO — Returned to client ***──




    }
}
