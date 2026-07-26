using System.ComponentModel.DataAnnotations;

namespace Sea_Trips_System.DTOs
{

    // DTO for assigning a staff member to an appointment
    public class AssignStaffDto
    {
        [Required(ErrorMessage = "Appointment ID is required.")]
        public int appointmentId { get; set; }

        [Required(ErrorMessage = "Staff ID is required.")]
        public int staffId { get; set; }

        public string? assignedRole { get; set; }        //(e.g., Captain, Guide)


    }



    // DTO for returning assigned staff information in responses
    public class AppointmentStaffResponseDto
    {
        public int appointmentStaffId { get; set; }
        public int appointmentId { get; set; }
        public int staffId { get; set; }
        public string? staffName { get; set; }
        public string? staffRole { get; set; }
        public string? assignedRole { get; set; }
    }
}
