using System.ComponentModel.DataAnnotations;

namespace Sea_Trips_System.DTOs
{

    public class AssignStaffDto
    {
        [Required(ErrorMessage = "Appointment ID is required.")]
        public int appointmentId { get; set; }

        [Required(ErrorMessage = "Staff ID is required.")]
        public int staffId { get; set; }

        public string? assignedRole { get; set; }


    }
}
